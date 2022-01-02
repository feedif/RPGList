using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGList.scr
{
    public class Hero : BaseEntity
    {
        public string Name { get; set; }
        public HeroClass HeroClass { get; set; }
        public bool Removed { get; set; }

        public Hero(int id, string name, HeroClass heroClass)
        {
            this.Id = id;
            this.Name = name;
            this.HeroClass = heroClass;
            this.Removed = false;
        }

        public override string ToString()
        {
            string _return = "";
            _return += "Name: " + this.Name + Environment.NewLine;
            _return += "Class Hero: " + this.HeroClass.ClassName + Environment.NewLine;
            _return += "Level: " + this.HeroClass.Level + Environment.NewLine;
            _return += "Hit Points: " + this.HeroClass.HitPoints + Environment.NewLine;
            _return += "Spell Slots: " + this.HeroClass.SpellSlot + Environment.NewLine;
            return _return;
        }

        public string NameReturn()
        { return this.Name; }

        public int IdReturn()
        { return this.Id; }

        public HeroClass HeroClassReturn()
        { return this.HeroClass; }

        public bool RemovedReturn()
        { return this.Removed; }

        public void Remove()
        { this.Removed = true; }

    }
}
