using System;
using System.Drawing;
using System.Drawing.Imaging;

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
                        Console.WriteLine("saving the image");

                        string filePath = AppDomain.CurrentDomain.BaseDirectory + "\\img\\";

                        System.IO.FileInfo file = new System.IO.FileInfo(filePath);
                        file.Directory.Create();

                        string name = DateTimeOffset.Now.ToUnixTimeSeconds().ToString()+".jpg";
                        bitmap.Save(filePath + name, ImageFormat.Jpeg);
                        Console.WriteLine(name + " has been saved");
                        Console.WriteLine();
                    }
            }
        }
    }
}
