// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Swastika.Cms.Lib.Models.Cms;
using Swastika.Domain.Data.ViewModels;

namespace Swastika.Cms.Lib.ViewModels
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Swastika.Domain.Data.ViewModels.ViewModelBase{Swastika.Cms.Lib.Models.SiocCmsContext, Swastika.Cms.Lib.Models.SiocCategoryCategory, Swastika.Cms.Lib.ViewModels.CategoryCategoryViewModel}" />
    public class CategoryCategoryViewModel : ViewModelBase<SiocCmsContext, SiocCategoryCategory, CategoryCategoryViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryCategoryViewModel"/> class.
        /// </summary>
        public CategoryCategoryViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryCategoryViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="_context"></param>
        /// <param name="_transaction"></param>
        public CategoryCategoryViewModel(SiocCategoryCategory model, SiocCmsContext _context = null, IDbContextTransaction _transaction = null)
            : base(model, _context, _transaction)
        {
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is actived.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is actived; otherwise, <c>false</c>.
        /// </value>
        public bool IsActived { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
