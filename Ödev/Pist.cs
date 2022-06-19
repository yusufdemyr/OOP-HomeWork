using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace Ödev
{
    class Pist
    {
        private object[][] pist;


        public uint PistUzunlugu { get; set; }
        // Yarışma sonucundaki durumları yazdırmayı sağlar. Yazdırma işlemi bittiğinde oyun içeriğini sıfırlar.
        public void DurumuYazdir()
        {
            try
            {
                if (pist[PistUzunlugu] == null) throw new NullReferenceException();
                for (int i = 0; i < PistUzunlugu + 1; i++)
                {
                    if (pist[i] == null) continue;
                    else
                    {
                        int sayac = 1;
                        for (int j = 0; j < pist[0].Length; j++)
                        {
                            if (pist[i][j] == null)
                            {
                                if (j == pist[0].Length - 1 && i > 0) Console.Write("\n");
                                else continue;
                            }
                            else
                            {
                                if (pist[i][j] != null)
                                {
                                    sayac++;
                                }
                                switch (pist[i][j].GetType().Name.ToLower())
                                {
                                    case ("salyanbot"):
                                        SalyanBot Test = pist[i][j] as SalyanBot;
                                        if (sayac > 2) Console.Write($" :: {Test.YarismaciNo}, {Test.Isim}");
                                        else Console.Write($"{i}  :: {Test.YarismaciNo}, {Test.Isim}");
                                        break;
                                    case ("devekusu"):
                                        DeveKusu Test2 = pist[i][j] as DeveKusu;
                                        if (sayac > 2) Console.Write($" :: {Test2.YarismaciNo}, {Test2.Isim}");
                                        else Console.Write($"{i}  :: {Test2.YarismaciNo}, {Test2.Isim}");
                                        break;
                                    case ("cakal"):
                                        Cakal Test3 = pist[i][j] as Cakal;
                                        if (sayac > 2) Console.Write($" :: {Test3.YarismaciNo}, {Test3.Isim}");
                                        else Console.Write($"{i}  :: {Test3.YarismaciNo}, {Test3.Isim}");
                                        break;
                                    case "mekanikfil":
                                    case "mekanıkfıl":
                                        MekanikFil Test4 = pist[i][j] as MekanikFil;
                                        if (sayac > 2) Console.Write($" :: {Test4.YarismaciNo}, {Test4.Isim}");
                                        else Console.Write($"{i}  :: {Test4.YarismaciNo}, {Test4.Isim}");
                                        break;
                                    default:
                                        break;
                                }

                            }
                            if (j == pist[0].Length - 1 && i > 0)
                            {
                                if (pist[i][j] == null) continue;
                                Console.Write("\n");
                            }
                        }
                    }
                }
                for (int i = 0; i < PistUzunlugu; i++)
                {
                    if (pist[i] == null) continue;
                    else pist[i] = null;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Yarışma başlamadığından dolayı yarışma bitirilemedi."); 
            }
        }
        // Konum güncellenmeden önceki veya güncellemeden sonraki yarışmacıların konumlarını ekrana yazdırır.
        public void KonumdakiYarismacilar()
        {
            for (int i = 0; i < PistUzunlugu + 1; i++)
            {
                if (pist[i] == null) continue;
                else
                {
                    for (int j = 0; j < pist[0].Length; j++)
                    {
                        if (pist[i][j] == null) continue;
                        else
                        {
                            switch (pist[i][j].GetType().Name.ToLower())
                            {
                                case ("salyanbot"):
                                    SalyanBot Test = pist[i][j] as SalyanBot;
                                    Console.WriteLine($"{i}.konumdaki {j}.oyuncu = {Test.YarismaciNo}, {Test.Isim}");
                                    break;
                                case ("devekusu"):
                                    DeveKusu Test2 = pist[i][j] as DeveKusu;
                                    Console.WriteLine($"{i}.konumdaki {j}.oyuncu = {Test2.YarismaciNo}, {Test2.Isim}");
                                    break;
                                case ("cakal"):
                                    Cakal Test3 = pist[i][j] as Cakal;
                                    Console.WriteLine($"{i}.konumdaki {j}.oyuncu = {Test3.YarismaciNo}, {Test3.Isim}");
                                    break;
                                case "mekanikfil":
                                case "mekanıkfıl":
                                    MekanikFil Test4 = pist[i][j] as MekanikFil;
                                    Console.WriteLine($"{i}.konumdaki {j}.oyuncu = {Test4.YarismaciNo}, {Test4.Isim}");
                                    break;
                                default:
                                    break;
                            }

                        }

                    }
                }
            }
        }
        
        // Yarışma sırasında yarışmacıların hareketi burada gerçekleşitirilir. Konum güncelle fonksiyonu olmadan
        // yarışma çalışmaz.
        public void KonumGuncelle()
        {
            try
            {
                if (pist[0][0] == null) throw new NullReferenceException();
                else
                {
                    int[] degerler = new int[pist[0].Length];
                    bool flag = false;
                    int turSayisi = 1;
                    Random rnd = new Random();
                    int value = 0;
                    int value2 = 0;
                    int value3 = 0;
                    do
                    {
                        try
                        {
                            for (int i = 0; i < pist[0].Length; i++)
                            {
                                switch (pist[0][i].GetType().Name.ToLower())
                                {
                                    case "cakal":
                                        Cakal test = pist[0][i] as Cakal;
                                        degerler[i] += test.HareketEt();
                                        do { degerler[i] += test.HareketEt(); } while (degerler[i] < 0);
                                        break;
                                    case "devekusu":
                                        DeveKusu test1 = pist[0][i] as DeveKusu;
                                        if (test1.Paralize != true)
                                        {
                                            degerler[i] += test1.HareketEt();
                                            do { degerler[i] += test1.HareketEt(); } while (degerler[i] < 0);
                                        }
                                        else continue; //Console.WriteLine("DeveKusu Paralize.");
                                        break;
                                    case "mekanikfil":
                                    case "mekanıkfıl":
                                        MekanikFil test2 = pist[0][i] as MekanikFil;
                                        degerler[i] += test2.HareketEt();
                                        break;
                                    case "salyanbot":
                                        SalyanBot test3 = pist[0][i] as SalyanBot;
                                        degerler[i] += test3.HareketEt();
                                        break;
                                    default:
                                        continue;
                                }
                            }

                            //Console.WriteLine($"{turSayisi}.Tur Sona Erdi ve Yeni Tur Başlıyor");

                            // Yarışma esnasında oluşan özel durumlar burada tanımlı.
                            for (int i = 0; i < degerler.Length; i++)
                            {
                                for (int j = 0; j < degerler.Length; j++)
                                {

                                    if (degerler[i] == degerler[j])
                                    {

                                        if ((pist[0][i].GetType().Name.ToLower() == "cakal"
                                            && pist[0][j].GetType().Name.ToLower() == "devekusu") && (value2 != 1 || value != 1))
                                        {
                                            DeveKusu test = pist[0][j] as DeveKusu;
                                            if (test.Paralize != true)
                                            {
                                                //Değeri sabit kalacak %50 ihtimalle.
                                                value = rnd.Next(1, 3);

                                                if (value == 1)
                                                {
                                                    test.Paralize = true;
                                                    //Console.WriteLine("DeveKusu, Çakal tarafından paralize edildi.");
                                                }
                                                //deve kuşu hiç hareket etmeyecek.
                                            }
                                            else continue;
                                        }
                                        else
                                        {
                                            if (((pist[0][i].GetType().Name.ToLower() == "mekanıkfıl"
                                            || pist[0][i].GetType().Name.ToLower() == "mekanikfil")
                                            && pist[0][j].GetType().Name.ToLower() == "devekusu") && (value != 1 || value2 != 1))
                                            {
                                                //Değeri sabit kalacak %20 ihtimalle. 1-4 arasında rakam seçilir
                                                //seçilen rakam 1 ise paralize olacaktır.
                                                DeveKusu test = pist[0][j] as DeveKusu;
                                                if (test.Paralize != true)
                                                {
                                                    value2 = rnd.Next(1, 6);

                                                    if (value2 == 1)
                                                    {
                                                        test.Paralize = true;
                                                        //Console.WriteLine("DeveKusu, MekanikFil tarafından paralize edildi.");
                                                    }
                                                }
                                                else continue;
                                                //deve kuşu hiç hareket etmeyecek.
                                            }
                                            else
                                            {
                                                // Eğer salyanbot ile hayvan sınıfına ait başka bir nesne aynı konumdaysa
                                                // hayvan sınıfındaki nesnenin hareket değeri bir düşürülür yani bir geri gider.
                                                if (pist[0][i].GetType().Name.ToLower() == "salyanbot"
                                                && pist[0][j].GetType().BaseType.Name.ToLower() == "hayvan")
                                                {
                                                    value3 = rnd.Next(1, 5);
                                                    if (value3 == 1)
                                                    {
                                                        degerler[j] = (degerler[j] - 1);
                                                        //Console.WriteLine($"Salyanbot {pist[0][j].GetType().Name}'e çarptı.");
                                                    }
                                                }
                                            }

                                        }

                                    }
                                }
                            }
                            // Eğer herhangi bir değer pist uzunluğuna ulaşmışsa yarışmayı durdurur.
                            for (int i = 0; i < degerler.Length; i++)
                            {
                                //Console.WriteLine(degerler[i]);
                                if (degerler[i] == pist.Length || degerler[i] >= pist.Length)
                                {
                                    flag = true;
                                }
                            }
                            turSayisi++;
                        }
                        catch
                        {
                            continue;
                        }
                    } while (!flag);




                    int deger = 0;
                    int deger2 = 0;

                    // Yarışma sonu pist çizgisini geçen ilk kişinin değerini pistUzunluğunu geçmeyecek şekilde eşitler.
                    // Aynı şekilde yarışma bittiğinde başlangıç çizgisinden geriye doğru gidilemeyeceği için onları başlangıçtaymış
                    // gibi gösterir.
                    for (int j = 0; j < degerler.Length; j++)
                    {
                        if (degerler[j] > PistUzunlugu)
                        {
                            deger = degerler[j];
                            do
                            {
                                deger--;

                            } while (deger != PistUzunlugu);
                            degerler[j] = deger;
                        }
                        if (degerler[j] < 0)
                        {
                            deger2 = degerler[j];
                            do
                            {
                                deger2++;

                            } while (deger != 0);
                            degerler[j] = deger2;
                        }
                    }


                    // Yarışma sonunda her yarışmacı için bulundukları konumlara ait alan ayrılır.
                    for (int i = 0; i < degerler.Length; i++)
                    {
                        pist[degerler[i]] = new object[degerler.Length];
                    }
                    // Ayrılan bu alanlara yarışmacılar yerleştirilir.
                    for (int i = 0; i < degerler.Length; i++)
                    {
                        pist[degerler[i]][i] = pist[0][i];
                    }
                    int index = 0;
                    // Yarışma bittiğinde bu alanlardaki yarışmacılar silinir.
                    foreach (var s in degerler)
                    {
                        if (s != 0) pist[0][index] = null;
                        else continue;
                        index++;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"Yarışmacı olmadan yarışma başlayamaz.");
            }
            
        }

        // Dosyadan okunan yarışmacıların nesnelerini başlangıç pozisyonunda oluşturur.
        public void YarismaciEkle(string[] yarismacilar)
        {

            int[] yarismaciNumaralari = new int[yarismacilar.Length];
            string[] yarismaciAdlari = new string[yarismacilar.Length];
            string[] yarismaciTurleri = new string[yarismacilar.Length];
            object[] oyuncular = new object[yarismacilar.Length];



            // Yarışmacıların özel olarak değerlerine erişebilmek için parçalara ayrılır.
            for (int j = 0; j < yarismacilar.Length; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    string[] subs = yarismacilar[j].Split(' ');
                    yarismaciNumaralari[j] = Int32.Parse(subs[0]);
                    yarismaciAdlari[j] = subs[1];
                    yarismaciTurleri[j] = subs[2];
                }
            }


            // oyuncular dizisine yarışmacıların türlerine göre nesneler oluşturur
            for (int i = 0; i < yarismacilar.Length; i++)
            {
                if (yarismaciTurleri[i].ToLower() == "cakal") { oyuncular[i] = new Cakal(yarismaciAdlari[i], yarismaciNumaralari[i]); }
                else if (yarismaciTurleri[i].ToLower() == "mekanikfil" || yarismaciTurleri[i].ToLower() == "mekanıkfıl") { oyuncular[i] = new MekanikFil(yarismaciAdlari[i], yarismaciNumaralari[i]); }
                else if (yarismaciTurleri[i].ToLower() == "salyanbot") { oyuncular[i] = new SalyanBot(yarismaciAdlari[i], yarismaciNumaralari[i]); }
                else if (yarismaciTurleri[i].ToLower() == "devekusu") { oyuncular[i] = new DeveKusu(yarismaciAdlari[i], yarismaciNumaralari[i]); }
            }

            // Oluşturulan oyuncular başlangıç çizgisine yerleştirilir.
            pist[0] = new object[oyuncular.Length]; // Tekrardan başladığında yeterli alan olması için gerekli.
            for (int i = 0; i < oyuncular.Length; i++)
            {
                pist[0][i] = oyuncular[i];

            }
            //foreach (var k in pist[0]) { Console.WriteLine(k); }



        }

        public Pist(int yarismaciSayisi,uint _pist)
        {
            PistUzunlugu = _pist;
            pist = new object[PistUzunlugu+1][];
            // Başlangıç cizgisine oyuncuları eklemek için yeterli alan oluşturmalıyız.
            pist[0] = new object[yarismaciSayisi];
            

        }

        
    }
}
