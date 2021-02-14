using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Car car = new Car
            {
                ColorId = 2,
                BrandId = 1,
                DailyPrice = 30000,
                Description = "Good",
                ModelYear = 2020
            };
            Color color = new Color
            {
                Name = "Pembe"
            };
            Brand brand = new Brand
            {
                Name = "Toros"
            };


            //Color color = new Color { Name = "Mavi" };
            //colorManager.Add(color);
            //Car car = new Car() {BrandId = 1,ColorId = 1,DailyPrice=11132,Description= "Aileler için",ModelYear=1992};
            //carManager.Add(car);
            //carManager.Delete(new Car {Id = 3,BrandId=1,ColorId=1,DailyPrice=199235, ModelYear = 1999,Description ="Good for family"});
            //carManager.Delete(car);
            //Console.WriteLine("Oldu!\n{0}\t{1}",color.Id,color.Name);
            //Console.ReadLine();
        }
    }
}
