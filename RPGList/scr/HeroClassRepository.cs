using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGList.scr
{
    public class HeroClassRepository
    {
        public static List<HeroClass> GetHeroClasses()
        {
            var list = new List<HeroClass>();
            list.AddRange(new[]
            {   new HeroClass(0, "Wizard", 6, 4, 1),
                new HeroClass(1, "Fighter", 12, 0, 1)
            });

            return list;
        }
    }
}
