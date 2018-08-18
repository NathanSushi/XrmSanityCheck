namespace XrmToolBoxHackaton.XrmSanityCheck
{
    partial class CheckListControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSample = new System.Windows.Forms.ToolStripButton();
            this.lvwChecklists = new System.Windows.Forms.ListView();
            this.grpCheckLists = new System.Windows.Forms.GroupBox();
            this.btnLoadLists = new System.Windows.Forms.Button();
            this.grpCheckListItems = new System.Windows.Forms.GroupBox();
            this.grdCheckListItems = new System.Windows.Forms.DataGridView();
            this.toolStripMenu.SuspendLayout();
            this.grpCheckLists.SuspendLayout();
            this.grpCheckListItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCheckListItems)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbSample});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(559, 25);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(86, 22);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSample
            // 
            this.tsbSample.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSample.Name = "tsbSample";
            this.tsbSample.Size = new System.Drawing.Size(47, 22);
            this.tsbSample.Text = "Try me";
            this.tsbSample.Click += new System.EventHandler(this.tsbSample_Click);
            // 
            // lvwChecklists
            // 
            this.lvwChecklists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwChecklists.Location = new System.Drawing.Point(6, 46);
            this.lvwChecklists.Name = "lvwChecklists";
            this.lvwChecklists.Size = new System.Drawing.Size(233, 320);
            this.lvwChecklists.TabIndex = 5;
            this.lvwChecklists.UseCompatibleStateImageBehavior = false;
            // 
            // grpCheckLists
            // 
            this.grpCheckLists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpCheckLists.Controls.Add(this.btnLoadLists);
            this.grpCheckLists.Controls.Add(this.lvwChecklists);
            this.grpCheckLists.Location = new System.Drawing.Point(3, 28);
            this.grpCheckLists.Name = "grpCheckLists";
            this.grpCheckLists.Size = new System.Drawing.Size(245, 372);
            this.grpCheckLists.TabIndex = 6;
            this.grpCheckLists.TabStop = false;
            this.grpCheckLists.Text = "Checklists";
            // 
            // btnLoadLists
            // 
            this.btnLoadLists.Location = new System.Drawing.Point(7, 17);
            this.btnLoadLists.Name = "btnLoadLists";
            this.btnLoadLists.Size = new System.Drawing.Size(53, 23);
            this.btnLoadLists.TabIndex = 6;
            this.btnLoadLists.Text = "Load";
            this.btnLoadLists.UseVisualStyleBackColor = true;
            this.btnLoadLists.Click += new System.EventHandler(this.btnLoadLists_Click);
            // 
            // grpCheckListItems
            // 
            this.grpCheckListItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCheckListItems.Controls.Add(this.grdCheckListItems);
            this.grpCheckListItems.Location = new System.Drawing.Point(254, 28);
            this.grpCheckListItems.Name = "grpCheckListItems";
            this.grpCheckListItems.Size = new System.Drawing.Size(302, 366);
            this.grpCheckListItems.TabIndex = 7;
            this.grpCheckListItems.TabStop = false;
            this.grpCheckListItems.Text = "Items";
            // 
            // grdCheckListItems
            // 
            this.grdCheckListItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCheckListItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCheckListItems.Location = new System.Drawing.Point(6, 46);
            this.grdCheckListItems.Name = "grdCheckListItems";
            this.grdCheckListItems.Size = new System.Drawing.Size(290, 314);
            this.grdCheckListItems.TabIndex = 0;
            // 
            // CheckListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpCheckListItems);
            this.Controls.Add(this.grpCheckLists);
            this.Controls.Add(this.toolStripMenu);
            this.Name = "CheckListControl";
            this.Size = new System.Drawing.Size(559, 403);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.grpCheckLists.ResumeLayout(false);
            this.grpCheckListItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCheckListItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbSample;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ListView lvwChecklists;
        private System.Windows.Forms.GroupBox grpCheckLists;
        private System.Windows.Forms.Button btnLoadLists;
        private System.Windows.Forms.GroupBox grpCheckListItems;
        private System.Windows.Forms.DataGridView grdCheckListItems;
    }
}
