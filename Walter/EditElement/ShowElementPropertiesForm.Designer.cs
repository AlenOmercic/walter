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
			this.lblElementProperties = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.dgvFamilyProp = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			this.lblFamily = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			((System.ComponentModel.ISupportInitialize)(this.dgvShowProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvFamilyProp)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvShowProperties
			// 
			this.dgvShowProperties.AllowUserToAddRows = false;
			this.dgvShowProperties.AllowUserToDeleteRows = false;
			this.dgvShowProperties.AllowUserToResizeRows = false;
			this.dgvShowProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvShowProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvShowProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvShowProperties.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvShowProperties.Location = new System.Drawing.Point(12, 47);
			this.dgvShowProperties.MaximumSize = new System.Drawing.Size(687, 202);
			this.dgvShowProperties.MinimumSize = new System.Drawing.Size(687, 202);
			this.dgvShowProperties.MultiSelect = false;
			this.dgvShowProperties.Name = "dgvShowProperties";
			this.dgvShowProperties.ReadOnly = true;
			this.dgvShowProperties.RowTemplate.Height = 24;
			this.dgvShowProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvShowProperties.Size = new System.Drawing.Size(687, 202);
			this.dgvShowProperties.TabIndex = 0;
			this.dgvShowProperties.Click += new System.EventHandler(this.dgvShowProperties_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOK.Location = new System.Drawing.Point(599, 509);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(100, 32);
			this.btnOK.TabIndex = 1;
			this.btnOK.Values.Text = "OK";
			// 
			// lblElementProperties
			// 
			this.lblElementProperties.Location = new System.Drawing.Point(12, 17);
			this.lblElementProperties.Name = "lblElementProperties";
			this.lblElementProperties.Size = new System.Drawing.Size(140, 24);
			this.lblElementProperties.TabIndex = 2;
			this.lblElementProperties.Values.Text = "Element Properties";
			// 
			// dgvFamilyProp
			// 
			this.dgvFamilyProp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvFamilyProp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvFamilyProp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFamilyProp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvFamilyProp.Location = new System.Drawing.Point(12, 294);
			this.dgvFamilyProp.MaximumSize = new System.Drawing.Size(687, 202);
			this.dgvFamilyProp.MinimumSize = new System.Drawing.Size(687, 202);
			this.dgvFamilyProp.MultiSelect = false;
			this.dgvFamilyProp.Name = "dgvFamilyProp";
			this.dgvFamilyProp.ReadOnly = true;
			this.dgvFamilyProp.RowTemplate.Height = 24;
			this.dgvFamilyProp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvFamilyProp.Size = new System.Drawing.Size(687, 202);
			this.dgvFamilyProp.TabIndex = 3;
			this.dgvFamilyProp.Click += new System.EventHandler(this.dgvFamilyProp_Click);
			// 
			// lblFamily
			// 
			this.lblFamily.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFamily.Location = new System.Drawing.Point(12, 264);
			this.lblFamily.Name = "lblFamily";
			this.lblFamily.Size = new System.Drawing.Size(129, 24);
			this.lblFamily.TabIndex = 4;
			this.lblFamily.Values.Text = "Family Properties";
			// 
			// ShowElementPropertiesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnOK;
			this.ClientSize = new System.Drawing.Size(711, 553);
			this.Controls.Add(this.lblFamily);
			this.Controls.Add(this.dgvFamilyProp);
			this.Controls.Add(this.lblElementProperties);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.dgvShowProperties);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(729, 600);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(729, 600);
			this.Name = "ShowElementPropertiesForm";
			this.ShowInTaskbar = false;
			this.Text = "Element Properties";
			this.Load += new System.EventHandler(this.ShowElementProperties_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvShowProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvFamilyProp)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvShowProperties;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel lblElementProperties;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvFamilyProp;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel lblFamily;
	}
}