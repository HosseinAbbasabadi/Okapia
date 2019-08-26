using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Okapia.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class FileManagerController : Controller
    {
        public static string basePath = "Data/";
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileManagerController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CreateDirectory(string path, string type)
        {
            path = AppDomain.CurrentDomain.BaseDirectory + basePath + type + '/' + path;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch
                {
                    return Json(new
                    {
                        Message =
                            "There_is_a_problom_check_your_dir_Name", //MessageHandler.GetMessage("There_is_a_problom_check_your_dir_Name").MessageText,
                        MessageTitle =
                            "There_is_a_problom_check_your_dir_Name_Title", //MessageHandler.GetMessage("There_is_a_problom_check_your_dir_Name_Title").MessageText,
                        Success = false
                    });
                }
            }
            else
                return Json(new
                {
                    Message =
                        "Directory_is_Exist_Change_Directory_Name", //MessageHandler.GetMessage("Directory_is_Exist_Change_Directory_Name").MessageText,
                    MessageTitle = "Directory_is_Exist", //MessageHandler.GetMessage("Directory_is_Exist").MessageText,
                    Success = false
                });

            return Json(new {Success = true});
        }

        public JsonResult Upload(string pathFile = "")
        {
            object op = new
            {
                Message = "Upload_File_Success",
                MessageTitle = "Upload_Done",
                Success = true
            };
            //DomainModel.Common.OperationResult op = new DomainModel.Common.OperationResult
            //{
            //    Message = MessageHandler.GetMessage("Upload_File_Success").MessageText,
            //    MessageTitle = MessageHandler.GetMessage("Upload_Done").MessageText,
            //    Opration = FrameWork.Enums.OperationType.Upload.ToString(),
            //    Success = true
            //};

            if (Request.Form.Files.Count > 0)
            {
                try
                {
                    var file = Request.Form.Files[0];

                    if (!CheckFile(pathFile, file))
                    {
                        op = new
                        {
                            Message = "file_Not_Valid",
                            MessageTitle = "file_Not_Valid",
                            Success = false
                        };
                        //op.MessageTitle = MessageHandler.GetMessage("file_Not_Valid").MessageText;
                        //op.Message = MessageHandler.GetMessage("file_Not_Valid").MessageText;
                        //op.Success = false;
                    }
                }
                catch (Exception e)
                {
                    op = new
                    {
                        Message = "Upload_Faild",
                        MessageTitle = "Upload_File_Faild",
                        Success = false
                    };
                    //op.MessageTitle = MessageHandler.GetMessage("Upload_Faild").MessageText;
                    //op.Message = MessageHandler.GetMessage("Upload_File_Faild").MessageText;
                    //op.Success = false;
                }
            }
            else
            {
                op = new
                {
                    Message = "There_is_no_file_for_Upload",
                    MessageTitle = "No_file_found",
                    Success = false
                };
                //op.Message = MessageHandler.GetMessage("There_is_no_file_for_Upload").MessageText;
                //op.MessageTitle = MessageHandler.GetMessage("No_file_found").MessageText;
                //op.Success = false;
            }

            //return Json(MessageHandler.SendMessage(op));
            return Json(op);
        }

        public JsonResult getFile(string type, string path = "")
        {
            //--- define Variable
            List<string> FileVitPath = new List<string>();
            string[] Temp;
            string[] Directories = null;
            string[] fileList = null;


            if (type.ToLower() == "all")
                type = "";

            string pathFile = string.Format("{0}{1}/{2}", basePath, type, path);

            //---- create Path
            //in masir to .net core dige injoori nist
            //bayad avaz beshe
            pathFile = string.Format("{0}/{1}", _hostingEnvironment.WebRootPath, pathFile);

            try
            {
                fileList = Directory.GetFiles(pathFile).OrderByDescending(x => new FileInfo(x).CreationTime).ToArray();
            }
            catch
            {
            }


            //--- create Vitural Path for File        
            if (fileList != null)
            {
                for (int i = 0; i < fileList.Length; i++)
                {
                    Temp = fileList[i].Split('/');
                    string VitPath = "";
                    for (int a = 1; a < Temp.Length; a++)
                    {
                        VitPath += "/" + Temp[a];
                    }

                    FileVitPath.Add(VitPath);
                }
            }

            try
            {
                Directories = Directory.GetDirectories(pathFile);
            }
            catch
            {
            }

            //--- create Vitural Path for Directories
            if (Directories != null)
            {
                for (int i = 0; i < Directories.Length; i++)
                {
                    Temp = Directories[i].Split('\\');
                    Directories[i] = "";
                    bool FindBasePath = false;
                    for (int a = 1; a < Temp.Length; a++)
                    {
                        if (Temp[a].IndexOf(basePath) > -1 || FindBasePath)
                        {
                            Directories[i] += Temp[a];

                            if (a != Temp.Length - 1)
                                Directories[i] += '/';

                            FindBasePath = true;
                        }
                    }
                }
            }

            return Json(new {files = FileVitPath, Directories = Directories});
        }

        //public JsonResult UploadImage(IFormFile file)
        //{
        //    string vitPath = "";
        //    try
        //    {
        //        string PhysicalAddress = Server.MapPath(Request.ApplicationPath + "/Data/image/");
        //        string fn = System.IO.Path.GetFileName(file.FileName);

        //        DateTime nowTime = DateTime.Now;
        //        fn = string.Format("{0}{1}{2}{3}{4}", nowTime.Hour, nowTime.Minute, nowTime.Second, nowTime.Millisecond,
        //            fn);

        //        PhysicalAddress = PhysicalAddress + fn;
        //        vitPath = "/Data/image/" + fn;
        //        file.SaveAs(PhysicalAddress);
        //    }
        //    catch
        //    {
        //    }

        //    return Json(new {url = vitPath});
        //}

        protected bool CheckFile(string pathFile, IFormFile file)
        {
            bool res = false;
            string FilePath = file.FileName;
            string FileName = Path.GetFileName(FilePath);

            var checkStream = file.OpenReadStream();
            using (var chkBinary = new BinaryReader(checkStream))
            {
                byte[] chkbytes = chkBinary.ReadBytes(0x10);

                var data_as_hex = BitConverter.ToString(chkbytes);
                var magicCheck = data_as_hex.Substring(0, 8);

                //Set the contenttype based on File Extension

                switch (magicCheck)
                {
                    //---- images                    
                    case "FF-D8-FF":
                        SaveFile(pathFile, file, "Image");
                        res = true;
                        break;
                    case "89-50-4E":
                        SaveFile(pathFile, file, "Image");
                        res = true;
                        break;
                    case "47-49-46":
                        SaveFile(pathFile, file, "Image");
                        res = true;
                        break;
                    case "42-4D-BE":
                        SaveFile(pathFile, file, "Image");
                        res = true;
                        break;
                    //----- Video
                    case "4F-67-67":
                        SaveFile(pathFile, file, "Video");
                        res = true;
                        break;
                    case "66-74-79":
                        SaveFile(pathFile, file, "Video");
                        res = true;
                        break;
                    case "00-00-00":
                        SaveFile(pathFile, file, "Video");
                        res = true;
                        break;
                    ////----- audio   
                    //case "49-44-33":
                    //    SaveFile(pathFile, file, "audio");
                    //    res = true;
                    //    break;


                    //case "52-49-46":
                    //    SaveFile(pathFile, file, "audio");
                    //    res = true;
                    //    break;
                    ////----- docs
                    //case "25-50-44":
                    //    SaveFile(pathFile, file, "doc");
                    //    res = true;
                    //    break;
                    //case "52-61-72":
                    //    SaveFile(pathFile, file, "doc");
                    //    res = true;
                    //    break;
                    //case "37-7A-BC":
                    //    SaveFile(pathFile, file, "doc");
                    //    res = true;
                    //    break;
                }

                return res;
            }
        }

        private async Task SaveFile(string pathFile, IFormFile file, string mainPath)
        {
            //  get time for name
            var dateForName = DateTime.Now.ToString("mmssFFF");
            var fileName = file.FileName;

            if (fileName.Length > 15)
                fileName = fileName.Substring((fileName.Length - 14));

            fileName = _hostingEnvironment.WebRootPath + "\\Data\\" + mainPath + "\\" + dateForName + fileName;
            var output = System.IO.File.Create(fileName);
            await file.CopyToAsync(output);
        }

        [HttpPost]
        public JsonResult Delete(string url)
        {
            //bool res = true;
            //string fullPath = Request.MapPath("~" + url);
            //try
            //{
            //    if (System.IO.File.Exists(fullPath))
            //    {
            //        System.IO.File.Delete(fullPath);
            //    }
            //}
            //catch
            //{
            //    res = false;
            //}

            return Json(new {res = "Ok"});
        }
    }
}