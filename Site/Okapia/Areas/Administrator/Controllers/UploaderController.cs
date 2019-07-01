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
        public async Task<JsonResult> Upload(IList<IFormFile> files)
        {
            var photo = files.First();
            if (!photo.FileName.IsValidFileName()) return Json(400);
            if (photo.Length > ThreeMegaBytes) return Json(401);
            var filename = ContentDispositionHeaderValue.Parse(photo.ContentDisposition).FileName.ToString()
                .Trim('"');
            var uniqueFileName = DateTime.Now.ToFileName() + "_" + filename;
            uniqueFileName = EnsureCorrectFilename(uniqueFileName);
            using (var output = System.IO.File.Create(GetOriginalFilePath(uniqueFileName)))
            {
                await photo.CopyToAsync(output);
            }

            MagicImageTools(uniqueFileName);

            return Json(uniqueFileName);
        }

        private static string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\", StringComparison.Ordinal) + 1);

            return filename;
        }

        private string GetOriginalFilePath(string filename)
        {
            var path = _hostingEnvironment.WebRootPath + "\\JobPhotos\\";
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);
            return path + filename;
        }

        private string GetThumbFilePath(string filename)
        {
            var path = _hostingEnvironment.WebRootPath + "\\JobPhotos\\" + "Thumbs\\";
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);
            return path + filename;
        }

        public void MagicImageTools(string fileName)
        {
            var fileNameOnServer = GetOriginalFilePath(fileName);
            using (var image = new MagickImage(fileNameOnServer))
            {
                var thumbFileNameOnServer = GetThumbFilePath(fileName);
                var size = new MagickGeometry(200, 0);
                image.Resize(size);

                image.Write(thumbFileNameOnServer);
            }
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            var filename = GetOriginalFilePath(id);
            var thumb = GetThumbFilePath(id);

            if (!System.IO.File.Exists(filename) || !System.IO.File.Exists(thumb)) return Json(400);
            System.IO.File.Delete(filename);
            System.IO.File.Delete(thumb);
            return Json(200);
        }
    }
}