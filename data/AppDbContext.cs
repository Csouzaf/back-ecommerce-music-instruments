using ecommerce_music_back.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

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

            modelBuilder.Entity<DrumnsCategory>()
                .HasMany(relations => relations.DrumnsPercussions)
                .WithOne(relations => relations.DrumnsCategory)
                .HasForeignKey(relations => relations.DrumnsPercussionId);

            modelBuilder.Entity<PianoCategory>()
                .HasMany(relations => relations.PianoKeyboards)
                .WithOne(relations => relations.PianoCategory)
                .HasForeignKey(relations => relations.PianoCategoryId);

            modelBuilder.Entity<WindCategory>()
                .HasMany(relations => relations.WindInstruments)
                .WithOne(relations => relations.WindCategory)
                .HasForeignKey(relations => relations.WindInstrumentId);

            modelBuilder.Entity<StringsCategory>()
                .HasMany(relations => relations.StringInstruments)
                .WithOne(relations => relations.StringsCategory)
                .HasForeignKey(relations => relations.StringsInstrumentId);

            modelBuilder.Entity<SoundBoxCategory>()
                .HasMany(relations => relations.SoundBoxs)
                .WithOne(relations => relations.SoundBoxCategory)
                .HasForeignKey(relations => relations.SoundBoxId);
        }

    }

    

    

}