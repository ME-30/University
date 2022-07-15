using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.Helper
{
    public class FileUploder
    {
        public static string UploadFile(string LocalPath ,IFormFile File)
        {
            try
            {
                // 1 ) Get Directory

                string FolderPath = Directory.GetCurrentDirectory() + LocalPath;


                //2) Get File Name

                string FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);


                // 3) Merge Path with File Name

                string FinalPath = Path.Combine(FolderPath, FileName);


                //4) Save File As Streams "Data Overtime"

                using (var Stream = new FileStream(FinalPath, FileMode.Create))

                {

                    File.CopyTo(Stream);

                }
                return FileName;
            }
            catch (Exception ex)
            {

                return ex.Message ;
            }


        }


        public static string RemoveFile(string LocalPath, string FileName)
        {
            try
            {
                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + LocalPath + FileName))
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + LocalPath + FileName);
                }
                var Result = "Deleted";
                return Result;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


        }

    }
}
