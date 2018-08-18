using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrmToolBoxHackaton.XrmSanityCheck.Models
{
    public class CheckListItem
    {
        public Guid? Id { get; set; }
        public Guid? PublicId { get; set; }
        public string Title { get; set; }
        public bool IsChecked { get; set; }
        public DateTime? CheckedOn { get; set; }
        public Guid CheckListId { get; set; }
    }
}
