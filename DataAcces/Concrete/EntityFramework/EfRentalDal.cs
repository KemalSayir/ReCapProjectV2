using Core.DataAccess.Concrete;
using DataAcces.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcces.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result2 = from r in context.Rentals
                              join c in context.Cars
                              on r.CarId equals c.Id
                              join b in context.Brands
                              on c.BrandId equals b.Id
                              join u in context.Users
                              on r.CustomerId equals u.Id
                              select new RentalDetailDto
                              {
                                  Id = r.Id,
                                  BrandName = b.Name,
                                  FirstAndLastName = u.FirstName +" "+ u.LastName,
                                  RentDate = r.RentDate,
                                  ReturnDate = r.ReturnDate
                              };
                return result2.ToList();
            }
        }
    }
}
