using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persion_Assistant08.Play_Song
{
   public  class Audio
    {
        public Audio() :this(null, null,  TimeSpan.Zero)
        {

        }

        public Audio(string name, string addres)
        {
            Name = name;
            Addres = addres;
        }

        public Audio(string name, string addres, TimeSpan time) : this(name, addres)
        {
            Time = time;
        }

        public string Name { get; set; }
        public string Addres { get; set; }
        public TimeSpan Time { get; set; }
    }
}
