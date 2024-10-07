using System;

namespace StudentManagement.Entities
{
    internal class Person
    {
        // Thuộc tính non-nullable với giá trị khởi tạo mặc định
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly Birthday { get; set; }
        public string Address { get; set; } = string.Empty;
        public double Height { get; set; }
        public double Weight { get; set; }

        // Constructor mặc định
        public Person() { }

        // Constructor với tham số
        public Person(int id, string name, DateOnly birthday, string address, double height, double weight)
        {
            Id = id;
            Name = name;
            Birthday = birthday;
            Address = address;
            Height = height;
            Weight = weight;
        }

        // Ghi đè phương thức ToString
        public override string ToString() => $"Person: {Id} - {Name} - {Birthday} - {Address} - {Height} - {Weight}";
    }
}
