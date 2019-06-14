using System;


namespace Shop.BLL.Services
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
