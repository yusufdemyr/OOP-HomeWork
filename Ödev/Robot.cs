using System;
using System.Collections.Generic;
using System.Text;

namespace Ödev
{
    abstract class Robot : IYarismaci
    {
        private static string isim;
        protected static int[] rng;
        private static int yarismaciNo;
        protected static int yarismaPisti;

        protected bool Bozuldu { get; set; }
        public int Konum { get; set; }
        public int YarismaciNo { get; set; }
        public string Isim { get; set; }


        public virtual int HareketEt()
        {
            // Nesnelerin hareketini sağlayacaktır.
            return 0;
        }
        public Robot()
        {

        }
    }
}
