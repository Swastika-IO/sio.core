using Swastika.Common;
using Swastika.Common.Helper;
using Swastika.Domain.Core.Models;
using Swastika.Cms.Lib;
using Swastika.Cms.Lib.ViewModels;
using Swastika.IO.Common.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Swastika.Cms.Lib.Repositories
{
    public class TemplateRepository
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static volatile TemplateRepository instance;

        /// <summary>
        /// The synchronize root
        /// </summary>
        private static object syncRoot = new Object();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static TemplateRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new TemplateRepository();
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="TemplateRepository"/> class from being created.
        /// </summary>
        private TemplateRepository()
        {
        }

        public TemplateViewModel GetTemplate(string templatePath, List<TemplateViewModel> templates, string templateFolder)
        {
            var result = templates.FirstOrDefault(
                v => !string.IsNullOrEmpty(templatePath) && v.Filename == templatePath.Replace(@"\", "/").Split('/')[1]);
            result = result ?? new TemplateViewModel() { FileFolder = templateFolder.ToString() };
            return result;
        }

        public TemplateViewModel GetTemplate(string name, string templateFolder)
        {
            DirectoryInfo d = new DirectoryInfo(templateFolder);
            FileInfo[] Files = d.GetFiles(name); //Getting cshtml files
            var file = Files.FirstOrDefault();
            TemplateViewModel result = null;
            if (file != null)
            {

                using (StreamReader s = file.OpenText())
                {
                    result = new TemplateViewModel()
                    {
                        FileFolder = templateFolder,
                        Filename = file.Name,
                        Extension = file.Extension,
                        Content = s.ReadToEnd()
                    };

                }
            }
            result = result ?? new TemplateViewModel() { FileFolder = templateFolder.ToString() };
            return result;
        }

        public bool DeleteTemplate(string name, string templateFolder)
        {
            string fullPath = SWCmsHelper.GetFullPath(new string[]
            {
                templateFolder,
                name + SWCmsConstants.Parameters.TemplateExtension
            });
            if (File.Exists(fullPath))
            {
                CommonHelper.RemoveFile(fullPath);
            }
            return true;
        }

        public List<TemplateViewModel> GetTemplates(string folder)
        {
            //string fullPath = string.Format(Constants.StringTemplates.TemplateFolder, folder);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            DirectoryInfo d = new DirectoryInfo(folder);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles(string.Format("*{0}", SWCmsConstants.Parameters.TemplateExtension)); //Getting cshtml files
            List<TemplateViewModel> result = new List<TemplateViewModel>();
            foreach (var file in Files)
            {
                using (StreamReader s = file.OpenText())
                {
                    result.Add(new TemplateViewModel()
                    {
                        FileFolder = folder,
                        Filename = file.Name,//.Split('.').First(),
                        Extension = SWCmsConstants.Parameters.TemplateExtension,
                        Content = s.ReadToEnd()
                    });

                }
            }
            return result;
        }

      
        public bool SaveTemplate(TemplateViewModel file)
        {
            try
            {
                if (!string.IsNullOrEmpty(file.Filename))
                {
                    if (!Directory.Exists(file.FileFolder))
                    {
                        Directory.CreateDirectory(file.FileFolder);
                    }
                    string fileName = SWCmsHelper.GetFullPath(new string[] { file.FileFolder, file.Filename + file.Extension }); //string.Format(file.FileFolder, file.Filename);
                    //var logPath = System.IO.Path.GetTempFileName();
                    using (var writer = File.CreateText(fileName))
                    {
                        writer.WriteLine(file.Content); //or .Write(), if you wish
                        return true;
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
