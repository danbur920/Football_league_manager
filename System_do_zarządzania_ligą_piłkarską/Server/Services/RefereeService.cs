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

        public async Task<RefereeDTO> GetRefereeInfoById(int refereeId)
        {
            var referee = await _refereeRepository.GetRefereeInfoById(refereeId);
            var mappedReferee =  _mapper.Map<RefereeDTO>(referee);

            var totalRefereeStats = mappedReferee.RefereeStats;

            foreach (var stat in totalRefereeStats)
            {
                mappedReferee.TotalYellowCards += stat.YellowCardsGiven;
                mappedReferee.TotalRedCards += stat.RedCardsGiven;
                mappedReferee.TotalRefereedMatches += stat.RefereedMatches;
                mappedReferee.TotalPenaltiesAwarded += stat.PenaltiesAwarded;
                mappedReferee.TotalFoulsCalled += stat.FoulsCalled;
            }

            return mappedReferee;
        }

        public async Task<List<RefereeDTO>> GetRefereesByPage(int pageNumber, int pageSize)
        {
            var referees = await _refereeRepository.GetRefereesByPage(pageNumber, pageSize);
            return _mapper.Map<List<RefereeDTO>>(referees);
        }
    }
}
