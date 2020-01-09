using Persion_Assistant08.Play_Video;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Persion_Assistant08.Play_Song
{
    /// <summary>
    /// Interaction logic for Song_Player.xaml
    /// </summary>
    public partial class Song_Player : Window
    {
        bool hasVid = false;
        public Song_Player(List<string> vs)
        {
            InitializeComponent();
            Vs = vs;
            hasVid = false;
            Current = 0;
            ReapeatOn = false;
            Playing(vs[Current]);
            #region Bug
            //if (hasVid)
            //{
            //    Play_video P = new Play_video(mediaPlayer.Source.AbsoluteUri);
            //    MessageBox.Show("برای راهنمایی کلید 2 در کیبورد ماشین حساب را وارد کنید", "پخش کننده 08", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
            //    P.mediaElement.Source = new Uri(mediaPlayer.Source.AbsoluteUri);
            //    mediaPlayer.Stop();
            //    this.Hide();
            //    P.Show();
            //    P.mediaElement.Play();
            //    this.Close();
            //    return;
            //}
            #endregion


            mediaPlayer.MediaEnded +=Ended ;
            IS_Shuffleing = false;
            mediaPlayer.MediaOpened += Opened;
            Shown = false;
            // mediaPlayer.Changed += Changed;
            
            SoundSlider.ValueChanged += Changed;
            SoundSlider.DragOver += Changed;
            SoundSlider.PreviewMouseLeftButtonDown += Changed;
            SoundSlider.PreviewMouseLeftButtonUp += Changed;
            SoundSlider.MouseLeftButtonUp += Changed;
            SoundSlider.Value = 0.7;

            SongSlider.ValueChanged +=SongChanged;
            SongSlider.DragOver += SongChanged;
            //SongSlider.PreviewMouseLeftButtonDown += SongChanged;
          //  SongSlider.PreviewMouseLeftButtonUp += SongChanged;
            //SongSlider.MouseLeftButtonUp += SongChanged;
            

        }
        public bool Shown;
        bool ReapeatOn;
        List<string> Vs;
        public MediaPlayer mediaPlayer;
        int Current;
       
        void SongChanged(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.FromMilliseconds(SongSlider.Value * SongSlider.Maximum);
        }
        void Changed(object sender, EventArgs e)
        {
            mediaPlayer.Volume =SoundSlider.Value;
        }
        void Opened(object sender, EventArgs e)
        {
            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
                SongSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
                SongSlider.Value = 0;
            }

        }
        void Ended(object sender, EventArgs e)
        {
            Next_Click(null, null);
        }
        private void Ellipse_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
       public  void Playing(string urisource)
       {
            
            try
            {
                TagLib.File f = new TagLib.Mpeg.AudioFile(urisource);
                TagLib.IPicture pic = f.Tag.Pictures[0];
                MemoryStream ms = new MemoryStream(pic.Data.Data);
                ms.Seek(0, SeekOrigin.Begin);

                // ImageSource for System.Windows.Controls.Image
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = ms;
                bitmap.EndInit();


                SongCover.Source = bitmap;

            }
            catch
            {
                string st = Directory.GetCurrentDirectory();
                st = st.Replace(@"bin\Debug", @"Fonts And Pictures\Audio player\");
                st += "music.png";
                SongCover.Source = new BitmapImage(new Uri(st));


            }
            int index = urisource.LastIndexOf(@"\".ToCharArray()[0]);
            string s = urisource.Remove(0, index + 1);
            SongLabel.Text = "Name : " +s;


            mediaPlayer = new MediaPlayer();
            try
            {
                mediaPlayer.Open(new Uri(urisource));

            }
            catch (Exception)
            {

                MessageBox.Show("Select a valid one");
            }
            if (mediaPlayer.HasVideo)
            {
                hasVid = true;
                return;
            }
            if ( !isPlaying)
            {
                Play_Click(null, null);
            }
            else
            {
                Stop_Click(null, null);
                Play_Click(null, null);
            }

            
            About();
       }
        
        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            if (Shown)
            {
                playListWindow.Hide();
                playListWindow.Close();

            }
            this.Close();
         }
        bool isPlaying = false;
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            string  s = Directory.GetCurrentDirectory();
            s = s.Replace(@"bin\Debug", @"Fonts And Pictures\Audio player\");

            if ( !isPlaying)
            {
                //play
                // playerClass.Play();
                mediaPlayer.Play();
                s += "pause.png";
                PImage.Source = new BitmapImage(new Uri(s));
                isPlaying = true;
            }
            else
            {
                //pause
                // playerClass.Pause();
                mediaPlayer.Pause();
                s += "play.png";
                PImage.Source = new BitmapImage(new Uri(s));
                isPlaying = false;

            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (ReapeatOn)
            {
                try
                {
                    Play_Click(null, null);
                   Playing(Vs[(Current + 1)%Vs.Count]);
                    Current = (Current + 1) % Vs.Count;
                }
                catch
                {


                }
            }
            else
            {
                try
                {
                    Play_Click(null, null);
                    Playing(Vs[Current + 1]);
                    Current++;
                }
                catch
                {


                }
            }
        }

        private void Perv_Click(object sender, RoutedEventArgs e)
        {
            if (ReapeatOn)
            {
                try
                {
                    Play_Click(null, null);
                    Playing(Vs[(Current - 1)%Vs.Count]);
                    Current=(Current-1)%Vs.Count;
                }
                catch
                {


                }
            }
            else
            {
                try
                {
                    Play_Click(null, null);
                    Playing(Vs[Current - 1]);
                    Current--;
                }
                catch
                {


                }
            }

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Play_Click(null, null);
            mediaPlayer.Stop();
        }
        bool IS_Shuffleing;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (! IS_Shuffleing)
            {
                Shuffle();
                IS_Shuffleing = true;
                About();
            }
            else
            {
                UnShuffle();
                IS_Shuffleing = false;
                About();
            }
        }
        List<string> FirstPL;
        void Shuffle()
        {
            Random random = new Random();
            List<string> newvs = new List<string>();
            int[] indexs = new int[Vs.Count];
            bool IsInArray(int x,int i)
            {
                foreach (var item in indexs)
                {
                    if (item==x)
                    {
                        return true;
                    }
                }
                indexs[i] = x;
                return false;
            }
            for (int i = 0; i < Vs.Count; i++)
            {
                int index = random.Next(0, Vs.Count);
                if (! IsInArray(index,i ))
                {
                    newvs.Add ( Vs[index]);
                }
            }
            FirstPL = Vs;
            Vs = newvs;
        }
        void UnShuffle()
        {
           
            Vs = FirstPL;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
            if (ReapeatOn)
            {
                ReapeatOn = false;
                About();
            }
            else
            {
                ReapeatOn = true;
                About();
            }
        }
        void About()
        {
            if (ReapeatOn)
            {
                SongLabel.Text += "\n" + "Repeat is On";
            }
            else if(!ReapeatOn)
            {
                SongLabel.Text = SongLabel.Text.Replace ("\n" + "Repeat is On","");
            }
            if (IS_Shuffleing)
            {
                SongLabel.Text += "\n" + "Shuffle is On";
            }
            else if(!IS_Shuffleing)
            {
                SongLabel.Text = SongLabel.Text.Replace("\n" + "Shuffle is On", "");

            }
        }
        List<Audio> GetAudios()
        {
            List<Audio> audios = new List<Audio>();
           // MediaPlayer media = new MediaPlayer();
            foreach (var item in Vs)
            {
                int index = item.LastIndexOf(@"\".ToCharArray()[0]);
                string s = item.Remove(0, index + 1);
                // media.Open(new Uri(item));

                //if(media.NaturalDuration.HasTimeSpan)
                //{
                //     audios.Add(new Audio(s, item, media.NaturalDuration.TimeSpan));
                //}
                //else
                // {
                if (!(item is null))
                {
                    audios.Add(new Audio(s, item));

                }
                // }
            }
            return audios;
        }
        private void PlayList_Click(object sender, RoutedEventArgs e)
        {
            playListWindow = new PlayListWindow(GetAudios(),this);
            playListWindow.Show();
            Shown = true;
        }
        PlayListWindow playListWindow;

        private void Eject_Click(object sender, RoutedEventArgs e)
        {
            List<string> vs = new List<string>();
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*",
                Multiselect = true
            };
            
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (var item in openFileDialog.FileNames)
                {
                    vs.Add(item);
                }
                Vs = vs;
                Stop_Click(null, null);
                Playing(Vs[0]);
            }
        }
    }
}
