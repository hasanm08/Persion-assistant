using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Persion_Assistant08.Personalize_Orders
{
    public class Order
    {
        public string Title { get; set; }
        public string Address { get; set; }

        public Intionalize_Title_And_Address Intionalize_Title_And_Address
        {
            get => default;
            set
            {
            }
        }

        public Order(string title, string address)
        {
            Title = title;
            Address = address;
        }
        public static bool operator ==(Order A, Order B)
        {
            if (A.Title == B.Title && A.Address == B.Address)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Order A, Order B)
        {
            return !(A == B);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Order))
            {
                return false;
            }

            var order = (Order)obj;
            return Title == order.Title &&
                   Address == order.Address;
        }

        public override int GetHashCode()
        {
            var hashCode = -1981435388;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Address);
            return hashCode;
        }
        public override string ToString()
        {
            string a = "عنوان" + ":" + "\t" + Title + "\n\n" + "مقصد" + ":" + "\n\n" + Address;
            return a;
        }
    }
    class Edit_Orders
    {
        public static List<Order> orders = new List<Order>();

        public Order_Eror Order_Eror
        {
            get => default;
            set
            {
            }
        }

        public static void Fill_List()
        {


            {
                StreamReader S = new StreamReader(@"Orders.txt");
                string q = S.ReadToEnd();
                var X = q.Split('\n');
                S.Dispose();
                S.Close();
                for (int i = 0; i < X.Length; i++)
                {
                    if (X[i] != "" && X[i] != null)
                    {

                        string[] v = X[i].Split('*');
                        if (v.Length >= 2)
                        {
                            Order order = new Order(System.Text.RegularExpressions.Regex.Replace(v[1], "[\r]", ""), v[0]);
                            orders.Add(order);
                        }

                    }

                }

            }



        }

        public static void Follow_Orders(string input, ref bool c)
        {
            for (int i = 0; i < orders.Count; i++)
            {
               Persion_Assistant08.Play_Video.Play_video.WriteToTxtFile<object>("Orders.txt", orders[i].Address + "*" + orders[i].Title, true);
                if (input == orders[i].Title)
                {
                    StartProcess(orders[i]);
                    c = true;
                    return;
                }
            }
        }
        public static void Edit(Order order, string new_Address = null, string new_Title = null)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i] == order)
                {
                    if (new_Title != null)
                    {
                        orders[i].Title = new_Title;
                    }
                    if (new_Address != null)
                    {
                        orders[i].Address = new_Address;
                    }
                }
            }

        }
        static void StartProcess(Order A)
        {
            try
            {

                ProcessStartInfo StartInformation = new ProcessStartInfo
                {
                    FileName = A.Address
                };

                Process process = Process.Start(StartInformation);

                process.EnableRaisingEvents = true;
            }
            catch
            {
                Order_Eror order_Eror = new Order_Eror(A);
                order_Eror.ShowDialog();
            }

        }

    }

}
