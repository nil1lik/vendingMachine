using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //**************************** ÖDEV **********************//
            // Giriş alanında admin girişi yapılırsa ürün ve fiyat bilgileri girilsin
            // Giriş alanında member girişi yapılırsa 
            // dizi ürünler[Kola,bisküvi,çikolata]
            // dizi fiyat[7,3,2]
            // Ürünler ekrana yazdırın. Müşteri ürün adını girerek ürün almak istesin. İstenilen ürün fiyatını ekrana yazdırarak kullanıcıdan para alın ve para üstünü verin
            //  

            int hak = 2;
            double toplam = 0;
            string adminPass = "admin";
            string[] urunler = { "Kola", "Bisküvi", "Çikolata" };
            double[] urunfiyat = { 7, 3, 2 };


        //SORUNLAR: Yeni ürün eklendikten sonra member giriş yapınca otomattan ürün alınmıyo...

        ANAMENU:
            Console.Clear();
            Console.Write("**********GİRİŞ SEÇENEKLERİ**********\n\t1 Admin Girişi\n\t2 Kullanıcı Girişi\n\t3 Çıkış\nSeçim: ");
            string girisSecim = Console.ReadLine();

            if (girisSecim == "1") //admin giriş
            {
                while (hak >= 0) //3 haklı şifre döngüsü
                {
                    Console.Write("Lütfen admin şifrenizi giriniz: ");
                    string adminSifre = Console.ReadLine();

                    if (adminSifre == adminPass) //eğer admin girişi yapılırsa;
                    {
                        Console.Clear();
                        Console.Write("1 Ürün Güncelle\n2 Fiyat Güncelle\n3 Çıkış\nLütfen yapmak istediğiniz işlemi seçiniz: ");
                        string secim = Console.ReadLine();
                        if (secim == "1")
                        {
                            Console.Clear();
                            for (int i = 0; i < urunler.Length; i++)
                            {
                                Console.WriteLine("{0}-{1} ({2} TL)", (i + 1), urunler[i], urunfiyat[i]);
                            }
                            Console.Write("Güncellemek istediğiniz ürünü giriniz: ");
                            int degisim = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Eklemek istediğiniz ürünü giriniz: ");
                            string yeniurun = Console.ReadLine();
                            urunler[degisim - 1] = yeniurun;
                            Console.Clear();
                            Console.WriteLine("Değişim Başarılı.");
                            goto ANAMENU;

                        }
                        else if (secim == "2")
                        {
                            Console.Clear();
                            for (int i = 0; i < urunler.Length; i++)
                            {
                                Console.WriteLine("{0}-{1} ({2} TL)", (i + 1), urunler[i], urunfiyat[i]);
                            }
                            Console.Write("Fiyatını güncellemek istediğiniz ürünü giriniz: ");
                            int degisim = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Yeni fiyatı giriniz: ");
                            double yenifiyat = Convert.ToDouble(Console.ReadLine());
                            urunfiyat[degisim - 1] = yenifiyat;
                            Console.Clear();
                            Console.WriteLine("Değişim Başarılı.");
                            goto ANAMENU;
                        }
                        else if (secim == "3")
                        {
                            Console.WriteLine("Çıkış yapılıyor...");
                            break;
                        }
                    }
                    else if (hak == 0)
                    {
                        Console.Write("Hesaptan çıkış yapılıyor...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Şifreniz yanlıştır. Kalan hakkınız {hak}");
                    }
                    hak--;
                }
            }
            //notepaddeki kullanıcı girşi buraya eklencek
            else if (girisSecim == "2") //member giriş
            {
            BAKIYEGIRIS:
                
                Console.Write("Lütfen bakiye giriniz:");
                double bakiye = Convert.ToDouble(Console.ReadLine());
                Console.Clear();

                for (int i = 0; i < urunler.Length; i++)
                {
                    Console.WriteLine("{0}-{1} {2} TL", (i + 1), urunler[i], urunfiyat[i]);
                }
                Console.Write("Lütfen almak istediğiniz ürünü giriniz: ");
                int urunsecim = Convert.ToInt32(Console.ReadLine());

                if (bakiye < urunfiyat[urunsecim - 1])
                {
                BAKIYEMENU:
                    Console.Clear();
                    Console.WriteLine("Bakiye Yetersiz\n1 Para Ekle\n2 Para İade");
                    string bakiyesecim = Console.ReadLine();

                    if (bakiyesecim == "1")
                    {
                        goto BAKIYEGIRIS;
                    }
                    else if (bakiyesecim == "2")
                    {
                        Console.Clear();
                        Console.WriteLine($"Para iadesi yapılmıştır. İade edilen tutar: {bakiye} TL");
                        Console.WriteLine("Çıkış yapılıyor...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("Hatalı Giriş!!!");
                        goto BAKIYEMENU;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.Write($"Alınan Ürün: {urunler[urunsecim - 1]}\nPara Üstü: {bakiye - (urunfiyat[urunsecim - 1])}\nİyi Günler Dileriz...");
                }

            }
            else if (girisSecim == "3")
            {
                Console.WriteLine("Çıkış yapılıyor...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir değer giriniz.");
                goto ANAMENU;
            }

            Console.ReadLine();
        }
    }
}
