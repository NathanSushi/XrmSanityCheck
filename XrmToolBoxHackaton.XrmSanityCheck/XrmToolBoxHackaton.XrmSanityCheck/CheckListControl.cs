using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using XrmToolBoxHackaton.XrmSanityCheck.Repository;
using XrmToolBoxHackaton.XrmSanityCheck.Forms;
using XrmToolBoxHackaton.XrmSanityCheck.Models;

namespace XrmToolBoxHackaton.XrmSanityCheck
{
    public partial class CheckListControl : PluginControlBase
    {
        private Settings mySettings;
        public ICheckListRepository Repository { get; set; }

        private List<CheckList> _checklists = new List<CheckList>();
        private BindingSource _source = new BindingSource();

        public CheckListControl()
        {
            InitializeComponent();
            ShowHideControls();


            grdCheckListItems.DataMemberChanged += GrdCheckListItems_DataMemberChanged;
            grdCheckListItems.CellValueChanged += GrdCheckListItems_CellValueChanged;
            grdCheckListItems.UserAddedRow += GrdCheckListItems_UserAddedRow;
            grdCheckListItems.MouseUp += GrdCheckListItems_MouseUp;
        }

        private void GrdCheckListItems_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var hitTestInfo = grdCheckListItems.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                    grdCheckListItems.BeginEdit(true);
                else
                    grdCheckListItems.EndEdit();
            }
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            //ExecuteMethod(GetAccounts);
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void btnLoadLists_Click(object sender, EventArgs args)
        {
            this.Repository = new CheckListRepository(this.Service);
            LoadCheckLists();
        }

        private void LoadCheckLists()
        {
            lvwChecklists.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Checklists...",
                Work = (w, e) =>
                {
                    IEnumerable<Models.CheckList> lists = this.Repository.GetCheckLists();

                    //w.ReportProgress(-1, "I have found the user id");

                    e.Result = lists;
                },
                ProgressChanged = e =>
                {
                    // it will display "I have found the user id" in this example
                    //SetWorkingMessage(e.UserState.ToString());
                },
                PostWorkCallBack = e =>
                {
                    _checklists = e.Result as List<Models.CheckList>;
                    ListViewItem[] items = _checklists.Select(x => new ListViewItem
                    {
                        Name = x.Id.ToString(),
                        Tag = x,
                        Text = $"{x.Name} ({x.CreatedOn?.ToString("d")})",
                        Checked = false
                    }).ToArray();

                    lvwChecklists.View = View.List;
                    lvwChecklists.Items.AddRange(items);
                    lvwChecklists.Refresh();

                    lvwChecklists.MultiSelect = false;
                    lvwChecklists.SelectedIndexChanged += LvwChecklists_SelectedIndexChanged;

                },
                AsyncArgument = null,
                // Progress information panel size
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void LvwChecklists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvwChecklists.SelectedItems?.Count > 0)
            {
                Models.CheckList checkList = lvwChecklists.SelectedItems[0].Tag as Models.CheckList;
                var list = _checklists.FirstOrDefault(x => x.Id == checkList.Id);

                 _source = new BindingSource();
                _source.DataSource = list?.CheckListItems;

                grdCheckListItems.DataSource = _source;
                grdCheckListItems.Refresh();
            }
            else
            {

            }

            ShowHideControls();
        }

        private void GrdCheckListItems_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void GrdCheckListItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(grdCheckListItems.Columns[e.ColumnIndex].Name == "isCheckedDataGridViewCheckBoxColumn")
            {
                if(((CheckListItem) grdCheckListItems.Rows[e.RowIndex].DataBoundItem).IsChecked == true)
                {
                    ((CheckListItem)grdCheckListItems.Rows[e.RowIndex].DataBoundItem).CheckedOn = DateTime.Now;
                }
                else
                {
                    ((CheckListItem)grdCheckListItems.Rows[e.RowIndex].DataBoundItem).CheckedOn = null;
                }
            }
            //CheckListItem listItem = grdCheckListItems.Rows[e.RowIndex].DataBoundItem as CheckListItem;
            //this.Repository.UpdateCheckListItem(listItem);
        }

        private void GrdCheckListItems_DataMemberChanged(object sender, EventArgs e)
        {

        }

        private void btnCreateCheckList_Click(object sender, EventArgs e)
        {
            frmCreateCheckList createForm = new frmCreateCheckList();
            createForm.Plugin = this;

            DialogResult result = createForm.ShowDialog();
            if(result == DialogResult.OK)
            {
                LoadCheckLists();
            }
        }

        private void ShowHideControls()
        {
            if(lvwChecklists.SelectedItems?.Count == 0)
            {
                grdCheckListItems.Hide();
                btnSave.Hide();
            }
            else
            {
                grdCheckListItems.Show();
                btnSave.Show();
            }
        }

        private void btnCreateCheckListItem_Click(object sender, EventArgs e)
        {
            _source.Add(new CheckListItem
            {
                Title = ""
            });

            grdCheckListItems.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs args)
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Saving...",
                Work = (w, e) =>
                {
                    this.Repository.UpdateAll(this._checklists);
                },
                ProgressChanged = e =>
                {
                    // it will display "I have found the user id" in this example
                    //SetWorkingMessage(e.UserState.ToString());
                },
                PostWorkCallBack = e =>
                {
                },
                AsyncArgument = null,
                // Progress information panel size
                MessageWidth = 340,
                MessageHeight = 150
            });
        }

        private void grdCheckListItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}