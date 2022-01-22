using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace KACDC.Class.FileSaving
{
    public class SaveFile
    {
        public bool SavingFileOnServer(string path,string FileName,byte[] fileData)
        {
            CheckDirExist(path);
            File.WriteAllBytes(path+FileName, fileData);
            return true;
        }
        public void CheckDirExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public void IfFileExistDelete(string path,string filename)
        {
            if (Directory.Exists(path))
            {
                if (File.Exists(path+ filename))
                {
                    File.Delete(path+ filename);
                }
            }
        }
    }
}