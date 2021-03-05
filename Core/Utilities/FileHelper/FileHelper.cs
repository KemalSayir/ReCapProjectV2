using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Core.Utilities.FileHelper
{
    public static class FileHelper
    {
        public static IResult DeleteFile(string path)
        {
            if (!File.Exists(path))
            {
                return new ErrorResult();
            }
            File.Delete(path);
            return new SuccesResult();
        }
        public static async Task<string> WriteFile(IFormFile file)
        {
            string fileName, path;
            try
            {
                // i looked this web site : https://www.codeproject.com/Articles/1256591/Upload-Image-to-NET-Core-2-1-API
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = NewGuid(extension);      //Create a new Name            //for the file due to security reasons.
                path = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }

            }
            catch (Exception e)
            {
                return e.Message;
            }

            return path;
        }
        private static string NewGuid(string extension)
        {
            return Guid.NewGuid().ToString() + extension;
        }
    }
}
