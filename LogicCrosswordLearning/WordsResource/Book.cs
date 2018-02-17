namespace LogicCrosswordLearning.WordsResource
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            WordEntries = new HashSet<WordEntry>();
            Authors = new HashSet<Author>();
        }

        [Key]
        public int Book_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int Language_ID { get; set; }

        public int NumberOfPages { get; set; }

        public int Format_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegisterDate { get; set; }

        public virtual Format Format { get; set; }

        public virtual Language Language { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WordEntry> WordEntries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Author> Authors { get; set; }
    }
}
