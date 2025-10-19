using System;

namespace UniversityApp
{
    public class University
    {
        // Приватні поля
        private string name;
        private string city;
        private int foundedYear;
        private int studentCount;
        private int facultyCount;
        private string rector;
        private double rating;

        // Конструктор без параметрів
        public University()
        {
            name = "Невідомо";
            city = "Невідомо";
            foundedYear = 0;
            studentCount = 0;
            facultyCount = 0;
            rector = "Невідомо";
            rating = 0.0;
        }

        // Властивості
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public int FoundedYear { get => foundedYear; set => foundedYear = value; }
        public int StudentCount { get => studentCount; set => studentCount = value; }
        public int FacultyCount { get => facultyCount; set => facultyCount = value; }
        public string Rector { get => rector; set => rector = value; }
        public double Rating { get => rating; set => rating = value; }

        // Методи
        public string GetUniversityAge()
        {
            if (foundedYear == 0) return "Рік заснування не вказано.";
            int age = DateTime.Now.Year - foundedYear;
            return $"Вік університету: {age} років.";
        }

        public double AverageStudentsPerFaculty()
        {
            if (facultyCount == 0) return 0;
            return (double)studentCount / facultyCount;
        }

        public string GetInfo()
        {
            return $"Назва: {name}\n" +
                   $"Місто: {city}\n" +
                   $"Рік заснування: {foundedYear}\n" +
                   $"Кількість студентів: {studentCount}\n" +
                   $"Кількість факультетів: {facultyCount}\n" +
                   $"Ректор: {rector}\n" +
                   $"Рейтинг: {rating:F1}";
        }
    }
}
