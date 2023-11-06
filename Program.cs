using System;

class Program
{
    // Квадратное уравнение
    private class Квадратное_уравнение
    {
        private double a;
        private double b;
        private double c;
        private double дискриминант;
        private double корень1;
        private double корень2;

        public Квадратное_уравнение(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            CalculateDiscriminant();
            CalculateRoots();
        }

        private void CalculateDiscriminant()
        {
            дискриминант = b * b - 4 * a * c;
        }

        private void CalculateRoots()
        {
            if (дискриминант > 0)
            {
                корень1 = (-b + Math.Sqrt(дискриминант)) / (2 * a);
                корень2 = (-b - Math.Sqrt(дискриминант)) / (2 * a);
            }
            else if (дискриминант == 0)
            {
                корень1 = корень2 = -b / (2 * a);
            }
            else
            {
                корень1 = корень2 = double.NaN;
            }
        }

        public void РешитьУравнение()
        {
            Console.WriteLine("Корни уравнения:");
            Console.WriteLine($"Корень 1: {корень1}");
            Console.WriteLine($"Корень 2: {корень2}");
        }
    }

    // Примерное число
    private class Примерное_число
    {
        private int п = 0;

        public bool SetNumber(int number)
        {
            if (number == п + 1)
            {
                п = number;
                return true;
            }
            else
            {
                п = 0;
                return false;
            }
        }

        public int ПолучитьОжидаемоеЧисло()
        {
            return п + 1;
        }
    }

    // Шифр Цезаря
    private class Шифр_Цезаря
    {
        private int ключ;

        public Шифр_Цезаря(int ключ)
        {
            this.ключ = ключ;
        }

        public string Зашифровать(string текст)
        {
            char[] символы = текст.ToCharArray();

            for (int i = 0; i < символы.Length; i++)
            {
                if (Char.IsLetter(символы[i]))
                {
                    char базовыйСимвол = Char.IsUpper(символы[i]) ? 'A' : 'a';
                    символы[i] = (char)(((символы[i] + ключ - базовыйСимвол) % 26) + базовыйСимвол);
                }
            }

            return new string(символы);
        }

        public string Расшифровать(string зашифрованныйТекст)
        {
            ключ = -ключ;
            return Зашифровать(зашифрованныйТекст);
        }
    }

    public static void Main()
    {
        Console.WriteLine("Выберите программу: (1) - Решение квадратного уравнения, (2) - Примерное число, (3) - Шифр Цезаря:");
        int выбор = int.Parse(Console.ReadLine());

        switch (выбор)
        {
            case 1:
                Console.WriteLine("Введите коэффициенты a, b и c для квадратного уравнения:");
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double c = double.Parse(Console.ReadLine());

                Квадратное_уравнение уравнение = new Квадратное_уравнение(a, b, c);
                уравнение.РешитьУравнение();
                break;
            case 2:
                Примерное_число примерное_число = new Примерное_число();

                while (true)
                {
                    Console.WriteLine($"Введите число {примерное_число.ПолучитьОжидаемоеЧисло()}:");
                    int введенное_число = int.Parse(Console.ReadLine());

                    if (примерное_число.SetNumber(введенное_число))
                    {
                        Console.WriteLine("Верно! Можете ввести следующее число.");
                    }
                    else
                    {
                        Console.WriteLine("Неверно. Начните заново.");
                    }
                }
            case 3:
                Console.WriteLine("Введите текст для шифрования:");
                string исходныйТекст = Console.ReadLine();

                Console.WriteLine("Введите ключ для шифра Цезаря (целое число):");
                int ключ = int.Parse(Console.ReadLine());

                Шифр_Цезаря шифр = new Шифр_Цезаря(ключ);

                string зашифрованныйТекст = шифр.Зашифровать(исходныйТекст);
                Console.WriteLine($"Зашифрованный текст: {зашифрованныйТекст}");

                string расшифрованныйТекст = шифр.Расшифровать(зашифрованныйТекст);
                Console.WriteLine($"Расшифрованный текст: {расшифрованныйТекст}");
                break;
            default:
                Console.WriteLine("Неверный выбор программы.");
                break;
        }
    }
}

