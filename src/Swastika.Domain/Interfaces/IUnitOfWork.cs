using System;
using Swastika.Domain.Core.Commands;

namespace Swastika.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
