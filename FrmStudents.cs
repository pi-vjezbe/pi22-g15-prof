using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager {
	public partial class FrmStudents : Form {
		public FrmStudents() {
			InitializeComponent();
			}

		private void FrmStudents_Load(object sender, EventArgs e) {
			dgvStudents.DataSource = StudentRepository.GetStudents();
			}

		private void btnEvaluateStudent_Click(object sender, EventArgs e) {
			//dohvat studenta
			Student selectedStudent = dgvStudents.CurrentRow.DataBoundItem as Student;

			//prikaz nove forme i slanje studenta
			if (selectedStudent != null) {
				FrmEvaluation frmEvaluation = new FrmEvaluation(selectedStudent);
				frmEvaluation.ShowDialog();
				}
			}
		}
	}
