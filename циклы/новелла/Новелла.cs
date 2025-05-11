using System;
using System.Collections.Generic;

namespace AnimeElectricianNovel
{
    class Program
    {
        // Класс главного героя
        class Protagonist
        {
            public string Name { get; } = "Каито Ито";
            public int Wires { get; set; } = 15;
            public int AnimePower { get; set; } = 5;
            public List<string> KnownQuotes { get; } = new List<string>()
            {
                "Электричество - это жизнь!",
                "Банкай: Молниевый монтажник!",
                "Я видел это в аниме!"
            };
            public bool HasSpecialGloves { get; set; } = true;
            public int Reputation { get; set; } = 0;
        }

        static Protagonist hero = new Protagonist();
        static Random random = new Random();
        static bool hasArtifact = false;

        static void Main()
        {
            SetupConsole();
            ShowIntroduction();
            Chapter1_PowerStation();
        }

        static void SetupConsole()
        {
            Console.Title = "Электромонтажер-анимешник: Пробой реальности";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.CursorVisible = false;
        }

        static void ShowIntroduction()
        {
            Console.Clear();
            PrintHeader("電撃の冒険が始まる！");
            Console.WriteLine("Вы - Каито Ито, 28-летний электромонтажник и заядлый отаку.");
            Console.WriteLine("В обычный рабочий день на подстанции №7 происходит нечто странное...\n");
            WaitForInput();
        }

        static void Chapter1_PowerStation()
        {
            Console.Clear();
            PrintHeader("ПОДСТАНЦИЯ №7. УТРО");

            Console.WriteLine("Перед вами:");
            Console.WriteLine("- Искрящийся трансформатор");
            Console.WriteLine("- Странные символы на щитке");
            Console.WriteLine("- Шепот из распределительной коробки\n");

            Console.WriteLine("1. Провести стандартный ремонт (-3 жилы)");
            Console.WriteLine("2. Произнести аниме-цитату");
            Console.WriteLine("3. Исследовать странные символы");
            Console.WriteLine("4. Проигнорировать и продолжить работу");

            switch (GetChoice(1, 4))
            {
                case 1:
                    StandardRepair();
                    break;
                case 2:
                    UseAnimeQuote();
                    break;
                case 3:
                    InvestigateSymbols();
                    break;
                case 4:
                    IgnoreAnomaly();
                    break;
            }
        }

        static void StandardRepair()
        {
            hero.Wires -= 3;
            Console.WriteLine("\nВы успешно починили оборудование.");
            
            if (random.Next(100) < 30)
            {
                Console.WriteLine("Но что-то пошло не так...");
                hero.AnimePower += 2;
                Console.WriteLine("Ваша аниме-сила увеличилась!");
            }

            CheckResources();
            Chapter2_City();
        }

        static void UseAnimeQuote()
        {
            if (hero.KnownQuotes.Count == 0)
            {
                Console.WriteLine("\nУ вас нет известных цитат!");
                Chapter1_PowerStation();
                return;
            }

            string quote = hero.KnownQuotes[random.Next(hero.KnownQuotes.Count)];
            Console.WriteLine($"\nВы кричите: \"{quote}\"");

            if (random.Next(100) < 50 + hero.AnimePower)
            {
                Console.WriteLine("Это сработало! Оборудование починено!");
                hero.Reputation += 1;
            }
            else
            {
                Console.WriteLine("Ничего не произошло...");
                hero.Wires -= 2;
            }

            CheckResources();
            Chapter2_City();
        }

        static void CheckResources()
        {
            if (hero.Wires <= 0)
            {
                Console.WriteLine("\nУ вас закончились материалы!");
                GameOver();
            }
        }

        static void Chapter2_City()
        {
            // Продолжение сюжета...
        }

        static int GetChoice(int min, int max)
        {
            while (true)
            {
                Console.Write($"\n[{hero.Wires}🔌|{hero.AnimePower}✨] Выбор: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                    return choice;
                
                Console.WriteLine($"Введите число от {min} до {max}!");
            }
        }

        static void PrintHeader(string text)
        {
            Console.WriteLine(new string('═', text.Length + 4));
            Console.WriteLine($"  {text}");
            Console.WriteLine(new string('═', text.Length + 4) + "\n");
        }

        static void WaitForInput()
        {
            Console.WriteLine("\nНажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
