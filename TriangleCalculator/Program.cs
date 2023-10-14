using System;
using System.Collections.Generic;
using System.IO;

namespace TriangleCalculator
{
    public enum TriangleType
    {
        Equilateral,  // Равносторонний треугольник
        Isosceles,  // Равнобедренный треугольник
        Scalene,  // Разносторонний треугольник
        NotTriangle,  // Не является треугольником
        InvalidInput  // Некорректный ввод
    }

    public class Triangle
    {
        public TriangleType Type { get; set; }  // Тип треугольника
        public List<(int, int)> Vertices { get; set; }  // Координаты вершин
    }

    public class Program
    {
        private const int FieldSize = 100;  // Размер поля
        private const string LogFilePath = "log.txt";  // Путь к файлу журнала

        public static void Main()
        {
            // Подсказка пользователю для ввода длины стороны A, B и C
            Console.WriteLine("Введите длину стороны A:");
            string sideAInput = Console.ReadLine();

            Console.WriteLine("Введите длину стороны B:");
            string sideBInput = Console.ReadLine();

            Console.WriteLine("Введите длину стороны C:");
            string sideCInput = Console.ReadLine();

            // Расчет треугольника на основе введенных пользователем данных
            Triangle triangle = CalculateTriangle(sideAInput, sideBInput, sideCInput);

            // Запись запроса пользователя и информации о треугольнике в журнал
            LogRequest(sideAInput, sideBInput, sideCInput, triangle);

            // Вывод типа треугольника и координат вершин
            Console.WriteLine($"Тип треугольника: {triangle.Type}");
            Console.WriteLine("Координаты вершин:");
            foreach (var vertex in triangle.Vertices)
            {
                Console.WriteLine($"({vertex.Item1}, {vertex.Item2})");
            }

            Console.ReadLine();
        }

        public static Triangle CalculateTriangle(string sideAInput, string sideBInput, string sideCInput)
        {
            // Создание нового объекта Triangle с начальными значениями
            Triangle triangle = new Triangle()
            {
                Type = TriangleType.InvalidInput,
                Vertices = new List<(int, int)>()
            };

            // Проверка корректности ввода для длин сторон A, B и C
            if (!float.TryParse(sideAInput, out float sideA) || !float.TryParse(sideBInput, out float sideB) || !float.TryParse(sideCInput, out float sideC))
            {
                // Если хотя бы одно из значений некорректно, устанавливаем тип треугольника InvalidInput
                triangle.Type = TriangleType.InvalidInput;
                triangle.Vertices.Add((-2, -2));
                triangle.Vertices.Add((-2, -2));
                triangle.Vertices.Add((-2, -2));
                return triangle;
            }

            // Проверка наличия сторон нулевой длины или отрицательных значений
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                // Если длина хотя бы одной из сторон равна нулю или отрицательна, устанавливаем тип треугольника NotTriangle
                triangle.Type = TriangleType.NotTriangle;
                triangle.Vertices.Add((-1, -1));
                triangle.Vertices.Add((-1, -1));
                triangle.Vertices.Add((-1, -1));
                return triangle;
            }

            // Проверка соблюдения неравенства треугольника по длинам сторон
            if (sideA + sideB <= sideC || sideB + sideC <= sideA || sideA + sideC <= sideB)
            {
                // Если неравенство треугольника нарушено, устанавливаем тип треугольника NotTriangle
                triangle.Type = TriangleType.NotTriangle;
                triangle.Vertices.Add((-1, -1));
                triangle.Vertices.Add((-1, -1));
                triangle.Vertices.Add((-1, -1));
                return triangle;
            }

            // Расчет// Расчет периметра треугольника
            float perimeter = sideA + sideB + sideC;

            // Расчет площади треугольника по формуле Герона
            float semiperimeter = perimeter / 2;
            float area = (float)Math.Sqrt(semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC));

            // Определение типа треугольника
            if (sideA == sideB && sideB == sideC)
            {
                triangle.Type = TriangleType.Equilateral;
            }
            else if (sideA == sideB || sideB == sideC || sideA == sideC)
            {
                triangle.Type = TriangleType.Isosceles;
            }
            else
            {
                triangle.Type = TriangleType.Scalene;
            }

            // Расчет координат вершин треугольника
            int centerX = FieldSize / 2;
            int centerY = FieldSize / 2;
            int radius = FieldSize / 4;

            triangle.Vertices.Add((centerX, centerY - radius));  // Вершина A
            triangle.Vertices.Add((centerX - (int)(radius * Math.Cos(Math.PI / 3)), centerY + (int)(radius * Math.Sin(Math.PI / 3))));  // Вершина B
            triangle.Vertices.Add((centerX + (int)(radius * Math.Cos(Math.PI / 3)), centerY + (int)(radius * Math.Sin(Math.PI / 3))));  // Вершина C

            return triangle;
        }

        private static void LogRequest(string sideA, string sideB, string sideC, Triangle triangle)
        {
            string logEntry = $"Запрос: A={sideA}, B={sideB}, C={sideC} | Тип треугольника: {triangle.Type}";

            try
            {
                // Запись в файл журнала
                using (StreamWriter writer = new StreamWriter(LogFilePath, true))
                {
                    writer.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                // В случае ошибки записи в файл, выводим сообщение об ошибке
                Console.WriteLine($"Ошибка записи в файл журнала: {ex.Message}");
            }
        }
    }
}


