using System;
using System.IO;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Service.Impl
{
    public class ImageProcessServiceImpl : IImageProcessingService
    {
        private const string FileUploadDir = "\\images\\";

        public async Task Process(ImageFile imageFile)
        {
            if (imageFile.File.Length != 383588L)
            {
                throw new Exception();
            }

            var fileName = imageFile.File.FileName;

            var fileUploadDir = FileUploadDir + fileName;
            if (!Directory.Exists(FileUploadDir))
            {
                Directory.CreateDirectory(FileUploadDir);
            }


            await using var fileStream =
                File.Create(fileUploadDir);

            await imageFile.File.CopyToAsync(fileStream);
            // var bmp = new Bitmap(Image.FromStream(fileStream), 510, 350);
            // System.IO.File.Create(FileUploadDir + imageFile.File.FileName);
            fileStream.Flush();
        }

        public bool IsFileNotEmpty(ImageFile file) => file.File.Length > 0;
    }
}