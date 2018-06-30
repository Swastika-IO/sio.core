// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Cms.Lib.Services;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.BackEnd
{
    public class BEMediaViewModel
        : ViewModelBase<SiocCmsContext, SiocMedia, BEMediaViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("fileFolder")]
        public string FileFolder { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("fileType")]
        public string FileType { get; set; }

        [JsonProperty("fileSize")]
        public int FileSize { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        #endregion Models

        #region Views

        [JsonProperty("domain")]
        public string Domain { get { return GlobalConfigurationService.Instance.GetLocalString("Domain", Specificulture, "/"); } }

        [JsonProperty("fullPath")]
        public string FullPath
        {
            get
            {
                return string.IsNullOrEmpty(FileName) ? string.Empty : SwCmsHelper.GetFullPath(new string[]{
                    Domain,
                    FileFolder,
                    $"{FileName}{Extension}"
                });
            }
        }

        [JsonProperty("mediaFile")]
        public FileViewModel MediaFile { get; set; }
        #endregion Views

        #endregion Properties

        #region Contructors

        public BEMediaViewModel() : base()
        {
        }

        public BEMediaViewModel(SiocMedia model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        public override SiocMedia ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                Id = BEMediaViewModel.Repository.Max(c => c.Id).Data + 1;
                CreatedDateTime = DateTime.UtcNow;
            }

            if (MediaFile.FileStream != null)
            {
                MediaFile.FileFolder = SwCmsHelper.GetFullPath(new[] {
                    SWCmsConstants.Parameters.UploadFolder,
                    DateTime.UtcNow.ToString("MMM-yyyy")
                }); ;
                var isSaved = FileRepository.Instance.SaveWebFile(MediaFile);
                if (isSaved)
                {
                    Extension = MediaFile.Extension;
                    FileName = MediaFile.Filename;
                    FileFolder = MediaFile.FileFolder;
                }
                else
                {
                    IsValid = false;
                }

            }
            FileType = FileType ?? "image";
            return base.ParseModel(_context, _transaction);
        }

        public override void Validate(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            base.Validate(_context, _transaction);

        }

        public override void ExpandView(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            IsClone = false;
            ListSupportedCulture = GlobalLanguageService.ListSupportedCulture;
            this.ListSupportedCulture.ForEach(c => c.IsSupported = true);
            MediaFile = new FileViewModel();
        }

        public override RepositoryResponse<bool> RemoveRelatedModels(BEMediaViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = new RepositoryResponse<bool>
            {
                IsSucceed = FileRepository.Instance.DeleteFile(FileName, Extension, FileFolder)
            };
            return result;
        }

        public override Task<RepositoryResponse<bool>> RemoveRelatedModelsAsync(BEMediaViewModel view, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            FileRepository.Instance.DeleteFile(FileName, Extension, FileFolder);
            return base.RemoveRelatedModelsAsync(view,_context,_transaction);
        }

        #endregion Overrides
    }
}