using ecommerce_music_back.Models;
using ecommerce_music_back.Models.admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce_music_back.data
{
    public class AppDbContext : DbContext
    {
        //private string _schema;
        protected readonly IConfiguration _configuration;

      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CommonUser> common_user { get; set; }

        public DbSet<AdminUser> admin_user { get; set; }
        
        public DbSet<DrumnsCategory> drumns_category { get; set; }

        public DbSet<PianoCategory> piano_category { get; set; }

        public DbSet<SoundBoxCategory> sound_box_category { get; set; }

        public DbSet<StringsCategory> strings_category { get; set; }

        public DbSet<WindCategory> wind_category { get; set; }

        public DbSet<Brand> brand  {get; set; }

        public DbSet<DrumnsPercussion> drumns_percussion { get; set; }

        public DbSet<Model> model { get; set; }

        public DbSet<PianoKeyboard> piano_keyboard { get; set; }

        public DbSet<SoundBox> sound_box { get; set; }

        public DbSet<StringInstrument> string_instrument { get; set; }

        public DbSet<WindInstrument> wind_instrument { get; set; }

        public DbSet<OrderPaymentProduct> order_payment_product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
    #region Brand

            modelBuilder.Entity<Brand>()
                .HasMany(relations => relations.models)
                .WithOne(relations => relations.brand)
                .HasForeignKey(relations => relations.brandId);

            modelBuilder.Entity<Brand>()
                .HasMany(relations => relations.pianoKeyboards)
                .WithOne(relations => relations.brand)
                .HasForeignKey(relations => relations.brandId);

            modelBuilder.Entity<Brand>()
                .HasMany(relations => relations.soundBoxs)
                .WithOne(relations => relations.brand)
                .HasForeignKey(relations => relations.brandId);

            modelBuilder.Entity<Brand>()
                .HasMany(relations => relations.stringInstruments)
                .WithOne(relations => relations.brand)
                .HasForeignKey(relations => relations.brandId);

            modelBuilder.Entity<Brand>()
                .HasMany(relations => relations.windInstruments)
                .WithOne(relations => relations.brand)
                .HasForeignKey(relations => relations.brandId);
#endregion
//------------------------------------------------------------------------------------------------------------------
#region model
            modelBuilder.Entity<Model>()
                .HasMany(relations => relations.windInstruments)
                .WithOne(relations => relations.model)
                .HasForeignKey(relations => relations.modelId);

            modelBuilder.Entity<Model>()
                .HasMany(relations => relations.stringInstruments)
                .WithOne(relations => relations.Models)
                .HasForeignKey(relations => relations.modelId);

            modelBuilder.Entity<Model>()
                .HasMany(relations => relations.drumnsPercussions)
                .WithOne(relations => relations.model)
                .HasForeignKey(relations => relations.modelId);
#endregion
//------------------------------------------------------------------------------------------------------------------
#region category
            modelBuilder.Entity<DrumnsCategory>()
                .HasMany(relations => relations.drumnsPercussions)
                .WithOne(relations => relations.drumnsCategory)
                .HasForeignKey(relations => relations.drumnsPercussionCategoryId);

            modelBuilder.Entity<PianoCategory>()
                .HasMany(relations => relations.pianoKeyboards)
                .WithOne(relations => relations.pianoCategory)
                .HasForeignKey(relations => relations.pianoCategoryId);

            modelBuilder.Entity<WindCategory>()
                .HasMany(relations => relations.windInstruments)
                .WithOne(relations => relations.windCategory)
                .HasForeignKey(relations => relations.windInstrumentCategoryId);

            modelBuilder.Entity<StringsCategory>()
                .HasMany(relations => relations.stringInstruments)
                .WithOne(relations => relations.stringsCategory)
                .HasForeignKey(relations => relations.stringInstrumentCategoryId);

            modelBuilder.Entity<SoundBoxCategory>()
                .HasMany(relations => relations.soundBoxs)
                .WithOne(relations => relations.soundBoxCategory)
                .HasForeignKey(relations => relations.soundBoxCategoryId);
#endregion
//------------------------------------------------------------------------------------------------------------------
#region commonuser

            modelBuilder.Entity<CommonUser>()
                .HasMany(relations => relations.StringInstruments)
                .WithOne(relations => relations.commonUser)
                .HasForeignKey(relations => relations.userId);

            modelBuilder.Entity<CommonUser>()
                .HasMany(relations => relations.WindInstruments)
                .WithOne(relations => relations.commonUser)
                .HasForeignKey(relations => relations.userId);

            modelBuilder.Entity<CommonUser>()
                .HasMany(relations => relations.SoundBoxs)
                .WithOne(relations => relations.commonUser)
                .HasForeignKey(relations => relations.userId);

            modelBuilder.Entity<CommonUser>()
                .HasMany(relations => relations.DrumnsPercussions)
                .WithOne(relations => relations.commonUser)
                .HasForeignKey(relations => relations.userId);

#endregion
//------------------------------------------------------------------------------------------------------------------
#region drumns
            modelBuilder.Entity<DrumnsPercussion>()
                .HasOne(relations => relations.brand)
                .WithMany(relations => relations.drumnsPercussions)
                .HasForeignKey(relations => relations.brandId);

#endregion


#region PaymentProduct

            modelBuilder.Entity<PaymentProduct>()
                .HasOne(relations => relations.commonUser)
                .WithMany(relations => relations.paymentProducts)
                .HasForeignKey(relations => relations.commonUserId);


            modelBuilder.Entity<PaymentProduct>()
                .HasMany(relations => relations.orderPaymentProducts)
                .WithOne(relations => relations.paymentProduct)
                .HasForeignKey(relations => relations.paymentProductId);

            
            modelBuilder.Entity<PaymentProduct>()
                .HasOne(relations => relations.drumnsPercussion)
                .WithMany(relations => relations.paymentProducts)
                .HasForeignKey(relations => relations.drumnsPercussionId);

            modelBuilder.Entity<PaymentProduct>()
                .HasOne(relations => relations.pianoKeyboard)
                .WithMany(relations => relations.paymentProducts)
                .HasForeignKey(relations => relations.pianoKeyboardId);
                
            modelBuilder.Entity<PaymentProduct>()
                .HasOne(relations => relations.soundBox)
                .WithMany(relations => relations.paymentProducts)
                .HasForeignKey(relations => relations.soundBoxId);

            modelBuilder.Entity<PaymentProduct>()
                .HasOne(relations => relations.stringInstrument)
                .WithMany(relations => relations.paymentProducts)
                .HasForeignKey(relations => relations.stringInstrumentId);

            modelBuilder.Entity<PaymentProduct>()
                .HasOne(relations => relations.windInstrument)
                .WithMany(relations => relations.paymentProducts)
                .HasForeignKey(relations => relations.windInstrumentId);
        
#endregion

            
#region OrderProduct

            modelBuilder.Entity<OrderPaymentProduct>()
                .HasOne(relations => relations.commonUser)
                .WithMany(relations => relations.orderPaymentProducts)
                .HasForeignKey(relations => relations.common_user_Id);

 
#endregion       
        
        
        
        
        
        
        
        
        
        
        
        }

    }


}