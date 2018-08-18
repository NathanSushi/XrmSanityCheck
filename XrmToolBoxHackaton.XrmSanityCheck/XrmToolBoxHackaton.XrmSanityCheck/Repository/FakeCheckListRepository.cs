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
        private List<Models.CheckList> _checkLists = new List<Models.CheckList>();

        public FakeCheckListRepository()
        {
            _checkLists = new List<Models.CheckList>()
            {
                new Models.CheckList
                {
                    Id = Guid.NewGuid(),
                    Name = "Sanity Check",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    CheckListItems= new List<CheckListItem>()
                    {
                        new CheckListItem
                        {
                            CheckedOn =DateTime.Now,
                            IsChecked = true,
                            Id = Guid.NewGuid(),
                            PublicId= Guid.NewGuid(),
                            Title = "All custom entities have icons"
                        },
                        new CheckListItem
                        {
                            CheckedOn =DateTime.Now,
                            IsChecked = false,
                            Id = Guid.NewGuid(),
                            PublicId= Guid.NewGuid(),
                            Title = "Enable auditing on required entities"
                        }
                    }
                },
                new Models.CheckList
                {
                    Id = Guid.NewGuid(),
                    Name = "Post GO Live Check 31/07",
                    CreatedOn = DateTime.Now.AddDays(-1),
                    ModifiedOn = DateTime.Now.AddDays(-1),
                    CheckListItems = new List<CheckListItem>()
                },
                new Models.CheckList
                {
                    Id = Guid.NewGuid(),
                    Name = "Daily Sanity Check",
                    CreatedOn = DateTime.Now.AddDays(-2),
                    ModifiedOn = DateTime.Now.AddDays(-2),
                    CheckListItems = new List<CheckListItem>()
                }
            };
        }
        public Guid CreateCheckList(Models.CheckList list)
        {
            _checkLists.Add(list);
            return list.Id.Value;
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
            return _checkLists;
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
