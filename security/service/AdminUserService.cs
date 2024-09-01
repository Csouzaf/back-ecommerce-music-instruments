using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce_music_back.data;
using ecommerce_music_back.Models;
using ecommerce_music_back.Models.admin;
using ecommerce_music_back.security.Data;


namespace ecommerce_music_back.security.service
{
    public class AdminUserService : IAdminUser
    {

        private readonly AppDbContext _appDbContext;

        public AdminUserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public AdminUser findByName(string Name){
            return _appDbContext.admin_user.FirstOrDefault(u => u.FirstName == Name);
        }
        
        public AdminUser FindByEmail(string Email){
            return _appDbContext.admin_user.FirstOrDefault(u => u.Email == Email);
        }

        public AdminUser Create(AdminUser AdminUser){
            _appDbContext.admin_user.Add(AdminUser);
            _appDbContext.SaveChanges();
            return AdminUser;
        }
    }

}