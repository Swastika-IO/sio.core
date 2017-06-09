using System;
using Swastika.Domain.Core.Commands;

namespace Swastika.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        CommandResponse Commit();
    }
}
