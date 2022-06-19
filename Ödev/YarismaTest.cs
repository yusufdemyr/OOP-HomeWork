using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ödev
{
    class YarismaTest
    {
        static void Main(string[] args)
        {

            Yarisma testYarismasi = new Yarisma("yarismacilar.txt", 45);

            testYarismasi.Baslat();

            testYarismasi.KonumlariYazdir();
           


            Console.Write("\n\nYENİDENA\n\n\n");

            Yarisma testYarismasi2 = new Yarisma("yarismacilar2.txt", 60);
            testYarismasi2.Baslat();
            testYarismasi2.KonumlariYazdir();

            Console.ReadKey();
        }
    }
}
