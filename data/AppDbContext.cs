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


        public DbSet<UserModel> user_model { get; set; }
        
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

        public DbSet<OrderProductsUser> order_products_user { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(relations => relations.models)
                .WithOne(relations => relations.brand)
                .HasForeignKey(relations => relations.brandId);

            modelBuilder.Entity<DrumnsPercussion>()
                .HasOne(relations => relations.brand)
                .WithMany(relations => relations.drumnsPercussions)
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

            modelBuilder.Entity<UserModel>()
                .HasMany(relations => relations.StringInstruments)
                .WithOne(relations => relations.userModel)
                .HasForeignKey(relations => relations.userId);

            modelBuilder.Entity<UserModel>()
                .HasMany(relations => relations.WindInstruments)
                .WithOne(relations => relations.userModel)
                .HasForeignKey(relations => relations.userId);

            modelBuilder.Entity<UserModel>()
                .HasMany(relations => relations.SoundBoxs)
                .WithOne(relations => relations.userModel)
                .HasForeignKey(relations => relations.userId);

            modelBuilder.Entity<UserModel>()
                .HasMany(relations => relations.DrumnsPercussions)
                .WithOne(relations => relations.userModel)
                .HasForeignKey(relations => relations.userId);

            modelBuilder.Entity<DrumnsPercussion>()
                .HasOne(relations => relations.orderProductsUser)
                .WithOne(relations => relations.drumnsPercussion)
                .HasForeignKey<OrderProductsUser>(relations => relations.drumnsPercussionId);
        }

    }

    

    

}