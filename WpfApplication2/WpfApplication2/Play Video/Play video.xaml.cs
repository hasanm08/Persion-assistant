using Microsoft.Win32;
using Persion_Assistant08.Default_Orders_Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using WpfApplication2;

namespace Persion_Assistant08.Play_Video
{

    /// <summary>
    /// Interaction logic for Play_video.xaml
    /// </summary>
    /// 
    public partial class Play_video : Window
    {
     public static   DispatcherTimer timer;
        string[] p2;
        public bool FullScreen = false;
        public delegate void timerTick();
        timerTick tick;
        bool play = true;
        bool visibale = true;
        public string l ;
        public int len ;
        public bool Sub=false;
        public int i = 0;

        public Play_video(string x)
        {
            
            l =x;
           
            len = 0;
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += new EventHandler(Timer_Tick);
            tick = new timerTick(ChangeStatus);
            this.WindowState = WindowState.Normal;
            WindowStyle = WindowStyle.None;
            this.FlowDirection = FlowDirection.RightToLeft;
            InitializeComponent();
        }
       
        void ChangeStatus()
        {   
            if ( fileIsPlaying)   
            {   
                string sec, min, hours;  

                #region customizeTime   
                if (mediaElement.Position.Seconds< 10)   
                    sec = "0" + mediaElement.Position.Seconds.ToString();   
                else  
                    sec = mediaElement.Position.Seconds.ToString();   
  
  
                if (mediaElement.Position.Minutes< 10)   
                    min = "0" + mediaElement.Position.Minutes.ToString();   
                else  
                    min = mediaElement.Position.Minutes.ToString();   
  
                if (mediaElement.Position.Hours< 10)   
                    hours = "0" + mediaElement.Position.Hours.ToString();   
                else  
                    hours = mediaElement.Position.Hours.ToString();  
 
                #endregion customizeTime   
  
                seekBar.Value = mediaElement.Position.TotalMilliseconds;   
  
                if (mediaElement.Position.Hours == 0)   
                {   
  
                    currentTimeTextBlock.Text = min + ":" + sec;   
                }   
                else  
                {   
                    currentTimeTextBlock.Text = hours + ":" + min + ":" + sec;   
                }   
            }   
        }
        bool isDragging = false;

	 

	void Timer_Tick(object sender, EventArgs e)

	{
            Dispatcher.Invoke(tick);

        if (!isDragging)
	    {

	        seekBar.Value = mediaElement.Position.TotalSeconds;

	    }

	}

	 

	private void SeekBar_DragStarted(object sender, DragStartedEventArgs e)

	{

	    isDragging = true;

	}

	 

	private void SeekBar_DragCompleted(object sender, DragCompletedEventArgs e)

	{

	    isDragging = false;

	    mediaElement.Position = TimeSpan.FromSeconds(seekBar.Value);

    }
    private void SeekSlider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {   
            TimeSpan ts = new TimeSpan(0, 0, 0,  (int)seekBar.Value);   
  
            ChangePostion(ts);   
        }   
  
//mouse down on slide bar in order to seek   
        private void SeekSlider_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {   
            isDragging = true;   
        }   
  
        private void SeekSlider_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {   
            if (isDragging)   
            {   
                TimeSpan ts = new TimeSpan(0, 0, 0,  (int)seekBar.Value);   
                ChangePostion(ts);   
            }   
            isDragging = false;   
        }   
  
//change position of the file   
    void ChangePostion(TimeSpan ts)
    {   
      mediaElement.Position = ts;   
    }  

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            double h;double w;
            if (FullScreen)
            {
                this.WindowState = WindowState.Normal;
              
                h = mediaElement.Height;
                w = mediaElement.Width;
                mediaElement.Height =h/ 2;
                mediaElement.Width = w/2;
                FullScreen = false;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                h = mediaElement.Height;
                w = mediaElement.Width;
                mediaElement.Height = h*2;
                mediaElement.Width = w*2;
                FullScreen = true;
            }
            
        }

