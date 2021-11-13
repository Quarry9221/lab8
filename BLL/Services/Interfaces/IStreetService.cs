using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IStreetService
    {
        IEnumerable<StreetDTO> GetStreets(int page);
    }
}