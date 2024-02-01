using ecommerce_music_back.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_music_back.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

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

            // modelBuilder.Entity<DrumnsPercussion>()
            //     .HasOne(relations => relations.Brand)
            //     .WithMany(relations => relations.DrumnsPercussions)
            //     .HasForeignKey(relations => relations.BrandId);

            // modelBuilder.Entity<Brand>()
            //     .HasMany(relations => relations.PianoKeyboards)
            //     .WithOne(relations => relations.Brand)
            //     .HasForeignKey(relations => relations.BrandId);

            // modelBuilder.Entity<Brand>()
            //     .HasMany(relations => relations.SoundBoxs)
            //     .WithOne(relations => relations.Brand)
            //     .HasForeignKey(relations => relations.BrandId);

            // modelBuilder.Entity<Brand>()
            //     .HasMany(relations => relations.StringInstruments)
            //     .WithOne(relations => relations.Brand)
            //     .HasForeignKey(relations => relations.BrandId);

            // modelBuilder.Entity<Brand>()
            //     .HasMany(relations => relations.WindInstruments)
            //     .WithOne(relations => relations.Brand)
            //     .HasForeignKey(relations => relations.BrandId);
        }

    }

    

    

}