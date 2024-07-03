using AutoMapper;
using ecommerce_music_back.data;
using ecommerce_music_back.Error;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;
using ecommerce_music_back.Repository;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.Services
{
    public class DrumnsPercussionService : IDrumnsPercussionRepository
    {
        private AppDbContext _appDbContext;

        public readonly IMapper _mapper;

        public DrumnsPercussionService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<List<DrumnsPercussion>> FindAllAsync()
        {
            return await _appDbContext.drumns_percussion.ToListAsync();
        }

        public async Task<DrumnsPercussion> FindByIdAsync(int id)
        {
            return await _appDbContext.drumns_percussion.FirstOrDefaultAsync(result => result.Id == id);
        }

        public async Task<DrumnsPercussion> CreateAsync(DrumnsPercussion drumnsPercussion)
        {
            await _appDbContext.drumns_percussion.AddAsync(drumnsPercussion);
            await _appDbContext.SaveChangesAsync();
            return drumnsPercussion;
        }

        public async Task<DrumnsPercussionResponse> UpdateAsync(DrumnsPercussion drumnsPercussion, int id)
        {
            var verifyDrumsPercussionExist = await _appDbContext.drumns_percussion.FirstOrDefaultAsync(result => result.Id == id);

            if(verifyDrumsPercussionExist == null)
            {
                throw new BadRequestError("Id não encontrado");
            }

            var updateUser = _mapper.Map<DrumnsPercussion>(drumnsPercussion);
            // _appDbContext.Entry(verifyDrumsPercussionExist).CurrentValues.SetValues(updateUser);
            _appDbContext.drumns_percussion.Update(updateUser);
            await _appDbContext.SaveChangesAsync();
            return _mapper.Map<DrumnsPercussionResponse>(updateUser);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var verifyDrumsPercussionExist = await _appDbContext.drumns_percussion.FirstOrDefaultAsync(result => result.Id == id);

            if(verifyDrumsPercussionExist == null)
            {
                throw new BadRequestError("Id não encontrado");
            }

            _appDbContext.drumns_percussion.Remove(verifyDrumsPercussionExist);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

    }
}