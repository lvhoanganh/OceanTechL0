using StudentManagement.Service;
using System;

namespace StudentManagement.Entities
{
    internal class Student : Person
    {
        public string Code { get; set; } = string.Empty;
        public string School { get; set; } = string.Empty;
        public DateOnly StartDate { get; set; }
        public double Average { get; set; }
        public AcademicPerformance Performance { get; private set; }

        // Constructor mặc định
        public Student() { }

        // Constructor với tham số
        public Student(string code, string school, DateOnly startDate, double average) : base()
        {
            Code = code;
            School = school;
            StartDate = startDate;
            Average = average;
            UpdatePerformance();
        }

        // Constructor với tất cả các tham số
        public Student(int id, string name, DateOnly birthday, string address, double height, double weight,
            string code, string school, DateOnly startDate, double average) : base(id, name, birthday, address, height, weight)
        {
            Code = code;
            School = school;
            StartDate = startDate;
            Average = average;
            UpdatePerformance();
        }

        // Ghi đè phương thức ToString
        public override string ToString()
        {
            return base.ToString() + $" - Student: {Code} - {School} - {StartDate} - {Average} - Performance: {Performance}";
        }

        public void UpdatePerformance()
        {
            if (Average < 3)
                Performance = AcademicPerformance.Poor;
            else if (Average < 5)
                Performance = AcademicPerformance.Weak;
            else if (Average < 6.5)
                Performance = AcademicPerformance.Average;
            else if (Average < 7.5)
                Performance = AcademicPerformance.Good;
            else if (Average < 9)
                Performance = AcademicPerformance.Excellent;
            else
                Performance = AcademicPerformance.Outstanding;
        }
    }
}
