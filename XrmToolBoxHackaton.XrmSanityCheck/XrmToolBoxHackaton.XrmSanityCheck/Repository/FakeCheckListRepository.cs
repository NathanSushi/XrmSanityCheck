using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrmToolBoxHackaton.XrmSanityCheck.Models;

namespace XrmToolBoxHackaton.XrmSanityCheck.Repository
{
    public class FakeCheckListRepository : ICheckListRepository
    {
        private IEnumerable<Models.CheckList> _checkLists = new List<Models.CheckList>();
        private IEnumerable<Models.CheckListItem> _checkListItems = new List<Models.CheckListItem>();

        public Guid CreateCheckList(Models.CheckList list)
        {
            throw new NotImplementedException();
        }

        public Guid CreateCheckListItem(CheckListItem item)
        {
            throw new NotImplementedException();
        }

        public void DeleteCheckList(Models.CheckList list)
        {
            throw new NotImplementedException();
        }

        public void DeleteCheckListItem(CheckListItem item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.CheckList> GetCheckListItems(Guid checklistItemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.CheckList> GetCheckLists()
        {
            return new List<Models.CheckList>()
            {
                new Models.CheckList
                {
                    Id = Guid.NewGuid(),
                    Name = "Sanity Check",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                },
                new Models.CheckList
                {
                    Id = Guid.NewGuid(),
                    Name = "Post GO Live Check 31/07",
                    CreatedOn = DateTime.Now.AddDays(-1),
                    ModifiedOn = DateTime.Now.AddDays(-1),
                },
                new Models.CheckList
                {
                    Id = Guid.NewGuid(),
                    Name = "Daily Sanity Check",
                    CreatedOn = DateTime.Now.AddDays(-2),
                    ModifiedOn = DateTime.Now.AddDays(-2),
                }
            };
        }

        public void UpdateCheckList(Models.CheckList list)
        {
            throw new NotImplementedException();
        }

        public void UpdateCheckListItem(CheckListItem item)
        {
            throw new NotImplementedException();
        }
    }
}
