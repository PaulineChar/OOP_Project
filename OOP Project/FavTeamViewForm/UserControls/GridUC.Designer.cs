namespace UI_Windows_Forms
{
    partial class GridUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridUC));
            label2 = new Label();
            lbNumber = new Label();
            pbPicture = new PictureBox();
            pbFavorite = new PictureBox();
            lbYellowCard = new Label();
            label5 = new Label();
            lbAppearance = new Label();
            label7 = new Label();
            label8 = new Label();
            lbGoal = new Label();
            lbRank = new Label();
            pbCaptain = new PictureBox();
            lbName = new Label();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFavorite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCaptain).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // lbNumber
            // 
            resources.ApplyResources(lbNumber, "lbNumber");
            lbNumber.ForeColor = Color.Black;
            lbNumber.Name = "lbNumber";
            // 
            // pbPicture
            // 
            resources.ApplyResources(pbPicture, "pbPicture");
            pbPicture.Image = Properties.Resources.UserIcon;
            pbPicture.Name = "pbPicture";
            pbPicture.TabStop = false;
            // 
            // pbFavorite
            // 
            resources.ApplyResources(pbFavorite, "pbFavorite");
            pbFavorite.Image = Properties.Resources.FavIcon;
            pbFavorite.Name = "pbFavorite";
            pbFavorite.TabStop = false;
            // 
            // lbYellowCard
            // 
            resources.ApplyResources(lbYellowCard, "lbYellowCard");
            lbYellowCard.Name = "lbYellowCard";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // lbAppearance
            // 
            resources.ApplyResources(lbAppearance, "lbAppearance");
            lbAppearance.Name = "lbAppearance";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // lbGoal
            // 
            resources.ApplyResources(lbGoal, "lbGoal");
            lbGoal.Name = "lbGoal";
            // 
            // lbRank
            // 
            resources.ApplyResources(lbRank, "lbRank");
            lbRank.ForeColor = Color.DeepSkyBlue;
            lbRank.Name = "lbRank";
            // 
            // pbCaptain
            // 
            resources.ApplyResources(pbCaptain, "pbCaptain");
            pbCaptain.Image = Properties.Resources.CaptainIcon;
            pbCaptain.Name = "pbCaptain";
            pbCaptain.TabStop = false;
            // 
            // lbName
            // 
            resources.ApplyResources(lbName, "lbName");
            lbName.Name = "lbName";
            // 
            // GridUC
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(192, 255, 192);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lbName);
            Controls.Add(pbCaptain);
            Controls.Add(lbRank);
            Controls.Add(lbGoal);
            Controls.Add(label8);
            Controls.Add(lbAppearance);
            Controls.Add(label7);
            Controls.Add(lbYellowCard);
            Controls.Add(label5);
            Controls.Add(pbFavorite);
            Controls.Add(pbPicture);
            Controls.Add(lbNumber);
            Controls.Add(label2);
            Name = "GridUC";
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFavorite).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCaptain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label lbNumber;
        private PictureBox pbPicture;
        private PictureBox pbFavorite;
        private Label lbYellowCard;
        private Label label5;
        private Label lbAppearance;
        private Label label7;
        private Label label8;
        private Label lbGoal;
        private Label lbRank;
        private PictureBox pbCaptain;
        private Label lbName;
    }
}
