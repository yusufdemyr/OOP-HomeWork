namespace Ödev
{
    interface IYarismaci
    {
        string Isim { get; set; }
        int Konum { get; set; }
        int YarismaciNo { get; set; }
        int HareketEt();
    }
}
