using Core.Business;
using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IImageService : IService<ImageDto>
    {
        IDataResult<List<Image>> GetAllImage();
        IDataResult<List<Image>> GetImageById(int id);
    }
}
