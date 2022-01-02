using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGList.scr
{
    public class HeroClass
    {
        public int IdClass { get; set; }
        public string ClassName { get; set; }
        public int HitPoints { get; set; }
        public int SpellSlot { get; set; }
        public int Level { get; set; }

        public HeroClass(int idClass, string className, int hitPoints, int spellSlot, int level)
        {
            this.IdClass = idClass;
            this.ClassName = className;
            this.HitPoints = hitPoints;
            this.SpellSlot = spellSlot;
            this.Level = level;
        }


        public static void Attack(HeroClass cl1, HeroClass cl2)
        {
            int rollDice = RollDice(20);
            int rollAtack = rollDice + cl1.Level;

            int _bonus = HeroClass.CheckHeroClass(cl1);

            Console.WriteLine($"{cl1.ClassName} attacks {cl2.ClassName}");
            Console.WriteLine($"{cl1.ClassName} roll {rollDice} to hit");

            if (rollAtack > (cl2.Level + 10))
            {
                int damage = RollDice(cl1.HitPoints) + _bonus;
                cl2.TakeDamage(damage);
                Console.WriteLine(cl1.ClassName + " attacks with " + damage + "  damage and " + cl2.ClassName + " takes this damage");
                if (cl2.HitPoints <= 0)
                {
                    cl2.HitPoints = 0;
                    Console.WriteLine($"The {cl2.ClassName} has been defeated.");
                    Console.WriteLine($"The {cl1.ClassName} is the champion.");
                    LevelUp(cl1);
                }   
            }
            else
            {
                Console.WriteLine("The attack did not hit " + cl2.ClassName);
            }

        }

        public static int CheckHeroClass(HeroClass heroClass)
        {
            switch (heroClass.ClassName)
            {
                case "Wizard":
                    Console.WriteLine($"Is this a spell attack? (Y/N)");
                    string spellAttack = Console.ReadLine();
                    if (spellAttack == "Y" || spellAttack == "y")
                    {
                        if (heroClass.SpellSlot > 0)
                        {
                            heroClass.SpellSlot -= 1;
                            Console.WriteLine($"The wizard consumes 1 spell slots and now has {heroClass.SpellSlot} spell slots");
                            int bonus = RollDice(10);
                            return bonus;
                        }
                        else
                        {
                            Console.WriteLine("The Hero no has spell slot! The attack will be without bonus.");
                        }
                    }
                    return 0;
                default:
                    return 0;
            }
        }

        public static int RollDice(int numberSides)
        {
            Random dice = new Random();
            int valueDice = dice.Next(1,numberSides);
            return valueDice;
        }

        public void TakeDamage(int damage)
        {
            HitPoints -= damage;
        }

        public static void LevelUp(HeroClass heroClass)
        {
            heroClass.Level++;
            heroClass.HitPoints += RollDice(heroClass.HitPoints);
            if(heroClass.ClassName == "Wizard")
            {
                heroClass.SpellSlot += heroClass.Level;
                Console.WriteLine($"The {heroClass.ClassName} level up to {heroClass.Level}, now has {heroClass.HitPoints} Hit Points and {heroClass.SpellSlot} Spells Slots.");
            }
            Console.WriteLine($"The {heroClass.ClassName} level up to {heroClass.Level} and now has {heroClass.HitPoints} Hit Points.");
        }

    }
}
