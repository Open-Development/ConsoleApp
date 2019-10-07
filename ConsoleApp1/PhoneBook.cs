using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Konsoldan girilen verinin saklanacagi classimiz, bu class ile degisken olusturacagiz.
    public class PhoneBook : IPhoneBook
    {
        public int Id { get; set; } 
        public string Name { get; set; } //Kisi adi
        public string PhoneNumber { get; set; } //Telefon numarasi

        public override string ToString()
        {
            return "ID: [" + Id.ToString() + "] Name: " + Name + " Phone: " + PhoneNumber + " |";
        }
    }

    public interface IPhoneBook
    {
        int Id { get; set; }
        string Name { get; set; } 
        string PhoneNumber { get; set; }
    }
}
