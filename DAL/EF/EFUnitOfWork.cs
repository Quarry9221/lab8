using System;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private OSNContext db;
        private OSNRepository osnRepository;
        private StreetRepository streetRepository;

        public EFUnitOfWork(OSNContext context)
        {
            db = context;
        }
        public IOSNRepository OSNs
        {
            get
            {
                if (osnRepository == null)
                    osnRepository = new OSNRepository(db);
                return osnRepository;
            }
        }

        public IStreetRepository Streets
        {
            get
            {
                if (streetRepository == null)
                    streetRepository = new StreetRepository(db);
                return streetRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}