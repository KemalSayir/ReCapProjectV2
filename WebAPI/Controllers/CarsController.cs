using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    // ATribute
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int color)
        {
            var result = _carService.GetCarsByColorId(color);
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }
        // GetCarImageDetails()
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _carService.GetCarDetails();
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcarimagesdetails")]
        public IActionResult GetCarImagesDetails()
        {
            var result = _carService.GetCarImageDetails();
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcarimagesdetail")]
        public IActionResult GetCarImagesDetailByCarId(int carId)
        {
            var result = _carService.GetCarImageDetailByCarId(carId);
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getcarimagesdetailbybrandid")]
        public IActionResult GetCarImagesDetailByBrandId(int brandId)
        {
            var result = _carService.GetCarImageDetailByBrandId(brandId);
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }
        
        [HttpGet("getcarimagesdetailbycolorid")]
        public IActionResult GetCarImagesDetailByColorId(int colorId)
        {
            var result = _carService.GetCarImageDetailByColorId(colorId);
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("getcarimagesdetailbycoloridandbrandid")]
        public IActionResult GetCarImagesDetailByColorIdAndBrandId(int colorId,int brandId)
        {
            var result = _carService.GetCarImageDetailByColorIdAndBrandId(colorId,brandId);
            if (result.Succes)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
