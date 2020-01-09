using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace Persion_Assistant08.Video_Downloader
{
    public class LinkItem
    {
        public string Href { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return Href + "\n\t" + Text;
        }

    }
    //public class textItem
    //{
      
    //    public string Text { get; set; }

    //    public override string ToString()
    //    {
    //        return  Text;
    //    }

    //}

    static class LinkFinder
    {
        public static LinkItem Links
        {
            get => default;
            set
            {
            }
        }

        public static List<LinkItem> Find(string file)
        {
            List<LinkItem> list = new List<LinkItem>();
            // 1.
            // Find all matches in file.
            MatchCollection m1 = Regex.Matches(file, @"(<a.*?>.*?</a>)",
                RegexOptions.Singleline);

            // 2.
            // Loop over each match.
            foreach (Match m in m1)
            {
                string value = m.Groups[1].Value;
                LinkItem i = new LinkItem();

                // 3.
                // Get href attribute.
                Match m2 = Regex.Match(value, @"href=\""(.*?)\""",
                    RegexOptions.Singleline);
                if (m2.Success)
                {
                    i.Href = m2.Groups[1].Value;
                }

                // 4.
                // Remove inner tags from text.
                string t = Regex.Replace(value, @"\s*<.*?>\s*", "",
                    RegexOptions.Singleline);
                i.Text = t;

                list.Add(i);
            }
            return list;
        }
    }
    //static class textFinder
    //{
    //    public static List<textItem> Find(string file)
    //    {
    //        List<textItem> list = new List<textItem>();
    //        MatchCollection m1 = Regex.Matches(file, @"(<p>"+ "<span style=" + "\"color: #800080\"" + "><strong>خلاصه داستان :</strong></span>" + ".*?</p>)",

    //            RegexOptions.Singleline);
    //        foreach (Match m in m1)
    //        {
    //            string value = m.Groups[1].Value;
    //            textItem i = new textItem();
    //            Match m2 = Regex.Match(value, @"<span style="+"\"color: #800080\""+"><strong>خلاصه داستان :</strong></span>"+".*?",
    //                RegexOptions.Multiline);
    //           value= Regex.Replace(value, "[A-Za-z<>/#=0-9\"&;]", "");
    //            value = Regex.Replace(value, "[:]", " ");
    //           // int ins = 0;
    //            int VL = value.Length;
    //            value= Adding_New_Line( value);
    //            if (value !=""&&value !=null)
    //            {
    //                i.Text = value;
    //                list.Add(i);

    //            }
    //            MatchCollection matchList = Regex.Matches(value, @"<span style=" + "\"color: #800080\"" + "><strong>خلاصه داستان :</strong></span>.*?", RegexOptions.Multiline);
    //        }
    //        return list;
    //    }
    //   static string Adding_New_Line( string newline)
    //    {
    //        StringBuilder sb = new StringBuilder(newline);
    //        int spaces = 0;
    //        int length = sb.Length;
    //        for (int i = 0; i < length; i++)
    //        {
    //            if (sb[i] == ' ')
    //            {
    //                spaces++;
    //            }
    //            if (spaces == 9)
    //            {
    //                sb.Insert(i,System. Environment.NewLine);
    //                break;
    //                //spaces = 0; //if you want to insert new line after each 9 words
    //            }

    //        }
          
    //        return  sb.ToString();
    //    }
    //}

}
