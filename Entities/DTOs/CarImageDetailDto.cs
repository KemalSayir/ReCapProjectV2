using Core.Entities.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImageDetailDto : CarDetailDto , IDto
    {
        public int ModelYear { get; set; }
        public string Description { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
