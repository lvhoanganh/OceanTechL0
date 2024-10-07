using StudentManagement.Entities;
using StudentManagement.Valid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudentManagement.Service
{
    public class StudentService
    {
        private List<Student> students = new List<Student>();
        private static int nextId = 1;
        private Validation validation = new Validation();

        public void AddStudent()
        {
            Student newStudent = new Student
            {
                Id = nextId++,
                Name = validation.GetName(),
                Birthday = validation.GetDate(),
                Address = validation.GetAddress(),
                Height = validation.GetHeight(),
                Weight = validation.GetWeight(),
                Code = validation.GetCode(),
                School = validation.GetSchool(),
                Average = validation.GetAverage(),
                StartDate = validation.GetStartDate() // Thêm trường StartDate
            };

            newStudent.UpdatePerformance(); // Cập nhật tình trạng học tập
            students.Add(newStudent);
            Console.WriteLine($"Added Student: {newStudent}");
        }

        public void ReadStudent()
        {
            if (!students.Any())
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public void FindStudent()
        {
            Console.Write("Enter student ID to find: ");
            int id = validation.GetInt();
            var student = students.Find(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine("No student found with this ID.");
            }
            else
            {
                Console.WriteLine(student);
            }
        }

        public void UpdateStudent()
        {
            Console.Write("Enter student ID to update: ");
            int id = validation.GetInt();
            var student = students.Find(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine("No student found with this ID.");
                return;
            }

            Console.WriteLine("Updating student information...");
            string newName = validation.GetName();
            DateOnly newBirthday = validation.GetDate();
            string newAddress = validation.GetAddress();
            double newHeight = validation.GetHeight();
            double newWeight = validation.GetWeight();
            string newCode = validation.GetCode();
            string newSchool = validation.GetSchool();
            double newAverage = validation.GetAverage();
            DateOnly newStartDate = validation.GetStartDate(); // Cập nhật trường StartDate

            // Cập nhật thông tin sinh viên
            student.Name = newName;
            student.Birthday = newBirthday;
            student.Address = newAddress;
            student.Height = newHeight;
            student.Weight = newWeight;
            student.Code = newCode;
            student.School = newSchool;
            student.Average = newAverage;
            student.StartDate = newStartDate; // Cập nhật trường StartDate
            student.UpdatePerformance(); // Cập nhật tình trạng học tập

            Console.WriteLine($"Updated Student: {student}");
        }

        public void RemoveStudent()
        {
            Console.Write("Enter student ID to delete: ");
            int id = validation.GetInt();
            var student = students.Find(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine("No student found with this ID.");
                return;
            }

            students.Remove(student);
            Console.WriteLine($"Deleted Student with ID: {id}");
        }

        public void DisplayPerformance()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Student: {student.Name}, Performance: {student.Performance}");
            }
        }

        public void DisplayAverageScorePercentages()
        {
            if (!students.Any())
            {
                Console.WriteLine("No students to calculate average.");
                return;
            }

            double average = students.Average(s => s.Average);
            Console.WriteLine($"Average GPA of all students: {average}");
        }

        public void PrintStudentByPerformance()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Student: {student.Name}, Performance: {student.Performance}");
            }
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.Id},{student.Name},{student.Birthday},{student.Address},{student.Height},{student.Weight},{student.Code},{student.School},{student.Average},{student.StartDate}"); // Thêm StartDate vào file
                }
            }
            Console.WriteLine("Students have been saved to the file.");
        }

        public void LoadFromFile(string filePath)
        {
            students.Clear();
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found!");
                return;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(',');

                    var student = new Student
                    {
                        Id = int.Parse(data[0]),
                        Name = data[1],
                        Birthday = DateOnly.Parse(data[2]),
                        Address = data[3],
                        Height = double.Parse(data[4]),
                        Weight = double.Parse(data[5]),
                        Code = data[6],
                        School = data[7],
                        Average = double.Parse(data[8]),
                        StartDate = DateOnly.Parse(data[9]) // Đọc trường StartDate từ file
                    };

                    student.UpdatePerformance(); // Cập nhật tình trạng học tập khi tải sinh viên từ file
                    students.Add(student);
                }
            }
            Console.WriteLine("Students have been loaded from the file.");
        }
    }
}
