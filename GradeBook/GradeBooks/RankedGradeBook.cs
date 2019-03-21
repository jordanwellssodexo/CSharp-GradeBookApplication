using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var aGradeRank = (int)Math.Ceiling(Students.Count * 0.2);
            var bGradeRank = (int)Math.Ceiling(Students.Count * 0.4);
            var cGradeRank = (int)Math.Ceiling(Students.Count * 0.6);
            var dGradeRank = (int)Math.Ceiling(Students.Count * 0.8);

            var rankOrderedStudents = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (rankOrderedStudents[aGradeRank - 1] <= averageGrade)
            { return 'A'; }
            else if (rankOrderedStudents[bGradeRank - 1] <= averageGrade)
            { return 'B'; }
            else if (rankOrderedStudents[cGradeRank - 1] <= averageGrade)
            { return 'C'; }
            else if (rankOrderedStudents[dGradeRank - 1] <= averageGrade)
            { return 'D'; }
            else { return 'F'; }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}