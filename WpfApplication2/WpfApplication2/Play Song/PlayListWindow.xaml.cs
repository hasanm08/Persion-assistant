using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Persion_Assistant08.Play_Song
{
    /// <summary>
    /// Interaction logic for PlayListWindow.xaml
    /// </summary>
    public partial class PlayListWindow : Window
    {
        List<Audio> Audios;
        Song_Player Song_Player;
        public PlayListWindow(List<Audio> audios,Song_Player song_Player)
        {
            InitializeComponent();
            Audios = audios;
            AudioDG.ItemsSource = audios;
            Song_Player = song_Player;
            
            
        }

        private void Ellipse_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            Song_Player.Shown = false;
            this.Close();
        }

        private void AudioDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var cellInfo = AudioDG.SelectedCells[1];
                var content = (cellInfo.Column.GetCellContent(AudioDG.SelectedItem) as System.Windows.Controls.TextBlock).Text;
                //MessageBox.Show(content);
                Song_Player.mediaPlayer.Stop();
                Song_Player.Playing(content);

            }
            catch (Exception ee)
            {

              //  System.Windows.MessageBox.Show(ee.Message);
            }
           
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var cellInfo = AudioDG.SelectedCells[1];
            var content = (cellInfo.Column.GetCellContent(AudioDG.SelectedItem) as System.Windows.Controls.TextBlock).Text;
            foreach (var item in Audios.ToArray())
            {
                if (item.Addres==content)
                {
                    Audios.Remove(item);
                    
                    AudioDG.ItemsSource = Audios;
                    System.Windows.MessageBox.Show("Removed Succesfully");
                }
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string playlist_name= DateTime.Now.ToString("yyyy MM dd hh mm ss");
            string place =System.IO.Path.GetDirectoryName(path: System.IO.Path.GetDirectoryName(Directory.GetCurrentDirectory()))
;
            //    FolderBrowserDialog fileDialog = new FolderBrowserDialog
            //    {
            //        Filter = "All files (*.*)|*.*",
            //        Multiselect = false,
            //        RestoreDirectory=true,
            //        InitialDirectory = System.IO.Path.GetDirectoryName(path: System.IO.Path.GetDirectoryName(Directory.GetCurrentDirectory()))

            //};
                 var dialog = new FolderBrowserDialog();


                DialogResult result = dialog.ShowDialog();
                System.Windows.MessageBox.Show(result.ToString());
            
            //if (fileDialog.ShowDialog() == true)
            //{
                try
                {
                    place = dialog.SelectedPath;

                }
                catch (Exception)
                {
                }
           // }
            using (StreamWriter sw = new StreamWriter(place + @"\" + playlist_name + ".splpa08"))
            {
                sw.Write(JsonConvert.SerializeObject(Audios, Formatting.Indented));
            }
        }
        List<Audio> LoadPl()
        {
            string place = "";
            List<Audio> audios = new List<Audio>();
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Song Playlist files (*.pa08)|*.splpa08",
                Multiselect = false,
                RestoreDirectory = true,
                InitialDirectory = System.IO.Path.GetDirectoryName(path: System.IO.Path.GetDirectoryName(Directory.GetCurrentDirectory()))

            };
            if (fileDialog.ShowDialog() == true)
            {
                try
                {
                    place = fileDialog.FileName;

                }
                catch (Exception)
                {
                }
            }
            if (place!="")
            {
                using (StreamReader sr = new StreamReader(place))
                {
                    audios = JsonConvert.DeserializeObject<List<Audio>>(sr.ReadToEnd());

                }
            }
            List<Audio> audios2 = new List<Audio>();

            foreach (var item in audios)
            {
                if (!(item is null))
                {
                    audios2.Add(item);
                }
            }
            AudioDG.ItemsSource = audios2;
            System.Windows.MessageBox.Show(audios.Count > 0 ? "Loaded Succesfully":"Load Failed");
            return audios;
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            LoadPl();
        }
    }
}
