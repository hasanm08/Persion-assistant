using System;
using System.Collections.Generic;
using static System.Windows.MessageBox;
using static System.Text.RegularExpressions.Regex;
using WpfApplication2;
using Persion_Assistant08.Video_Downloader;

namespace Persion_Assistant08.Reminder
{
    class A_Reminder_That_FindLink
    {
        ///<summary>
        ///<para>this method work for unpublished movies but wont diagnose published</para>
        ///<para>مرحله دوم طی نمیشه </para>
        ///</summary>
        public static bool Is_published(string Reminder_Film_Name)
        {

            try
            {
                MainWindow mainWindow = new MainWindow();
                List<LinkItem> b = new List<LinkItem>();
                List<LinkItem> dynamic = mainWindow.Find_Link(("https://salamdl.info/?s=" + Reminder_Film_Name), Reminder_Film_Name, links: out b,out _);

                //
                List<LinkItem> linkItems = new List<LinkItem>();


                string s = Replace(input: dynamic[0].Text, pattern: @"[ ]", replacement: "-");
                s = Replace(input: dynamic[0].Text.ToString(), pattern: @"[^A-Z^a-z]", replacement: "");
                string s2 = Replace(s, @"(\p{Lu})", " $1").TrimStart();

                string d = Replace(s2, @"[ ]", "-");
                List<LinkItem> linkItemsB = new List<LinkItem>();
                linkItems = mainWindow.Find_Link(dynamic[0].Href, s2.ToLower(), links: out b,out _);
                var links = mainWindow.Find_Link(linkItems[0].Href, s2.ToLower(), out _,out _);
                linkItems = links;
                List<LinkItem> temp = new List<LinkItem>(), IsnotTrailer = new List<LinkItem>();
                for (int i = 0; i < links.Count; i++)
                {
                    Show(links[i].ToString());
                    System.Diagnostics.Process.Start(links[i].Href);
                    // Show((links[i].Text.ToLower().Contains("720p") || links[i].Text.ToLower().Contains("1080p") || links[i].Text.ToLower().Contains("2160p") || links[i].Text.ToLower().Contains("480p") || links[i].Text.ToLower().Contains("360p")).ToString());
                    if (links[i].Text.ToLower().Contains("720p") || links[i].Text.ToLower().Contains("1080p") || links[i].Text.ToLower().Contains("2160p") || links[i].Text.ToLower().Contains("480p") || links[i].Text.ToLower().Contains("360p"))
                    {
                        linkItemsB.Add(links[i]);
                    }
                }
                for (int i = 0; i < linkItemsB.Count; i++)
                {
                    Show(linkItemsB[i].ToString());
                    //System.Diagnostics.Process.Start(linkItemsB[i].Href);
                    if (linkItemsB[i].Href.ToLower().Contains(d.ToLower()))
                    {
                        temp.Add(linkItemsB[i]);
                    }
                }
                linkItemsB = temp;

                for (int i = 0; i < linkItemsB.Count; i++)
                {
                    if ((linkItemsB[i].Text.IndexOf(value: "تریلر")) == -1)
                    {
                        IsnotTrailer.Add(linkItemsB[i]);
                    }
                }
                if (IsnotTrailer.Count > 1)
                {
                    Show("yeeeeeeeeeeah");
                    return true;
                }
                Show("Nooooooooooooo"); return false;
            }
            catch (Exception e)
            {

                Show(e.ToString());
                Show("EEEEEEEEEEEEEEEEEEE");
                return false;
            }

        }
    }

}
