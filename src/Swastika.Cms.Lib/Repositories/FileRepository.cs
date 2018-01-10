using Swastika.Common;
using Swastika.Cms.Lib.ViewModels;
using Swastika.IO.Common.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.IO.Compression;
using Microsoft.AspNetCore.Http;

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

        public FileViewModel GetWebFile(string filename, string folder)
        {
            string fullPath = CommonHelper.GetFullPath(new string[] 
            {
                SWCmsConstants.Parameters.WebRootPath,
                SWCmsConstants.Parameters.FileFolder,
                folder,
                filename
            });
            string folderPath = CommonHelper.GetFullPath(new string[]
            {
                SWCmsConstants.Parameters.WebRootPath,
                SWCmsConstants.Parameters.FileFolder,
                folder
            });
            FileInfo file = new FileInfo(fullPath);
            FileViewModel result = null;
            if (file != null)
            {
                try
                {
                    DirectoryInfo path = new DirectoryInfo(folderPath);
                    using (StreamReader s = file.OpenText())
                    {
                        result = new FileViewModel()
                        {
                            FolderName = path.Name,
                            FileFolder = folder,
                            Filename = file.Name.Substring(0, file.Name.LastIndexOf('.')),
                            Extension = file.Extension,
                            Content = s.ReadToEnd()
                        };

                    }
                }
                catch
                {
                    // File invalid
                }
            }

            result = result ?? new FileViewModel() { FileFolder = folder };
            return result;
        }
        public bool DeleteWebFile(string filename, string folder)
        {
            string fullPath = CommonHelper.GetFullPath(new string[]
           {
                SWCmsConstants.Parameters.WebRootPath,
                SWCmsConstants.Parameters.FileFolder,
                folder,
                filename
           });

            if (File.Exists(fullPath))
            {
                CommonHelper.RemoveFile(fullPath);
            }
            return true;
        }
        public bool DeleteWebFile(string filePath)
        {
            string fullPath = CommonHelper.GetFullPath(new string[]
           {
                SWCmsConstants.Parameters.WebRootPath,
                filePath
           });

            if (File.Exists(fullPath))
            {
                CommonHelper.RemoveFile(fullPath);
            }
            return true;
        }

        public bool DeleteWebFolder(string folderPath)
        {
            string fullPath = CommonHelper.GetFullPath(new string[] 
            { SWCmsConstants.Parameters.WebRootPath,
                folderPath
            });

            if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, true);
            }
            return true;
        }


        public FileViewModel GetUploadFile(string name, string ext, string FileFolder)
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

        public FileViewModel GetFile(string name, string ext, string FileFolder)
        {
            FileViewModel result = null;

            string fullPath = string.Format(@"{0}/{1}{2}", FileFolder, name, ext);

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

        public bool DeleteFile(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                CommonHelper.RemoveFile(fullPath);
            }
            return true;
        }

        
        public bool DeleteFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
                return true;
            }
            return false;
        }
        public bool CopyDirectory(string srcPath, string desPath)
        {
            if (srcPath != desPath)
            {

                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(srcPath, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(srcPath, desPath));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(srcPath, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(srcPath, desPath), true);
                return true;
            }
            return false;
        }

        public List<FileViewModel> GetUploadFiles(string folder)
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
                        Extension = file.Extension,
                        Content = s.ReadToEnd()

                    });

                }
            }
            return result;
        }
        public List<string> GetTopDirectories(string folder)
        {
            string fullPath = CommonHelper.GetFullPath(new string[]
            {
                SWCmsConstants.Parameters.WebRootPath,
                SWCmsConstants.Parameters.FileFolder,
                folder
            });
            //if (!Directory.Exists(fullPath))
            //{
            //    Directory.CreateDirectory(fullPath);
            //}
            List<string> result = new List<string>();
            if (Directory.Exists(fullPath))
            {

                foreach (string dirPath in Directory.GetDirectories(fullPath, "*",
                    SearchOption.TopDirectoryOnly))
                {
                    DirectoryInfo path = new DirectoryInfo(dirPath);
                    result.Add(path.Name);
                }
            }
            return result;
        }
        public List<FileViewModel> GetTopFiles(string folder)
        {
            string fullPath = CommonHelper.GetFullPath(new string[]
             {
                SWCmsConstants.Parameters.WebRootPath,
                SWCmsConstants.Parameters.FileFolder,
                folder
             });           
            List<FileViewModel> result = new List<FileViewModel>();
            if (Directory.Exists(fullPath))
            {
                DirectoryInfo path = new DirectoryInfo(fullPath);
                string folderName = path.Name;

                var Files = path.GetFiles();
                foreach (var file in Files.OrderByDescending(f => f.CreationTimeUtc))
                {
                    result.Add(new FileViewModel()
                    {
                        FolderName = folderName,
                        FileFolder = folder,
                        Filename = file.Name.Substring(0, file.Name.LastIndexOf('.')),
                        Extension = file.Extension,
                        //Content = s.ReadToEnd()
                    });                  
                }
            }
            return result;
        }

        public List<FileViewModel> GetFilesWithContent(string fullPath)
        {
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            //DirectoryInfo d = new DirectoryInfo(fullPath);//Assuming Test is your Folder
            FileInfo[] Files = { };
            List<FileViewModel> result = new List<FileViewModel>();
            foreach (string dirPath in Directory.GetDirectories(fullPath, "*",
                SearchOption.AllDirectories))
            {
                DirectoryInfo path = new DirectoryInfo(dirPath);
                string folderName = path.Name;

                Files = path.GetFiles();
                foreach (var file in Files.OrderByDescending(f => f.CreationTimeUtc))
                {
                    using (StreamReader s = file.OpenText())
                    {
                        result.Add(new FileViewModel()
                        {
                            FolderName = folderName,
                            FileFolder = CommonHelper.GetFullPath(new string[] { fullPath, folderName }),
                            Filename = file.Name.Substring(0, file.Name.LastIndexOf('.')),
                            Extension = file.Extension,
                            Content = s.ReadToEnd()

                        });

                    }
                }
            }
            return result;
        }

        public List<FileViewModel> GetFiles(string fullPath)
        {
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            //DirectoryInfo d = new DirectoryInfo(fullPath);//Assuming Test is your Folder
            FileInfo[] Files = { };
            List<FileViewModel> result = new List<FileViewModel>();
            foreach (string dirPath in Directory.GetDirectories(fullPath, "*",
                SearchOption.AllDirectories))
            {
                DirectoryInfo path = new DirectoryInfo(dirPath);
                string folderName = path.Name;

                Files = path.GetFiles();
                foreach (var file in Files.OrderByDescending(f => f.CreationTimeUtc))
                {
                    result.Add(new FileViewModel()
                    {
                        FolderName = folderName,
                        FileFolder = CommonHelper.GetFullPath(new string[] { fullPath, folderName }),
                        Filename = file.Name.Substring(0, file.Name.LastIndexOf('.')),
                        Extension = file.Extension,
                        //Content = s.ReadToEnd()

                    });
                    //using (StreamReader s = file.OpenText())
                    //{
                    //    result.Add(new FileViewModel()
                    //    {
                    //        FolderName = folderName,
                    //        FileFolder = CommonHelper.GetFullPath(new string[] { fullPath, folderName }),
                    //        Filename = file.Name.Substring(0, file.Name.LastIndexOf('.')),
                    //        Extension = file.Extension,
                    //        Content = s.ReadToEnd()

                    //    });

                    //}
                }
            }
            return result;
        }
        public List<FileViewModel> GetWebFiles(string folder)
        {
            string fullPath = CommonHelper.GetFullPath(new string[] {
                    SWCmsConstants.Parameters.WebRootPath,
                    folder
                });

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            //DirectoryInfo d = new DirectoryInfo(fullPath);//Assuming Test is your Folder
            FileInfo[] Files = { };
            List<FileViewModel> result = new List<FileViewModel>();
            foreach (string dirPath in Directory.GetDirectories(fullPath, "*",
                SearchOption.AllDirectories))
            {
                DirectoryInfo path = new DirectoryInfo(dirPath);
                string folderName = path.ToString().Replace(@"\", "/").Replace(SWCmsConstants.Parameters.WebRootPath, string.Empty);

                Files = path.GetFiles();
                foreach (var file in Files.OrderByDescending(f => f.CreationTimeUtc))
                {
                    result.Add(new FileViewModel()
                    {
                        FolderName = path.Name,
                        FileFolder = folderName,//CommonHelper.GetFullPath(new string[] { folderName, path.Name }),
                        Filename = file.Name.Substring(0, file.Name.LastIndexOf('.')),
                        Extension = file.Extension,
                        //Content = s.ReadToEnd()

                    });
                    //using (StreamReader s = file.OpenText())
                    //{
                    //    result.Add(new FileViewModel()
                    //    {
                    //        FolderName = path.Name,
                    //        FileFolder = folderName,//CommonHelper.GetFullPath(new string[] { folderName, path.Name }),
                    //        Filename = file.Name.Substring(0, file.Name.LastIndexOf('.')),
                    //        Extension = file.Extension,
                    //        Content = s.ReadToEnd()

                    //    });

                    //}
                }
            }
            return result;
        }

        public List<FileViewModel> GetFiles(SWCmsConstants.FileFolder FileFolder)
        {
            string folder = FileFolder.ToString();
            return GetUploadFiles(folder);
        }

        public bool SaveWebFile(FileViewModel file)
        {
            try
            {
                string fullPath = CommonHelper.GetFullPath(new string[] {
                    SWCmsConstants.Parameters.WebRootPath,
                    file.FileFolder
                });
                if (!string.IsNullOrEmpty(file.Filename))
                {
                    if (!Directory.Exists(fullPath))
                    {
                        Directory.CreateDirectory(fullPath);
                    }
                    string fileName = SWCmsHelper.GetFullPath(new string[] { fullPath, file.Filename + file.Extension }); //string.Format(file.FileFolder, file.Filename);
                    //var logPath = System.IO.Path.GetTempFileName();
                    if (File.Exists(fileName))
                    {
                        DeleteFile(fileName);
                    }
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

        public string SaveFile(IFormFile file, string fullPath)
        {
            try
            {
                //string fullPath = CommonHelper.GetFullPath(new string[] {
                //    SWCmsConstants.Parameters.WebRootPath,
                //    folder
                //});
                if (file.Length > 0)
                {
                    if (!Directory.Exists(fullPath))
                    {
                        Directory.CreateDirectory(fullPath);
                    }
                    string filename = file.FileName;// Guid.NewGuid().ToString("N");
                    string filePath = SWCmsHelper.GetFullPath(new string[] { fullPath, filename });
                    //var logPath = System.IO.Path.GetTempFileName();
                    if (File.Exists(filePath))
                    {
                        DeleteFile(filePath);
                    }
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return filename;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }
        public string SaveWebFile(IFormFile file, string folder)
        {
            try
            {
                string fullPath = CommonHelper.GetFullPath(new string[] {
                    SWCmsConstants.Parameters.WebRootPath,
                    folder
                });
                return SaveFile(file, fullPath);
            }
            catch
            {
                return string.Empty;
            }
        }
        public void UnZipFile(string fileName, string folder)
        {
            string filePath = SWCmsHelper.GetFullPath(new string[] {
                SWCmsConstants.Parameters.WebRootPath,
                folder,
                fileName });
            string webFolder = SWCmsHelper.GetFullPath(new string[]
            {
                SWCmsConstants.Parameters.WebRootPath,
                folder
            });
            try
            {
                ZipFile.ExtractToDirectory(filePath, webFolder);
            }
            catch
            {
            }
        }
    }
}
