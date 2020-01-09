using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using HtmlAgilityPack;
using System.Globalization;
using Persion_Assistant08;
using Darkhasts = Persion_Assistant08.Default_Orders_Functions.Naseza;
using Persion_Assistant08.Reminder;
using Persion_Assistant08.Personalize_Orders;
using Persion_Assistant08.Play_Video;
using Persion_Assistant08.Toast_Notification;
using Persion_Assistant08.Video_Downloader;
using Persion_Assistant08.Default_Orders_Functions;

namespace WpfApplication2
{
    public class Ans
    {
        public string درخواست { get; set; }
        public string پاسخ { get; set; }
        public Ans(string A,string b)
        {
            درخواست = A;
            پاسخ = b;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      //  public string Sho { get; set; }
        public List<Ans> All=new List<Ans> ();
        public bool DS = false;
        public bool Fuhsh = false;
        public string Darkhast;
        public bool Command = false;
        bool FilmDown = false;
        bool MusicDown = false;
        public int Search_Numbers = 0;
        public List<string> Musics = new List<string>();
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public bool Sound = false;
        
        public MainWindow()
        {
           

            InitializeComponent();
          
            //dataGrid.FlowDirection = FlowDirection.RightToLeft;
            ////expander.ExpandDirection = ExpandDirection.Left;
            //textBox.FlowDirection = FlowDirection.RightToLeft;
            //label2.FlowDirection = FlowDirection.RightToLeft;
            //label.FlowDirection = FlowDirection.RightToLeft;
            //label1.FlowDirection = FlowDirection.RightToLeft;
            ////label3.FlowDirection = FlowDirection.RightToLeft;


        

            //label2.Content = "سلام "+"\n"+ " خوشحال میشم بتونم کمک کنم"+"\n"+ "بفرمایید";
            label1.Text = "برای اطلاع از دستورات" + "\n" + "راهنما را بفرستید";
            //DispatcherTimer timer = new DispatcherTimer
            //{
            //    Interval = TimeSpan.FromSeconds(1)
            //};
            //timer.Tick += Timer_Tick;
            //timer.Start();

        }
        public bool Founded(List<LinkItem> linkItems, LinkItem link)
        {
            for(int i = 0; i < linkItems.Count; i++)
            {
                if (link.Href == linkItems[i].Href&&link.Text==linkItems[i].Text)
                {
                    return true;
                }
            }
            return false;
        }
        public List<LinkItem> Finded_links = new List<LinkItem>();
        public static List<LinkItem> Finded_Subtitle = new List<LinkItem>();
       // public static List<textItem> textFinders = new List<textItem>();
        public   List<LinkItem> Find_Link(string URL,string Searched_String, out List<LinkItem> links,out string Short)
        {
          //  ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
    // | SecurityProtocolType.Tls11
    // | SecurityProtocolType.Tls12
    // | SecurityProtocolType.Ssl3;
            Short = "First" ;
            links = new List<LinkItem>();
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;


                List<string> Searched_Words = new List<string>(Searched_String.Split(' '));
                WebClient w = new WebClient
                {
                    Encoding = Encoding.UTF8

                };
            w.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            // ServicePointManager.Expect100Continue = true;
            //  ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // string url = "https://www.converse.com";
            w.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
            w.Headers.Add("Cache-Control", "no-cache");
            //wc.Encoding = Encoding.UTF8;
            //string result = wc.DownloadString(url);
            //w.Headers.Add("user-agent", " Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0");
            string s = w.DownloadString(URL);

                foreach (LinkItem i in LinkFinder.Find(s))
                {
                    links.Add(i);
                }

                //foreach (textItem i in textFinder.Find(s))
                //{

                //    MessageBox.Show(i.ToString());


                //}
                //MessageBox.Show(textFinders.Count.ToString());
                //Short = textFinders.Count is int ? textFinder.Find(s)[0].Text :"H08:";
                for (int i = 0; i < links.Count; i++)
                {
                    if (links[i].Href.Contains("zirdl.pw/subtitles"))
                    {
                         if (!Founded(Finded_Subtitle, links[i]))
                         {
                            Finded_Subtitle.Add(links[i]);
                        }
                    }
                    for (int j = 0; j < Searched_Words.Count; j++)
                    {
                      if (links[i].Href.ToLower().Contains(Searched_Words[j].ToLower()))
                        {
                            if (links[i].Text.ToLower().Contains(Searched_Words[j].ToLower()))
                            {
                                if(!Founded(Finded_links, links[i]))
                                {
                                    Finded_links.Add(links[i]);
                                }
                                
                            }
                        }
                    }
                }
                Mouse.OverrideCursor = Cursors.Arrow;
            }
            catch
            {
            }
            return Finded_links;
        }
      string Test( string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;


            // Skip validation of SSL/TLS certificate
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };


