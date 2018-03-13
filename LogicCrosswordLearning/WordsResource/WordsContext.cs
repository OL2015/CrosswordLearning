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

        public virtual DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
