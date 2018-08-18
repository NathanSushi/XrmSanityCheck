﻿using System;
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

namespace XrmToolBoxHackaton.XrmSanityCheck
{
    public partial class CheckListControl : PluginControlBase
    {
        private Settings mySettings;

        public CheckListControl()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

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
            ExecuteMethod(GetAccounts);
        }

        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
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
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading Checklists...",
                Work = (w, e) =>
                {
                    ICheckListRepository repository = new FakeCheckListRepository();
                    IEnumerable<Models.CheckList> lists = repository.GetCheckLists();

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
                    IEnumerable<Models.CheckList> checkLists =  e.Result as IEnumerable<Models.CheckList>;
                    ListViewItem[] items = checkLists.Select(x => new ListViewItem
                    {
                        Name = x.Id.ToString(),
                        Tag = x,
                        Text = $"{x.Name} ({x.CreatedOn?.ToString("s")})",
                        Checked = false
                    }).ToArray();

                    lvwChecklists.View = View.List;
                    lvwChecklists.Items.AddRange(items);
                    lvwChecklists.Refresh();

                    lvwChecklists.MultiSelect = false;
                    lvwChecklists.SelectedIndexChanged += LvwChecklists_SelectedIndexChanged;
                    // This code is executed in the main thread
                    //MessageBox.Show($"You are {(Guid)e.Result}");
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
                grdCheckListItems.DataSource = null;

            }
        }
    }
}