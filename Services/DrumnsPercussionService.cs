using ecommerce_music_back.data;
using ecommerce_music_back.Error;
using ecommerce_music_back.Models;
using ecommerce_music_back.Repository;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.Services
{
    public class DrumnsPercussionService : IDrumnsPercussionRepository
    {
        private AppDbContext _appDbContext;

        public DrumnsPercussionService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<DrumnsPercussion>> FindAllAsync()
        {
            return await _appDbContext.drumnsPercussions.ToListAsync();
        }

        public async Task<DrumnsPercussion> FindByIdAsync(int id)
        {
            return await _appDbContext.drumnsPercussions.FirstOrDefaultAsync(result => result.Id == id);
        }

        public async Task<DrumnsPercussion> CreateAsync(DrumnsPercussion drumnsPercussion)
        {
            await _appDbContext.drumnsPercussions.AddAsync(drumnsPercussion);
            await _appDbContext.SaveChangesAsync();
            return drumnsPercussion;
        }

        public async Task<DrumnsPercussion> UpdateAsync(DrumnsPercussion drumnsPercussion, int id)
        {
            var verifyDrumsPercussionExist = await _appDbContext.drumnsPercussions.FirstOrDefaultAsync(result => result.Id == id);

            if(verifyDrumsPercussionExist == null)
            {
                throw new BadRequestError("Id não encontrado");
            }
            
            verifyDrumsPercussionExist.Name = drumnsPercussion.Name;

            verifyDrumsPercussionExist.Photo = drumnsPercussion.Photo;

            verifyDrumsPercussionExist.Material = drumnsPercussion.Material;

            verifyDrumsPercussionExist.Height = drumnsPercussion.Height;

            verifyDrumsPercussionExist.Width = drumnsPercussion.Width;
        
            verifyDrumsPercussionExist.Description = drumnsPercussion.Description;
            
            verifyDrumsPercussionExist.HasBaqueta = drumnsPercussion.HasBaqueta;

            verifyDrumsPercussionExist.IsNewOrUsed = drumnsPercussion.IsNewOrUsed;

            verifyDrumsPercussionExist.BrandId = drumnsPercussion.BrandId;

            verifyDrumsPercussionExist.ModelId = drumnsPercussion.ModelId;

            verifyDrumsPercussionExist.DrumnsPercussionCategoryId = drumnsPercussion.DrumnsPercussionCategoryId;

            _appDbContext.drumnsPercussions.Update(drumnsPercussion);
            await _appDbContext.SaveChangesAsync();
            return verifyDrumsPercussionExist;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var verifyDrumsPercussionExist = await _appDbContext.drumnsPercussions.FirstOrDefaultAsync(result => result.Id == id);

            if(verifyDrumsPercussionExist == null)
            {
                throw new BadRequestError("Id não encontrado");
            }

            _appDbContext.drumnsPercussions.Remove(verifyDrumsPercussionExist);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

    }
}