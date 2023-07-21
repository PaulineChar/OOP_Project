namespace UI
{
    partial class TeamChooserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeamChooserForm));
            label1 = new Label();
            cbCountries = new ComboBox();
            btnConfirm = new Button();
            pnlContainer2 = new Panel();
            btnCancel = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            lbError = new Label();
            lbCountFav = new Label();
            label2 = new Label();
            btnSubmit = new Button();
            flpAllPlayers = new FlowLayoutPanel();
            flpFavPlayers = new FlowLayoutPanel();
            pnlCountry = new Panel();
            cmsFromAllPlayers = new ContextMenuStrip(components);
            cmsiAddFavorite = new ToolStripMenuItem();
            cmsFromFavoritePlayers = new ContextMenuStrip(components);
            cmsiAddAllPlayers = new ToolStripMenuItem();
            pnlContainer2.SuspendLayout();
            pnlCountry.SuspendLayout();
            cmsFromAllPlayers.SuspendLayout();
            cmsFromFavoritePlayers.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // cbCountries
            // 
            resources.ApplyResources(cbCountries, "cbCountries");
            cbCountries.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCountries.FormattingEnabled = true;
            cbCountries.Name = "cbCountries";
            cbCountries.Sorted = true;
            // 
            // btnConfirm
            // 
            resources.ApplyResources(btnConfirm, "btnConfirm");
            btnConfirm.Name = "btnConfirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // pnlContainer2
            // 
            resources.ApplyResources(pnlContainer2, "pnlContainer2");
            pnlContainer2.Controls.Add(btnCancel);
            pnlContainer2.Controls.Add(label5);
            pnlContainer2.Controls.Add(label4);
            pnlContainer2.Controls.Add(label3);
            pnlContainer2.Controls.Add(lbError);
            pnlContainer2.Controls.Add(lbCountFav);
            pnlContainer2.Controls.Add(label2);
            pnlContainer2.Controls.Add(btnSubmit);
            pnlContainer2.Controls.Add(flpAllPlayers);
            pnlContainer2.Controls.Add(flpFavPlayers);
            pnlContainer2.Name = "pnlContainer2";
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // lbError
            // 
            resources.ApplyResources(lbError, "lbError");
            lbError.ForeColor = Color.Red;
            lbError.Name = "lbError";
            // 
            // lbCountFav
            // 
            resources.ApplyResources(lbCountFav, "lbCountFav");
            lbCountFav.ForeColor = Color.Red;
            lbCountFav.Name = "lbCountFav";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // btnSubmit
            // 
            resources.ApplyResources(btnSubmit, "btnSubmit");
            btnSubmit.Name = "btnSubmit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // flpAllPlayers
            // 
            resources.ApplyResources(flpAllPlayers, "flpAllPlayers");
            flpAllPlayers.AllowDrop = true;
            flpAllPlayers.BackColor = SystemColors.GradientInactiveCaption;
            flpAllPlayers.Name = "flpAllPlayers";
            flpAllPlayers.Tag = "All";
            flpAllPlayers.DragDrop += PlayerUC_DragDrop;
            flpAllPlayers.DragEnter += PlayerUC_DragEnter;
            // 
            // flpFavPlayers
            // 
            resources.ApplyResources(flpFavPlayers, "flpFavPlayers");
            flpFavPlayers.AllowDrop = true;
            flpFavPlayers.BackColor = Color.LemonChiffon;
            flpFavPlayers.Name = "flpFavPlayers";
            flpFavPlayers.Tag = "Fav";
            flpFavPlayers.DragDrop += PlayerUC_DragDrop;
            flpFavPlayers.DragEnter += PlayerUC_DragEnter;
            // 
            // pnlCountry
            // 
            resources.ApplyResources(pnlCountry, "pnlCountry");
            pnlCountry.Controls.Add(btnConfirm);
            pnlCountry.Controls.Add(label1);
            pnlCountry.Controls.Add(cbCountries);
            pnlCountry.Name = "pnlCountry";
            // 
            // cmsFromAllPlayers
            // 
            resources.ApplyResources(cmsFromAllPlayers, "cmsFromAllPlayers");
            cmsFromAllPlayers.ImageScalingSize = new Size(24, 24);
            cmsFromAllPlayers.Items.AddRange(new ToolStripItem[] { cmsiAddFavorite });
            cmsFromAllPlayers.Name = "cmsFromAllPlayers";
            // 
            // cmsiAddFavorite
            // 
            resources.ApplyResources(cmsiAddFavorite, "cmsiAddFavorite");
            cmsiAddFavorite.Name = "cmsiAddFavorite";
            cmsiAddFavorite.Click += cmsiAddFavorite_Click;
            // 
            // cmsFromFavoritePlayers
            // 
            resources.ApplyResources(cmsFromFavoritePlayers, "cmsFromFavoritePlayers");
            cmsFromFavoritePlayers.ImageScalingSize = new Size(24, 24);
            cmsFromFavoritePlayers.Items.AddRange(new ToolStripItem[] { cmsiAddAllPlayers });
            cmsFromFavoritePlayers.Name = "cmsFromFavoritePlayers";
            // 
            // cmsiAddAllPlayers
            // 
            resources.ApplyResources(cmsiAddAllPlayers, "cmsiAddAllPlayers");
            cmsiAddAllPlayers.Name = "cmsiAddAllPlayers";
            cmsiAddAllPlayers.Click += cmsiAddAllPlayers_Click;
            // 
            // TeamChooserForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            ControlBox = false;
            Controls.Add(pnlCountry);
            Controls.Add(pnlContainer2);
            Name = "TeamChooserForm";
            FormClosing += teamChooserForm_FormClosing;
            Load += TeamChooserForm_Load;
            pnlContainer2.ResumeLayout(false);
            pnlContainer2.PerformLayout();
            pnlCountry.ResumeLayout(false);
            pnlCountry.PerformLayout();
            cmsFromAllPlayers.ResumeLayout(false);
            cmsFromFavoritePlayers.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private ComboBox cbCountries;
        private Button btnConfirm;
        private Panel pnlContainer2;
        private Label label4;
        private Label label3;
        private Label lbError;
        private Label lbCountFav;
        private Label label2;
        private Button btnSubmit;
        private FlowLayoutPanel flpAllPlayers;
        private FlowLayoutPanel flpFavPlayers;
        private Panel pnlCountry;
        private Label label5;
        private ContextMenuStrip cmsFromAllPlayers;
        private ToolStripMenuItem cmsiAddFavorite;
        private ContextMenuStrip cmsFromFavoritePlayers;
        private ToolStripMenuItem cmsiAddAllPlayers;
        private Button btnCancel;
    }
}