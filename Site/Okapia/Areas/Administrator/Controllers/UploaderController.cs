using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Okapia.Application.Utilities;

namespace Okapia.Areas.Administrator.Controllers
{
    public class UploaderController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private const int ThreeMegaBytes = 3 * 1024 * 1024;

        public UploaderController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<JsonResult> Upload(IList<IFormFile> files, [FromQuery(Name = "type")] string type)
        {
            var containingFoler = DetectContainingFoler(type);
            var photo = files.First();
            if (!photo.FileName.IsValidFileName()) return Json(400);
            if (photo.Length > ThreeMegaBytes) return Json(401);
            var filename = ContentDispositionHeaderValue.Parse(photo.ContentDisposition).FileName.ToString()
                .Trim('"');
            var uniqueFileName = DateTime.Now.ToFileName() + "_" + filename;
            uniqueFileName = EnsureCorrectFilename(uniqueFileName);
            using (var output = System.IO.File.Create(GetOriginalFilePath(uniqueFileName, containingFoler)))
            {
                await photo.CopyToAsync(output);
            }

            MagicImageTools(uniqueFileName, containingFoler);

            return Json(uniqueFileName);
        }

        private static string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\", StringComparison.Ordinal) + 1);

            return filename;
        }

        private string GetOriginalFilePath(string filename, string containingFoler)
        {
            var path = _hostingEnvironment.WebRootPath + "\\"+ containingFoler + "\\";
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);
            return path + filename;
        }

        private string GetThumbFilePath(string filename, string containingFoler)
        {
            var path = _hostingEnvironment.WebRootPath + "\\" + containingFoler + "\\" + "Thumbs\\";
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);
            return path + filename;
        }

        public void MagicImageTools(string fileName, string containingFoler)
        {
            var fileNameOnServer = GetOriginalFilePath(fileName, containingFoler);
            using (var image = new MagickImage(fileNameOnServer))
            {
                var thumbFileNameOnServer = GetThumbFilePath(fileName, containingFoler);
                var size = new MagickGeometry(200, 0);
                image.Resize(size);

                image.Write(thumbFileNameOnServer);
            }
        }

        [HttpPost]
        public JsonResult Delete(string id, [FromQuery(Name = "type")] string type)
        {
            var containingFoler = DetectContainingFoler(type);
            var filename = GetOriginalFilePath(id, containingFoler);
            var thumb = GetThumbFilePath(id, containingFoler);

            if (!System.IO.File.Exists(filename) || !System.IO.File.Exists(thumb)) return Json(400);
            System.IO.File.Delete(filename);
            System.IO.File.Delete(thumb);
            return Json(200);
        }

        private static string DetectContainingFoler(string type)
        {
            string containingFoler = null;
            if (type == "category")
                containingFoler = "CategoryPhotos";
            if (type == "job")
                containingFoler = "JobPhotos";
            return containingFoler;
        }
    }
}