            WebResponse respon = req.GetResponse();
            Stream res = respon.GetResponseStream();

            string ret = "";
            byte[] buffer = new byte[1048];
            int read = 0;
            while ((read = res.Read(buffer, 0, buffer.Length)) > 0)
            {
               // MessageBox.Show(Encoding.ASCII.GetString(buffer, 0, read));
                ret += Encoding.ASCII.GetString(buffer, 0, read);
            }
            return ret;
        }
        void Search(string Search_String)
        {
            label1.Text = "دربین دستورات یافت نشد"+"\n"+"درحال یافتن "+Search_String;
           
            string GS = "http://google.com/search?q="+Search_String;
           StartProcess(GS);
          
        }

        private void StartProcess(string path)
        {
            try {

                ProcessStartInfo StartInformation = new ProcessStartInfo
                {
                    FileName = path
                };

                Process process = Process.Start(StartInformation);

                process.EnableRaisingEvents = true;
            } catch(Exception e) { MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.ServiceNotification); }
           
        }
        //void Timer_Tick(object sender, EventArgs e)
        //{
        //    if (mediaElement.Source != null)
        //    {
        //        if (mediaElement.NaturalDuration.HasTimeSpan)
        //            label3.Content = string.Format("{0} / {1}",mediaElement.Position.ToString(@"mm\:ss"), mediaElement.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
        //    }
        //    else
        //       label3.Content = "فایلی انتخاب نشده است";
        //}
        public static void Fohsh()
        {
            Naseza N = new Naseza("بیشعور");
         Darkhasts.   Fohsh.Add(N);
            N = new Naseza("گاو");
            Darkhasts.Fohsh.Add(N);
            Darkhasts.Fohsh.Add(new Naseza("کچه سگ"));
            Darkhasts.Fohsh.Add(new Naseza("بی فرهنگ"));
            Darkhasts.Fohsh.Add(new Naseza("خیلی خری"));
            Darkhasts.Fohsh.Add(new Naseza("خر"));
        }
     

