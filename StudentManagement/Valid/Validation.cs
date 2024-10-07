using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Valid
{
    public class Validation
    {
        public const int MaxLength = 299;
        public const int MinLength = 1;
        public const int MaxNameLength = 99;
        public static readonly DateOnly MinDate = new DateOnly(1900, 1, 1);
        public static readonly DateOnly MaxDate = DateOnly.FromDateTime(DateTime.Now);
        public const double MaxWeight = 1000.0;
        public const double MinWeight = 5.0;
        public const double MaxHeight = 300.0;
        public const double MinHeight = 50.0;
        public const int MaxCode = 10;
        public const int MaxSchool = 199;
        public const double MaxAverage = 10.0;
        public const double MinAverage = 0.0;

        public enum ValidationMessage
        {
            Valid,
            NameEmpty,
            NameTooShort,
            NameTooLong,
            NameInvalid,
            DateEmpty,
            DateInvalidFormat,
            DateOutOfRange,
            AddressTooLong,
            HeightInvalidInput,
            HeightOutOfRange,
            WeightInvalidInput,
            WeightOutOfRange,
            CodeEmpty,
            CodeInvalidLength,
            SchoolEmpty,
            SchoolInvalidLength,
            YearEmpty,
            YearInvalidFormat,
            YearOutOfRange,
            IdInvalidInput,
            AverageInvalidInput,
            AverageOutOfRange
        }

        // Phương thức kiểm tra tên
        public ValidationMessage CheckName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return ValidationMessage.NameEmpty;

            if (name.Length < MinLength)
                return ValidationMessage.NameTooShort;

            if (name.Length > MaxNameLength)
                return ValidationMessage.NameTooLong;

            // Kiểm tra xem tên chỉ chứa chữ cái, dấu cách và các ký tự có dấu
            if (!name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || IsVietnameseCharacter(c)))
                return ValidationMessage.NameInvalid;

            return ValidationMessage.Valid;
        }

        // Phương thức kiểm tra ký tự có phải là ký tự tiếng Việt hay không
        private bool IsVietnameseCharacter(char c)
        {
            // Danh sách các ký tự có dấu tiếng Việt (có thể thêm các ký tự khác nếu cần)
            char[] vietnameseCharacters = { 'á', 'à', 'ả', 'ã', 'ạ', 'ắ', 'ằ', 'ẳ', 'ẵ', 'ặ',
                                      'é', 'è', 'ẻ', 'ẽ', 'ẹ', 'ế', 'ề', 'ể', 'ễ', 'ệ',
                                      'í', 'ì', 'ỉ', 'ĩ', 'ị',
                                      'ó', 'ò', 'ỏ', 'õ', 'ọ', 'ố', 'ồ', 'ổ', 'ỗ', 'ộ',
                                      'ớ', 'ờ', 'ở', 'ỡ', 'ợ',
                                      'ú', 'ù', 'ủ', 'ũ', 'ụ', 'ứ', 'ừ', 'ử', 'ữ', 'ự',
                                      'ý', 'ỳ', 'ỷ', 'ỹ', 'ỵ' };
            return vietnameseCharacters.Contains(c);
        }


        public string GetName()
        {
            string? name;
            ValidationMessage validation;

            do
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();
                validation = CheckName(name);
                if (validation != ValidationMessage.Valid)
                    Console.WriteLine(validation.ToString());
            } while (validation != ValidationMessage.Valid);

            return name ?? string.Empty;
        }

        // Phương thức kiểm tra ngày
        public ValidationMessage CheckDate(string? inputDate, out DateOnly date)
        {
            string[] formats = { "MM/dd/yyyy", "dd/MM/yyyy" };
            date = default;

            if (string.IsNullOrWhiteSpace(inputDate))
                return ValidationMessage.DateEmpty;

            if (!DateOnly.TryParseExact(inputDate, formats, out date))
                return ValidationMessage.DateInvalidFormat;

            if (date < MinDate || date > MaxDate)
                return ValidationMessage.DateOutOfRange;

            return ValidationMessage.Valid;
        }

        public DateOnly GetDate()
        {
            DateOnly date;
            ValidationMessage validation;
            string? inputDate;

            do
            {
                Console.Write("Enter your birthdate (dd/MM/yyyy) or (MM/dd/yyyy): ");
                inputDate = Console.ReadLine();
                validation = CheckDate(inputDate, out date);
                if (validation != ValidationMessage.Valid)
                    Console.WriteLine(validation.ToString());
            } while (validation != ValidationMessage.Valid);

            return date;
        }

        // Phương thức kiểm tra địa chỉ
        public ValidationMessage CheckAddress(string? address)
        {
            if (address.Length > MaxLength)
                return ValidationMessage.AddressTooLong;

            return ValidationMessage.Valid;
        }

        public string GetAddress()
        {
            string? address;
            ValidationMessage validation;

            do
            {
                Console.Write("Enter the Address: ");
                address = Console.ReadLine();
                validation = CheckAddress(address);
                if (validation != ValidationMessage.Valid)
                    Console.WriteLine(validation.ToString());
            } while (validation != ValidationMessage.Valid);

            return address ?? string.Empty;
        }

        // Phương thức kiểm tra chiều cao
        public ValidationMessage CheckHeight(string? inputLength, out double length)
        {
            bool isValid = double.TryParse(inputLength, out length);

            if (!isValid)
                return ValidationMessage.HeightInvalidInput;

            if (length < MinHeight || length > MaxHeight)
                return ValidationMessage.HeightOutOfRange;

            return ValidationMessage.Valid;
        }

        public double GetHeight()
        {
            double height;
            ValidationMessage validation;
            string? inputLength;

            do
            {
                Console.Write("Enter your Height: ");
                inputLength = Console.ReadLine();
                validation = CheckHeight(inputLength, out height);
                if (validation != ValidationMessage.Valid)
                    Console.WriteLine(validation.ToString());
            } while (validation != ValidationMessage.Valid);

            return height;
        }

        // Phương thức kiểm tra cân nặng
        public ValidationMessage CheckWeight(string? inputLength, out double weight)
        {
            bool isValid = double.TryParse(inputLength, out weight);

            if (!isValid)
                return ValidationMessage.WeightInvalidInput;

            if (weight < MinWeight || weight > MaxWeight)
                return ValidationMessage.WeightOutOfRange;

            return ValidationMessage.Valid;
        }

        public double GetWeight()
        {
            double weight;
            ValidationMessage validation;
            string? inputLength;

            do
            {
                Console.Write("Enter your Weight: ");
                inputLength = Console.ReadLine();
                validation = CheckWeight(inputLength, out weight);
                if (validation != ValidationMessage.Valid)
                    Console.WriteLine(validation.ToString());
            } while (validation != ValidationMessage.Valid);

            return weight;
        }

        // Phương thức kiểm tra mã
        public ValidationMessage CheckCode(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return ValidationMessage.CodeEmpty;
            if (code.Length < MinLength || code.Length > MaxCode)
                return ValidationMessage.CodeInvalidLength;

            return ValidationMessage.Valid;
        }

        public string GetCode()
        {
            string? code;
            ValidationMessage validation;

            do
            {
                Console.Write("Enter your Code: ");
                code = Console.ReadLine();
                validation = CheckCode(code);
                if (validation != ValidationMessage.Valid)
                    Console.WriteLine(validation.ToString());
            } while (validation != ValidationMessage.Valid);

            return code ?? string.Empty;
        }

        // Phương thức kiểm tra trường học
        public ValidationMessage CheckSchool(string? school)
        {
            if (string.IsNullOrWhiteSpace(school))
                return ValidationMessage.SchoolEmpty;
            if (school.Length < MinLength || school.Length > MaxSchool)
                return ValidationMessage.SchoolInvalidLength;

            return ValidationMessage.Valid;
        }

        public string GetSchool()
        {
            string? school;
            ValidationMessage validation;

            do
            {
                Console.Write("Enter your School: ");
                school = Console.ReadLine();
                validation = CheckSchool(school);
                if (validation != ValidationMessage.Valid)
                    Console.WriteLine(validation.ToString());
            } while (validation != ValidationMessage.Valid);

            return school ?? string.Empty;
        }

        // Phương thức kiểm tra năm
        public ValidationMessage CheckYear(string? inputYear, out int year)
        {
            year = 0;

            if (string.IsNullOrWhiteSpace(inputYear))
                return ValidationMessage.YearEmpty;

            if (!int.TryParse(inputYear, out year))
                return ValidationMessage.YearInvalidFormat;

            if (inputYear.Length != 4 || year < 1900 || year > MaxDate.Year)
                return ValidationMessage.YearOutOfRange;

            return ValidationMessage.Valid;
        }

        public int GetYearDate()
        {
            string? inputYear;
            ValidationMessage validation;
            int year;

            do
            {
                Console.Write("Enter your school years: ");
                inputYear = Console.ReadLine();
                validation = CheckYear(inputYear, out year);
                if (validation != ValidationMessage.Valid)
                    Console.WriteLine(validation.ToString());
            } while (validation != ValidationMessage.Valid);

            return year;
        }

        // Phương thức kiểm tra ID
        public ValidationMessage CheckId(string? inputId, out int id)
        {
            bool valid = int.TryParse(inputId, out id);
            if (!valid)
                return ValidationMessage.IdInvalidInput;

            if (id < MinLength)
                return ValidationMessage.YearOutOfRange; // Thay thế thông điệp nếu cần

            return ValidationMessage.Valid;
        }

        public int GetInt()
        {
            int id;
            string? inputId;
            ValidationMessage validation;

            do
            {
                Console.Write("Enter your ID: ");
                inputId = Console.ReadLine();
                validation = CheckId(inputId, out id);
                if (validation != ValidationMessage.Valid)
                    Console.WriteLine(validation.ToString());
            } while (validation != ValidationMessage.Valid);

            return id;
        }

        // Phương thức kiểm tra điểm trung bình
        public ValidationMessage CheckAverage(string? inputAverage, out double average)
        {
            bool valid = double.TryParse(inputAverage, out average);
            if (!valid)
                return ValidationMessage.AverageInvalidInput;

            if (average < MinAverage || average > MaxAverage)
                return ValidationMessage.AverageOutOfRange;

            return ValidationMessage.Valid;
        }

        public double GetAverage()
        {
            double average;
            ValidationMessage validation;
            string? inputAverage;

            do
            {
                Console.Write("Enter your Average: ");
                inputAverage = Console.ReadLine();
                validation = CheckAverage(inputAverage, out average);
                if (validation != ValidationMessage.Valid)
                    Console.WriteLine(validation.ToString());
            } while (validation != ValidationMessage.Valid);

            return average;
        }
        public ValidationMessage CheckStartDate(string? inputDate, out DateOnly date)
        {
            string[] formats = { "MM/dd/yyyy", "dd/MM/yyyy" };
            date = default;

            if (string.IsNullOrWhiteSpace(inputDate))
                return ValidationMessage.DateEmpty;

            if (!DateOnly.TryParseExact(inputDate, formats, out date))
                return ValidationMessage.DateInvalidFormat;

            if (date < MinDate || date > MaxDate)
                return ValidationMessage.DateOutOfRange;

            return ValidationMessage.Valid;
        }

        public DateOnly GetStartDate()
        {
            DateOnly date;
            ValidationMessage validation;
            string? inputDate;

            do
            {
                Console.Write("Enter your Start Date (dd/MM/yyyy) or (MM/dd/yyyy): ");
                inputDate = Console.ReadLine();
                validation = CheckStartDate(inputDate, out date);
                if (validation != ValidationMessage.Valid)
                    Console.WriteLine(validation.ToString());
            } while (validation != ValidationMessage.Valid);

            return date;
        }

    }
}
