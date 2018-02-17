namespace LogicCrosswordLearning.WordsResource
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WordsContext : DbContext
    {
        public WordsContext()
            : base("name=WordsContext")
        {
        }       

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Format> Formats { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LearnStatistic> LearnStatistics { get; set; }
        public virtual DbSet<SpeechPart> SpeechParts { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<WordEntry> WordEntries { get; set; }
        public virtual DbSet<WordMeaning> WordMeanings { get; set; }
        public virtual DbSet<WordMeaningStatistic> WordMeaningStatistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithMany(e => e.Authors)
                .Map(m => m.ToTable("AuthorBook").MapLeftKey("Author_ID").MapRightKey("Book_ID"));

            modelBuilder.Entity<Book>()
                .HasMany(e => e.WordEntries)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Format>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Format)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Words)
                .WithRequired(e => e.Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Word>()
                .HasMany(e => e.WordEntries)
                .WithRequired(e => e.Word)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Word>()
                .HasMany(e => e.WordMeanings)
                .WithRequired(e => e.Word)
                .HasForeignKey(e => e.MasterWord_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Word>()
                .HasMany(e => e.WordMeanings1)
                .WithRequired(e => e.Word1)
                .HasForeignKey(e => e.TranslateWord_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WordEntry>()
                .HasMany(e => e.WordMeanings)
                .WithMany(e => e.WordEntries)
                .Map(m => m.ToTable("WordTranslation").MapLeftKey("WordEntry_ID").MapRightKey("WordMeaning_ID"));

            modelBuilder.Entity<WordMeaning>()
                .HasMany(e => e.LearnStatistics)
                .WithRequired(e => e.WordMeaning)
                .WillCascadeOnDelete(false);
        }
    }
}
