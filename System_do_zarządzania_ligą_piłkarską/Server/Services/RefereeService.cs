using AutoMapper;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Referees;

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

        // League Master Panel:

        public async Task<List<ShortRefereeInfoDTO>> GetAllReferees()
        {
            var referees = await _refereeRepository.GetAllReferees();
            return _mapper.Map<List<ShortRefereeInfoDTO>>(referees);
        }

        public async Task AddRefereeToTheSeason(NewRefereeStatDTO newRefereeDTO)
        {
            var refereeToAdd = _mapper.Map<RefereeStat>(newRefereeDTO);

            refereeToAdd.RefereedMatches = 0;
            refereeToAdd.YellowCardsGiven = 0;
            refereeToAdd.RedCardsGiven = 0;
            refereeToAdd.PenaltiesAwarded = 0;
            refereeToAdd.FoulsCalled = 0;

            await _refereeRepository.AddRefereeToTheSeason(refereeToAdd);
        }
    }
}


//public int Id { get; set; }
//public int RefereeId { get; set; }
//public int LeagueId { get; set; }
//public int RefereedMatches { get; set; }
//public int YellowCardsGiven { get; set; }
//public int RedCardsGiven { get; set; }
//public int PenaltiesAwarded { get; set; }
//public int FoulsCalled { get; set; }