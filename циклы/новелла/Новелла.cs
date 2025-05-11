using System;
using System.Collections.Generic;

namespace AnimeElectricianAdventure
{
    class Program
    {
        // Обновленный класс главного героя
        class ElectricianWeeb
        {
            public string Name { get; } = "Кайто";
            public int Wires { get; set; } = 15;         // Медные жилы
            public int AnimePower { get; set; } = 5;     // Уровень отаку
            public List<string> AnimeQuotes { get; } = new List<string>() 
            {
                "Электро - это жизнь!",
                "Банкай: Молниевый монтажник!",
                "Неспроста я пересмотрел все сезоны Toaru!"
            };
            public bool HasVoltageGloves { get; set; } = true;
        }

        static ElectricianWeeb player = new ElectricianWeeb();
        static Random rnd = new Random();

        static void Main()
        {
            Console.Title = "Электромонтажер-анимешник: Пробой реальности";
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            ShowElectricIntro();
            PowerStationEvent();
        }

        static void ShowElectricIntro()
        {
            Console.Clear();
            Console.WriteLine("☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆");
            Console.WriteLine("  電撃の冒険が始まる！ (Начинается электроприключение!)");
            Console.WriteLine("☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n");
            
            Console.WriteLine($"Вы - {player.Name}, электромонтажник 5 разряда и хардкорный отаку.");
            Console.WriteLine("Во время аварии на подстанции вы получили странные способности...\n");
            
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void PowerStationEvent()
        {
            Console.Clear();
            Console.WriteLine("▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂");
            Console.WriteLine("  ПОДСТАНЦИЯ №7. АВАРИЙНАЯ СИТУАЦИЯ");
            Console.WriteLine("▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂▂\n");
            
            Console.WriteLine("Вы видите:");
            Console.WriteLine("- Искрящийся трансформатор");
            Console.WriteLine("- Странные руны на электрощите");
            Console.WriteLine("- Своё отражение с аниме-глазами\n");
            
            Console.WriteLine("1. Попытаться починить стандартным методом (-3 жилы)");
            Console.WriteLine("2. Произнести аниме-цитату (шанс 50/50)");
            Console.WriteLine("3. Прикоснуться к рунам голыми руками");
            Console.WriteLine("4. Сбежать с криком 'Yamete kudasai!'");

            switch (GetChoice(1, 4))
            {
                case 1:
                    StandardRepair();
                    break;
                case 2:
                    AnimeQuoteAttempt();
                    break;
                case 3:
                    TouchRunes();
                    break;
                case 4:
                    EscapeEnding();
                    break;
            }
        }

        static void StandardRepair()
        {
            player.Wires -= 3;
            Console.WriteLine("\nВы починили оборудование, но...");
            Console.WriteLine("Обычные методы больше не работают как раньше!");
            
            if (player.Wires <= 0)
            {
                Console.WriteLine("\nУ вас закончились материалы!");
                GameOver();
                return;
            }

            Console.WriteLine("\n1. Идти в аниме-магазин за артефактами");
            Console.WriteLine("2. Проверить другие подстанции");

            if (GetChoice(1, 2) == 1)
                VisitOtakuShop();
            else
                CheckOtherStations();
        }

        static void VisitOtakuShop()
        {
            Console.Clear();
            Console.WriteLine("✧･ﾟ: *✧･ﾟ:*  АНИМЕ-МАГАЗИН 'OTAKU FLOW' *:･ﾟ✧*:･ﾟ✧");
            Console.WriteLine("На полках:\n");
            
            Console.WriteLine("1. Изолента с рунами (+5 к силе, стоит 3 жилы)");
            Console.WriteLine("2. Фигурка Мисаки из 'Toaru' (+2 AnimePower)");
            Console.WriteLine("3. Манга 'Электромагия для чайников'");
            Console.WriteLine("4. Уйти без покупок");

            int choice = GetChoice(1, 4);

            switch (choice)
            {
                case 1 when player.Wires >= 3:
                    player.Wires -= 3;
                    player.AnimePower += 5;
                    Console.WriteLine("\nТеперь вы чувствуете магию в проводах!");
                    break;
                case 2:
                    player.AnimePower += 2;
                    Console.WriteLine("\nФигурка излучает странную энергию...");
                    break;
                case 3:
                    Console.WriteLine("\nВы узнали секрет: Ctrl+Alt+Рем-тян!");
                    player.AnimeQuotes.Add("Я прочитал мангу до конца!");
                    break;
            }

            UniversityRooftopEvent();
        }

        static void UniversityRooftopEvent()
        {
            Console.Clear();
            Console.WriteLine("☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁");
            Console.WriteLine("  КРЫША ТОКИЙСКОГО УНИВЕРСИТЕТА");
            Console.WriteLine("☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁☁\n");
            
            Console.WriteLine("Перед финальным выбором:");
            Console.WriteLine("- Город без электричества");
            Console.WriteLine("- Порталы в другие миры");
            Console.WriteLine("- Ваши новые способности\n");
            
            Console.WriteLine("1. Восстановить энергосистему (требует 10 Wires)");
            Console.WriteLine($"2. Использовать Bankai Mode (требует 15 AnimePower)");
            Console.WriteLine("3. Найти девушку-киборга из видений");

            int choice = GetChoice(1, 3);

            if (choice == 1 && player.Wires >= 10)
            {
                player.Wires -= 10;
                LegendaryElectricianEnding();
            }
            else if (choice == 2 && player.AnimePower >= 15)
            {
                TrueOtakuEnding();
            }
            else
            {
                Console.WriteLine("\nНе хватает ресурсов! Но...");
                CyberGhostEnding();
            }
        }

        static void LegendaryElectricianEnding()
        {
            Console.Clear();
            Console.WriteLine("≪✦≫≪✦≫≪✦≫ ЛЕГЕНДАРНЫЙ ЭЛЕКТРИК ≪✦≫≪✦≫≪✦≫");
            Console.WriteLine("Вы стабилизировали энергосистему города!");
            Console.WriteLine("Теперь вас называют 'Богом проводов'");
            ExitGame();
        }

        static void TrueOtakuEnding()
        {
            Console.Clear();
            Console.WriteLine("(◕‿◕✿) ИСТИННЫЙ ОТАКУ (◕‿◕✿)");
            Console.WriteLine("Bankai Mode активирован! Портал открыт!");
            Console.WriteLine("Вы перенеслись в мир аниме навсегда!");
            ExitGame();
        }

        static int GetChoice(int min, int max)
        {
            while (true)
            {
                Console.Write($"\n[{player.Wires}🔌|{player.AnimePower}💬] Выбор: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine($"Нужно число от {min} до {max}!");
            }
        }

        // Другие методы концовок...
    }
}
