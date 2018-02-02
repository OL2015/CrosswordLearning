﻿using System;
using System.Collections.Generic;

namespace LogicCrosswordLearning
{
    public class Crossword
    {
        public char[,] Board { get;  set; } 
        public int N { get;  set; } //size X
        public int M { get;  set; } //size Y
        public Dictionary<Tuple<int, int>, char> UserAnswers { get; set; }
        public Dictionary<Tuple<int, int>, Word> VerticalWords { get; set; }
        public Dictionary<Tuple<int, int>, Word> HorizontalWords { get; set; }       

    }

    
}
