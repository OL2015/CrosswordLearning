using LogicCrosswordLearning;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Collections.Generic;
using WebCrosswordLearning.ViewModels;

namespace WebCrosswordLearning.Services
{
    public class WordSourceService : IWordSourceService
    {
        private IConfiguration configuration;
        private int quantityWord;

        public WordSourceService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IEnumerable<Word> GetWords(int quantityWord)
        {
            var filepath = configuration.GetConnectionString("FileConnection");
            var wordSource = new FileWordSource(filepath);
            var v = wordSource.GetWords(quantityWord);           
            return v;
        }

        public Crossword GetCrossword(int? n, int? m)
        {
            Crossword crossword;
            if (n.HasValue && m.HasValue)
                crossword = GetDummyCrossword(n.Value, m.Value);
            else
                crossword = GetDummyCrossword(5, 5);
            return crossword;
        }

        private Crossword GetDummyCrossword(int n, int m)
        {
            if (n < 5 || m < 5)
                throw new ApplicationException("Field can't be less than 5*5") ;
                        
            
            var board = new char[n, m];            
           
            var horizontalWords = new Dictionary<Tuple<int, int>, Word>();
            var verticalWords = new Dictionary<Tuple<int, int>, Word>();
            horizontalWords.Add(new Tuple<int, int>(0, 0), new Word() { Id = 1, Value = "cat"});
            horizontalWords.Add(new Tuple<int, int>(0, 3), new Word() { Id = 2, Value = "small" });
            verticalWords.Add(new Tuple<int, int>(0, 0), new Word() { Id = 3, Value = "cross" });
            verticalWords.Add(new Tuple<int, int>(4, 1), new Word() { Id = 4, Value = "ball" });
            board[0, 0] = 'c';
            board[1, 0] = 'a';
            board[2, 0] = 't';

            board[0, 3] = 's';
            board[1, 3] = 'm';
            board[2, 3] = 'a';
            board[3, 3] = 'l';
            board[4, 3] = 'l';

            board[0, 0] = 'c';
            board[0, 1] = 'r';
            board[0, 2] = 'o';
            board[0, 3] = 's';
            board[0, 4] = 's';

            board[4, 1] = 'b';
            board[4, 2] = 'a';
            board[4, 3] = 'l';
            board[4, 4] = 'l';

            Crossword crossword = new Crossword(board, verticalWords, horizontalWords);
            return crossword;
        }
    }
}
