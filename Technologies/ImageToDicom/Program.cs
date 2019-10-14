using System;
using System.IO;

namespace ImageToDicom
{
    class Program
    {
        static void Main(string[] args)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "R_CC.png");
            var dicomPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "dicomSC.dcm");
            Console.WriteLine(imagePath);
            BitmapToDicom.ImportImage(imagePath, dicomPath);
            
            Console.WriteLine($"Complete {dicomPath}");

            Console.ReadKey();
        }
    }
}