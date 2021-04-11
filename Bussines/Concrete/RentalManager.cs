using Bussines.Abstract;
using Bussines.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAcces.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental Entity)
        {
            _rentalDal.Add(Entity);
            return new SuccesResult($"{Entity.GetType()} Added.");
        }

        public IResult Delete(Rental Entity)
        {
            _rentalDal.Delete(Entity);
            return new SuccesResult($"{Entity.GetType()} Deleted.");
        }


        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetAll(),"Rentals Listed");
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccesDataResult<Rental>(_rentalDal.GetById(p=>p.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetRentalsByCarId(int carId)
        {
            return new SuccesDataResult<List<Rental>>(_rentalDal.GetRentalByCarId(carId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccesDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult HireACar(CardInformations CardInformations)
        {
            Rental rental = new Rental { CarId = CardInformations.CarId,CustomerId= CardInformations.CustomerId,RentDate=CardInformations.RentDate,ReturnDate = CardInformations.ReturnDate};
            IResult result = BusinessRules.Run(CheckIfDatesWrong(rental), CheckIfCoincident(rental));
            if (result != null)
                return new ErrorResult(result.Message);
            // kontrolleri yaptık: kısaca valdation sayesinde rent'date ve returnDate'in günümüzden geçmişte olmasını engelledik,
            // yukarıda çalıştırdığımız iki methodun ilki ile girilen başlangıç tarihinin bitiş tarihinden geç olmasını önledik
            // ikincisi ile ise gönderilen tarihlerin database'de ki kiralamalar ile yani; daha önceden kiralanıp kiralanmadıgını kontrol ettik.
            // ve en son olarak kontrollerin ardından kiralama operasyonunu gerçekleştirdik; yani databaseye ekledik.
            // sırada sadece webapide karşılığını yazmak kalıyor :)
            _rentalDal.Add(rental);
            return new SuccesResult($"{rental.GetType()} Added.");
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental Entity)
        {
            _rentalDal.Update(Entity);
            return new SuccesResult($"{Entity.GetType()}");
        }

        private IResult CheckIfDatesWrong(Rental rental)
        {
            if (rental.RentDate.Date >= rental.ReturnDate.Date)
            {
                return new ErrorResult("Kiralama bitiş tarihi başlangıç tarihinden erken ya da eşit olamaz.\nEn az bir gün kiralamalısınız.");
            }
            return new SuccesResult();
        }
        
        /// <summary>
        /// Gönderilen kiralamanın tarihinin sahip olduğumuz veriler ile çakışma durumunun kontrol ediyor.
        /// </summary>
        /// <param name="rental"></param>
        /// <returns>eğer elimizdeki veriler ile çakışıyor ise error, çakışmıyor ise success result döndürür.</returns>
        private IResult CheckIfCoincident(Rental rental)
        {
            IDataResult<List<Rental>> result = GetRentalsByCarId(rental.CarId);
            if (result.Data.Count == 0)
                return new SuccesResult();

            foreach (var item in result.Data)
            {
                if (rental.RentDate.Date > item.ReturnDate.Date || rental.ReturnDate.Date < item.RentDate.Date)
                {
                    return new SuccesResult();
                }
            }
            return new ErrorResult("Belirtilen tarihler içerisinde bu araba kiralanmış.");
        }
    }
}
