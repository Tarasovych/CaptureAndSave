using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace CaptureAndSave
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            while (true)
            {
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Escape)
                    break;
                if (cki.Key == ConsoleKey.S)
                    using (Bitmap bitmap = new Bitmap(1920, 1080))
                    {
                        using (Graphics g = Graphics.FromImage(bitmap))
                        {
                            g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                        }
                        Console.WriteLine("saving the image...");
                        string name = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
                        bitmap.Save(AppDomain.CurrentDomain.BaseDirectory + "\\" + name + ".jpg", ImageFormat.Jpeg);
                        Console.WriteLine(name + ".jpg has been saved");
                    }
            }
        }
    }
}
