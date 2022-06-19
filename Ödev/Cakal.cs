using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ödev
{
    class Cakal : Hayvan
    {
        public override int HareketEt()
        {
   
            // { Koşma,Koşma,Koşma,Yürüme,Yürüme,Yürüme,Yürüme,Yürüme,Kayma,Kayma}
            // Yukarıdan rastgele bir değer seçilecek ve o hareketi gerçekleştirecek.
            // Aynı sınıfa ait oyuncuların farklı hareketler gerçekleştirebilmesi için thread kütüphanesi kullanıldı.

            int Kosma = 3;
            int Yurume = 2;
            int Kayma = -4;
            rng = new int[10] { Kosma, Kosma, Kosma, Yurume, Yurume, Yurume, Yurume, Yurume, Kayma, Kayma };
            Random rnd = new Random();
            int number = rnd.Next(0, 10);
            Thread.Sleep(10);
            
            return rng[number];

        }


        public Cakal(string _isim, int _yarismaciNo)
        {
            Isim = _isim;
            YarismaciNo = _yarismaciNo;
        }

    }
}
