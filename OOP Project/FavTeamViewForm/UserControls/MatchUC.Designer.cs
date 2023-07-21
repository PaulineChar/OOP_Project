namespace UI_Windows_Forms.UserControllers
{
	partial class MatchUC
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchUC));
			tableLayoutPanel1 = new TableLayoutPanel();
			lbLocation = new Label();
			lbVisitors = new Label();
			lbAwayTeam = new Label();
			lbHomeTeam = new Label();
			tableLayoutPanel1.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
			tableLayoutPanel1.Controls.Add(lbLocation, 0, 0);
			tableLayoutPanel1.Controls.Add(lbVisitors, 1, 0);
			tableLayoutPanel1.Controls.Add(lbAwayTeam, 3, 0);
			tableLayoutPanel1.Controls.Add(lbHomeTeam, 2, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// lbLocation
			// 
			resources.ApplyResources(lbLocation, "lbLocation");
			lbLocation.BackColor = Color.Silver;
			lbLocation.Name = "lbLocation";
			// 
			// lbVisitors
			// 
			resources.ApplyResources(lbVisitors, "lbVisitors");
			lbVisitors.BackColor = Color.LightGray;
			lbVisitors.Name = "lbVisitors";
			// 
			// lbAwayTeam
			// 
			resources.ApplyResources(lbAwayTeam, "lbAwayTeam");
			lbAwayTeam.BackColor = Color.LightGray;
			lbAwayTeam.Name = "lbAwayTeam";
			// 
			// lbHomeTeam
			// 
			resources.ApplyResources(lbHomeTeam, "lbHomeTeam");
			lbHomeTeam.BackColor = Color.Silver;
			lbHomeTeam.Name = "lbHomeTeam";
			// 
			// MatchUC
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(tableLayoutPanel1);
			Name = "MatchUC";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private Label lbLocation;
		private Label lbVisitors;
		private Label lbAwayTeam;
		private Label lbHomeTeam;
	}
}
