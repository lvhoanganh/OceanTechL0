using StudentManagement.Service;
using StudentManagement.Valid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();
            string filePath = @"C:\Users\lvha0\OneDrive\Máy tính\students.txt"; // Đường dẫn đến file trên Desktop

            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Read Students");
                Console.WriteLine("3. Find Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Remove Student");
                Console.WriteLine("6. Display Performance");
                Console.WriteLine("7. Display Average Score Percentages");
                Console.WriteLine("8. Save to File");
                Console.WriteLine("9. Load from File");
                Console.WriteLine("0. Exit");


                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        studentService.AddStudent();
                        break;
                    case 2:
                        studentService.ReadStudent();
                        break;
                    case 3:
                        studentService.FindStudent();
                        break;
                    case 4:
                        studentService.UpdateStudent();
                        break;
                    case 5:
                        studentService.RemoveStudent();
                        break;
                    case 6:
                        studentService.DisplayPerformance();
                        break;
                    case 7:
                        studentService.DisplayAverageScorePercentages();
                        break;
                    case 8:
                        studentService.SaveToFile(filePath);
                        break;
                    case 9:
                        studentService.LoadFromFile(filePath);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
