using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrmToolBoxHackaton.XrmSanityCheck.Models;

namespace XrmToolBoxHackaton.XrmSanityCheck.Repository
{
    public interface ICheckListRepository
    {
        #region CheckList Members
        IEnumerable<Models.CheckList> GetCheckLists();

        Guid CreateCheckList(Models.CheckList list);
        void UpdateCheckList(Models.CheckList list);
        void DeleteCheckList(Models.CheckList list);
        #endregion

        #region CheckListItem Members
        Guid CreateCheckListItem(CheckListItem item);
        void UpdateCheckListItem(CheckListItem item);
        void DeleteCheckListItem(CheckListItem item);

        #endregion
    }
}
