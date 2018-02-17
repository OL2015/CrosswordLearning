namespace LogicCrosswordLearning.WordsResource
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WordMeaningStatistic")]
    public partial class WordMeaningStatistic
    {
        [Key]
        public int WordMeaningStatistic_ID { get; set; }

        public int WordMeaning_ID { get; set; }

        public bool NewEntry { get; set; }

        public DateTime EntryTime { get; set; }

        public virtual WordMeaning WordMeaning { get; set; }
    }
}
