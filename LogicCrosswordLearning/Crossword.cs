using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicCrosswordLearning
{
    public class Crossword
    {
        public char[,] Board { get; private set; }
        public Dictionary<Tuple<int, int>, char> UserAnswers { get; set; }
        public Dictionary<Tuple<int, int>, Word> VerticalWords { get; private set; }
        public Dictionary<Tuple<int, int>, Word> HorizontalWords { get; private set; }
        private List<Tuple<int, int>> AllPositions { get; set; } = new List<Tuple<int, int>>();

        public int N { get { return Board.GetLength(0); } } //size X
        public int M { get { return Board.GetLength(1); } } //size Y

        public Crossword(char[,] board, Dictionary<Tuple<int, int>, Word> verticalWords, Dictionary<Tuple<int, int>, Word> horizontalWords)
        {
            Board = board;
            VerticalWords = verticalWords;
            HorizontalWords = horizontalWords;
            SortPositions();
        }

        public int? GetWordPos(int x, int y)
        {
            int? pos = new int?();
            var zzz = AllPositions.FindIndex(z=> z.Item1 == x && z.Item2 == y);
            if (zzz >= 0)
                pos = zzz + 1;
            return pos;
        }

        private void SortPositions()
        {            
            AllPositions.AddRange(HorizontalWords.Keys);
            AllPositions.AddRange(VerticalWords.Keys);
            AllPositions = AllPositions.Select(z => z).Distinct().ToList();
            AllPositions = AllPositions.OrderBy(z => z.Item2).ThenBy(z => z.Item1).ToList();
        }

    }


}
