namespace Evaluation_Manager
{
    partial class FrmStudents
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
			this.dgvStudents = new System.Windows.Forms.DataGridView();
			this.btnEvaluateStudent = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStudents.Location = new System.Drawing.Point(12, 12);
			this.dgvStudents.Name = "dataGridView1";
			this.dgvStudents.Size = new System.Drawing.Size(776, 373);
			this.dgvStudents.TabIndex = 0;
			// 
			// btnEvaluateStudent
			// 
			this.btnEvaluateStudent.Location = new System.Drawing.Point(628, 403);
			this.btnEvaluateStudent.Name = "btnEvaluateStudent";
			this.btnEvaluateStudent.Size = new System.Drawing.Size(160, 23);
			this.btnEvaluateStudent.TabIndex = 1;
			this.btnEvaluateStudent.Text = "Evaluiraj studenta";
			this.btnEvaluateStudent.UseVisualStyleBackColor = true;
			this.btnEvaluateStudent.Click += new System.EventHandler(this.btnEvaluateStudent_Click);
			// 
			// FrmStudents
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 437);
			this.Controls.Add(this.btnEvaluateStudent);
			this.Controls.Add(this.dgvStudents);
			this.Name = "FrmStudents";
			this.Text = "FrmStudents";
			this.Load += new System.EventHandler(this.FrmStudents_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudents;
		private System.Windows.Forms.Button btnEvaluateStudent;
		}
}