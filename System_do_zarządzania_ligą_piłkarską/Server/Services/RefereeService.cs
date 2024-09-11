using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class RefereeService : IRefereeService
    {
        private readonly IRefereeRepository _refereeRepository;
        private readonly IMapper _mapper;

        public RefereeService(IRefereeRepository refereeRepository, IMapper mapper)
        {
            _refereeRepository = refereeRepository;
            _mapper = mapper;
        }
        public async Task<List<RefereeDTO>> GetRefereesByPage(int pageNumber, int pageSize)
        {
            var referees = await _refereeRepository.GetRefereesByPage(pageNumber, pageSize);
            return _mapper.Map<List<RefereeDTO>>(referees);
        }
    }
}
