using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using XrmToolBoxHackaton.XrmSanityCheck.Models;

namespace XrmToolBoxHackaton.XrmSanityCheck.Repository
{
    public class CheckListRepository : ICheckListRepository
    {
        private IOrganizationService Service;
        private string prefix = "xsc";
        private string webResourceName = "xsc_xrmsanitycheck.json";
        private Entity webResourceEntity;
        private List<CheckList> checkLists;

        public CheckListRepository(IOrganizationService service)
        {
            this.Service = service;
        }

        public IEnumerable<CheckList> GetCheckLists()
        {
            this.webResourceEntity = getWebResource();
            var content = Convert.FromBase64String(this.webResourceEntity.GetAttributeValue<string>("content"));
            this.checkLists = JsonConvert.DeserializeObject<List<CheckList>>(Encoding.UTF8.GetString(content));
            return checkLists;
        }

        public Guid CreateCheckList(CheckList list)
        {
            this.checkLists.Add(list);
            updateWebResource();
            return list.Id.Value;
        }
        public void UpdateCheckList(CheckList list)
        {
            throw new NotImplementedException();
        }
        public void DeleteCheckList(CheckList list)
        {
            throw new NotImplementedException();
        }

        public Guid CreateCheckListItem(CheckListItem item)
        {
            throw new NotImplementedException();
        }

        public void UpdateCheckListItem(CheckListItem item)
        {
            CheckListItem updatedItem = this.checkLists.First(x => x.CheckListItems.Any(y => y.Id == item.Id)).CheckListItems.First(z => z.Id == item.Id);
            updatedItem = item;
            updateWebResource();
        }
        public void DeleteCheckListItem(CheckListItem item)
        {
            throw new NotImplementedException();
        }

        private Entity createWebResource()
        {
            List<CheckList> defaultCheckLists = new List<CheckList>();
            CheckList firstCheckList = new CheckList()
            {
                CreatedOn = DateTime.Today,
                Id = Guid.NewGuid(),
                ModifiedOn = DateTime.Today,
                Name = "My Check List",
                CheckListItems = new List<CheckListItem>()
            };
            defaultCheckLists.Add(firstCheckList);

            var json = JsonConvert.SerializeObject(defaultCheckLists);
            Entity webResource = new Entity("webresource");
            webResource["content"] = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            webResource["displayname"] = "XrmSanityCheck Data";
            webResource["description"] = "This is a JSON file that stores your data for the XrmSanityCheck tool";
            webResource["name"] = webResourceName;
            webResource["webresourcetype"] = new OptionSetValue(3); //JS

            Guid webResourceId = Service.Create(webResource);
            if (webResourceId != null) return webResource;
            else return null;
        }

        private void updateWebResource()
        {
            var json = JsonConvert.SerializeObject(this.checkLists);
            Entity updatedWebResource = new Entity(this.webResourceEntity.LogicalName) { Id = this.webResourceEntity.Id };
            updatedWebResource["content"] = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            Service.Update(updatedWebResource);

            publishWebResource();
        }

        private void publishWebResource()
        {
            PublishXmlRequest publishRequest = new PublishXmlRequest();
            string webResctag = "<webresource>" + this.webResourceEntity.Id + "</webresource>";
            string webrescXml = "<importexportxml><webresources>" + webResctag + "</webresources></importexportxml>";
            publishRequest.ParameterXml = String.Format(webrescXml);
            Service.Execute(publishRequest);
        }

        private Entity getWebResource()
        {
            QueryExpression query = new QueryExpression("webresource");
            query.Criteria.AddCondition("name", ConditionOperator.Equal, webResourceName);
            query.ColumnSet = new ColumnSet("content");
            EntityCollection results = Service.RetrieveMultiple(query);
            
            if (results.Entities.Any())
            {
                return results.Entities.First();
            }
            else
            {
                return createWebResource();
            }
        }
    }
}
