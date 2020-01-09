using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Persion_Assistant08.Play_Song
{
    class PlayerClass
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public bool Opend = false;
        Song Song { get; set; }
        int i ;
        Song[] PL;
       // private DoublyLinkedList<Song> doublyLinkedList;

       

        public PlayerClass(DoublyLinkedList<Song> doublyLinkedList)
        {
            i = 0;
            PL = doublyLinkedList.ToArray<Song>();// (doublyLinkedList.GetEnumerator() as IEnumerable<Song>);
            Song song = PL[i];
            Song = song;
            mediaPlayer.Open(song.Address);
        }

        public  void Play() => mediaPlayer.Play();
        public void Pause() => mediaPlayer.Pause();
        public void Stop() => mediaPlayer.Stop();
        public MediaTimeline GetTime => mediaPlayer.Clock.Timeline;
        public bool Next()
        {
            if (i+1<PL.Length)
            {
                i++;
                mediaPlayer.Open(PL[i].Address);
                Play();

                return true;
            }
            else
            {
                return false;
            }
        }
        public bool  Prev()
        {
            if (i -1 >-1)
            {
                i--;
                mediaPlayer.Open(PL[i].Address);
                Play();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
