using System.IO;

namespace Persion_Assistant08.Toast_Notification
{
    class PYNotif
    {
        public PYNotif(string File)
        {
            switch (File)
            {
                case "Deadline_Of_an_Reminder": { Deadline_Of_an_Reminder(); break; }
                case "Startup": { Startup(); break; }
                case "NotFound": { NotFound(); break; }
                case "Email": { Email(); break; }

            }
        }
        public static void Deadline_Of_an_Reminder()
        {
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = wanted_path + @"\Toast Notification\PyCodes\dist\NotFound\Deadline_Of_an_Reminder.exe";
            process.Start();
        }
        public static void Startup()
        {
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = wanted_path + @"\Toast Notification\PyCodes\dist\NotFound\Startup.exe";
            process.Start();
        }
        public static void NotFound()
        {
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = wanted_path + @"\Toast Notification\PyCodes\dist\NotFound\NotFound.exe";
            process.Start();
        }
        public static void Email()
        {
            string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = wanted_path + @"\Toast Notification\PyCodes\dist\NotFound\Email.exe";
            process.Start();
        }
    }
}
