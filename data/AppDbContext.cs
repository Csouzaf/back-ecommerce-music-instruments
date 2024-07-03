using ecommerce_music_back.Models;
using ecommerce_music_back.Models.admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce_music_back.data
{
    public class AppDbContext : DbContext
    {
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(relations => relations.Models)
                .WithOne(relations => relations.Brand)
                .HasForeignKey(relations => relations.BrandId);

            modelBuilder.Entity<DrumnsPercussion>()
                .HasOne(relations => relations.Brand)
                .WithMany(relations => relations.DrumnsPercussions)
                .HasForeignKey(relations => relations.BrandId);

            modelBuilder.Entity<Brand>()
                .HasMany(relations => relations.PianoKeyboards)
                .WithOne(relations => relations.Brand)
                .HasForeignKey(relations => relations.BrandId);

            modelBuilder.Entity<Brand>()
                .HasMany(relations => relations.SoundBoxs)
                .WithOne(relations => relations.Brand)
                .HasForeignKey(relations => relations.BrandId);

            modelBuilder.Entity<Brand>()
                .HasMany(relations => relations.StringInstruments)
                .WithOne(relations => relations.Brand)
                .HasForeignKey(relations => relations.BrandId);

            modelBuilder.Entity<Brand>()
                .HasMany(relations => relations.WindInstruments)
                .WithOne(relations => relations.Brand)
                .HasForeignKey(relations => relations.BrandId);

            modelBuilder.Entity<Model>()
                .HasMany(relations => relations.WindInstruments)
                .WithOne(relations => relations.Model)
                .HasForeignKey(relations => relations.ModelId);

            modelBuilder.Entity<Model>()
                .HasMany(relations => relations.StringInstruments)
                .WithOne(relations => relations.Models)
                .HasForeignKey(relations => relations.ModelId);

            modelBuilder.Entity<Model>()
                .HasMany(relations => relations.DrumnsPercussions)
                .WithOne(relations => relations.Model)
                .HasForeignKey(relations => relations.ModelId);

            modelBuilder.Entity<DrumnsCategory>()
                .HasMany(relations => relations.DrumnsPercussions)
                .WithOne(relations => relations.DrumnsCategory)
                .HasForeignKey(relations => relations.DrumnsPercussionCategoryId);

            modelBuilder.Entity<PianoCategory>()
                .HasMany(relations => relations.PianoKeyboards)
                .WithOne(relations => relations.PianoCategory)
                .HasForeignKey(relations => relations.PianoCategoryId);

            modelBuilder.Entity<WindCategory>()
                .HasMany(relations => relations.WindInstruments)
                .WithOne(relations => relations.WindCategory)
                .HasForeignKey(relations => relations.WindInstrumentCategoryId);

            modelBuilder.Entity<StringsCategory>()
                .HasMany(relations => relations.StringInstruments)
                .WithOne(relations => relations.StringsCategory)
                .HasForeignKey(relations => relations.StringsInstrumentCategoryId);

            modelBuilder.Entity<SoundBoxCategory>()
                .HasMany(relations => relations.SoundBoxs)
                .WithOne(relations => relations.SoundBoxCategory)
                .HasForeignKey(relations => relations.SoundBoxCategoryId);
        }

    }

    

    

}