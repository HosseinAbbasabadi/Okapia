////using FileUploaderSample.Models;
////using ImageMagick;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using ImageMagick;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace FileUploaderSample.Controllers
//{
//    public class FileUploaderController : Controller
//    {
//        // GET: FileUploader
//        public ActionResult Index()
//        {
//            return View();
//        }


//        //view file in dropZone
//        public ActionResult GetAttachments(long artid, string folder, bool haveThumb)
//        {
//            //Get the images list from repository

//            //var model = new Article();
//            //if (artid > 0)
//            //{
//            //    model = artrep.ArtGetbyID(artid);
//            //}

//            if (haveThumb)
//            {
//                folder = folder + "/Small";
//            }

//            var attachmentsList = new List<AttachmentsModel>();

//            var imageToLoad = "";
//            if (!string.IsNullOrEmpty(imageToLoad)) //(!string.IsNullOrEmpty(model.ArtPic))
//            {
//                var getmulti = imageToLoad.Split(';').ToList(); //model.ArtPic.Split(';').ToList();
//                getmulti = getmulti.Where(w => !string.IsNullOrEmpty(w)).ToList();
//                foreach (var f in getmulti)
//                {
//                    var getnamepic = Path.GetFileNameWithoutExtension(Server.MapPath(folder + "/" + f));
//                    var getexepic = Path.GetExtension(Server.MapPath(folder + "/" + f));

//                    FileInfo fi =
//                        new FileInfo(
//                            Server.MapPath(folder + "/" + getnamepic + (haveThumb ? "350x0" : "") + getexepic));
//                    if (fi.Exists)
//                    {
//                        //attachmentsList = new List<AttachmentsModel>() { new AttachmentsModel { } };

//                        attachmentsList.Add(
//                            new AttachmentsModel
//                            {
//                                AttachmentID = 1,
//                                FileName = f,
//                                Path = folder + "/" + f,
//                                Size = fi.Length
//                            });
//                    }
//                }
//            }

//            return Json(new { Data = attachmentsList });
//        }

//        public JsonResult UploadFile2(string folder)
//        {
//            string fileNameSave = "";
//            string fileNameNew = "";

//            if (Request.Form.Files.Count > 0 && !string.IsNullOrEmpty(folder))
//            {
//                foreach (string s in Request.Form.Files)
//                {
//                    var file1 = Request.Form.Files[s];

//                    string fileExtension = "";
//                    var fileSizeInBytes = file1.Length;
//                    string fileName = file1.FileName;


//                    if (!string.IsNullOrEmpty(fileName))
//                        fileExtension = Path.GetExtension(fileName);

//                    fileNameNew = Guid.NewGuid().ToString() + fileExtension;
//                    fileNameSave = Server.MapPath(folder + "/" + fileNameNew);
//                    file1.SaveAs(fileNameSave);

//                    if (fileExtension.Contains("jpg") || fileExtension.Contains("png") || fileExtension.Contains("bmp"))
//                    {
//                        magicImageTools(fileNameSave, folder + "/small", 350, 0);
//                        magicImageTools(fileNameSave, folder + "/small", 500, 0);
//                        magicImageTools(fileNameSave, folder + "/small", 900, 0);
//                        magicImageTools(fileNameSave, folder + "/small", 1280, 0);
//                    }
//                }
//            }

//            return Json(fileNameNew);
//        }

//        public void magicImageTools(string filename, string folder, int x, int y)
//        {
//            using (var image = new MagickImage(filename))
//            {
//                string fileExtension = "";
//                string name = "";

//                MagickGeometry size = new MagickGeometry(x, y);
//                // This will resize the image to a fixed size without maintaining the aspect ratio.
//                // Normally an image will be resized to fit inside the specified size.
//                // size.IgnoreAspectRatio = true;

//                image.Resize(size);

//                if (!string.IsNullOrEmpty(filename))
//                {
//                    fileExtension = Path.GetExtension(filename);
//                    name = Path.GetFileNameWithoutExtension(filename);
//                    // Save the result
//                    image.Write(Server.MapPath(folder + "/" + name + x + "x" + y + fileExtension));
//                }
//            }
//        }


//        public ActionResult Uploadthumbnail(string upfile, string filename, string folder)
//        {
//            string fileNameSave = "";
//            try
//            {
//                if (!string.IsNullOrEmpty(upfile))
//                {
//                    string getBased64 = upfile.ToString();
//                    string[] pd = getBased64.Split(',');
//                    byte[] bytes = Convert.FromBase64String(pd[1]);
//                    Image image;
//                    using (MemoryStream ms = new MemoryStream(bytes))
//                    {
//                        image = Image.FromStream(ms, true);


//                        if (!string.IsNullOrEmpty(filename))
//                            fileNameSave = Path.GetFileName(filename);


//                        var randomFileName = fileNameSave;
//                        var fullPath = Server.MapPath(folder + "/Small/" + randomFileName);
//                        image.Save(fullPath);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                var geterror = ex.Message;
//            }

//            return Json("ok");
//        }

//        public JsonResult DeleteFileServer(string filename, string folder, long id)
//        {
//            string getfiles = "";
//            if (!string.IsNullOrEmpty(filename) && !string.IsNullOrEmpty(folder))
//            {
//                FileInfo fi = new FileInfo(Server.MapPath(folder + @"\" + filename));
//                FileInfo fiSmall = new FileInfo(Server.MapPath(folder + @"\Small\" + filename));

//                if (fi.Exists)
//                {
//                    fi.Delete();
//                }

//                if (fiSmall.Exists)
//                {
//                    fiSmall.Delete();
//                }


//                //if you want update models

//                //var model = artrep.ArtGetbyID(id);
//                //model.ArtPic = model.ArtPic.Replace(filename, "");
//                //getfiles = model.ArtPic;

//                //artrep.updateArt(model);
//            }

//            return Json(getfiles);
//        }
//    }
//}