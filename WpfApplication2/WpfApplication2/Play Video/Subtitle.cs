using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Persion_Assistant08.Play_Video
{
    public class Subtitle
    {
        public string text;
        public int number;
        public string start;
        public string end;
        public static TimeSpan Start;
        public static TimeSpan End;
        public static TextBlock final_Text = new TextBlock();
        public static List<Subtitle> Sub = new List<Subtitle>();
        public static List<Ti> X = new List<Ti>();


        public Subtitle(string text, int number, string start, string end)
        {
            this.text = text;
            this.number = number;
            this.start = start;
            this.end = end;
        }

        public Ti Timing
        {
            get => default;
            set
            {
            }
        }

        static public void Subload(string path)
        {
            string sub = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    sub = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            List<string> subs = sub.Split(new string[] { "-->" }, StringSplitOptions.None).ToList<string>();
            List<Subtitle> subtitles = new List<Subtitle>();

            for (int k = 1; k < subs.Count() - 1; k++)
            {
                string text = Gettext(subs[k]);
                string start = Lines(subs[k - 1])[Lines(subs[k - 1]).Count() - 1];
                string end = Lines(subs[k])[0];
                int num = Convert.ToInt32(Lines(subs[k - 1])[Lines(subs[k - 1]).Count() - 2]);

                Sub.Add(new Subtitle(text, num, start, end));
                Start = new TimeSpan();
                End = new TimeSpan();
                Show(text, start, end);
                subtitles.Add(new Subtitle(text, num, start, end));
            }

            int i = subs.Count() - 1;
            string laststart = Lines(subs[i - 1])[Lines(subs[i - 1]).Count() - 1];
            string lastend = Lines(subs[i])[0];
            int lastnum = Convert.ToInt32(Lines(subs[i - 1])[Lines(subs[i - 1]).Count() - 2]);
            string lasttext = "";
            List<string> line = Lines(subs[subs.Count() - 1]);
            for (int j = 1; j < line.Count; j++)
            {
                lasttext += line[j];
            }
            subtitles.Add(new Subtitle(lasttext, lastnum, laststart, lastend));
        }
        private static List<string> Lines(string str)
        {
            return str.Split(new string[] { "\n" }, StringSplitOptions.None).ToList<string>();
        }

        private static string Gettext(string str)
        {
            string text = "";
            List<string> line = Lines(str);
            for (int i = 1; i < line.Count - 3; i++)
            {
                text += line[i];
            }
            //  h = text;

            return text;
        }

        public static void Show(string Text, string From, string To)//,out TimeSpan Start, out TimeSpan End)
        {
            Ti x = new Ti();

            //TextBlock j= new TextBlock() ;

            var A = From.Split(',');

            var B = A[0].Split(':');

            TimeSpan Start2 = new TimeSpan(0, int.Parse(B[0]), int.Parse(B[1]), int.Parse(B[2]), int.Parse(A[1]));

            x.Start = Start2;

            var C = To.Split(',');

            var D = C[0].Split(':');

            TimeSpan End2 = new TimeSpan(0, int.Parse(D[0]), int.Parse(D[1]), int.Parse(D[2]), int.Parse(C[1]));
            x.End = End2;
            X.Add(x);
            //j.Text = Text;


            //  return Text;

        }
    }
    public class Ti
    {
        public TimeSpan Start;
        public TimeSpan End;
    }

}
