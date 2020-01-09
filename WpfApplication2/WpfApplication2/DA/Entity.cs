using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persion_Assistant08.DA
{
    class Entity
    {
        DataBase dataBase = new DataBase();
        public void Clear()
        {
            foreach (var item in dataBase.entities)
            {
                dataBase.entities.Remove(item);
            }
        }
        public void Delete(Positions m)
        {
            dataBase.entities.Remove(m);

        }
        public void Delete(string  m)
        {
            foreach(Positions p in dataBase.entities)
            {
                if (p.Name == m)
                {
                    dataBase.entities.Remove(p);

                }
            }

        }
        public bool Addposition(Positions m)
        {
            dataBase.entities.Add(m);
            dataBase.SaveChanges();
            return true;
        }

        public List<Positions> GetAllPositions()
        {
            return dataBase.entities.ToList();
        }
    }
}
