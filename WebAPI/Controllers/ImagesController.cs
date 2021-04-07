using Business.Abstract;
using Core.Utilities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            this._imageService = imageService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _imageService.GetAllImage();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getimagebyid")]
        public IActionResult GetImageById(int id)
        {
            var result = _imageService.GetImageById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name =("carId"))] int carId)
        {
            var checkCount = CheckImageCount(Request.Form.Files);
            if (checkCount.Success)
            {
                var result = _imageService.Add(new ImageDto { CarId = carId, Files = Request.Form.Files });
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            return BadRequest(checkCount);

        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("id"))] int id)
        {
            var result = _imageService.Delete(new ImageDto {Id=id });
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("id"))] int id)
        {
            var checkCount = CheckImageCount(Request.Form.Files);
            if (checkCount.Success)
            {
                var result = _imageService.Update(new ImageDto { Id = id, Files = Request.Form.Files });
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            return BadRequest(checkCount);
        }

        private IResult CheckImageCount(IFormFileCollection formFiles)
        {
            if (formFiles.Count < 1)
            {
                return new ErrorResult(message: "Lütfen resim ekleyiniz");
            }
            if (formFiles.Count > 5)
            {
                return new ErrorResult(message: "En fazla 5 resim eklenebilir");
            }
            return new SuccessResult();

        }
    }
}
