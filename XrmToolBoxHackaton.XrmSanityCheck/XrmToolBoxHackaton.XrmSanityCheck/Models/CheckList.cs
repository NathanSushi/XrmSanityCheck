﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrmToolBoxHackaton.XrmSanityCheck.Models
{
    public class CheckList
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public List<CheckListItem> CheckListItems { get; set; }
    }
}
