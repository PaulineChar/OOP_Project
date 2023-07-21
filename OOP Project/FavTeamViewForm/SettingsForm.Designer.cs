namespace UI
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            rbtnEnglish = new RadioButton();
            rbtnFrench = new RadioButton();
            gbLanguage = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            gbChampionship = new GroupBox();
            rbtnMen = new RadioButton();
            rbtnWomen = new RadioButton();
            btnConfirm = new Button();
            btnCancel = new Button();
            checkBoxIsLocal = new CheckBox();
            gbLanguage.SuspendLayout();
            gbChampionship.SuspendLayout();
            SuspendLayout();
            // 
            // rbtnEnglish
            // 
            resources.ApplyResources(rbtnEnglish, "rbtnEnglish");
            rbtnEnglish.Checked = true;
            rbtnEnglish.Name = "rbtnEnglish";
            rbtnEnglish.TabStop = true;
            rbtnEnglish.UseVisualStyleBackColor = true;
            // 
            // rbtnFrench
            // 
            resources.ApplyResources(rbtnFrench, "rbtnFrench");
            rbtnFrench.Name = "rbtnFrench";
            rbtnFrench.UseVisualStyleBackColor = true;
            // 
            // gbLanguage
            // 
            resources.ApplyResources(gbLanguage, "gbLanguage");
            gbLanguage.Controls.Add(rbtnEnglish);
            gbLanguage.Controls.Add(rbtnFrench);
            gbLanguage.Name = "gbLanguage";
            gbLanguage.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // gbChampionship
            // 
            resources.ApplyResources(gbChampionship, "gbChampionship");
            gbChampionship.Controls.Add(rbtnMen);
            gbChampionship.Controls.Add(rbtnWomen);
            gbChampionship.Name = "gbChampionship";
            gbChampionship.TabStop = false;
            // 
            // rbtnMen
            // 
            resources.ApplyResources(rbtnMen, "rbtnMen");
            rbtnMen.Checked = true;
            rbtnMen.Name = "rbtnMen";
            rbtnMen.TabStop = true;
            rbtnMen.UseVisualStyleBackColor = true;
            // 
            // rbtnWomen
            // 
            resources.ApplyResources(rbtnWomen, "rbtnWomen");
            rbtnWomen.Name = "rbtnWomen";
            rbtnWomen.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            resources.ApplyResources(btnConfirm, "btnConfirm");
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.Name = "btnConfirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsLocal
            // 
            resources.ApplyResources(checkBoxIsLocal, "checkBoxIsLocal");
            checkBoxIsLocal.Name = "checkBoxIsLocal";
            checkBoxIsLocal.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkBoxIsLocal);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(gbChampionship);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(gbLanguage);
            KeyPreview = true;
            Name = "SettingsForm";
            FormClosing += SettingsForm_FormClosing;
            KeyUp += SettingsForm_KeyUp;
            gbLanguage.ResumeLayout(false);
            gbLanguage.PerformLayout();
            gbChampionship.ResumeLayout(false);
            gbChampionship.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rbtnEnglish;
        private RadioButton rbtnFrench;
        private GroupBox gbLanguage;
        private Label label1;
        private Label label2;
        private GroupBox gbChampionship;
        private RadioButton rbtnMen;
        private RadioButton rbtnWomen;
        private Button btnConfirm;
        private Button btnCancel;
        private CheckBox checkBoxIsLocal;
    }
}