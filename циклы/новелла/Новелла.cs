using System;

namespace AnimeMontagerAdventure
{
    class Program
    {
        // Характеристики персонажа
        class Hero
        {
            public string Name { get; } = "Сатоши";
            public int Screws { get; set; } = 10; // Крепежные элементы
            public int AnimePower { get; set; } = 3; // Уровень аниме-силы
            public bool HasToolbelt { get; set; } = true;
            public bool KnowsSecretTechnique { get; set; } = false;
        }

        static Hero player = new Hero();
        static Random rnd = new Random();

        static void Main()
        {
            Console.Title = "Аниме-приключения монтажника";
            Console.ForegroundColor = ConsoleColor.Magenta;
            
            ShowIntro();
            FirstDayAtWork();
        }

        static void ShowIntro()
        {
            Console.Clear();
            Console.WriteLine("≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪≪");
            Console.WriteLine("  あなたの新しい冒険が始まります！");
            Console.WriteLine("≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫≫\n");
            
            Console.WriteLine($"Вы - {player.Name}, монтажник 4 разряда и фанат аниме.");
            Console.WriteLine("Сегодня обычный рабочий день, но...\n");
            
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void FirstDayAtWork()
        {
            Console.Clear();
            Console.WriteLine("＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝");
            Console.WriteLine("  7:30 УТРА. СТРОЙПЛОЩАДКА 'NEO-TOKYO'");
            Console.WriteLine("＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝\n");
            
            Console.WriteLine("Бригадир Иванов кричит:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\"Сатоши! Срочно чини вентиляцию на 25 этаже!\"\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            
            Console.WriteLine("1. Взять инструменты и выполнить задание");
            Console.WriteLine("2. Устроить перерыв с просмотром аниме");
            Console.WriteLine("3. Применить 'Технику Наруто' для ускорения");
            Console.WriteLine("4. Сказать, что это не ваша работа");

            switch (GetChoice(1, 4))
            {
                case 1:
                    FixVentilation();
                    break;
                case 2:
                    AnimeBreak();
                    break;
                case 3:
                    TryNarutoTechnique();
                    break;
                case 4:
                    RefuseWork();
                    break;
            }
        }

        static void FixVentilation()
        {
            Console.Clear();
            Console.WriteLine("・・・・・・・・・・・・・・・・・・・・・・・・・");
            Console.WriteLine("  25 ЭТАЖ. ВЕНТИЛЯЦИОННАЯ ШАХТА");
            Console.WriteLine("・・・・・・・・・・・・・・・・・・・・・・・・・\n");
            
            Console.WriteLine("Вы обнаруживаете:");
            Console.WriteLine("- Сломанный вентилятор");
            Console.WriteLine("- Странные аниме-рисунки на стенах");
            Console.WriteLine("- Звуки битвы из соседнего помещения\n");
            
            Console.WriteLine("1. Починить стандартным способом (-5 болтов)");
            Console.WriteLine("2. Попробовать 'Технику Удзумаки'");
            Console.WriteLine("3. Исследовать источник звуков");

            int choice = GetChoice(1, 3);

            if (choice == 1)
            {
                player.Screws -= 5;
                Console.WriteLine("\nВы успешно починили вентиляцию!");
                Console.WriteLine("Но бригадир недоволен расходом материалов...");
                NormalEnding();
            }
            else if (choice == 2)
            {
                if (player.AnimePower > 4)
                {
                    Console.WriteLine("\n☆★☆ УРА! Вентилятор починен с помощью Чакры! ☆★☆");
                    Console.WriteLine("Но теперь все хотят узнать ваш секрет...");
                    SecretTechniqueEnding();
                }
                else
                {
                    Console.WriteLine("\nНедостаточно аниме-силы! Вентилятор взорвался!");
                    GameOver();
                }
            }
            else
            {
                Console.WriteLine("\nВы находите потайную дверь...");
                AnimeWorldPortal();
            }
        }

        static void AnimeWorldPortal()
        {
            Console.Clear();
            Console.WriteLine("☆*:.｡.o(≧▽≦)o.｡.:*☆*:.｡.o(≧▽≦)o.｡.:*☆");
            Console.WriteLine("  ВЫ ПОПАЛИ В МИР АНИМЕ!");
            Console.WriteLine("☆*:.｡.o(≧▽≦)o.｡.:*☆*:.｡.o(≧▽≦)o.｡.:*☆\n");
            
            Console.WriteLine("Перед вами:");
            Console.WriteLine("- Гиперболоидный болт от Гандама");
            Console.WriteLine("- Манга-инструкция по ремонту");
            Console.WriteLine("- Девушка-киборг, просящая помощи\n");
            
            Console.WriteLine("1. Взять болт для коллекции");
            Console.WriteLine("2. Изучить мангу");
            Console.WriteLine("3. Помочь киборгу");

            int choice = GetChoice(1, 3);

            if (choice == 1)
            {
                Console.WriteLine("\nБолт оказался ключом к межпространственному порталу!");
                Console.WriteLine("Теперь вы можете путешествовать между мирами!");
                TrueAnimeEnding();
            }
            else if (choice == 2)
            {
                player.KnowsSecretTechnique = true;
                Console.WriteLine("\nВы изучили 'Технику Монтажа Ками'!");
                Console.WriteLine("Теперь можете чинить что угодно без инструментов!");
                SecretTechniqueEnding();
            }
            else
            {
                Console.WriteLine("\nВы починили девушке-киборгу руку...");
                Console.WriteLine("Оказалось, она дочь президента корпорации!");
                RomanceEnding();
            }
        }

        static void TrueAnimeEnding()
        {
            Console.Clear();
            Console.WriteLine("∧,,,∧\n( ̳• · • ̳)\n/    づ♡ КОНЦОВКА");
            Console.WriteLine("Вы стали мостом между мирами!");
            Console.WriteLine("Совмещаете монтаж и аниме-приключения!");
            ExitGame();
        }

        static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("(×_×) GAME OVER");
            Console.WriteLine("Вас уволили за порчу имущества...");
            ExitGame();
        }

        static int GetChoice(int min, int max)
        {
            while (true)
            {
                Console.Write("\nВыбор: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine($"Нужно число от {min} до {max}!");
            }
        }

        // Другие методы сюжета...
    }
}
