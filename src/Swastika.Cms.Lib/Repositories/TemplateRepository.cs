using Swastika.Common;
using Swastika.Common.Helper;
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
        public static TemplateRepository GetInstance()
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

        /// <summary>
        /// Prevents a default instance of the <see cref="TemplateRepository"/> class from being created.
        /// </summary>
        private TemplateRepository()
        {
        }
        public TemplateViewModel GetTemplate(string templatePath, List<TemplateViewModel> templates, Constants.TemplateFolder templateFolder)
        {
            var result = templates.FirstOrDefault(v => !string.IsNullOrEmpty(templatePath) && v.Filename == templatePath.Replace(@"\", "/").Split('/')[1]);
            result = result ?? new TemplateViewModel() { FileFolder = templateFolder.ToString() };
            return result;
        }

        public TemplateViewModel GetTemplate(string name, Constants.TemplateFolder templateFolder)
        {
            string folder = templateFolder.ToString();
            string fullPath = string.Format(@"Views\Shared\{0}", folder);

            DirectoryInfo d = new DirectoryInfo(fullPath);
            FileInfo[] Files = d.GetFiles(string.Format("{0}.cshtml", name)); //Getting cshtml files
            var file = Files.FirstOrDefault();
            TemplateViewModel result = null;
            if (file != null)
            {

                using (StreamReader s = file.OpenText())
                {
                    result = new TemplateViewModel()
                    {
                        FileFolder = folder,
                        Filename = file.Name.Split('.').First(),
                        Content = s.ReadToEnd()
                    };

                }
            }
            result = result ?? new TemplateViewModel() { FileFolder = templateFolder.ToString() };
            return result;
        }

        public bool DeleteTemplate(string name, Constants.TemplateFolder templateFolder)
        {
            string folder = templateFolder.ToString();
            string fullPath = string.Format(@"Views\Shared\{0}\{1}.cshtml", folder, name);

            if (File.Exists(fullPath))
            {
                Common.CommonHelper.RemoveFile(fullPath);
            }
            return true;
        }

        public List<TemplateViewModel> GetTemplates(string folder)
        {
            string fullPath = string.Format(Constants.StringTemplates.TemplateFolder, folder);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            DirectoryInfo d = new DirectoryInfo(fullPath);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.cshtml"); //Getting cshtml files
            List<TemplateViewModel> result = new List<TemplateViewModel>();
            foreach (var file in Files)
            {
                using (StreamReader s = file.OpenText())
                {
                    result.Add(new TemplateViewModel()
                    {
                        FileFolder = folder,
                        Filename = file.Name.Split('.').First(),
                        Content = s.ReadToEnd()
                    });

                }
            }
            return result;
        }

        public List<TemplateViewModel> GetTemplates(Constants.TemplateFolder templateFolder)
        {
            string folder = templateFolder.ToString();
            return GetTemplates(folder);
        }

        public bool SaveTemplate(TemplateViewModel file)
        {
            try
            {
                if (!string.IsNullOrEmpty(file.Filename))
                {

                    string fileName = string.Format(@"Views\Shared\{0}\{1}.cshtml", file.FileFolder, file.Filename);
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
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
