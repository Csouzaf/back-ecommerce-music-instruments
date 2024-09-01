
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ecommerce_music_back.Models.admin
{
    [Table("admin_user")]
    public class AdminUser
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
 
        [Required]
        public string Password { get; set; }
        
        public string Address { get; set; }

        public string Cep { get; set; }

        public string Cnpj { get; set; }

        public string? Role { get; set; } = "ADMIN";

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public AdminUser()
        {
            Id = Guid.NewGuid();

        }
       
    }
}