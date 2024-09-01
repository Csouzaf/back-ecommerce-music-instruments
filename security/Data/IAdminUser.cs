

using ecommerce_music_back.Models.admin;

namespace ecommerce_music_back.security.Data
{
    public interface IAdminUser
    {
        AdminUser findByName(string Name);

        AdminUser FindByEmail(string Email);

        AdminUser Create(AdminUser AdminUser);
    }
}