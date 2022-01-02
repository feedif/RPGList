using RPGList.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGList.scr
{
    public class HeroRepository : IRepository<Hero>
    {
        private List<Hero> _heroList = new List<Hero>();
        public void Delete(int id)
        {
            _heroList[id].Remove();
        }

        public void Insert(Hero entity)
        {
            _heroList.Add(entity);
        }

        public List<Hero> List()
        {
            return _heroList;
        }

        public int NextId()
        {
            return _heroList.Count;
        }

        public Hero ReturnById(int id)
        {
            return _heroList[id];
        }

        public void Update(int id, Hero entity)
        {
            _heroList[id] = entity;
        }
    }
}
