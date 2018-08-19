using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NCMB
{
    public class ScoreRanking
    {
        public string _name { get; private set; }
        public int _score { get; set; }
        
        public ScoreRanking(string name, int score)
        {
            _name = name;
            _score = score;
        }

        public string GetRanking()
        {
            return "  " + _name + "  " + _score.ToString();
        }
    }

}
