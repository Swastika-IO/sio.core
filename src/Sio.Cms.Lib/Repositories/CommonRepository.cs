// Licensed to the Sio I/O Foundation under one or more agreements.
// The Sio I/O Foundation licenses this file to you under the GNU General Public License v3.0.
// See the LICENSE file in the project root for more information.

using Microsoft.EntityFrameworkCore.Storage;
using Sio.Cms.Lib.Models.Cms;
using Sio.Domain.Core.Models;
using Sio.Cms.Lib.ViewModels.SioSystem;
using System;
using System.Collections.Generic;

namespace Sio.Cms.Lib.Repositories
{
    public class CommonRepository
    {
        private static volatile CommonRepository instance;
        private static readonly object syncRoot = new Object();

        private CommonRepository()
        {
        }

        public static CommonRepository Instance {
            get {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new CommonRepository();
                    }
                }

                return instance;
            }
        }

        public List<SupportedCulture> LoadCultures(string initCulture = null, SioCmsContext _context = null, IDbContextTransaction _transaction = null)
        {
            var getCultures = SystemCultureViewModel.Repository.GetModelList(_context, _transaction);
            var result = new List<SupportedCulture>();
            if (getCultures.IsSucceed)
            {
                foreach (var culture in getCultures.Data)
                {
                    result.Add(
                        new SupportedCulture()
                        {
                            Icon = culture.Icon,
                            Specificulture = culture.Specificulture,
                            Alias = culture.Alias,
                            FullName = culture.FullName,
                            Description = culture.FullName,
                            Id = culture.Id,
                            Lcid = culture.Lcid,
                            IsSupported = culture.Specificulture == initCulture
                        });

                }
            }
            return result;
        }
    }
}
