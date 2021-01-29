using System.Collections.Generic;
using System.Threading.Tasks;
using RPG_Project.DTOs;
using RPG_Project.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;
using RPG_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace RPG_Project.Services.Character
{
    public class CharacterService : ICharacterService
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger _log;

        public CharacterService(AppDBContext dbContext, IMapper mapper, ILogger<CharacterService> log)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _log = log;
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newSkill)
        {
            _log.LogInformation("Start Add CharacterSkill process.");
            var character = await _dbContext.Characters
            .Include(x => x.Weapon)
            .Include(x => x.CharacterSkills).ThenInclude(x => x.Skill)
            .FirstOrDefaultAsync(x => x.Id == newSkill.CharacterId);


            if (character == null)
            {
                _log.LogError("Character not found.");
                return ResponseResult.Failure<GetCharacterDto>("Character not found.");
            }

            _log.LogInformation("Character founded.");

            var skill = await _dbContext.Skills.FirstOrDefaultAsync(x => x.Id == newSkill.SkillId);
            if (skill == null)
            {
                _log.LogError("Skill not found.");
                return ResponseResult.Failure<GetCharacterDto>("Character not found.");
            }

            _log.LogInformation("Skill founded.");
            var characterSkill = new CharacterSkill
            {
                Character = character,
                Skill = skill
            };


            _dbContext.CharacterSkills.Add(characterSkill);
            await _dbContext.SaveChangesAsync();

            _log.LogInformation("Success.");

            var dto = _mapper.Map<GetCharacterDto>(character);

            _log.LogInformation("End.");

            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon)
        {
            var character = await _dbContext.Characters.FirstOrDefaultAsync(x => x.Id == newWeapon.CharacterId);
            if (character == null)
            {
                return ResponseResult.Failure<GetCharacterDto>("Character not found.");
            }

            var weapon = new Weapon
            {
                Name = newWeapon.Name,
                Damage = newWeapon.Damage,
                CharacterId = newWeapon.CharacterId

            };
            _dbContext.Weapons.Add(weapon);
            await _dbContext.SaveChangesAsync();

            var dto = _mapper.Map<GetCharacterDto>(character);
            return ResponseResult.Success(dto);

        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var characters = await _dbContext.Characters
            .Include(x => x.Weapon)
            .AsNoTracking()
            .ToListAsync();
            var dto = _mapper.Map<List<GetCharacterDto>>(characters);

            return ResponseResult.Success(dto);
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int characterId)
        {
            var character = await _dbContext.Characters
            .Include(x => x.Weapon)
            .FirstOrDefaultAsync(x => x.Id == characterId);
            if (character == null)
            {
                return ResponseResult.Failure<GetCharacterDto>("Character not found.");
            }

            var dto = _mapper.Map<GetCharacterDto>(character);

            return ResponseResult.Success(dto);
        }
    }
}