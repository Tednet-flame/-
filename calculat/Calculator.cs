using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Простой калькулятор");
            Console.WriteLine("Доступные операции: + - * / % & | ^");
            Console.WriteLine("-------------------------------------");

            try 
            {
                // Ввод данных
                int firstNumber = GetNumber("Введите первое число: ");
                int secondNumber = GetNumber("Введите второе число: ");
                string operation = GetOperation();

                // Вычисление результата
                int result = Calculate(firstNumber, secondNumber, operation);
                
                // Вывод результата
                Console.WriteLine($"\nРезультат: {firstNumber} {operation} {secondNumber} = {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ошибка: деление на ноль!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введено некорректное число!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            
            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        // Метод для получения числа от пользователя
        static int GetNumber(string prompt)
        {
            Console.Write(prompt);
            return Convert.ToInt32(Console.ReadLine());
        }

        // Метод для получения операции
        static string GetOperation()
        {
            Console.Write("Введите операцию (+, -, *, /, %, &, |, ^): ");
            string operation = Console.ReadLine();
            
            // Проверка допустимости операции
            string[] validOperations = { "+", "-", "*", "/", "%", "&", "|", "^" };
            if (!validOperations.Contains(operation))
            {
                throw new ArgumentException("Некорректная операция!");
            }
            
            return operation;
        }

        // Метод для выполнения вычислений
        static int Calculate(int a, int b, string operation)
        {
            switch (operation)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/": return a / b;  // Может вызвать DivideByZeroException
                case "%": return a % b;   // Может вызвать DivideByZeroException
                case "&": return a & b;
                case "|": return a | b;
                case "^": return a ^ b;
                default: throw new ArgumentException("Неизвестная операция");
            }
        }
    }
}
