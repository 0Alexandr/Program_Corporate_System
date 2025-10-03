# Практика 2
## Задание 1 (15 вариант)
```cs
using System;

class Program
{
    // Вычисление двойного факториала (n!!)
    // Для чётных n: n!! = 2 * 4 * 6 * ... * n
    // Для нечётных n: n!! = 1 * 3 * 5 * ... * n
    static double DoubleFactorial(int n)
    {
        double result = 1;
        for (int i = n; i > 0; i -= 2)
        {
            result *= i;
        }
        return result;
    }

    // Вычисление n-го члена ряда для arcsin x
    // T_n = [(2n-1)!! / (2n)!!] * [x^(2n+1) / (2n+1)]
    static double GetNthTerm(double x, int n)
    {
        if (n == 0)
        {
            return x; // Первый член: x^1 / 1 = x
        }

        double numerator = DoubleFactorial(2 * n - 1);
        double denominator = DoubleFactorial(2 * n);
        double coefficient = numerator / denominator;
        double powerTerm = Math.Pow(x, 2 * n + 1);

        return coefficient * powerTerm / (2 * n + 1);
    }

    // Вычисление arcsin x с заданной точностью
    static double CalculateArcsin(double x, double epsilon)
    {
        double sum = 0;
        double term;
        int n = 0;

        do
        {
            term = GetNthTerm(x, n);
            sum += term;
            n++;
        } while (Math.Abs(term) > epsilon && n < 1000); // Защита от бесконечного цикла

        return sum;
    }

    static void Main()
    {
        Console.WriteLine("Введите x (|x| < 1):");
        double x = double.Parse(Console.ReadLine());

        if (Math.Abs(x) >= 1)
        {
            Console.WriteLine("Ошибка: |x| должен быть < 1");
            return;
        }

        Console.WriteLine("Введите точность e (e < 0.01):");
        double epsilon = double.Parse(Console.ReadLine());
        if (epsilon >= 0.01)
        {
            Console.WriteLine("Точность должна быть меньше 0.01");
            return;
        }

        double result = CalculateArcsin(x, epsilon);
        Console.WriteLine($"arcsin({x}) с точностью {epsilon}: {result}");
        Console.WriteLine($"Проверка через Math.Asin: {Math.Asin(x)}");

        Console.WriteLine("Введите номер члена ряда (n):");
        int n = int.Parse(Console.ReadLine());
        double nthTerm = GetNthTerm(x, n);
        Console.WriteLine($"Значение {n}-го члена ряда: {nthTerm}");
    }
}
```
Результат:

Введите x (|x| < 1):  
0,35  
Введите точность e (e < 0.01):  
0,005  
arcsin(0,35) с точностью 0,005: 0,35753974739583333  
Проверка через Math.Asin: 0,35757110364551026  
Введите номер члена ряда (n):  
8  
Значение 8-го члена ряда: 2,0502482451987115E-10  

## Задание 2
```cs
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите шестизначный номер билета: ");
        int ticket = int.Parse(Console.ReadLine());

        int digit1 = ticket / 100000;
        int digit2 = (ticket / 10000) % 10;
        int digit3 = (ticket / 1000) % 10;
        int digit4 = (ticket / 100) % 10;
        int digit5 = (ticket / 10) % 10;
        int digit6 = ticket % 10;

        int sumFirst = digit1 + digit2 + digit3;
        int sumLast = digit4 + digit5 + digit6;

        Console.WriteLine(sumFirst == sumLast);
    }
}
```
Результат:

1.Введите шестизначный номер билета: 123321  
True  
2.Введите шестизначный номер билета: 123456  
False  

## Задание 3
```cs
using System;

class Program
{
    static int FindNOD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static void Main()
    {
        Console.Write("Введите числитель M: ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("Введите знаменатель N: ");
        int n = int.Parse(Console.ReadLine());

        int nod = FindNOD(Math.Abs(m), Math.Abs(n));

        if (n < 0 && m > 0)
        {
            Console.WriteLine($"Результат: -{m / nod}/{Math.Abs(n) / nod}");
        }
        else if (m < 0 && n < 0)
        {
            Console.WriteLine($"Результат: {Math.Abs(m) / nod}/{Math.Abs(n) / nod}");
        }
        else
        {
            Console.WriteLine($"Результат: {m / nod}/{n / nod}");
        }
    }
}
```
Результат:

1.Введите числитель M: 9  
Введите знаменатель N: 6  
Результат: 3/2  
2.Введите числитель M: 25  
Введите знаменатель N: -40  
Результат: -5/8  

## Задание 4
```cs
using System;

class Program
{
    static void Main()
    {
        int low = 0, high = 63;
        int guess;

        Console.WriteLine("Загадайте число от 0 до 63. Отвечайте: 1 (да) или 0 (нет). Если число правильное введи Yes.");

        for (int i = 0; i < 6; i++)
        {
            guess = (low + high) / 2;
            Console.Write($"Ваше число больше {guess}? ");
            string answer = (Console.ReadLine());

            if (answer == "Yes")
            {
                low = guess;
                break;
            }
            else if (answer == "1")
            {
                low = guess + 1;
            }
            else if (answer == "0")
            {
                high = guess;
            }
            else
            {
                Console.WriteLine("Введен не верный формат, попробуйте исправить на 1, 2, Yes.");
            }
        }

        Console.WriteLine($"Ваше число: {low}");
    }
}
```
Результат:

