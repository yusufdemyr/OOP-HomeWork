using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ödev
{
    class MekanikFil : Robot
    {
        public override int HareketEt()
        {
            // { Bekleme,Bekleme,Bekleme,Bekleme,Bekleme,Yurume,Yurume,Yurume,Yurume,Kosma}
            // Yukarıdan rastgele bir değer seçilecek ve o hareketi gerçekleştirecek.
            // Aynı sınıfa ait oyuncuların farklı hareketler gerçekleştirebilmesi için thread kütüphanesi kullanıldı.


            int Kosma = 3;
            int Yurume = 2;
            int Bekleme = 0;
            rng = new int[10] { Bekleme,Bekleme,Bekleme,Bekleme,Bekleme,Yurume,Yurume,Yurume,Yurume,Kosma};
            Random rnd = new Random();
            int number = rnd.Next(0, 10);

            Thread.Sleep(10);
            return rng[number];
        }


        public MekanikFil(string _isim, int _yarismaciNo)
        {
            Isim = _isim;
            YarismaciNo = _yarismaciNo;
        }

    }
}
