

using ecommerce_music_back.Models.admin;

namespace ecommerce_music_back.security.Data
{
    public interface IUserModel
    {
        UserModel findByName(string Name);

        UserModel Create(UserModel userModel);
    }
}