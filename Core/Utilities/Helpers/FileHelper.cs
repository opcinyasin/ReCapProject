using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static IResult add(IFormFile file)
        {
            
            var fileName = newFileName() + new FileInfo(file.FileName).Extension;
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                file.CopyTo(stream);

            }
            return new SuccessResult(fileName);

        }

        public static IResult Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return new SuccessResult();
            }
            return new ErrorResult("Resim bulunamadı");
        }

        private static string newFileName()
        {
            var folderName = "Images";
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", folderName);
            var dbPath = Path.Combine(pathToSave, Guid.NewGuid().ToString());


            return dbPath;
        }
    }
}
