using GaleryApp.Data;
using GaleryApp.Models.Entities;

class Program
{
    //ana metot: Kullanıcı işlem yaparken bir ana metotada ihtiyaç duyar.
    static void Main()
    {
        //program ilk çalıştığında kayıtlarımızı tutacağımız iki farklı dosya oluştur.
        var otomobilRepo = new GenericRepository<Otomobil>("otomobil.json");
        var kamyonetRepo = new GenericRepository<Kamyonet>("kamyonet.json");

        //Kullanıcının CRUD işlemlerini yapabilmesi için ve programı tekrar tekrar çalıştırmamak için kullanıcıyı sürekli ekranda tutmamız gerekir. Bunun için bir döngüye ihtiyaç duyulur. Kullanıcı istemediği sürece program kapanmasın. Bunun için while döngüsü kullanılabilir.
        bool isTrue = true;
        while (isTrue)
        {
            Console.WriteLine("------Galeri Uygulaması--------");
            Console.WriteLine("1- Otomobil Ekle");
            Console.WriteLine("2- Otomobil Listele");
            Console.WriteLine("3- Otomobil Güncelle");
            Console.WriteLine("4- Otomobil Sil\n----------------------");
            Console.WriteLine("5- Kamyonet Ekle");
            Console.WriteLine("6- Kamyonet Listele");
            Console.WriteLine("7- Kamyonet Güncelle");
            Console.WriteLine("8- Kamyonet Sil");
            Console.WriteLine("0- Çıkış");

            Console.Write("Seçiminiz: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var yeniOto = new Otomobil();
                    Console.Write("Marka: ");
                    yeniOto.Marka = Console.ReadLine();
                    Console.Write("Model: ");
                    yeniOto.Model = Console.ReadLine();
                    Console.Write("Yıl: ");
                    //yeniOto.Yil = Convert.ToInt32(Console.ReadLine());
                    yeniOto.Yil = int.Parse(Console.ReadLine());

                    //kullanıcıdan alınan değerleri otomobil.json dosyasına eklemesi için otomobilRepo'yu çağığırıyoruz.
                    otomobilRepo.Create(yeniOto);
                    Console.WriteLine("Otomobil eklendi...");
                    DataSil();
                    break;
                case 2:
                    var otomobiller = otomobilRepo.GetAll();
                    Console.WriteLine("----Otomobiller Listesi---------");
                    foreach (var oto in otomobiller)//otomobiller listesini tek tek gezerek kayıtları ekrana verecek.
                    {
                        Console.WriteLine($"Id: {oto.Id}\nMarka: {oto.Marka}\nModel: {oto.Model}\nYıl: {oto.Yil}");
                    }
                    DataSil();
                    break;
                case 3:
                    Console.WriteLine("Güncellenecek oto Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var guncellenecekOto = otomobilRepo.GetById(id);
                    if (guncellenecekOto != null)
                    {
                        Console.WriteLine("Yeni Marka: ");
                        guncellenecekOto.Marka = Console.ReadLine();
                        Console.WriteLine("Yeni Model: ");
                        guncellenecekOto.Model = Console.ReadLine();
                        Console.WriteLine("Yeni Model: ");
                        guncellenecekOto.Yil = int .Parse(Console.ReadLine());

                        otomobilRepo.Update(guncellenecekOto);
                        Console.WriteLine("İşlem başarılı...");
                    }
                    else
                    {
                        Console.WriteLine("Otomobil bulunamadı!..");
                    }
                    DataSil();
                    break;
                case 4:
                    Console.WriteLine("Silinecek oto Id: ");
                    int silinecekOtoId = Convert.ToInt32(Console.ReadLine());
                    otomobilRepo.Delete(silinecekOtoId);
                    Console.WriteLine("İşlem başarılı...");
                    break;
                case 5:
                    var yeniKamyonet = new Kamyonet();
                    Console.Write("Marka: ");
                    yeniKamyonet.Marka = Console.ReadLine();
                    Console.Write("Model: ");
                    yeniKamyonet.Model = Console.ReadLine();
                    Console.Write("Yıl: ");
                    //yeniOto.Yil = Convert.ToInt32(Console.ReadLine());
                    yeniKamyonet.Yil = int.Parse(Console.ReadLine());
                    Console.Write("Yük Kapasitesi: ");
                    yeniKamyonet.YukKapasitesi = int.Parse(Console.ReadLine());


                    //kullanıcıdan alınan değerleri kamyonet.json dosyasına eklemesi için otomobilRepo'yu çağığırıyoruz.
                    kamyonetRepo.Create(yeniKamyonet);
                    Console.WriteLine("Kamyonet eklendi...");
                    DataSil();
                    break;
                case 6:
                    var kamyonetler = kamyonetRepo.GetAll();
                    Console.WriteLine("----Kamyonetler Listesi---------");
                    foreach (var item in kamyonetler)//otomobiller listesini tek tek gezerek kayıtları ekrana verecek.
                    {
                        Console.WriteLine($"Id: {item.Id}\nMarka: {item.Marka}\nModel: {item.Model}\nYıl: {item.Yil}\nYük Kapasitesi: {item.YukKapasitesi}");
                    }
                    DataSil();
                    break;
                case 7:
                    Console.WriteLine("Güncellenecek kamyonet Id: ");
                    int guncellenecekId = Convert.ToInt32(Console.ReadLine());
                    var guncellenecekKmayonet = kamyonetRepo.GetById(guncellenecekId);
                    if (guncellenecekKmayonet != null)
                    {
                        Console.Write("Yeni Marka: ");
                        guncellenecekKmayonet.Marka = Console.ReadLine();
                        Console.Write("Yeni Model: ");
                        guncellenecekKmayonet.Model = Console.ReadLine();
                        Console.Write("Yeni Yıl: ");
                        guncellenecekKmayonet.Yil = int.Parse(Console.ReadLine());
                        Console.Write("Yeni Yük Kapasitesi: ");
                        guncellenecekKmayonet.YukKapasitesi = int.Parse(Console.ReadLine());

                        kamyonetRepo.Update(guncellenecekKmayonet);
                        Console.WriteLine("İşlem başarılı...");
                    }
                    else
                    {
                        Console.WriteLine("Kamyonet bulunamadı!..");
                    }
                    DataSil();
                    break;
                case 8:
                    Console.WriteLine("Silinecek kamyonet Id: ");
                    int silinecekKamyonetId = Convert.ToInt32(Console.ReadLine());
                    kamyonetRepo.Delete(silinecekKamyonetId);
                    Console.WriteLine("İşlem başarılı...");
                    DataSil();
                    break;
                case 0:
                    Console.WriteLine("Çıkış Yapıldı...");
                    return;//prpogramı sonlandırır.
                default:
                    Console.WriteLine("geçersiz seçim. Tekrar deneyiniz!..");
                    break;//case'den çıkış yapar.

            }
        }
    }
    private static void DataSil()
    {
        Console.WriteLine("Devam etmek için bir tuşa basınız!..");
        Console.ReadKey();
        Console.Clear();
    }
}