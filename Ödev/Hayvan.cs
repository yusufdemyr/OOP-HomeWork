using System;
using System.Collections.Generic;
using System.Text;

namespace Ödev
{
    abstract class Hayvan : IYarismaci
    {
        private readonly static string isim;
        protected static int[] rng;
        private readonly static int yarismaciNo;
        protected static int yarismaPisti;


        public string Isim { get; set; }
        public int Konum { get; set; }
        public int YarismaciNo { get; set; }

        public abstract int HareketEt();


        public Hayvan()
        {
        }
    }
}   
