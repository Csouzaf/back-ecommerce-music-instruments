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

                
        }

    }

    

    

}