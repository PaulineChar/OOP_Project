namespace UI_Windows_Forms
{
    partial class CloseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CloseForm));
            button2 = new Button();
            button1 = new Button();
            lbMess = new Label();
            SuspendLayout();
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.DialogResult = DialogResult.Cancel;
            button2.Name = "button2";
            button2.TabStop = false;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.DialogResult = DialogResult.OK;
            button1.Name = "button1";
            button1.TabStop = false;
            button1.UseVisualStyleBackColor = true;
            // 
            // lbMess
            // 
            resources.ApplyResources(lbMess, "lbMess");
            lbMess.Name = "lbMess";
            // 
            // CloseForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbMess);
            Controls.Add(button1);
            Controls.Add(button2);
            KeyPreview = true;
            Name = "CloseForm";
            KeyUp += CloseForm_KeyUp;
            ResumeLayout(false);
        }

        #endregion

        private Button button2;
        private Button button1;
        private Label lbMess;
    }
}