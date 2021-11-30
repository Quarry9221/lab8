using System;
using System.Collections.Generic;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;
using AutoMapper;

namespace BLL.Services.Impl
{
    public class StreetService : IStreetService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 8;
        
        public StreetService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }

            _database = unitOfWork;
        }
        

        public IEnumerable<StreetDTO> GetStreets(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Director)
                && userType != typeof(Worker))
            {
                throw new MethodAccessException();
            }
            var osbbId = user.OSNID;
            var streetsEntities = 
                _database
                    .Streets
                    .Find(z => z.OSNID == osbbId, pageNumber, pageSize);
            var mapper = 
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Street, StreetDTO>()
                ).CreateMapper();
            var streetsDto = 
                mapper
                    .Map<IEnumerable<Street>, List<StreetDTO>>(
                        streetsEntities);
            return streetsDto;
        }
    }
}