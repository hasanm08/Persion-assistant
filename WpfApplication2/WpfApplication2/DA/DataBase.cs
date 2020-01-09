using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persion_Assistant08.DA
{
    class DataBase:DbContext
    {
      public DbSet<Positions> entities { get; set; }

        internal Entity Entity
        {
            get => default;
            set
            {
            }
        }
    }
}
