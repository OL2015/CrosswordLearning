using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicCrosswordLearning.CrosswordCreator
{
    public class CrosswordCreator
    {

        const string Letters = "abcdefghijklmnopqrstuvwxyz";

        readonly int[] _dirX = { 0, 1 };
        readonly int[] _dirY = { 1, 0 };
        private List<Word> words = new List<Word>();
        readonly int _n;
        readonly int _m;
        char[,] _board;
        readonly int[,] _hWords;
        readonly int[,] _vWords;
       
        int _hCount, _vCount;
        static Random _rand;
        
        private List<string> _wordsToInsert = new List<string>();
        Dictionary<Tuple<int, int>, Word> verticalWords = new Dictionary<Tuple<int, int>, Word>();
        Dictionary<Tuple<int, int>, Word> horizontalWords = new Dictionary<Tuple<int, int>, Word>();
        private List<Word> notUsedListView = new List<Word>();
         

        public CrosswordCreator(int xDimen, int yDimen, IEnumerable<Word> words)
        {
            _n = xDimen;
            _m = yDimen;
            _rand = new Random();
            _board = new char[xDimen, yDimen];
            _hWords = new int[xDimen, yDimen];
            _vWords = new int[xDimen, yDimen];


            for (var i = 0; i < _n; i++)
            {
                for (var j = 0; j < _m; j++)
                {
                    _board[i, j] = ' ';
                }
            }
            this.words.AddRange(words);
        }
 

        public Crossword GetCrossword()
        {
            // create _board, verticalWords, horizontalWords
            GenCrossword();
            Crossword crossword = new Crossword(_board, verticalWords, horizontalWords);
            return crossword;
        }

        void GenCrossword()
        {
            horizontalWords.Clear();
            verticalWords.Clear();
            notUsedListView.Clear();
            Reset();
             
            foreach (var word in words)
            {
                //var wordToInsert = ((bool)RTLRadioButton.IsChecked) ? word.Reverse().Aggregate("",(x,y) => x + y) : word;
                var info = AddWord(word.Value);
                switch (info.Item3)
                {
                    case 0:
                        verticalWords.Add(new Tuple<int,int>(info.Item1, info.Item2), word);
                        break;
                    case 1:
                        horizontalWords.Add(new Tuple<int, int>(info.Item1, info.Item2), word);
                        break;
                    default:
                        notUsedListView.Add(word);
                        break;

                }
            }
            
        }

        public Tuple<int, int, int> AddWord(string word)
        {

            //var max = int.MaxValue;
            #region ubicate the word into the board
            var wordToInsert = word;
            var info = BestPosition(wordToInsert);
            if (info != null)
            {
                if (info.Item3 == 0)
                {
                    _hCount++;                    
                }
                else
                    _vCount++;
                var value = info.Item3 == 0 ? _hCount : _vCount;
                PutWord(wordToInsert, info.Item1, info.Item2, info.Item3, value);                
            }
            else
            {
                info = new Tuple<int, int, int>(-1, -1, -1);
            }
            #endregion

            return info;

        }

        void PutWord(string word, int x, int y, int dir, int value)
        {
            var mat = dir == 0 ? _hWords : _vWords;

            for (var i = 0; i < word.Length; i++)
            {
                int x1 = x + _dirX[dir] * i, y1 = y + _dirY[dir] * i;
                _board[x1, y1] = word[i];
                mat[x1, y1] = value;
            }

            int xStar = x - _dirX[dir], yStar = y - _dirY[dir];
            if (IsValidPosition(xStar, yStar)) _board[xStar, yStar] = '*';
            xStar = x + _dirX[dir] * word.Length;
            yStar = y + _dirY[dir] * word.Length;
            if (IsValidPosition(xStar, yStar)) _board[xStar, yStar] = '*';
        }

        List<Tuple<int, int, int>> FindPositions(string word)
        {
            #region find best position to ubicate the word into the board
            var max = 0;
            var positions = new List<Tuple<int, int, int>>();
            for (var x = 0; x < _n; x++)
            {
                for (var y = 0; y < _m; y++)
                {
                    for (var i = 0; i < _dirX.Length; i++)
                    {
                        var dir = i;
                        var wordToInsert = word;
                        var count = CanBePlaced(wordToInsert, x, y, dir);

                        if (count < max) continue;
                        if (count > max)
                            positions.Clear();

                        max = count;
                        positions.Add(new Tuple<int, int, int>(x, y, dir));
                    }
                }
            }
            #endregion

            return positions;
        }

        Tuple<int, int, int> BestPosition(string word)
        {
            var positions = FindPositions(word);
            if (positions.Count > 0)
            {
                var index = _rand.Next(positions.Count);
                return positions[index];
            }
            return null;
        }

        public void Reset()
        {
            for (var i = 0; i < _n; i++)
            {
                for (var j = 0; j < _m; j++)
                {
                    _board[i, j] = ' ';
                    _vWords[i, j] = 0;
                    _hWords[i, j] = 0;
                    _hCount = _vCount = 0;
                }
            }
        }

        int CanBePlaced(string word, int x, int y, int dir)
        {
            var result = 0;
            if (dir == 0)
            {

                for (var j = 0; j < word.Length; j++)
                {
                    int x1 = x, y1 = y + j;
                    if (!(IsValidPosition(x1, y1) && (_board[x1, y1] == ' ' || _board[x1, y1] == word[j])))
                        return -1;
                    if (IsValidPosition(x1 - 1, y1))
                        if (_hWords[x1 - 1, y1] > 0)
                            return -1;
                    if (IsValidPosition(x1 + 1, y1))
                        if (_hWords[x1 + 1, y1] > 0)
                            return -1;
                    if (_board[x1, y1] == word[j])
                        result++;
                }

            }

            else
            {
                for (var j = 0; j < word.Length; j++)
                {
                    int x1 = x + j, y1 = y;
                    if (!(IsValidPosition(x1, y1) && (_board[x1, y1] == ' ' || _board[x1, y1] == word[j])))
                        return -1;
                    if (IsValidPosition(x1, y1 - 1))
                        if (_vWords[x1, y1 - 1] > 0)
                            return -1;
                    if (IsValidPosition(x1, y1 + 1))
                        if (_vWords[x1, y1 + 1] > 0)
                            return -1;
                    if (_board[x1, y1] == word[j])
                        result++;
                }
            }

            int xStar = x - _dirX[dir], yStar = y - _dirY[dir];
            if (IsValidPosition(xStar, yStar))
                if (!(_board[xStar, yStar] == ' ' || _board[xStar, yStar] == '*'))
                    return -1;

            xStar = x + _dirX[dir] * word.Length;
            yStar = y + _dirY[dir] * word.Length;
            if (IsValidPosition(xStar, yStar))
                if (!(_board[xStar, yStar] == ' ' || _board[xStar, yStar] == '*'))
                    return -1;

            return result == word.Length ? -1 : result;

        }

        bool IsValidPosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < _n && y < _m;
        }

    }

}
