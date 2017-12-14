using Swastika.IO.Cms.Lib.Models;
using Swastika.Infrastructure.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;

namespace Swastika.IO.Cms.Lib.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Swastika.Infrastructure.Data.ViewModels.ViewModelBase{Swastika.IO.Cms.Lib.Models.SiocCmsContext, Swastika.IO.Cms.Lib.Models.SiocCategoryCategory, Swastika.IO.Cms.Lib.ViewModels.CategoryCategoryViewModel}" />
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
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }


        #region overrides

        #region Async



        #endregion

        #region Sync


        #endregion

        #endregion

    }
}
