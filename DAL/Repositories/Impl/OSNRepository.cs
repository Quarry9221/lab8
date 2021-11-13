using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Impl
{
    public class OSNRepository : BaseRepository<OSN>, IOSNRepository
    {
        internal OSNRepository(OSNContext context)
            : base(context)
        {
            
        }
    }
}