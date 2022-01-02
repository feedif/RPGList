using RPGList.scr;
using System;
using System.Collections.Generic;

namespace RPGList
{
    public class Program
    {
        static HeroRepository repository = new HeroRepository();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to RPG List!!!");

            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListHero();
                        break;
                    case "2":
                        InsertHero();
                        break;
                    case "3":
                        UpdateHero();
                        break;
                    case "4":
                        DeleteHero();
                        break;
                    case "5":
                        ViewHero();
                        break;
                    case "6":
                        Battle();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Thanks for using ours services!");
            Console.ReadLine();
        }

        private static void ListHero()
        {
            Console.WriteLine("List Hero");

            var _heroLista = repository.List();

            if (_heroLista.Count == 0)
            {
                Console.WriteLine("No heroes registered.");
                return;
            }
            foreach (var hero in _heroLista)
            {
                var removed = hero.RemovedReturn();
                Console.WriteLine("#ID {0}: - {1} - {2} {3}", hero.IdReturn(), hero.NameReturn(), hero.HeroClassReturn().ClassName, removed ? " - The Herois dead or removed" : "");
            }
        }

        private static void InsertHero()
        {
            Console.WriteLine("Insert a new Hero");

            List<HeroClass> listHeroClass = HeroClassRepository.GetHeroClasses();
            listHeroClass.ForEach(cl => Console.WriteLine($"Id: {cl.IdClass} Class Name: {cl.ClassName} Level: {cl.Level} HP: {cl.HitPoints} Spell Slots: {cl.SpellSlot}"));

            Console.Write("Choice a Hero Class above (ID): ");
            int inputClassIndex = int.Parse(Console.ReadLine());

            Console.Write("Enter Hero Name: ");
            string inputName = Console.ReadLine();

            Hero newHero = new Hero(id: repository.NextId(),
                                        name: inputName,
                                        heroClass: listHeroClass[inputClassIndex]);
            repository.Insert(newHero);
        }

        private static void UpdateHero()
        {
            Console.Write("Enter Hero Id: ");
            int indexHero = int.Parse(Console.ReadLine());

            List<HeroClass> listHeroClass = HeroClassRepository.GetHeroClasses();
            listHeroClass.ForEach(cl => Console.WriteLine($"Id: {cl.IdClass} Class Name: {cl.ClassName} Level: {cl.Level} HP: {cl.HitPoints} Spell Slots: {cl.SpellSlot}"));

            Console.Write("Choice a Hero Class above (ID): ");
            int inputClassIndex = int.Parse(Console.ReadLine());

            Console.Write("Enter Hero Name: ");
            string inputName = Console.ReadLine();

            Hero updateHero = new Hero(id: indexHero,
                                        name: inputName,
                                        heroClass: listHeroClass[inputClassIndex]);
            repository.Update(indexHero, updateHero);
        }

        private static void DeleteHero()
        {
            Console.Write("Enter Hero Id: ");
            int indexHero = int.Parse(Console.ReadLine());
            Console.WriteLine("Are you sure you want to remove the hero with id {0} (yes/no)?", indexHero);
            string answer = Console.ReadLine();
            if (answer == "yes" || answer == "Yes" || answer == "YES")
            {
                repository.Delete(indexHero);
            }
        }

        private static void ViewHero()
        {
            Console.Write("Enter Hero Id: ");
            int indexHero = int.Parse(Console.ReadLine());

            var hero = repository.ReturnById(indexHero);

            Console.WriteLine(hero);
        }

        private static void Battle()
        {
            Console.WriteLine("Enter Hero Id who will attack: ");
            int indexHero1 = int.Parse(Console.ReadLine());
            var hero1 = repository.ReturnById(indexHero1);

            Console.WriteLine("Enter Hero Id who will be attacked");
            int indexHero2 = int.Parse(Console.ReadLine());
            var hero2 = repository.ReturnById(indexHero2);

            if (hero1.HeroClass.HitPoints > 0)
            {
                if (hero2.HeroClass.HitPoints > 0)
                {
                    HeroClass.Attack(hero1.HeroClass, hero2.HeroClass);
                }
                else
                {
                    hero2.Remove();
                    Console.WriteLine($"The Hero {hero2.Name} is dead or removed. Choice another Hero to battle");
                }
            }
            else
            {
                Console.WriteLine($"The Hero {hero2.Name} is dead or removed. Choice another Hero to battle");
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Enter an option: ");
            Console.WriteLine("1 - List Hero");
            Console.WriteLine("2 - Insert a new Hero");
            Console.WriteLine("3 - Update Hero");
            Console.WriteLine("4 - Delete Hero");
            Console.WriteLine("5 - View Hero");
            Console.WriteLine("6 - Battle");
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
