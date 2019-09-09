namespace Walter
{
	partial class ShowElementPropertiesForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowElementPropertiesForm));
			this.dgvShowProperties = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			((System.ComponentModel.ISupportInitialize)(this.dgvShowProperties)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvShowProperties
			// 
			this.dgvShowProperties.AllowUserToAddRows = false;
			this.dgvShowProperties.AllowUserToDeleteRows = false;
			this.dgvShowProperties.AllowUserToResizeRows = false;
			this.dgvShowProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvShowProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvShowProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvShowProperties.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvShowProperties.Location = new System.Drawing.Point(12, 12);
			this.dgvShowProperties.MultiSelect = false;
			this.dgvShowProperties.Name = "dgvShowProperties";
			this.dgvShowProperties.ReadOnly = true;
			this.dgvShowProperties.RowTemplate.Height = 24;
			this.dgvShowProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvShowProperties.Size = new System.Drawing.Size(708, 313);
			this.dgvShowProperties.TabIndex = 0;
			this.dgvShowProperties.Click += new System.EventHandler(this.dgvShowProperties_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOK.Location = new System.Drawing.Point(620, 343);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(100, 32);
			this.btnOK.TabIndex = 1;
			this.btnOK.Values.Text = "OK";
			// 
			// ShowElementPropertiesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnOK;
			this.ClientSize = new System.Drawing.Size(732, 387);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.dgvShowProperties);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ShowElementPropertiesForm";
			this.ShowInTaskbar = false;
			this.Text = "Element Properties";
			this.Load += new System.EventHandler(this.ShowElementProperties_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvShowProperties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvShowProperties;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
	}
}