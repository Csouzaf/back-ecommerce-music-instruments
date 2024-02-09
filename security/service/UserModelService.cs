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
    public class UserModelService : IUserModel
    {

        private readonly AppDbContext _appDbContext;

        public UserModelService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public UserModel findByName(string Name){
            return _appDbContext.UserModel.FirstOrDefault(u => u.FirstName == Name);
        }
        
        public UserModel FindByEmail(string Email){
            return _appDbContext.UserModel.FirstOrDefault(u => u.Email == Email);
        }

        public UserModel Create(UserModel userModel){
            _appDbContext.UserModel.Add(userModel);
            _appDbContext.SaveChanges();
            return userModel;
        }
    }

}