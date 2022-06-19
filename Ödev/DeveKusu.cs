using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ödev
{
    class DeveKusu : Hayvan
    {
        public bool Paralize { get; set; }

        // Eğer paralize true ise hareket et fonksiyonu çalışmayacak ve olduğu konumda duracaktır.
        public override int HareketEt()
        {
            if(Paralize == true)
            {
                
                return 0;
            }
            else
            {
                // { Kosma, Kosma, Kosma, Kosma, Kosma, HizliKosma, HizliKosma, Kayma, Kayma, Kayma }
                // Yukarıdan rastgele bir değer seçilecek ve o hareketi gerçekleştirecek.
                // Aynı sınıfa ait oyuncuların farklı hareketler gerçekleştirebilmesi için thread kütüphanesi kullanıldı.
                // Diğer türlü sürekli aynı hareketleri yapıyorlar.

                int Kosma = 3;
                int HizliKosma = 6;
                int Kayma = -4;
                rng = new int[10] { Kosma, Kosma, Kosma, Kosma, Kosma, HizliKosma, HizliKosma, Kayma, Kayma, Kayma };
                Random rnd = new Random();
                int number = rnd.Next(0, 10);

                Thread.Sleep(10);
                return rng[number];
            }
        }


        public DeveKusu(string _isim, int _yarismaciNo)
        {
            Isim = _isim;
            YarismaciNo = _yarismaciNo;
        }

    }
}
