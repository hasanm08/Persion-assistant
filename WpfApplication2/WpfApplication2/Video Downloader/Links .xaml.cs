using Persion_Assistant08;
using Persion_Assistant08.Toast_Notification;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfApplication2;

namespace Persion_Assistant08.Video_Downloader
{
    /// <summary>
    /// Interaction logic for Links.xaml
    /// </summary>
    public partial class Links : Window
    {
       static int Counter = 0;
        public List<LinkItem> Button_Names { get; set; }
        public  BitmapImage Imag { get; set; }
        string IA = null;
        public string FIlm_Name = null;
        public List<LinkItem> Sub { get; set; }
        string vall = null;
        public Links(List<LinkItem>BN, string IMAGE_SOURCE=null, string Filmn=null ,string val=null)
        {
            InitializeComponent();
            Mouse.OverrideCursor = Cursors.Arrow;
            this.Button_Names = BN;
            
            Sub = MainWindow.Finded_Subtitle;
            vall = val;
            if (Counter==1 )
            {
                TextBlock SHL = new TextBlock
                {
                   Text = vall
                };
                sp.Children.Add(SHL);
              //  MessageBox.Show(vall);
            }
          
            if(Filmn == null)
            {
                this.Title = "لیست فیلم های یافت شده";
            }
            else
            {
                this.Title = "اطلاعات فیلم"+Filmn;
            }
           
            
            try {
                FIlm_Name = Filmn;
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(IMAGE_SOURCE);
                logo.EndInit();
                Film_image.Source = logo;
            } catch { } 
            Counter++;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Scroll.Content = sp;
            if (Button_Names.Count <=0&&Film_image.Source==null&&Counter==2)
            {
                PYNotif pYNotif = new PYNotif("NotFound");
                Close();
            }
            if (Button_Names.Count <= 0 &&  Counter != 2)
            {
                PYNotif pYNotif = new PYNotif("NotFound");
                Close();
            }

            if (Counter > 0)
            {
               for(int i = 0; i < sp.Children.Count; i++)
                {
                    sp.Children.RemoveAt(i);
                }
            }
            if (Counter > 0)
            {
                Image Film_image = new Image
                {
                    Source = Imag,
                    Name = "FilmIm"
                };
            }
            FlowDirection = FlowDirection.RightToLeft;
            for (int i = 0; i < Button_Names.Count; i++)
            {
                {
                    Button newBtn = new Button
                    {
                        Content = Button_Names[i].Text.ToString(),
                        Name = "Button" + i.ToString()
                    ,
                        FontFamily = new System.Windows.Media.FontFamily("Calibri (Body)"),
                        FontSize = 13
                    ,
                        BorderBrush = System.Windows.Media.Brushes.Orange
                    ,
                        Margin = new Thickness(1.76)

                    };

                    newBtn.Click += new RoutedEventHandler(ButtonClickHandler);
                    sp.Children.Add(newBtn);
                }
                    
            }
            
            if (Sub != null)
            {
                for (int i = 0; i < Sub.Count; i++)
                {
                    Button newBtn = new Button
                    {
                        Content = Sub[i].Text.ToString(),
                        Name = "Sub_Button" + i.ToString(),
                        FontFamily = new System.Windows.Media.FontFamily("Calibri (Body)"),
                        FontSize = 13
                    ,
                        BorderBrush = System.Windows.Media.Brushes.Black
                    ,
                        Margin = new Thickness(1.76),
                        Background = System.Windows.Media.Brushes.Orange
                    };
                    
                    newBtn.Click += new RoutedEventHandler(ButtonClickHandler);
                    sp.Children.Add(newBtn);
                }
            }
        }
        int Edit_Name(string A)
        {
         return int .Parse  ( A.Remove(0, 6));
        }

        private void ButtonClickHandler(object sender, RoutedEventArgs e)
        {
           if(Counter==1)
            {
                FIlm_Name = Regex.Replace(Button_Names[sp.Children.IndexOf(sender as UIElement)].Text, "[^A-Z^a-z^0-9^ ^:^-]", "");
            }


            if (Counter == 2)
            {
                int i = sp.Children.IndexOf(sender as UIElement);
                string url=null;
                if (i < Button_Names.Count)
                {
                    url = Button_Names[i].Href;
                }
                else
                {
                    url = Sub[i - Button_Names.Count].Href;
                }
                Process.Start(url);
            }
            if (Counter == 1)
            {
                
                try
                {

                    string url = Button_Names[sp.Children.IndexOf(sender as UIElement)].Href;
                    MainWindow mainWindow = new MainWindow();
                   List<LinkItem> links = mainWindow.Find_Link(url, Regex.Replace(Button_Names[sp.Children.IndexOf(sender as UIElement)].Text.ToString(), @"[^A-Z^a-z^0-9^:^ ]", ""), out List<LinkItem> items,out _);
                    List<LinkItem> linkItemsB = new List<LinkItem>();
                    Image image = new Image();
                    bool founded = false;
                    for (int i = 0; i < links.Count; i++)
                    {
                        if (links[i].Text.ToLower().Contains("720p") || links[i].Text.ToLower().Contains("1080p") || links[i].Text.ToLower().Contains("2160p") || links[i].Text.ToLower().Contains("480p") || links[i].Text.ToLower().Contains("360p"))
                        {
                            linkItemsB.Add(links[i]);
                        }
                        if (links[i].Href.ToLower().Contains(".jpg")&& !founded)
                        {
                            IA= (links[i].Href);
                            founded = true;
                        }

                    }
                   
                    Links Dlinks = new Links(linkItemsB,IA,FIlm_Name,val:vall);
                    Dlinks.Show();
                } catch(Exception ex) { MessageBox.Show(ex.ToString()); }
               
            }
}
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Counter > 0)
            {
                Counter--;
            }
            Button_Names.Clear() ;
            MainWindow.Sho=null;
            Sub.Clear();
        }

        public LinkItem shows
        {
            get => default;
            set
            {
            }
        }
    }
}