private void Button_Click(object sender, RoutedEventArgs e)
        {
            int DS2=1;
            string FD = null;
            string MD = null;
           // label2.Content = "";
            label1.Text = "";
            Fohsh();
            Random Rnd = new Random();
            
            //mediaElement.Source = new Uri(@"H:\Mobile\Telegram\New folder\Telegram\Telegram Video\1 (" + Rnd.Next(1, 255) + ").MP4", UriKind.Absolute);

           // play_button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            //mediaElement.Volume = 100;


            Darkhast = textBox.Text;
            label.Content = Darkhast;

            //Fill online commands

           
            Persion_Assistant08.Personalize_Orders.Edit_Orders.Follow_Orders(Darkhast,ref Command);



            if (!DS&& !FilmDown && !MusicDown)
            {
                for (int i = 0; i < Darkhasts.Fohsh.Count; i++)
                {

                    if (Darkhast == Darkhasts.Fohsh[i].N)
                    {
                        label1.Text = "متاسفم که شمارا عصبانی کردم";
                        Command = true;
                        Fuhsh = true;
                    }
                }
                
                textBox.Text = "";
                switch (Darkhast )
                {
                    case "ساختمان داده":
                        label1.Text = "شماره قسمت؟";
                        Command = true;
                        DS = true;
                        break;
                    case "ریاضی در زندگی":
                        label1.Text = "در حال باز کردن وبلاگ ریاضی در زندگی . . .";
                        Command = true;
                        string targetURL = @"http://mathinnature.mihanblog.com";
                        StartProcess(targetURL);
                        break;
                    case "گوگل":
                        label1.Text = "در حال باز کردن گوگل . . .";
                        StartProcess(@"http://google.com");
                        break;
                    case "بستن":
                        MainWindow_Closing(null, null);
                        break;
                    case "دانلود فیلم":
                    case "دف":
                        FilmDown = true;
                        label1.Text = "لطفا اسم فیلم را به انگلیسی " + "\n" + "وارد کنید";
                        InputLanguageManager.Current.CurrentInputLanguage = new CultureInfo("en-US");
                        break;
                    case "دانلود اهنگ":
                    case "دا":
                        MusicDown = true;
                        label1.Text = "لطفا اسم اهنگ را  وارد کنید";
                        break;
                    case "رزرو":
                    case "تغذیه":
                        StartProcess(@"http://nut.uk.ac.ir/nutrition/");
                        label1.Text = " در حال باز کردن سایت اتوماسیون تغذیه . . .";
                        break;
                    case "راهنما":
                        Help h = new Help
                        {
                            Player = false
                        };
                        h.Show();
                        break;
                    case "ایمیل":
                        send_Email s = new send_Email();
                        s.Show();
                        break;
                    case "یاداوری":
                        MessageBoxResult result = MessageBox.Show("ایا میخواهید یک یاداور بیافزایید؟", "دستیار08", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Yes, MessageBoxOptions.RightAlign);
                        switch (result)
                        {
                            case MessageBoxResult.Yes:
                                Add_Reminder S = new Add_Reminder();
                                S.Show();
                                break;
                            case MessageBoxResult.No:
                                Remember r = new Remember();
                                r.Show();
                                break;
                            case MessageBoxResult.Cancel:
                                MessageBox.Show("خیلی هم خوب", "دستیار08");
                                break;
                        }
                        break;
                    case "اسمت":
                        label1.Text = "اسمم کیارش است";
                        break;
                    case "چخبر":
                        label1.Text = "سلامتی";
                        break;
                    case "خوبی":
                    case "حالت جطوره":
                        label1.Text = "الحمدالله " + "\n" + "چون میگذرد غمی نیس";
                        break;
                    case "سلام":
                    case "های":
                    case "علیک سلام":
                        label1.Text = "امرتون";
                        break;
                    case "الو":
                        label1.Text = "در حال باز کردن الو . . .";
                        StartProcess(@"https://allo.google.com/web");
                        break;
                    case "میهن بلاگ":
                        label1.Text = "در حال باز کردن میهن بلاگ . . .";
                        StartProcess(@"http://mihanblog.com/web/signin/index");
                        break;
                    case "کویرا":
                    case "کوئرا":
                        label1.Text = "در حال باز کردن کوئرا . . .";
                        StartProcess(@"https://quera.ir/");
                        break;
                    case "مفشو":
                        label1.Text = "در حال باز کردن مفشو . . .";
                        StartProcess(@"http://mafshoo.mihanblog.com/");
                        break;
                    case "درباره":
                        About_US about_US = new About_US();
                        about_US.ShowDialog();
                        break;
                    case "واتساپ":
                        label1.Text = "در حال باز کردن واتساپ . . .";
                        StartProcess(@"https://web.whatsapp.com/");
                        break;
                    case "گلستان":
                        label1.Text = "در حال باز کردن گلستان . . .";
                        StartProcess(@"http://edu.uk.ac.ir");
                        break;

                    default  :
                        if (!(Command))
                        {
                            Search(Darkhast);
                            Search_Numbers++;
                        }
                          
                        break;
                }
               
                Command = false;

            }
            else if(DS&& !FilmDown&&!MusicDown)
            {
                DS2 = int.Parse(textBox.Text);
               // mediaElement.Source = new Uri(@"H:\Learn\Maktabkhooneh\Data Structures (Abam)\"+DS2.ToString()+".mp4", UriKind.Absolute);
               // play_button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                DS = false;
            }
            
            else if(FilmDown&& !DS&&!MusicDown)
            {
                FD = textBox.Text;
               // MessageBox.Show(test("https://salamdl.info/?s=" + FD));
                List<LinkItem> A = Find_Link("https://salamdl.info/?s=" + FD, FD, out List<LinkItem> items,out sho);
                
               // Reminser_and_findLink.Is_published(FD);
                Links links = new Links(A,val:sho);
                InputLanguageManager.Current.CurrentInputLanguage = new CultureInfo("fa-IR");

                links.Show();
                FilmDown = false;
            }
            else if(!FilmDown && !DS && MusicDown)
            {
                MD = textBox.Text;
                StartProcess("http://pop-music.ir/?blogs=1%2C5&s=" + MD);
                MusicDown = false;
            }
         
           
            All.Add( new Ans (Darkhast, label1.Text.ToString()));

        }
        private static string sho = null;
        private void Play_button_Click(object sender, RoutedEventArgs e)
        {
            if (!Sound)
            {
            // mediaElement.Play();
            }
            else
            {
                mediaPlayer.Play();
            }
           
            
           
        }

        private void Pause_button_Click(object sender, RoutedEventArgs e)
        {
            if (!Sound)
            {
            // mediaElement.Pause();
            }
            else
            {
                mediaPlayer.Pause();
            }
           
        }

        private void Stop_button_Click(object sender, RoutedEventArgs e)
        {
            if (!Sound)
            {
                // mediaElement.Stop();
            }
            else
            {
                mediaPlayer.Stop();
            }
           
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
          
           
          
            try
            {
                this.Width = 770;
            }
            catch { MessageBox.Show("مشکلی پیش آمده لطفا دوباره سعی کنید", "دستیار فارسی 08", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RtlReading); }

        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            try {
                this.Width = 770 * 2;

                dataGrid.ItemsSource = All;
            } catch { MessageBox.Show("مشکلی پیش آمده لطفا دوباره سعی کنید", "دستیار فارسی 08", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RtlReading); }
            
        }

        

        
           


        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter )
            {
                button.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (!Sound)
            { 
              //if( mediaElement.Volume>10)
              //  {
              //        mediaElement.Volume -= 10;
              //  }
              
            }
            else
            {
                mediaPlayer.Volume -= 10;
            }
           
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (!Sound)
            {
                // mediaElement.Volume += 10;
            }
            else
            {
                mediaPlayer.Volume += 10;
            }
           
        }

        private void Play_music_button_Click(object sender, RoutedEventArgs e)
        {
          //  label2.Content = "";
            label1.Text = "درحال  پخش کردن . . .";
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*"
            };
            ;
            if (openFileDialog.ShowDialog() == true)
            {
                
                mediaPlayer.Open(new Uri(openFileDialog.FileName));
                mediaPlayer.Play();
            }
            Sound = true;
        }
       // public static OpenFileDialog openFileDialog;
        string[] Browse(char type)
        {
            OpenFileDialog openFileDialog;
            //openFileDialog = new OpenFileDialog
            //    {
            //      Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV",
            //      Multiselect = true,
            //    };
            if (type == 'v')
            {
                openFileDialog = new OpenFileDialog
                {
                    Filter = "video files (*.mp4,*.mpeg,*.mkv,*.wav)|*.mp4;*.mpeg;*.mkv;*.wav|MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*",
                    Multiselect = false,
                };
                if (openFileDialog.ShowDialog() == true)
                {

                    return openFileDialog.FileNames;
                }
                return default;
            }
            else if (type == 's')
            {
                openFileDialog = new OpenFileDialog
                {
                    Filter = "MP3 files (*.mp3)|*.mp3|video files (*.mp4,*.mpeg,*.mkv,*.wav)|*.mp4;*.mpeg;*.mkv;*.wav|All files (*.*)|*.*",
                    Multiselect = true,
                };
                if (openFileDialog.ShowDialog() == true)
                {

                    return openFileDialog.FileNames;
                }
                return default;
            }
            return default;
        }
        private void Add_Movie_button_Click(object sender, RoutedEventArgs e)
        {

            label1.Text = "درحال گشودن پخش کننده . . .";
            string[] openFileDialog = Browse('v');
            Play_video P = new Play_video(openFileDialog[0]);
            MessageBox.Show("برای راهنمایی کلید 2 در کیبورد ماشین حساب را وارد کنید", "پخش کننده 08", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
            P.mediaElement.Source = new Uri(openFileDialog[0]);
            P.Show();
            P.mediaElement.Play();
              
            
            Close.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          

            PYNotif pYNotif = new PYNotif("Startup");
            InputLanguageManager.Current.CurrentInputLanguage = new CultureInfo("fa-IR");

            Edit_Orders.Fill_List();

           try
            {
                StreamReader S = new StreamReader(@"Reminder.txt");
                string q = S.ReadToEnd();
                var X = q.Split('\n');
                S.Dispose();
                S.Close();
                for (int i = 0; i < X.Length; i++)
                {
                    string[] v = X[i].Split('@');
                    DateTime DA = new DateTime(int.Parse(v[2]), int.Parse(v[3]), int.Parse(v[4]));
                    if (DA - DateTime.Today >= TimeSpan.Zero)
                    {
                        Remember.rem.Add(new Reminder(v[0], DA, v[1]));
                    }
                   
                   
                  
                }
               
            }
            catch(Exception ex)
            {
            //    MessageBox.Show(ex.Message);
            }
           
            for (int i = 0; i < Remember.rem.Count; i++)
            {
                if (DateTime.Today == Remember.rem[i].ReminderDate)
                {
                    PYNotif pyNotif = new PYNotif("Deadline_Of_an_Reminder");

                    reminder = Remember.rem[i];
                    reminder_DeadLine = new Reminder_DeadLine(  reminder );
                    reminder_DeadLine.Closing += Other_Window_Closing;
                    index = i;
                    reminder_DeadLine.Show();
                }
            }
           
            
        }
        public int index;
        public Reminder reminder;
        public Reminder_DeadLine reminder_DeadLine;
        private void Other_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int D = reminder_DeadLine.Days;
            Remember.rem[index].ReminderDate= Remember.rem[index].ReminderDate.AddDays(D);
            Add_Reminder.Save();
        }
       
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InputLanguageManager.Current.CurrentInputLanguage = new CultureInfo("en-US");
            Play_video.WriteToTxtFile<object>("Orders.txt", "");
            for (int index = 0; index < Edit_Orders.orders.Count; index++)
                Play_video.WriteToTxtFile<object>("Orders.txt", Edit_Orders.orders[index].Address + "*" + Edit_Orders.orders[index].Title, true);
            Environment.Exit(0);
        }
        Intionalize_Title_And_Address order_Eror = new Intionalize_Title_And_Address();

        public static string Sho { get => sho; set => sho = value; }

        private void Add_command_Click(object sender, RoutedEventArgs e)
        {
            
            
                order_Eror.Title = "افزودن دستور جدید";
                order_Eror.ok.Content = "افزودن";
                order_Eror.textBlock.Text = "عنوان دستور";
                order_Eror.textBlock1.Text = "ادرس ان";
                order_Eror.ok.Click -= order_Eror.Ok_Click;
                order_Eror.ok.Click += Command_Click;
                order_Eror.Closing -= order_Eror.Window_Closing;
                order_Eror.Closing += Window2_Closing;
                order_Eror.Show();
             Close.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));


        }
        private void Window2_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
           order_Eror.Visibility = Visibility.Hidden;
        }
        bool Is_An_Order(Order a)
        {
            for (int i = 0; i < Edit_Orders.orders.Count; i++)
            {
                if(a.Title == Edit_Orders.orders[i].Title)
                {
                    MessageBox.Show("دستوری با این عنوان موجود است"+"\n\n"+ Edit_Orders.orders[i].ToString(), "ویرایشگر دستیار", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.RtlReading);

                    return true;
                }
                if(a.Address== Edit_Orders.orders[i].Address)
                {
                   MessageBox.Show("دستوری با این مقصد موجود است" + "\n\n" + Edit_Orders.orders[i].ToString(), "ویرایشگر دستیار", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.RtlReading);
                    return true;

                }
            }
            return false;
        }
        private void Command_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order(order_Eror.textBox.Text, order_Eror.openFileDialog.FileName);
            if (!(Is_An_Order(order))&&order.Address!=""&&order.Title!= "" )
            {
                Edit_Orders.orders.Add(order);
                MessageBox.Show("با موفقیت افزوده شد","ویرایشگر دستیار",MessageBoxButton.OK,MessageBoxImage.Information,MessageBoxResult.OK,MessageBoxOptions.RtlReading);
                order_Eror.Hide();
                order_Eror.Close();
            }
          
            else if(order.Address == "")
            {
                MessageBox.Show("مقصدی انتخاب نشده است", "ویرایشگر دستیار", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RtlReading);

            }
            else if(order.Title == "")
            {
                MessageBox.Show("عنوان نمی تواند خالی باشد", "ویرایشگر دستیار", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RtlReading);

            }
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            MainWindow_Closing(null, null);
        }

        private void Ellipse_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AudioPlayer_Click(object sender, RoutedEventArgs e)
        {
            List<string> vs = new List<string>();
            string[] openFileDialog = Browse('s');/*new OpenFileDialog*/
            //{
            //    Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*",
            //      Multiselect=true
            //};
            ;
            if (openFileDialog is null)
            {
                return;
            }
                foreach (var item in openFileDialog)
                {
                    vs.Add(item);
                }
                Persion_Assistant08.Play_Song.Song_Player _Player = new Persion_Assistant08.Play_Song.Song_Player(vs);
                _Player.Show();

            
            Close.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));

        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Open.Visibility = Visibility.Hidden;
            Close.Visibility = Visibility.Visible;

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Open.Visibility = Visibility.Visible;
            Close.Visibility = Visibility.Hidden;

        }
    }
}
