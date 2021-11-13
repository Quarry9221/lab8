using System;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IOSNRepository OSNs { get; }
        IStreetRepository Streets { get; }
        void Save();
    }
}