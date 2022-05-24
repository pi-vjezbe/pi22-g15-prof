using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager
{
	public class Student : Person
	{
		public int Grade { get; set; }

		public List<Evaluation> GetEvaluations()
        {
			return EvaluationRepository.GetEvaluations(this);
        }

		public List<Activity> GetActivities()
		{
			return ActivityRepository.GetActivities();
		}

		public int CalculateTotalPoints()
        {
			int totalPoints = 0;

            foreach (var evaluation in GetEvaluations())
            {
				totalPoints += evaluation.Points;
            }

			return totalPoints;
        }

		public bool HasSignature()
        {
			//PRIMJER NEPOTREBNOG KOMENTARA
			//za potpis potrebno je imati odrađene sve aktivnost
			//i za svaku aktivnost potrebno je imati ostvaren minimalan broj bodova za potpis
		
			return IsEvaluationComplete() && IsMinimumAchievedForSignature();
        }

		/// <summary>
		/// Return <see langword="true"/> when student has right for signature and has achieved minimum points in all grading activities. Otherwise returns <see langword="false"/>
		/// </summary>
		/// <returns>True if student has right to receive a grade.</returns>
		public bool HasGrade()
        {
			return HasSignature() && IsMinimumAchievedForGrade();
		}

		public int? CalculateGrade()
        {
			int? grade = null;
			if (HasGrade())
            {
				int points = CalculateTotalPoints();
				grade = points >= 91 ? 5 : 
					    points >= 76 ? 4 : 
						points >= 61 ? 3 : 
						points >= 50 ? 2 : 1;
            }

			return grade;
        }

		private bool IsMinimumAchievedForSignature()
        {
			bool minimumAchieved = true;
			foreach (Evaluation evaluation in GetEvaluations())
			{
				if (!evaluation.IsSufficientForSignature())
				{
					minimumAchieved = false;
					break;
				}
			}
			return minimumAchieved;
		}

		private bool IsMinimumAchievedForGrade()
		{
			bool minimumAchieved = true;
			foreach (Evaluation evaluation in GetEvaluations())
			{
				if (!evaluation.IsSufficientForGrade())
				{
					minimumAchieved = false;
					break;
				}
			}
			return minimumAchieved;
		}

		private bool IsEvaluationComplete()
        {
			//dohvatimo listu svih aktivnosti
			//provjerimo za svaku aktivnost ima li pridruženu vrijednost bodova
			//ako sve aktivnosti imaju bodove vratimo true

			var activities = GetActivities();
			var evaluations = GetEvaluations();
			//return activities.Count == evaluations.Count;

			bool evaluationComplete = true;
            foreach (var activity in activities)
            {
				if (evaluations.Find(e => e.Activity.Id == activity.Id) == null)
				{
					evaluationComplete = false;
					break;
				}
            }

			return evaluationComplete;
        }
	}
}
