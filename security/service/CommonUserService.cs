
using ecommerce_music_back.data;
using ecommerce_music_back.Models.admin;
using ecommerce_music_back.security.Data;


namespace ecommerce_music_back.security.service
{
    public class CommonUserService : ICommonUser
    {

        private readonly AppDbContext _appDbContext;

        public CommonUserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public CommonUser findByName(string Name){
            return _appDbContext.common_user.FirstOrDefault(u => u.FirstName == Name);
        }
        
        public CommonUser FindByEmail(string Email){
            return _appDbContext.common_user.FirstOrDefault(u => u.Email == Email);
        }

        public CommonUser Create(CommonUser CommonUser){
            _appDbContext.common_user.Add(CommonUser);
            _appDbContext.SaveChanges();
            return CommonUser;
        }
    }

}