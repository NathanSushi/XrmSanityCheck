using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace XrmToolBoxHackaton.XrmSanityCheck.Forms
{
    public partial class frmCreateCheckList : Form
    {
        public CheckListControl Plugin { get; set; }

        public frmCreateCheckList()
        {
            InitializeComponent();
            EnableDisableControls();
        }

        private void EnableDisableControls()
        {
            if(string.IsNullOrEmpty(txtName.Text)) //|| ddlTemplate.SelectedItem == null
            {
                btnCreate.Enabled = false;
            }
            else
            {
                btnCreate.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            EnableDisableControls();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs args)
        {
            Plugin.WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Checklists...",
                Work = (w, e) =>
                {
                    string name = txtName.Text;
                    Guid id = Plugin.Repository.CreateCheckList(new Models.CheckList
                    {
                        CheckListItems =new List<Models.CheckListItem>(),
                        CreatedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                        Id = Guid.NewGuid(),
                        Name = name
                    });

                    //w.ReportProgress(-1, "I have found the user id");
                },
                PostWorkCallBack = e =>
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                },
                AsyncArgument = null,
                // Progress information panel size
                MessageWidth = 340,
                MessageHeight = 150
            });
        }
    }
}
