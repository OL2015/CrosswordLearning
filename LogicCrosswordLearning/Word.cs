namespace LogicCrosswordLearning
{
    public class Word
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Definition { get { return $"This is the {Value}"; } }
    }
}