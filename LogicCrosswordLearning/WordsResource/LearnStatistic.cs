namespace LogicCrosswordLearning.WordsResource
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LearnStatistic")]
    public partial class LearnStatistic
    {
        [Key]
        public int LearnStatistics_ID { get; set; }

        public int WordMeaning_ID { get; set; }

        public DateTime AttempTime { get; set; }

        public bool Answer { get; set; }

        public bool LearnDirection { get; set; }

        public virtual WordMeaning WordMeaning { get; set; }
    }
}
