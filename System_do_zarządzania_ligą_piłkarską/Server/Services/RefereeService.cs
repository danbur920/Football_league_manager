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
                mappedReferee.TotalYellowCardsGiven += stat.YellowCardsGiven;
                mappedReferee.TotalRedCardsGiven += stat.RedCardsGiven;
                mappedReferee.TotalRefereedMatches += stat.RefereedMatches;
                mappedReferee.TotalPenaltiesAwarded += stat.PenaltiesAwarded;
            }

            return mappedReferee;
        }

        public async Task<List<RefereeDTO>> GetRefereesByPage(int pageNumber, int pageSize)
        {
            var referees = await _refereeRepository.GetRefereesByPage(pageNumber, pageSize);
            return _mapper.Map<List<RefereeDTO>>(referees);
        }

        // League Master Panel:

        public async Task<RefereeInfoDTO> GetRefereeToManage(int refereeId)
        {
            var referee = await _refereeRepository.GetRefereeToManage(refereeId);
            return _mapper.Map<RefereeInfoDTO>(referee);
        }

        public async Task<List<ShortRefereeInfoDTO>> GetAllRefereesForLeagueMaster()
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

            await _refereeRepository.AddRefereeToTheSeason(refereeToAdd);
        }

        public async Task<List<ShortRefereeInfoDTO>> GetAllRefereesFromSpecificSeason(int leagueSeasonId)
        {
            var referees = await _refereeRepository.GetAllRefereesFromSpecificSeason(leagueSeasonId);
            return _mapper.Map<List<ShortRefereeInfoDTO>>(referees);
        }

        public async Task AddNewReferee(NewRefereeDTO newReferee)
        {
            var mappedReferee = _mapper.Map<Referee>(newReferee);
            await _refereeRepository.AddNewReferee(mappedReferee);
        }

        public async Task<List<RefereeInfoDTO>> GetCreatedRefereesByLeagueMaster(string userId)
        {
            var referees = await _refereeRepository.GetCreatedRefereesByLeagueMaster(userId);
            return _mapper.Map<List<RefereeInfoDTO>>(referees);
        }

        public async Task EditReferee(RefereeInfoDTO editReferee)
        {
            var currentReferee = await _refereeRepository.GetRefereeToManage(editReferee.Id);

            currentReferee.FirstName = editReferee.FirstName;
            currentReferee.LastName =  editReferee.LastName;
            currentReferee.Nationality = editReferee.Nationality;
            currentReferee.DateOfBirth = editReferee.DateOfBirth;
            currentReferee.Level = editReferee.Level;

            await _refereeRepository.UpdateReferee(currentReferee);
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