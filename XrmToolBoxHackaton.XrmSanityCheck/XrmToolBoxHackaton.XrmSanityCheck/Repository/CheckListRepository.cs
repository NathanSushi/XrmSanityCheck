using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private string webResourceName = "xsc_xrmsanitycheck";

        public IEnumerable<CheckList> GetCheckLists()
        {
            Entity webresource = getWebResource();
            return JsonConvert.DeserializeObject<List<CheckList>>(webresource.GetAttributeValue<string>("Content"));
        }

        public Guid CreateCheckList(CheckList list)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        public void DeleteCheckListItem(CheckListItem item)
        {
            throw new NotImplementedException();
        }

        ////Encodes the Web Resource File
        //private string getEncodedFileContents(String pathToFile)
        //{
        //    FileStream fs = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
        //    byte[] binaryData = new byte[fs.Length];
        //    long bytesRead = fs.Read(binaryData, 0, (int)fs.Length);
        //    fs.Close();
        //    return System.Convert.ToBase64String(binaryData, 0, binaryData.Length);
        //}

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
            firstCheckList.CheckListItems.Add(
                new CheckListItem()
                {
                    CheckedOn = DateTime.Today,
                    Id = Guid.NewGuid(),
                    IsChecked = false,
                    Title = "Lookups with no id",
                    PublicId = Guid.NewGuid()
                });
            defaultCheckLists.Add(firstCheckList);

            Entity webResource = new Entity("webresource");
            webResource["Content"] = JsonConvert.SerializeObject(defaultCheckLists);
            webResource["DisplayName"] = "XrmSanityCheck Data";
            webResource["Description"] = "This is a JSON file that stores your data for the XrmSanityCheck tool";
            webResource["Name"] = webResourceName;
            webResource["LogicalName"] = "webresource";
            webResource["WebResourceType"] = new OptionSetValue(3); //JS

            Guid webResourceId = Service.Create(webResource);
            if (webResourceId != null) return webResource;
            else return null;
        }

        private Entity getWebResource()
        {
            QueryExpression query = new QueryExpression("webresource");
            query.Criteria.AddCondition("Name", ConditionOperator.Equal, webResourceName);
            query.ColumnSet = new ColumnSet(true);
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
