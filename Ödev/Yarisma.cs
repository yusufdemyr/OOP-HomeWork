using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ödev
{
    class Yarisma
    {
        private string[] yarismacilar;
        private Pist yarismaPisti;

        // Yarışmayı başlatır.
        public void Baslat()
        {
            yarismaPisti.YarismaciEkle(yarismacilar);
            yarismaPisti.KonumGuncelle();
            //yarismaPisti.KonumdakiYarismacilar();

        }
        // Yarışma başlatılmadan konumlar yazılamaz.
        public void KonumlariYazdir()
        {
            yarismaPisti.DurumuYazdir();
        }

        // Dosyadan oyuncu listesi okunur ve yarışmanın uzunluğu parametre şeklinde alınır.
        public Yarisma(string file, uint _pistUzunlugu)
        {
            // yarışmacılar dizisine yarışmacılar kadar boyut tahsis edilir.Eğer dosyada boşluk varsa onun için
            // boyut arttırmaz.
            string[] text = File.ReadAllLines(file);
            
            int size = 0;
            for (int i = 0; i < text.Length; i++)
            {
                yarismacilar = new string[size];
                if (text[i] == "") continue;
                else
                {
                    size++;
                }
            }
            // eğer dosyada boşluklar varsa onları diziye eklemeden sadece yarışmacıları kapsayacak şekilde
            // diziye ekler.
            for (int i = 0; i < text.Length; i++)
            {
                
                if (text[i] == "") continue;
                else
                {
                    yarismacilar[i] = text[i];
                }
            }

            Pist _yarismaPisti = new Pist(yarismacilar.Length, _pistUzunlugu);
            yarismaPisti = _yarismaPisti;

            //foreach (var s in yarismacilar) Console.WriteLine(s);

        }
    }
}
