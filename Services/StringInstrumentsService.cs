
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using ecommerce_music_back.data;
using ecommerce_music_back.Error;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.response;
using ecommerce_music_back.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.Services
{

    public class StringInstrumentsService : IStringInstrumentsRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public StringInstrumentsService(AppDbContext appDbContext, IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }

        public async Task<List<StringInstrument>> FindAllAsync()
        {
            return await _appDbContext.string_instrument.ToListAsync();
        }


        public async Task<StringInstrument> FindByIdAsync(int stringId)
        {
            return await _appDbContext.string_instrument.FirstOrDefaultAsync(result => result.id == stringId);
        }

        public bool VerifyUserIsAuthenticated()
        {
            var httpContext = _httpContextAccessor.HttpContext.User;
            if (httpContext.Identity.IsAuthenticated)
            {
                return true;
            }
            return false;
        }

        public bool VerifyIsUserOrAdmin()
        {
            var httpContext = _httpContextAccessor.HttpContext.User;
            if (httpContext.IsInRole("ADMIN"))
            {
                return true;
            }
            return false;
        }

        public async Task<StringInstrumentResponse> CreateAsync(StringInstrument stringInstrument)
        {

            if (VerifyUserIsAuthenticated() && VerifyIsUserOrAdmin())
            {

                using (var contexto = _appDbContext)
                {

                    await _appDbContext.string_instrument.AddAsync(stringInstrument);
                    await _appDbContext.SaveChangesAsync();
                    return _mapper.Map<StringInstrumentResponse>(stringInstrument);

                }
            }

            else
            {
                return null;
            }

        }

        public async Task<StringInstrument> UpdateAsync(StringInstrument stringInstrument, int stringId)
        {
            var existStringInstument = await _appDbContext.string_instrument.FindAsync(stringId);

            if (existStringInstument == null)
            {
                throw new BadRequestError("Id doesn't exist");
            }
            // existStringInstument.Name = stringInstrument.Name;
            // existStringInstument.WithLever = stringInstrument.WithLever;
            // existStringInstument.NumberPickups = stringInstrument.NumberPickups;
            // existStringInstument.NumberStrings = stringInstrument.NumberPickups;
            // existStringInstument.HandOrientation = stringInstrument.HandOrientation;
            // existStringInstument.BrandId = stringInstrument.BrandId;
            // existStringInstument.Color = stringInstrument.Color;
            // existStringInstument.Photo = stringInstrument.Photo;
            // existStringInstument.WoodType = stringInstrument.WoodType;
            // existStringInstument.StringsInstrumentCategoryId = stringInstrument.StringsInstrumentCategoryId;

            _appDbContext.string_instrument.Update(existStringInstument);
            await _appDbContext.SaveChangesAsync();
            return existStringInstument;
        }

        public async Task<bool> DeleteAsync(int stringId)
        {
            StringInstrument existStringInstument = await _appDbContext.string_instrument.FindAsync(stringId);

            if (existStringInstument == null)
            {
                throw new BadRequestError("Id doesn't exist");
            }
            _appDbContext.string_instrument.Remove(existStringInstument);

            await _appDbContext.SaveChangesAsync();
            return true;
        }


        public async Task<int> CountStringInstruments(int id)
        {
            List<StringInstrument> stringInstruments = new List<StringInstrument>();
            int countStringInstruments = 0;

            try
            {
                using (var contexto = _appDbContext)
                {
                    stringInstruments = await contexto.string_instrument
                            .Where(m => m.stringInstrumentCategoryId == id)
                            .ToListAsync();

                    countStringInstruments = stringInstruments.Count();

                }

            }
            catch (System.Exception)
            {

                throw;
            }

            return countStringInstruments;

        }


    }
}