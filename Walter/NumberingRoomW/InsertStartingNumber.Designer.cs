namespace Walter
{
	partial class InsertStartingNumber
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InsertStartingNumber));
			this.lblStartNumber = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txtStartingNumber = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.btnAccept = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.SuspendLayout();
			// 
			// lblStartNumber
			// 
			this.lblStartNumber.Location = new System.Drawing.Point(12, 26);
			this.lblStartNumber.Name = "lblStartNumber";
			this.lblStartNumber.Size = new System.Drawing.Size(167, 24);
			this.lblStartNumber.TabIndex = 0;
			this.lblStartNumber.Values.Text = "Insert starting number:";
			// 
			// txtStartingNumber
			// 
			this.txtStartingNumber.Location = new System.Drawing.Point(185, 26);
			this.txtStartingNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.txtStartingNumber.Name = "txtStartingNumber";
			this.txtStartingNumber.Size = new System.Drawing.Size(124, 26);
			this.txtStartingNumber.TabIndex = 1;
			// 
			// btnAccept
			// 
			this.btnAccept.Location = new System.Drawing.Point(90, 74);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 32);
			this.btnAccept.TabIndex = 2;
			this.btnAccept.Values.Text = "Accept";
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(208, 74);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 32);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Values.Text = "Cancel";
			// 
			// InsertStartingNumber
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(328, 120);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.txtStartingNumber);
			this.Controls.Add(this.lblStartNumber);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(346, 167);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(346, 167);
			this.Name = "InsertStartingNumber";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Insert starting number";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonLabel lblStartNumber;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown txtStartingNumber;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnAccept;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
	}
}