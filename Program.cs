class Calculator
{
    static double memory = 0;

    static void Main()
    {
        double result = 0;
        bool exit = false;

        Console.WriteLine("Калькулятор (+, -, *, /, %, 1/x, x^2, sqrt, M+, M-, MR, exit)");

        while (!exit)
        {
            Console.Write("\nВведите выражение или команду: ");
            string input = Console.ReadLine();

            if (input == "exit")
            {
                exit = true;
            }
            else if (input == "MR")
            {
                Console.WriteLine($"MR = {memory}");
            }
            else if (input == "M+")
            {
                memory += result;
                Console.WriteLine($"Память: {memory}");
            }
            else if (input == "M-")
            {
                memory -= result;
                Console.WriteLine($"Память: {memory}");
            }

            else
            {
                string[] parts = input.Split(' ');

                try
                {
                    if (parts.Length == 2) // унарные операции (1/x, x^2, sqrt)
                    {
                        double x = Convert.ToDouble(parts[1]);

                        switch (parts[0])
                        {
                            case "1/x":
                                if (x == 0)
                                {
                                    Console.WriteLine("Ошибка: деление на 0!");
                                }
                                else
                                {
                                    result = 1 / x;
                                    Console.WriteLine($"Результат = {result}");
                                }
                                break;

                            case "x^2":
                                result = Math.Pow(x, 2);
                                Console.WriteLine($"Результат = {result}");
                                break;

                            case "sqrt":
                                if (x < 0)
                                {
                                    Console.WriteLine("Ошибка: отрицательное число под корнем!");
                                }
                                else
                                {
                                    result = Math.Sqrt(x);
                                    Console.WriteLine($"Результат = {result}");
                                }
                                break;

                            default:
                                Console.WriteLine("Неизвестная операция.");
                                break;
                        }
                    }

                    else if (parts.Length == 3) // бинарные операции
                    {
                        double a = Convert.ToDouble(parts[0]);
                        string op = parts[1];
                        double b = Convert.ToDouble(parts[2]);

                        switch (op)
                        {
                            case "+":
                                result = a + b;
                                break;

                            case "-":
                                result = a - b;
                                break;

                            case "*":
                                result = a * b;
                                break;

                            case "/":
                                if (b == 0)
                                {
                                    Console.WriteLine("Ошибка: деление на 0!");
                                }
                                else
                                {
                                    result = a / b;
                                }
                                break;

                            case "%":
                                if (b == 0)
                                {
                                    Console.WriteLine("Ошибка: деление на 0!");
                                }
                                else
                                {
                                    result = a % b;
                                }
                                break;
                            default:
                                Console.WriteLine("Неизвестная операция.");
                                break;
                        }

                        Console.WriteLine($"Результат = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Неверный ввод.");
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка: некорректные данные.");
                }
            }
        }
    }
}
