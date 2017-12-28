using Swastika.Common;
using Swastika.Cms.Lib.ViewModels;
using Swastika.IO.Common.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Swastika.Cms.Lib.Repositories
{
    public class FileRepository
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static volatile FileRepository instance;

        /// <summary>
        /// The synchronize root
        /// </summary>
        private static object syncRoot = new Object();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static FileRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new FileRepository();
                    }
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="FileRepository"/> class from being created.
        /// </summary>
        private FileRepository()
        {
        }
        public FileViewModel GetFile(string FilePath, List<FileViewModel> Files, string FileFolder)
        {
            var result = Files.FirstOrDefault(v => !string.IsNullOrEmpty(FilePath) && v.Filename == FilePath.Replace(@"\", "/").Split('/')[1]);
            result = result ?? new FileViewModel() { FileFolder = FileFolder.ToString() };
            return result;
        }

        public FileViewModel GetFile(string name, string ext, string FileFolder)
        {
            FileViewModel result = null;

            string folder = string.Format(SWCmsConstants.Parameters.UploadFolder, FileFolder.ToString());
            string fullPath = string.Format(@"{0}/{1}.{2}", folder, name, ext);

            FileInfo file = new FileInfo(fullPath);

            if (file != null)
            {
                try
                {
                    using (StreamReader s = file.OpenText())
                    {
                        result = new FileViewModel()
                        {
                            FileFolder = FileFolder.ToString(),
                            Filename = file.Name.Substring(0, file.Name.LastIndexOf('.')),
                            Extension = file.Extension.Remove(0, 1),
                            Content = s.ReadToEnd()
                        };

                    }
                }
                catch
                {
                    // File invalid
                }
            }

            result = result ?? new FileViewModel() { FileFolder = FileFolder.ToString() };
            return result;
        }

        public bool DeleteFile(string name, string extension, string FileFolder)
        {
            string folder = string.Format(SWCmsConstants.Parameters.UploadFolder, FileFolder);
            string fullPath = string.Format(@"{0}/{1}.{2}", folder, name, extension);

            if (File.Exists(fullPath))
            {
                CommonHelper.RemoveFile(fullPath);
            }
            return true;
        }

        public List<FileViewModel> GetFiles(string folder)
        {
            string fullPath = string.Format(SWCmsConstants.Parameters.UploadFolder, folder);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            DirectoryInfo d = new DirectoryInfo(fullPath);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles();
            List<FileViewModel> result = new List<FileViewModel>();
            foreach (var file in Files.OrderByDescending(f => f.CreationTimeUtc))
            {
                using (StreamReader s = file.OpenText())
                {
                    result.Add(new FileViewModel()
                    {
                        FileFolder = folder,
                        Filename = file.Name.Substring(0, file.Name.LastIndexOf('.')),
                        Extension = file.Extension.Remove(0, 1),
                        Content = s.ReadToEnd()

                    });

                }
            }
            return result;
        }

        public List<FileViewModel> GetFiles(SWCmsConstants.FileFolder FileFolder)
        {
            string folder = FileFolder.ToString();
            return GetFiles(folder);
        }

        public bool SaveFile(FileViewModel file)
        {
            try
            {
                if (!string.IsNullOrEmpty(file.Filename))
                {

                    string folder = string.Format(SWCmsConstants.Parameters.UploadFolder, file.FileFolder);
                    string fileName = string.Format(@"{0}/{1}.{2}", folder, file.Filename, file.Extension);
                    //var logPath = System.IO.Path.GetTempFileName();
                    if (string.IsNullOrEmpty(file.FileStream))
                    {
                        using (var writer = File.CreateText(fileName))
                        {
                            writer.WriteLine(file.Content); //or .Write(), if you wish
                            return true;
                        }
                    }
                    else
                    {
                        string base64 = file.FileStream.Split(',')[1];
                        byte[] bytes = Convert.FromBase64String(base64);
                        using (var writer = File.Create(fileName))
                        {
                            writer.Write(bytes, 0, bytes.Length);
                            return true;
                        }
                    }

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
