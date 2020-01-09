using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persion_Assistant08.DA
{
    class Positions
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public TimeSpan Time { get; set; }


        public Positions(string name,TimeSpan time)
        {
            Name = name;
            Time = time;
        }
        public Positions() : this(null, default) { }
        public override string ToString()
        {
            return "Name:  " + Name + "  Time:  " + Time.ToString() + "  ID : " + Id;
        }
    }
}
