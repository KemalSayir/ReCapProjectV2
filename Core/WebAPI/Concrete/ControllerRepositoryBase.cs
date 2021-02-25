//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Core.WebAPI.Concrete
//{
//    public class ControllerRepositoryBase<IService>
//    {
//        IService _Service;
//        public ControllerRepositoryBase(IService Service)
//        {
//            _Service = Service;
//        }

//        [HttpGet("getall")]
//        public IActionResult GetAll()
//        {
//            var result = _Service.GetAll();
//            if (result.Succes)
//                return Ok(result);
//            return BadRequest(result);
//        }

//        [HttpGet("getbyid")]
//        public IActionResult GetById(int id)
//        {
//            var result = _carService.GetById(id);
//            if (result.Succes)
//                return Ok(result);
//            return BadRequest(result);
//        }

//        [HttpGet("getcardetails")]
//        public IActionResult GetCarDetails()
//        {
//            var result = _carService.GetCarDetails();
//            if (result.Succes)
//                return Ok(result);
//            return BadRequest(result);
//        }

//        [HttpPost("add")]
//        public IActionResult Add(Car car)
//        {
//            var result = _carService.Add(car);
//            if (result.Succes)
//                return Ok(result);
//            return BadRequest(result);
//        }

//        [HttpPost("delete")]
//        public IActionResult Delete(Car car)
//        {
//            var result = _carService.Delete(car);
//            if (result.Succes)
//                return Ok(result);
//            return BadRequest(result);
//        }

//        [HttpPost("update")]
//        public IActionResult Update(Car car)
//        {
//            var result = _carService.Update(car);
//            if (result.Succes)
//                return Ok(result);
//            return BadRequest(result);
//        }

//        [HttpPost("getcarsbycolorid")]
//        public IActionResult GetCarsByColorİd(int colorId)
//        {
//            var result = _carService.GetCarsByColorId(colorId);
//            if (result.Succes)
//                return Ok(result);
//            return BadRequest(result);
//        }

//        [HttpPost("getcarsbybrandid")]
//        public IActionResult GetCarsByBrandİd(int brandId)
//        {
//            var result = _carService.GetCarsByColorId(brandId);
//            if (result.Succes)
//                return Ok(result);
//            return BadRequest(result);
//        }
//    }
//}
