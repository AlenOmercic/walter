namespace Walter
{
	partial class EditPropertyForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPropertyForm));
			this.lblProperty = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txtValue = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.SuspendLayout();
			// 
			// lblProperty
			// 
			this.lblProperty.Location = new System.Drawing.Point(12, 23);
			this.lblProperty.Name = "lblProperty";
			this.lblProperty.Size = new System.Drawing.Size(109, 24);
			this.lblProperty.TabIndex = 0;
			this.lblProperty.Values.Text = "kryptonLabel1";
			// 
			// txtValue
			// 
			this.txtValue.Location = new System.Drawing.Point(12, 53);
			this.txtValue.Name = "txtValue";
			this.txtValue.Size = new System.Drawing.Size(261, 27);
			this.txtValue.TabIndex = 1;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(173, 89);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(100, 32);
			this.btnOK.TabIndex = 2;
			this.btnOK.Values.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// EditPropertyForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(288, 133);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtValue);
			this.Controls.Add(this.lblProperty);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(306, 180);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(306, 180);
			this.Name = "EditPropertyForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit Property";
			this.Load += new System.EventHandler(this.EditPropertyForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonLabel lblProperty;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtValue;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
	}
}