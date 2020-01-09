using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Persion_Assistant08.Play_Song
{
    class Play_List
    {
        static List<Song> playList = new List<Song>();
        public List<Song> PlayList
        {
            get
            {
                return playList;
            }
            set
            {
                playList = value;
            }
        }
        public  void AddSong(Song song)
        {
            playList.Add(song);
        }
        public  void AddSong(Uri uri) => AddSong(new Song(uri));
        public  void RemoveSong(Song song)
        {
            playList.Remove(song);
        }
        public void Clear()
        {
            playList.Clear();
        }
        class PlayListDB
        {
            static List<SaveablePlayList> play_Lists = new List<SaveablePlayList>();
            public static bool  SavePlayList(string playListName,Play_List play_List)
            {
                foreach (var item in play_Lists)
                {
                    if (item.Name == playListName)
                    {
                        return false;
                    }
                }
                play_Lists.Add(new SaveablePlayList (play_List,playListName));
                Save();
                return true;
            }
            public static void Save()
            {
                string playListsJson = JsonConvert.SerializeObject(play_Lists, Formatting.Indented);
                System.IO.StreamWriter streamWriter = new System.IO.StreamWriter("PlayLists.json");
                streamWriter.Write(playListsJson);

            }
             
            public static void RemoveplayList(string playListName)
            {
                foreach (var item in play_Lists)
                {
                    if (item.Name==playListName)
                    {
                        play_Lists.Remove(item);
                    }
                }
                Save();
            }
            public static bool  Load()
            {
                try
                {
                    string Json;
                    using (System.IO.StreamReader sr = new System.IO.StreamReader("PlayLists.json"))
                    {
                        Json = sr.ReadToEnd();
                    }
                    play_Lists = JsonConvert.DeserializeObject<List<SaveablePlayList>>(Json);
                    return true;
                }
                catch 
                {

                    return false;
                }

            }
        }
        class SaveablePlayList
        {
            public SaveablePlayList(Play_List list, string name)
            {
                List = list;
                Name = name;
            }
            public SaveablePlayList()
            {
            }

            public  Play_List List { get; set; }
            public String Name { get; set; }
        }
    }
}
