using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CardInformations 
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public int CardNo { get; set; }
        public int Cvv { get; set; }
        public string LastDateOfUse { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
