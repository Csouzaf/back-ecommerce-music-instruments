

using ecommerce_music_back.Models.admin;

namespace ecommerce_music_back.security.Data
{
    public interface ICommonUser
    {
        CommonUser findByName(string Name);

        CommonUser FindByEmail(string Email);

        CommonUser Create(CommonUser commonUser);
    }
}