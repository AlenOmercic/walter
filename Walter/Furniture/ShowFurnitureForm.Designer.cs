namespace Walter
{
	partial class ShowFurnitureForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowFurnitureForm));
			this.trShowFurniture = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
			this.lblInfo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.SuspendLayout();
			// 
			// trShowFurniture
			// 
			this.trShowFurniture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trShowFurniture.Location = new System.Drawing.Point(12, 42);
			this.trShowFurniture.Name = "trShowFurniture";
			this.trShowFurniture.Size = new System.Drawing.Size(478, 345);
			this.trShowFurniture.TabIndex = 0;
			// 
			// lblInfo
			// 
			this.lblInfo.Location = new System.Drawing.Point(12, 12);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(6, 2);
			this.lblInfo.TabIndex = 1;
			this.lblInfo.Values.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOK.Location = new System.Drawing.Point(390, 406);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(100, 32);
			this.btnOK.TabIndex = 2;
			this.btnOK.Values.Text = "OK";
			// 
			// ShowFurnitureForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnOK;
			this.ClientSize = new System.Drawing.Size(502, 450);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.lblInfo);
			this.Controls.Add(this.trShowFurniture);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ShowFurnitureForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Show Furniture";
			this.Load += new System.EventHandler(this.ShowFurnitureForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonTreeView trShowFurniture;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel lblInfo;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
	}
}