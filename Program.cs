using gorev4;
using System.Reflection;
using System.Security.Cryptography;

namespace gorev4
{
    internal class Program
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        static void Main(string[] args)
        {
            Uygulama();
         

        }
        static void Uygulama()
        {
            SahteVeri();
            Menu();
            SecimAl();

        }
        static void Menu()
        {

            Console.WriteLine("Öğrenci Yönetim Uygulaması");
            Console.WriteLine("1- Öğrenci Ekle (E)");
            Console.WriteLine("2- Öğrenci Listele (L)");
            Console.WriteLine("3- Öğrenci Sil (S)");
            Console.WriteLine("4- Çıkış (X)");


        }
        static void SahteVeri()
        {
            Ogrenci o1 = new Ogrenci();
            o1.No = 1023;
            o1.Ad = "Ayşe";
            o1.Soyad = "Yılmaz";
            o1.Sube = "A";
            Ogrenci o2 = new Ogrenci();
            o2.No = 1047;
            o2.Ad = "Mehmet";
            o2.Soyad = "Kaya";
            o2.Sube = "B";
            Ogrenci o3 = new Ogrenci();
            o3.No = 1015;
            o3.Ad = "Elif";
            o3.Soyad = "Demir";
            o3.Sube = "A";
            Ogrenci o4 = new Ogrenci();
            o4.No = 1092;
            o4.Ad = "Can";
            o4.Soyad = "Öztürk";
            o4.Sube = "C";

            ogrenciler.Add(o1);
            ogrenciler.Add(o2);
            ogrenciler.Add(o3);
            ogrenciler.Add(o4);

        }
        static void OgrenciEkle()
        {
            Ogrenci o = new Ogrenci();
            
            while (true) 
            {

                Console.WriteLine("1- Öğrenci Ekle ----------");
                Console.WriteLine((ogrenciler.Count + 1) + ".Öğrencinin");
                Console.Write("No: ");
                o.No = int.Parse(Console.ReadLine());
                bool numaraVarmi = false;
                foreach (Ogrenci item in ogrenciler)

                {
                    if (item.No == o.No)
                    {
                        Console.WriteLine("Girdiğiniz numraya ait bir öğrenci mevcut yeniden giriniz.");
                        numaraVarmi = true;
                        break;
                    }

                }
                if(numaraVarmi==false)
                {
                    break;
                }
            } 
            
        
                Console.Write("Ad: ");
                o.Ad = Console.ReadLine().Trim();
                o.Ad = o.Ad.Substring(0, 1).ToUpper() + o.Ad.Substring(1).ToLower();
                Console.Write("Soyad: ");
                o.Soyad = Console.ReadLine().Trim();
                o.Soyad = o.Soyad.Substring(0, 1).ToUpper() + o.Soyad.Substring(1).ToLower();
                Console.Write("Şube: ");
                o.Sube = Console.ReadLine().ToUpper();
                Console.WriteLine();
                Console.Write("Öğrenciyi kaydetmek istediğinize emin misiniz? (E/H)");
                string girilen = Console.ReadLine().ToUpper();
                Console.WriteLine();
                if (girilen == "E")
                {
                    ogrenciler.Add(o);
                    Console.WriteLine("Öğrenci eklendi.");
                }
                else
                {
                    Console.WriteLine("Öğrenci eklenmedi.");
                }
            
        }
             
                 
              
            
           
        
        static void OgrenciSil()
        {

            Console.WriteLine("3- Öğrenci Sil ----------");
            Ogrenci ogr = null;
            foreach (Ogrenci item in ogrenciler)
            {
                if (item != null)
                {
                    ogr = item; break;
                }
                else
                {
                    Console.WriteLine("Silinecek öğrenci bulunamadı.");
                }
            }

            if (ogr != null)
            {
                Console.WriteLine("Silmek istediğiniz öğrencinin");
                Console.Write("No: ");
                int sil = int.Parse(Console.ReadLine());
                foreach (Ogrenci item in ogrenciler)
                {
                    if (item.No == sil)
                    {
                        Console.WriteLine("Adı: " + ogr.Ad);
                        Console.WriteLine("Soyadı: " + ogr.Soyad);
                        Console.WriteLine("Şubesi: " + ogr.Sube);
                        Console.WriteLine();
                        Console.Write("Öğrenciyi silmek istediğinize emin misiniz? (E/H) ");
                        string secilen = Console.ReadLine().ToUpper();
                        Console.WriteLine();
                        if (secilen == "E")
                        {
                            ogrenciler.Remove(ogr);
                            Console.WriteLine();
                            Console.WriteLine("Öğrenci silindi.");
                        }
                        else
                        {
                            Console.WriteLine("Öğrenci silinmedi");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Böyle bir öğrenci bulunamadı.");
                    }
                }

            }
            else
            {

                Console.WriteLine("Listede silinecek öğrenci yok.");
            }





        }
        static void OgrenciListele()
        {
            Ogrenci liste = null;
            foreach(Ogrenci item in ogrenciler)
            {
                    liste = item;break;
            }
            if(liste==null)
            {
                Console.WriteLine("Lİstelenecek öğrenci bulunamadı.");
            }
           
            else
            {
                Console.WriteLine("Öğrenci Listele-----------");
                Console.WriteLine();
                Console.WriteLine("Şube    No    Ad Soyad");
                Console.WriteLine("----------------------------------");

                foreach (Ogrenci item in ogrenciler)
                {

                    Console.WriteLine(item.Sube.PadRight(6) + item.No.ToString().PadRight(6) + item.Ad.PadLeft(2).PadRight(5) + item.Soyad.PadLeft(8));


                }
               
            }
        }
        static void SecimAl()
        {
            int girdi = 10;
            bool cik = true;

            while (cik)
            {
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine().ToUpper();
               
                switch (secim)
                {
                    case "E":
                    case "1":
                        OgrenciEkle();
                        break;
                    case "L":
                    case "2":
                        OgrenciListele();
                        break;
                    case "S":
                    case "3":
                        OgrenciSil();
                        break;
                    case "X":
                    case "5":
                        cik = false;
                        break;
                    default:
                        Console.WriteLine("Hatalı giriş yaptınız:");
                        girdi--;
                        break;


                }
                if (girdi == 0)
                {
                    Console.WriteLine("Üzgünüm sizi anlayamıyorum program sonlandırılıyor.");
                    cik = false;
                }
            }

        }
      
    }
}
