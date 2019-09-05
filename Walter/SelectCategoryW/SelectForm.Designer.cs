namespace Walter.SelectCategory
{
	partial class SelectForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectForm));
			this.btnAcceptExport = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.lblMessage = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.dgvListCategories = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvListCategories)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAcceptExport
			// 
			this.btnAcceptExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAcceptExport.Location = new System.Drawing.Point(108, 275);
			this.btnAcceptExport.Name = "btnAcceptExport";
			this.btnAcceptExport.Size = new System.Drawing.Size(135, 32);
			this.btnAcceptExport.TabIndex = 1;
			this.btnAcceptExport.Values.Text = "Accept && Export";
			this.btnAcceptExport.Click += new System.EventHandler(this.btnAcceptExport_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(265, 275);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 32);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Values.Text = "Cancel";
			// 
			// lblMessage
			// 
			this.lblMessage.Location = new System.Drawing.Point(12, 21);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(175, 24);
			this.lblMessage.TabIndex = 3;
			this.lblMessage.Values.Text = "Please select categories:";
			// 
			// dgvListCategories
			// 
			this.dgvListCategories.AllowUserToAddRows = false;
			this.dgvListCategories.AllowUserToDeleteRows = false;
			this.dgvListCategories.AllowUserToResizeColumns = false;
			this.dgvListCategories.AllowUserToResizeRows = false;
			this.dgvListCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvListCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvListCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvListCategories.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvListCategories.Location = new System.Drawing.Point(12, 51);
			this.dgvListCategories.Name = "dgvListCategories";
			this.dgvListCategories.ReadOnly = true;
			this.dgvListCategories.RowTemplate.Height = 24;
			this.dgvListCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvListCategories.Size = new System.Drawing.Size(355, 212);
			this.dgvListCategories.TabIndex = 4;
			this.dgvListCategories.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListCategories_CellMouseEnter);
			// 
			// SelectForm
			// 
			this.AcceptButton = this.btnAcceptExport;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(376, 325);
			this.Controls.Add(this.dgvListCategories);
			this.Controls.Add(this.lblMessage);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAcceptExport);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(394, 372);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(394, 372);
			this.Name = "SelectForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select";
			this.Load += new System.EventHandler(this.SelectForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvListCategories)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnAcceptExport;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel lblMessage;
		private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvListCategories;
	}
}