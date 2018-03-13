namespace LogicCrosswordLearning.WordsResource
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Word")]
    public partial class Word
    {
        [Key]
        public int Word_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Value { get; set; }

        public int Language_ID { get; set; }

        public bool? Archived { get; set; }
    }
}
