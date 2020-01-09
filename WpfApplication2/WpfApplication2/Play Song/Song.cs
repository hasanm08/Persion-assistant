using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Persion_Assistant08.Play_Song
{
    class Song
    {
        public Song(Uri address=null, TimeSpan duration=default, string name=null, BitmapImage image=null)
        {
            Address = address;
            Duration = duration;
            Name = name;
            Image = image;
        }

        public Uri Address { get; set; }
        public TimeSpan Duration { get; set; }
        public string Name { get; set; }
        public BitmapImage Image { get; set; }

        public override string ToString()
        {
          return   Address.ToString();
        }
    }
}
