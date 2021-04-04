using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        public static string FileAdd(IFormFile formFile)
        {
            var result = newPath(formFile);
            var sourceFilePath = Path.GetTempFileName();

            using(var stream=new FileStream(sourceFilePath,FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            File.Move(sourceFilePath, result.newPath);
            
            return result.Path2;

        }
        public static IResult FileDelete(string path)
        {

            File.Delete(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot"))+path);
            return new SuccessResult();
        }

        public static string FileUpdate(string sourceFilePath, IFormFile formFile)
        {
            var result = newPath(formFile);
            using (var stream = new FileStream(result.newPath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            File.Delete(sourceFilePath);

            return result.Path2;


        }

        public static (string newPath, string Path2) newPath(IFormFile file)
        {
            FileInfo fileinfo = new FileInfo(file.FileName);
            string fileExtension = fileinfo.Extension;
            var newFileName = Guid.NewGuid().ToString("N") + fileExtension;
            string path12 = @"\wwwroot\Images\";
            string result = Environment.CurrentDirectory + path12 + newFileName;
            return (result, $"\\Images\\{newFileName}");
        }
    }
}