1.Загадайте число от 0 до 63. Отвечайте: 1 (да) или 0 (нет). Если число правильное введи Yes.  
Ваше число больше 31? 1  
Ваше число больше 47? 1  
Ваше число больше 55? 1  
Ваше число больше 59? 0  
Ваше число больше 57? 1  
Ваше число больше 58? Yes  
Ваше число: 58  
2.Загадайте число от 0 до 63. Отвечайте: 1 (да) или 0 (нет). Если число правильное введи Yes.  
Ваше число больше 31? 1  
Ваше число больше 47? 0  
Ваше число больше 39? 1  
Ваше число больше 43? Yes  
Ваше число: 43  

## Задание 5
```cs
using System;

class CoffeeMachine
{
    private int water, milk;
    private int americanoCount, latteCount;
    private const int AMERICANO_WATER = 300, AMERICANO_PRICE = 150;
    private const int LATTE_WATER = 30, LATTE_MILK = 270, LATTE_PRICE = 170;

    public void Start()
    {
        Console.Write("Введите количество воды (мл): ");
        water = int.Parse(Console.ReadLine());
        Console.Write("Введите количество молока (мл): ");
        milk = int.Parse(Console.ReadLine());

        while (true)
        {
            if (!CanMakeAnyDrink()) break;
            ProcessOrder();
        }

        PrintReport();
    }

    private bool CanMakeAnyDrink()
    {
        return (water >= AMERICANO_WATER) || (water >= LATTE_WATER && milk >= LATTE_MILK);
    }

    private void ProcessOrder()
    {
        Console.WriteLine("Выберите напиток (1 — американо, 2 — латте):");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1: MakeAmericano(); break;
            case 2: MakeLatte(); break;
            default: Console.WriteLine("Неверный выбор"); break;
        }
    }

    private void MakeAmericano()
    {
        if (water >= AMERICANO_WATER)
        {
            water -= AMERICANO_WATER;
            americanoCount++;
            Console.WriteLine("Ваш напиток готов");
        }
        else
        {
            Console.WriteLine("Не хватает воды");
        }
    }

    private void MakeLatte()
    {
        if (water >= LATTE_WATER && milk >= LATTE_MILK)
        {
            water -= LATTE_WATER;
            milk -= LATTE_MILK;
            latteCount++;
            Console.WriteLine("Ваш напиток готов");
        }
        else
        {
            Console.WriteLine("Не хватает ингредиентов");
        }
    }

    private void PrintReport()
    {
        Console.WriteLine("*Отчёт*");
        Console.WriteLine($"Остаток воды: {water} мл");
        Console.WriteLine($"Остаток молока: {milk} мл");
        Console.WriteLine($"Американо: {americanoCount}");
        Console.WriteLine($"Латте: {latteCount}");
        Console.WriteLine($"Итого: {americanoCount * AMERICANO_PRICE + latteCount * LATTE_PRICE} рублей");
    }

    static void Main()
    {
        new CoffeeMachine().Start();
    }
}
```
Результат:

Введите количество воды (мл): 1000  
Введите количество молока (мл): 600  
Выберите напиток (1 - американо, 2 - латте):  
1  
Ваш напиток готов  
Выберите напиток (1 - американо, 2 - латте):  
2  
Ваш напиток готов  
Выберите напиток (1 - американо, 2 - латте):  
2  
Ваш напиток готов  
Выберите напиток (1 - американо, 2 - латте):  
1  
Ваш напиток готов  
Выберите напиток (1 - американо, 2 - латте):  
2  
Не хватает ингредиентов  
Выберите напиток (1 - американо, 2 - латте):  
1  
Ваш напиток готов  
*Отчёт*  
Остаток воды: 40 мл  
Остаток молока: 60 мл  
Американо: 3  
Латте: 2  
Итого: 790 рублей  

## Задание 6
```cs
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество бактерий: ");
        int bacteria = int.Parse(Console.ReadLine());
        Console.Write("Введите количество антибиотика: ");
        int antibiotic = int.Parse(Console.ReadLine());

        int hour = 0;
        int killPower = 10;

        while (bacteria > 0 && antibiotic > 0 && killPower > 0)
        {
            hour++;
            bacteria *= 2;
            bacteria -= killPower * antibiotic;
            if (bacteria < 0) bacteria = 0;

            Console.WriteLine($"После {hour} часа бактерий осталось {bacteria}");

            killPower--;
        }
    }
}
```
Результат:

Введите количество бактерий: 12  
Введите количество антибиотика: 1  
После 1 часа бактерий осталось 14  
После 2 часа бактерий осталось 19  
После 3 часа бактерий осталось 30  
После 4 часа бактерий осталось 53  
После 5 часа бактерий осталось 100  
После 6 часа бактерий осталось 195  
После 7 часа бактерий осталось 386  
После 8 часа бактерий осталось 769  
После 9 часа бактерий осталось 1536  
После 10 часа бактерий осталось 3071  

## Задание 7
```cs
using System;

class Program
{
    static bool CanPlace(int n, int a, int b, int h, int w, int d)
    {
        int width = a + 2 * d;
        int height = b + 2 * d;
        int count1 = (h / width) * (w / height);
        int count2 = (h / height) * (w / width);
        return Math.Max(count1, count2) >= n;
    }

    static void Main()
    {
        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введите b: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Введите w: ");
        int w = int.Parse(Console.ReadLine());
        Console.Write("Введите h: ");
        int h = int.Parse(Console.ReadLine());

        int d = 0;
        while (CanPlace(n, a, b, h, w, d + 1))
        {
            d++;
        }

        Console.WriteLine($"Ответ: d = {d}");
    }
}
```
Результат:

Введите n: 11  
Введите a: 2  
Введите b: 2  
Введите w: 21  
Введите h: 25  
Ответ: d = 2  
