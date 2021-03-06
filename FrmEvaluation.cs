using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager
{
	public partial class FrmEvaluation : Form
	{

		private Student SelectedStudent { get; }

		public FrmEvaluation(Student selectedStudent)
		{
			InitializeComponent();
			SelectedStudent = selectedStudent;
		}

		private void FrmEvaluation_Load(object sender, EventArgs e)
		{
			var activities = ActivityRepository.GetActivities();
			cboActivities.DataSource = activities;

			Text = SelectedStudent.FirstName + " " + SelectedStudent.LastName;
			//Text = SelectedStudent.ToString();
		}

		private void cboActivities_SelectedIndexChanged(object sender, EventArgs e)
		{
			var currentActivity = cboActivities.SelectedItem as Activity;
			txtActivityDescription.Text = currentActivity.Description;
			txtMinForGrade.Text = currentActivity.MinPointsForGrade + "/" +
			currentActivity.MaxPoints;
			txtMinForSignature.Text = currentActivity.MinPointsForSignature + "/" +
			currentActivity.MaxPoints;
			numPoints.Minimum = 0;
			numPoints.Maximum = currentActivity.MaxPoints;

			//popuniti podatke o evaluaciji ako je već napravljena
			var evaluation = EvaluationRepository.GetEvaluation(SelectedStudent, currentActivity);
			if (evaluation != null)
            {
				txtTeacher.Text = evaluation.Evaluator.ToString();
				txtEvaluationDate.Text = evaluation.EvaluationDate.ToString("dd.MM.yyyy");
				numPoints.Value = evaluation.Points;
            }
			else
            {
				txtTeacher.Text = "";
				txtEvaluationDate.Text = "";
				numPoints.Value = 0;
            }
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void btnSave_Click(object sender, EventArgs e)
        {
			var currentActivity = cboActivities.SelectedItem as Activity;
			var evaluation = EvaluationRepository.GetEvaluation(SelectedStudent, currentActivity);
			int points = (int)numPoints.Value;
			if (evaluation != null)
            {
				EvaluationRepository.UpdateEvaluation(evaluation, FrmLogin.LoggedTeacher, points);
            }
			else
            {
				EvaluationRepository.InsertEvaluation(SelectedStudent, currentActivity, FrmLogin.LoggedTeacher, points);
            }

			//nepopularan način osvježavanja sučelja,
			//bolje bi bilo imati metodu koja se samo bavi osvježavanje sučelja,
			//ali to ćemo jednom drugom zgodom
			cboActivities_SelectedIndexChanged(null, null);
		}
    }
}
