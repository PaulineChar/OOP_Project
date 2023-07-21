namespace UI
{
	partial class PlayerUC
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerUC));
			pbPlayer = new PictureBox();
			pbCaptain = new PictureBox();
			pbFav = new PictureBox();
			lbNumber = new Label();
			lbName = new Label();
			lbPosition = new Label();
			((System.ComponentModel.ISupportInitialize)pbPlayer).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbCaptain).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbFav).BeginInit();
			SuspendLayout();
			// 
			// pbPlayer
			// 
			pbPlayer.Image = UI_Windows_Forms.Properties.Resources.UserIcon;
			pbPlayer.InitialImage = UI_Windows_Forms.Properties.Resources.UserIcon;
			resources.ApplyResources(pbPlayer, "pbPlayer");
			pbPlayer.Name = "pbPlayer";
			pbPlayer.TabStop = false;
			// 
			// pbCaptain
			// 
			pbCaptain.Image = UI_Windows_Forms.Properties.Resources.CaptainIcon;
			pbCaptain.InitialImage = UI_Windows_Forms.Properties.Resources.CaptainIcon;
			resources.ApplyResources(pbCaptain, "pbCaptain");
			pbCaptain.Name = "pbCaptain";
			pbCaptain.TabStop = false;
			// 
			// pbFav
			// 
			pbFav.Image = UI_Windows_Forms.Properties.Resources.FavIcon;
			pbFav.InitialImage = UI_Windows_Forms.Properties.Resources.FavIcon;
			resources.ApplyResources(pbFav, "pbFav");
			pbFav.Name = "pbFav";
			pbFav.TabStop = false;
			// 
			// lbNumber
			// 
			resources.ApplyResources(lbNumber, "lbNumber");
			lbNumber.Name = "lbNumber";
			// 
			// lbName
			// 
			resources.ApplyResources(lbName, "lbName");
			lbName.Name = "lbName";
			// 
			// lbPosition
			// 
			resources.ApplyResources(lbPosition, "lbPosition");
			lbPosition.Name = "lbPosition";
			// 
			// PlayerUC
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(192, 255, 192);
			BorderStyle = BorderStyle.FixedSingle;
			Controls.Add(lbPosition);
			Controls.Add(lbName);
			Controls.Add(lbNumber);
			Controls.Add(pbFav);
			Controls.Add(pbCaptain);
			Controls.Add(pbPlayer);
			Name = "PlayerUC";
			((System.ComponentModel.ISupportInitialize)pbPlayer).EndInit();
			((System.ComponentModel.ISupportInitialize)pbCaptain).EndInit();
			((System.ComponentModel.ISupportInitialize)pbFav).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox pbPlayer;
		private PictureBox pbCaptain;
		private PictureBox pbFav;
		private Label lbNumber;
		private Label lbName;
		private Label lbPosition;
	}
}