        bool fileIsPlaying=true;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!fileIsPlaying)
            {
                mediaElement.Play();
                fileIsPlaying = true;
            }
          
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (fileIsPlaying)
            {
             mediaElement.Stop();
            fileIsPlaying = false;
            }
           
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (fileIsPlaying)
            {
                mediaElement.Pause();
                fileIsPlaying = false;
            }
           
        }
        public static void WriteToTxtFile<T>(string path, T objectToWrite, bool append = false) where T : new()
        {
            try
            {
                string lines = objectToWrite.ToString();

                StreamWriter file = new StreamWriter(path,append);
                file.WriteLine(lines);

                file.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification);
            }
        }
        public  void ToTxtFile(string path) 
        {
         
         
                StreamReader R = new StreamReader(path);

                string p = R.ReadLine();
           
          
            if(p != null)
            {
                p2 = p.Split('.');
            
                if (p2.Length != 0)
                {
                   

                    mediaElement.Position = new TimeSpan(int.Parse(p2[2]), int.Parse(p2[1]), int.Parse(p2[0]));
                 

                }

            }
            R.Close();
           
           
        }
        DA.Entity entity = new DA.Entity();
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                mediaElement.Position = TimeSpan.FromSeconds(seekBar.Value - 5);
            }
            if (e.Key == Key.Left)
            {
                mediaElement.Position = TimeSpan.FromSeconds(seekBar.Value + 5);
            }
            if (e.Key == Key.Up)
            {
                mediaElement.Volume += 0.1;

            }
            if (e.Key == Key.Down)
            {
                mediaElement.Volume -= 0.1;

            }
            if (e.Key == Key.Enter)
            {
                button4.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
            if (e.Key == Key.RightShift)
            {
                MessageBox.Show(mediaElement.Source.LocalPath, "نام فیلم", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            if (e.Key == Key.NumPad0)
            {
                if (visibale)
                {
                    button.Visibility = Visibility.Hidden;
                    button1.Visibility = Visibility.Hidden;
                    button2.Visibility = Visibility.Hidden;
                    button3.Visibility = Visibility.Hidden;
                    button4.Visibility = Visibility.Hidden;
                    visibale = false;
                }
                else
                {
                    button.Visibility = Visibility.Visible;
                    button1.Visibility = Visibility.Visible;
                    button2.Visibility = Visibility.Visible;
                    button3.Visibility = Visibility.Visible;
                    button4.Visibility = Visibility.Visible;
                    visibale = true;
                }
            }
            if(e.Key==Key.Space)
            {
                if (play)
                {
                    mediaElement.Pause();
                    seekBar.Value = seekBar.Value;
                    play = false;
                }
                else
                {
                    mediaElement.Position=(TimeSpan.FromSeconds(seekBar.Value));
                    mediaElement.Play();
                    
                    play = true;
                }
            }
            if (e.Key == Key.NumPad1)
            {
               button3.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        
            if (e.Key == Key.NumPad2)
            {
                Help j = new Help
                {
                    Player = true
                };
                j.Show();
            }
            if (e.Key == Key.RightCtrl)
            {
                this.Hide();
               
              
                for (int i=0;i<l.Length;i++)
                {
                    if (l[i] == '.')
                    {
                        len = i;
                    }
                }
                foreach (var item in entity.GetAllPositions())
                {
                    if(item.Name== l.Substring(0, len))
                    {
                        entity.Delete(item);
                    }
                }
                entity.Addposition(new DA.Positions(l.Substring(0, len), mediaElement.Position));
                  
              
          

                this.Close();
            }
        }
 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mediaElement.Volume = 0.5;
            this.Background = new ImageBrush();
            richTextBox.Background = new ImageBrush();
            richTextBox.Visibility = Visibility.Hidden;
            this.SizeChanged += Window_SizeChanged;
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            mediaElement.StretchDirection = StretchDirection.Both;
        }
      

        private void MediaElement_MediaOpened(object sender, RoutedEventArgs e)
        {
            
            if (!mediaElement.HasVideo)
            {
                Persion_Assistant08.Play_Song.Song_Player _Player = new Persion_Assistant08.Play_Song.Song_Player(new List<string> { mediaElement.Source.AbsoluteUri });
                _Player.Show();
                mediaElement.Stop();
                this.Hide();
                this.Close();
            }
            if (mediaElement.NaturalDuration.HasTimeSpan)
                

        {
                

            TimeSpan ts = mediaElement.NaturalDuration.TimeSpan;
                

            seekBar.Maximum = ts.TotalSeconds;
                

            seekBar.SmallChange = 1;
                

            seekBar.LargeChange = Math.Min(10, ts.Seconds / 10);
              
                

        }
            

        timer.Start();
        }
       
        private void SeekBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (Sub)
            {
             
               
                TimeSpan b =  TimeSpan.FromSeconds(e.NewValue);
                
               

                for (int k = 0; k < Subtitle.X.Count; k++)
                {
                    
                    if ((b-(Subtitle.X[k].Start)).Duration() <= TimeSpan.FromMilliseconds(500))
                    {
                        i = k;
                    }
                }
          
                
                if ((b - (Subtitle.X[i].Start)).Duration() <= TimeSpan.FromMilliseconds(500))
                {
                   
                    richTextBox.SelectAll();
                  

                     richTextBox.Selection.Text= Subtitle.Sub[i].text;
                    

                }
                if ((b - (Subtitle.X[i].End)).Duration() <= TimeSpan.FromMilliseconds(500))
                {
                    richTextBox.SelectAll();


                    richTextBox.Selection.Text = " ";
                    i++;
                }
            }
          
        }

       

          private void SeekBar_DragOver(object sender, DragEventArgs e)
          {
              isDragging = false;

              mediaElement.Position = TimeSpan.FromSeconds(seekBar.Value);
          }

        private void MediaElement_Loaded(object sender, RoutedEventArgs e)
        {
            //mediaElement.Volume = 60;
            //for (int i = 0; i < l.Length; i++)
            //{
            //    if (l[i] == '.')
            //    {
            //        len = i;
            //    }
            //}
            //foreach (var item in entity.GetAllPositions())
            //{
            //    if(item.Name== (l.Substring(0, len)))
            //    {
            //        mediaElement.Position = item.Time;
            //    }
            //}
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                mediaElement.Position = TimeSpan.FromSeconds(seekBar.Value - 5);
            }
            if (e.Key == Key.Left)
            {
                mediaElement.Position = TimeSpan.FromSeconds(seekBar.Value + 5);
            }
            if (e.Key == Key.Up)
            {
                mediaElement.Volume += 0.1;
                
            }
            if (e.Key == Key.Down)
            {
                mediaElement.Volume -= 0.1;
               
            }
        }
       
        public OpenFileDialog openFile;
        public bool Ended;
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            openFile = new OpenFileDialog
            {
                Filter = "Subtitle Files(*.srt)|*.srt"
            };
            if (openFile.ShowDialog() == true)
            {
                Subtitle.Subload(openFile.FileName);
                Sub = true;
                richTextBox.Visibility = Visibility.Visible;
            }
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            Ended = true;
        }

        private void MediaElement_MouseEnter(object sender, MouseEventArgs e)
        {
            //https://www.cnet.com/how-to/set-your-mouse-cursor-to-hide-automatically/
        }
    }
}
