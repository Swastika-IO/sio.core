// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Cms.Lib.Repositories;
using Swastika.Domain.Core.ViewModels;
using Swastika.Domain.Data.ViewModels;
using System;
using System.Threading.Tasks;

namespace Swastika.Cms.Lib.ViewModels.Info
{
    public class InfoFileViewModel
       : ViewModelBase<SiocCmsContext, SiocFile, InfoFileViewModel>
    {
        #region Properties

        #region Models

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("FileId")]
        public int FileId { get; set; }

        [JsonProperty("FileName")]
        public string FileName { get; set; }

        [JsonProperty("folderType")]
        public string FolderType { get; set; }

        [JsonProperty("fileFolder")]
        public string FileFolder { get; set; }

        [JsonProperty("themeName")]
        public string ThemeName { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("createdDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [JsonProperty("lastModified")]
        public DateTime? LastModified { get; set; }

        [JsonProperty("modifiedBy")]
        public string ModifiedBy { get; set; }

        #endregion Models

        #endregion Properties

        #region Contructors

        public InfoFileViewModel()
            : base()
        {
        }

        public InfoFileViewModel(SiocFile model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        #endregion Contructors

        #region Overrides

        #region Common

        public override SiocFile ParseModel(SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            if (Id == 0)
            {
                CreatedDateTime = DateTime.UtcNow;
            }
            if (FileName.IndexOf(Extension) == -1)
            {
                FileName += Extension;
            }
            Content = Content.Trim();
            return base.ParseModel(_context, _transaction);
        }

        #endregion Common

        #region Sync

        public override RepositoryResponse<bool> RemoveModel(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.RemoveModel(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                FileRepository.Instance.DeleteFile(FileName, Extension, FileFolder);
            }
            return result;
        }

        public override RepositoryResponse<InfoFileViewModel> SaveModel(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = base.SaveModel(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                FileRepository.Instance.SaveWebFile(new FileViewModel()
                {
                    Filename = FileName,
                    Extension = Extension,
                    Content = Content,
                    FileFolder = FileFolder
                });
            }
            return result;
        }

        #endregion Sync

        #region Async

        public override async Task<RepositoryResponse<bool>> RemoveModelAsync(bool isRemoveRelatedModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.RemoveModelAsync(isRemoveRelatedModels, _context, _transaction);
            if (result.IsSucceed)
            {
                FileRepository.Instance.DeleteFile(FileName, Extension, FileFolder);
            }
            return result;
        }

        public override async Task<RepositoryResponse<InfoFileViewModel>> SaveModelAsync(bool isSaveSubModels = false, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var result = await base.SaveModelAsync(isSaveSubModels, _context, _transaction);
            if (result.IsSucceed)
            {
                if (result.IsSucceed)
                {
                    FileRepository.Instance.SaveWebFile(new FileViewModel()
                    {
                        Filename = FileName,
                        Extension = Extension,
                        Content = Content,
                        FileFolder = FileFolder
                    });
                }
            }
            return result;
        }

        #endregion Async

        #endregion Overrides
    }
}
