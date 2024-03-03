using ecommerce_music_back.Models;
using ecommerce_music_back.Models.admin;
using ecommerce_music_back.security.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ecommerce_music_back.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    
        public DbSet<UserModel> UserModel { get; set; }
        
        public DbSet<DrumnsCategory> DrumnsCategory { get; set; }

        public DbSet<PianoCategory> PianoCategory { get; set; }

        public DbSet<SoundBoxCategory> SoundBoxCategory { get; set; }

        public DbSet<StringsCategory> StringsCategory { get; set; }

        public DbSet<WindCategory> WindCategory { get; set; }

        public DbSet<Brand> brand  {get; set; }

        public DbSet<DrumnsPercussion> drumnsPercussions { get; set; }

        public DbSet<Model> models { get; set; }

        public DbSet<PianoKeyboard> pianoKeyboards { get; set; }

        public DbSet<SoundBox> soundBoxes { get; set; }

        public DbSet<ResetPassword> ResetPassword { get; set; }

        public DbSet<StringInstrument> stringInstruments { get; set; }

        public DbSet<WindInstrument> windInstruments { get; set; }

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