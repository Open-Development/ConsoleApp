using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /*
     camelCase : phoneBook
     PascalCase : PhoneBook
    */

    class Program //Class isimleri PascalCase
    {
        private static List<IPhoneBook> RegistretedNummbers = new List<IPhoneBook>(); //Genel  degiskenleri PascalCase'e gore isimlendiriyoruz.

        static void Main(string[] args)
        {
            bool continueToWorking = true; //yerel degiskenlerde CamelCase kullaniyoruz.

            do
            {
                Console.WriteLine("\n --------------------------------------------------");
                Console.WriteLine("-Mevcut kayitlari goruntelemek icin S'ye basin.");
                Console.WriteLine("-Yeni kayit eklmek icin A'ya basin.");
                Console.WriteLine("-Programi sonlandirmak icin C'ya basin.");
                Console.WriteLine("-------------------------------------------------- \n");

                var userInput = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();//Bos satir eklemek icin.

                switch (userInput)
                {
                    case 'S':
                        ShowAllRecords();
                        break;
                    case 'A':
                        RegisterNewNumber();
                        break;                    
                    case 'C':
                        continueToWorking = false;
                        break;
                    default:
                        Console.WriteLine("Yanlis girdi!");
                        break;
                }

            } while (continueToWorking);

        }

        private static void ShowAllRecords()
        {
            if (RegistretedNummbers.Any())
            {
                Console.WriteLine("All registrated phone numbers; \n");

                foreach (var item in RegistretedNummbers)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Phone Book is empty!");
            }
        }

        private static void RegisterNewNumber()
        {
            Console.WriteLine("Add New Record; \n");

            PhoneBook newRec = new PhoneBook();// yerel gecici bir degisken oldugu icin CamelCase 

            Console.Write("Enter name of phone numer owner:");
            newRec.Name = Console.ReadLine();

            Console.Write("\nPhone number:");
            newRec.PhoneNumber = Console.ReadLine(); //Herhangi bir kontrol yapmadim. Telefon numarasi formati disinda da girdi olabilir. Eger kontrol etmek istenirse Regex ile kolayca kontrol edilip uyari veya hata kullaniciya gosterilebilir.

            if (AddItemToList(newRec))
                Console.WriteLine("Yeni kayit basari ile eklendi!");
            else
                Console.WriteLine("Yeni kayit eklenemedi!");
        }

        private static bool AddItemToList(IPhoneBook rec) //Fonkso=iyon isimlerini PascalCase, parametre isimlerini CamelCase gore isimlendiriyoruz.
        {
            if (rec == null && rec.Name.Length <= 0 && rec.PhoneNumber.Length <= 0)
                return false;

            rec.Id = RegistretedNummbers.Any() ? RegistretedNummbers.Select(s => s.Id).OrderBy(o => o).SingleOrDefault() + 1 : 1;

            RegistretedNummbers.Add(rec);

            return true;
        }
    }

    /*
     
    Degisken ve class isimleri disinda eger bir Interface yaziyorsak ismine 'I' ile basliyoruz. Ornek olarak IPhoneBook, sadece ornek olsun diye yazdim, aslinda bu proje icin interface gereksiz.
    CamelCase ve PascalCase disinda isimlendirme yaparken ozellikte kitapta anlatilan WinForm projelerinde componentlere isim verirken; eger bir Button ise 'Btn' ile isme basliyoruz.
        Ornet BtnSave, BtnEdit, TxtName, ListMain, TxtDescription gibi. Eger button1, button2 gibi isimlendirince proje buyudukce sayilarida arttigi icin kod yazarken button1 isminden o buttonun ne yaptigi anlasilmiyor. Her seferinde kontrol etmek gerekiyor, ve hatali kullanma ihtimalide doguyor. Bu nedenle isimlerin okunakli ilgili objenin ne icin oldugu hakkinda bilgi vermesi onemli. 

    */
}
