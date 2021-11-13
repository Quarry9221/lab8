using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl
{
    public class StreetRepository
        : BaseRepository<Street>, IStreetRepository
    {
        internal StreetRepository(OSNContext context) 
            : base(context)
        {
        }
    }
}