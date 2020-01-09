using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persion_Assistant08.Play_Song.PlayMethods
{
    class Normal : IPlay
    {
        public DoublyLinkedList<Song> Play(Play_List PL)
        {
            DoublyLinkList<Song> result = new DoublyLinkList<Song>();
            foreach (var item in PL.PlayList)
            {
                result.AddLast(item);
                System.Windows.Forms.MessageBox.Show(result.Size.ToString());
            }
            return result;
        }

    }
}
