using Sportsman.Data;
using Sportsman.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sportsman.Data.Models;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace Sportsman.Services
{
    public class SportsmanService : ISportsmanService
    {
        private readonly SportsmansDbContext _sportsmanDbContext;

        public SportsmanService(SportsmansDbContext sportsmanDbContext)
        {
            _sportsmanDbContext = sportsmanDbContext ?? throw new ArgumentNullException(nameof(sportsmanDbContext));
        }

        public async Task<SportsmanDto[]> Get(int id)
        {
            var sportsmans = await _sportsmanDbContext.Sportsmans
                .Where(x => x.TeamId.HasValue)
                .ToArrayAsync();

            var sportsmansDtos = new List<SportsmanDto>();
            foreach (var s in sportsmans)
            {
                sportsmansDtos.Add(new SportsmanDto
                {
                    TeamName = s.Team.Name
                });
            }

            return await _sportsmanDbContext.Sportsmans
                .Where(x => x.Team.Name == "Футбол")
                .Select(x => new SportsmanDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                    Experience = x.Experience,
                    TeamId = x.TeamId,
                    TeamName = x.Team.Name
                })
                .ToArrayAsync();
        }

        public async Task<int> Create(SportsmanDto sportsmanDto)
        {
            Data.Models.Sportsman sportsman = new Data.Models.Sportsman();

            AplyDtoToEntity(sportsman, sportsmanDto);

            _sportsmanDbContext.Sportsmans.Add(sportsman);
            await _sportsmanDbContext.SaveChangesAsync();

            return sportsman.Id;
        }

        public async Task<int> Update(SportsmanDto sportsmanDto)
        {
            Data.Models.Sportsman sportsman = _sportsmanDbContext.Sportsmans.Find(sportsmanDto.Id);

            AplyDtoToEntity(sportsman, sportsmanDto);

            await _sportsmanDbContext.SaveChangesAsync();

            return sportsman.Id;
        }

        public async Task Delete(int id)
        {
            Data.Models.Sportsman sportsman = _sportsmanDbContext.Sportsmans.Find(id);

            _sportsmanDbContext.Sportsmans.Remove(sportsman);
            await _sportsmanDbContext.SaveChangesAsync();
        }

        private void AplyDtoToEntity(Data.Models.Sportsman sportsman, SportsmanDto sportsmanDto)
        {
            sportsman.Name = sportsmanDto.Name;
            sportsman.Age = sportsmanDto.Age;
            sportsman.Experience = sportsmanDto.Experience;
            sportsman.TeamId = sportsmanDto.TeamId;
        }
    }
}
