using Core.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ImageDto:Image,IDto
    {
        public IFormFileCollection Files { get; set; }
    }
}
