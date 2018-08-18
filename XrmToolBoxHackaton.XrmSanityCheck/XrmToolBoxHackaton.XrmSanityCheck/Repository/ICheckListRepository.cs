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
        IEnumerable<CheckList> GetCheckLists();

        Guid CreateCheckList(CheckList list);
        void UpdateCheckList(CheckList list);
        void DeleteCheckList(CheckList list);
        void UpdateAll(List<CheckList> lists);
        #endregion

        #region CheckListItem Members
        Guid CreateCheckListItem(CheckListItem item);
        void UpdateCheckListItem(CheckListItem item);
        void DeleteCheckListItem(CheckListItem item);

        #endregion
    }
}
