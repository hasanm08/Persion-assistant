using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persion_Assistant08.Play_Song.PlayMethods
{
    interface IPlay
    {
        DoublyLinkedList<Song> Play(Play_List PL);
    }
}
