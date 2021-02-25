using Business.Abstract;
using Business.Concrete;
using Bussines.Concrete;
using DataAcces.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Araba Kiralama Servisimize Hosgeldiniz\nLütfenAşağıdaki Seçenlerden Birini Seçiniz.\nKullanıcı Ekleme-1\nMusteri Ekleme-2\nKiralama -3");
            int okunanDeger = Convert.ToInt32(Console.ReadLine());

            switch (okunanDeger)
            {
                case 1:
                    userManager.Add(AddUser(userManager));
                    break;
                case 2:
                    customerManager.Add(AddCustomer(customerManager));
                    break;
                case 3:
                    rentalManager.Add(AddRental(rentalManager,carManager,customerManager));
                    break;
                case 4:
                    break;
                case 5:
                    ArabalarıListele(carManager);
                    break;
                default:
                    break;
            }
            
            Console.ReadKey();
        }

        private static void ArabalarıListele(CarManager carManager)
        {
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car);
            }
        }

        private static Rental AddRental(RentalManager rentalManager,CarManager carManager,CustomerManager customerManager)
        {
            Console.WriteLine("Varolan Kiralama Işlemleri Llisteleniyor..");
            foreach (var item in rentalManager.GetAll().Data)
            {
                Console.WriteLine($"\nKiralanan Araba :{carManager.GetById(item.CarId).Data.Name}\nŞirket Adı : {customerManager.GetById(item.CustomerId).Data.CompanyName}\nKiralama Başlangıç Tarihi : {item.RentDate}\n Kiralama Bitiş Tarihi : {item.ReturnDate}");
            }
            Console.WriteLine("\nSırasıyla Bilgileri Giriniz:\nCarID giriniz : ");
            int carId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Müşteri ID Giriniz : ");
            int customerId= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kiralama Tarihini giriniz : ");
            DateTime rentDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Geri Getireceğiniz Tarihi Giriniz : ");
            DateTime returnTime = Convert.ToDateTime(Console.ReadLine());

            return new Rental { CarId = carId,CustomerId = customerId, RentDate = rentDate, ReturnDate = returnTime };
        }

        private static Customer AddCustomer(CustomerManager customerManager)
        {
            Console.WriteLine("Müşterileri listeleniyor...");
            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine($"\nMüşteri Id : {item.UserId }\nMüşteri Kurumu : {item.CompanyName}");
            }
            Console.WriteLine("Sırasıyla Bilgileri Giriniz:\nKullanıcı ID giriniz : ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kurum Ismi Giriniz : ");
            string companyName = Console.ReadLine();

            return new Customer { UserId = userId, CompanyName = companyName };
        }

        private static User AddUser(UserManager userManager)
        {
            Console.WriteLine("Kullanıcılar Listeleniyor...");
            foreach (var item in userManager.GetAll().Data)
            {
                Console.WriteLine($"\nKullanıcı ismi : {item.FirstName }\nKullanıcı Soyismi : {item.LastName}\nKullanıcı Email : {item.Email}\nKullanıcı Şifresi : {item.Password}");
            }
            Console.WriteLine("Sırasıyla Bilgileri Giriniz:\nIsmini giriniz : ");
            string firstname = Console.ReadLine();
            Console.WriteLine("Soy Ismi Giriniz : ");
            string lastName = Console.ReadLine();
            Console.WriteLine("E-mail giriniz : ");
            string eMail = Console.ReadLine();
            Console.WriteLine("Sifre Giriniz : ");
            string password = Console.ReadLine();

            return new User { FirstName = firstname, LastName = lastName, Email = eMail, Password = password };
        }
    }
}
