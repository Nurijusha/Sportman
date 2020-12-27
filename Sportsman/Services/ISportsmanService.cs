using Sportsman.Data.Dto;
using Sportsman.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Sportsman.Services
{
    public interface ISportsmanService
    {
        Task<SportsmanDto[]> Get(int id);

        Task<int> Create(SportsmanDto sportsmanDto);

        Task<int> Update(SportsmanDto sportsmanDto);

        Task Delete(int id);
    }
}
