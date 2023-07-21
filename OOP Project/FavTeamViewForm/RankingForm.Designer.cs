namespace UI
{
    partial class RankingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingForm));
            tcRanking = new TabControl();
            tpPlayerRanking = new TabPage();
            flpGridContainer = new FlowLayoutPanel();
            cmsSort = new ContextMenuStrip(components);
            sortByGoalsToolStripMenuItem = new ToolStripMenuItem();
            cmsiGoalsAsc = new ToolStripMenuItem();
            csmiGoalsDesc = new ToolStripMenuItem();
            sortByToolStripMenuItem = new ToolStripMenuItem();
            csmiCardsAsc = new ToolStripMenuItem();
            csmiCardsDesc = new ToolStripMenuItem();
            tpMatchRanking = new TabPage();
            flpMatchContainer = new FlowLayoutPanel();
            tsOption = new ToolStrip();
            tspSettings = new ToolStripButton();
            tsbPrint = new ToolStripButton();
            tcRanking.SuspendLayout();
            tpPlayerRanking.SuspendLayout();
            cmsSort.SuspendLayout();
            tpMatchRanking.SuspendLayout();
            tsOption.SuspendLayout();
            SuspendLayout();
            // 
            // tcRanking
            // 
            resources.ApplyResources(tcRanking, "tcRanking");
            tcRanking.Controls.Add(tpPlayerRanking);
            tcRanking.Controls.Add(tpMatchRanking);
            tcRanking.Name = "tcRanking";
            tcRanking.SelectedIndex = 0;
            tcRanking.SelectedIndexChanged += tcRanking_SelectedIndexChanged;
            // 
            // tpPlayerRanking
            // 
            resources.ApplyResources(tpPlayerRanking, "tpPlayerRanking");
            tpPlayerRanking.Controls.Add(flpGridContainer);
            tpPlayerRanking.Name = "tpPlayerRanking";
            tpPlayerRanking.UseVisualStyleBackColor = true;
            // 
            // flpGridContainer
            // 
            resources.ApplyResources(flpGridContainer, "flpGridContainer");
            flpGridContainer.BackColor = Color.Gainsboro;
            flpGridContainer.ContextMenuStrip = cmsSort;
            flpGridContainer.Name = "flpGridContainer";
            // 
            // cmsSort
            // 
            resources.ApplyResources(cmsSort, "cmsSort");
            cmsSort.ImageScalingSize = new Size(24, 24);
            cmsSort.Items.AddRange(new ToolStripItem[] { sortByGoalsToolStripMenuItem, sortByToolStripMenuItem });
            cmsSort.Name = "cmsSort";
            // 
            // sortByGoalsToolStripMenuItem
            // 
            resources.ApplyResources(sortByGoalsToolStripMenuItem, "sortByGoalsToolStripMenuItem");
            sortByGoalsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cmsiGoalsAsc, csmiGoalsDesc });
            sortByGoalsToolStripMenuItem.Name = "sortByGoalsToolStripMenuItem";
            // 
            // cmsiGoalsAsc
            // 
            resources.ApplyResources(cmsiGoalsAsc, "cmsiGoalsAsc");
            cmsiGoalsAsc.Name = "cmsiGoalsAsc";
            cmsiGoalsAsc.Click += cmsiGoalsAsc_Click;
            // 
            // csmiGoalsDesc
            // 
            resources.ApplyResources(csmiGoalsDesc, "csmiGoalsDesc");
            csmiGoalsDesc.Name = "csmiGoalsDesc";
            csmiGoalsDesc.Click += csmiGoalsDesc_Click;
            // 
            // sortByToolStripMenuItem
            // 
            resources.ApplyResources(sortByToolStripMenuItem, "sortByToolStripMenuItem");
            sortByToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { csmiCardsAsc, csmiCardsDesc });
            sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
            // 
            // csmiCardsAsc
            // 
            resources.ApplyResources(csmiCardsAsc, "csmiCardsAsc");
            csmiCardsAsc.Name = "csmiCardsAsc";
            csmiCardsAsc.Click += csmiCardsAsc_Click;
            // 
            // csmiCardsDesc
            // 
            resources.ApplyResources(csmiCardsDesc, "csmiCardsDesc");
            csmiCardsDesc.Name = "csmiCardsDesc";
            csmiCardsDesc.Click += csmiCardsDesc_Click;
            // 
            // tpMatchRanking
            // 
            resources.ApplyResources(tpMatchRanking, "tpMatchRanking");
            tpMatchRanking.Controls.Add(flpMatchContainer);
            tpMatchRanking.Name = "tpMatchRanking";
            tpMatchRanking.UseVisualStyleBackColor = true;
            // 
            // flpMatchContainer
            // 
            resources.ApplyResources(flpMatchContainer, "flpMatchContainer");
            flpMatchContainer.BackColor = Color.Transparent;
            flpMatchContainer.Name = "flpMatchContainer";
            // 
            // tsOption
            // 
            resources.ApplyResources(tsOption, "tsOption");
            tsOption.ImageScalingSize = new Size(24, 24);
            tsOption.Items.AddRange(new ToolStripItem[] { tspSettings, tsbPrint });
            tsOption.Name = "tsOption";
            // 
            // tspSettings
            // 
            resources.ApplyResources(tspSettings, "tspSettings");
            tspSettings.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tspSettings.Image = UI_Windows_Forms.Properties.Resources.SettingsIcon;
            tspSettings.Name = "tspSettings";
            tspSettings.Click += tspSettings_Click;
            // 
            // tsbPrint
            // 
            resources.ApplyResources(tsbPrint, "tsbPrint");
            tsbPrint.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbPrint.Image = UI_Windows_Forms.Properties.Resources.PrintIcon;
            tsbPrint.Name = "tsbPrint";
            tsbPrint.Click += tsbPrint_Click;
            // 
            // RankingForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tsOption);
            Controls.Add(tcRanking);
            Name = "RankingForm";
            tcRanking.ResumeLayout(false);
            tpPlayerRanking.ResumeLayout(false);
            cmsSort.ResumeLayout(false);
            tpMatchRanking.ResumeLayout(false);
            tsOption.ResumeLayout(false);
            tsOption.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tcRanking;
        private TabPage tpPlayerRanking;
        private Label label1;
        private TabPage tpMatchRanking;
        private FlowLayoutPanel flpGridContainer;
        private ContextMenuStrip cmsSort;
        private ToolStripMenuItem sortByGoalsToolStripMenuItem;
        private ToolStripMenuItem cmsiGoalsAsc;
        private ToolStripMenuItem csmiGoalsDesc;
        private ToolStripMenuItem sortByToolStripMenuItem;
        private ToolStripMenuItem csmiCardsAsc;
        private ToolStripMenuItem csmiCardsDesc;
        private ToolStrip tsOption;
        private ToolStripButton tspSettings;
        private ToolStripButton tsbPrint;
        private FlowLayoutPanel flpMatchContainer;
    }
}