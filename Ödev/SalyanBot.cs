using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Ödev
{
    class SalyanBot : Robot
    {
        public override int HareketEt()
        {

            int Surunme = 1;
            rng = new int[10] { Surunme, Surunme, Surunme, Surunme, Surunme, Surunme, Surunme, Surunme, Surunme, Surunme };
            Random rnd = new Random();
            int number = rnd.Next(0, 10);

            Thread.Sleep(10);
            return rng[number];
        }


        public SalyanBot(string _isim, int _yarismaciNo)
        {
            Isim = _isim;
            YarismaciNo = _yarismaciNo;

        }

    }
}

