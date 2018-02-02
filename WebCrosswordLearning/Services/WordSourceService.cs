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
            Crossword crossword = new Crossword();            
            crossword.N = n;
            crossword.M = m;
            crossword.Board = new char[n, m];            
           
            crossword.HorizontalWords = new Dictionary<Tuple<int, int>, Word>();
            crossword.VerticalWords = new Dictionary<Tuple<int, int>, Word>();
            crossword.HorizontalWords.Add(new Tuple<int, int>(0, 0), new Word() { Id = 1, Value = "cat"});
            crossword.HorizontalWords.Add(new Tuple<int, int>(0, 3), new Word() { Id = 2, Value = "small" });
            crossword.VerticalWords.Add(new Tuple<int, int>(0, 0), new Word() { Id = 3, Value = "cross" });
            crossword.VerticalWords.Add(new Tuple<int, int>(4, 1), new Word() { Id = 4, Value = "ball" });
            crossword.Board[0, 0] = 'c';
            crossword.Board[1, 0] = 'a';
            crossword.Board[2, 0] = 't';

            crossword.Board[0, 3] = 's';
            crossword.Board[1, 3] = 'm';
            crossword.Board[2, 3] = 'a';
            crossword.Board[3, 3] = 'l';
            crossword.Board[4, 3] = 'l';

            crossword.Board[0, 0] = 'c';
            crossword.Board[0, 1] = 'r';
            crossword.Board[0, 2] = 'o';
            crossword.Board[0, 3] = 's';
            crossword.Board[0, 4] = 's';

            crossword.Board[4, 1] = 'b';
            crossword.Board[4, 2] = 'a';
            crossword.Board[4, 3] = 'l';
            crossword.Board[4, 4] = 'l';

            return crossword;
        }
    }
}
