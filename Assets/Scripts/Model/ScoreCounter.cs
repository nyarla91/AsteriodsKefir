using System;

namespace Model
{
    public class ScoreCounter
    {
        private int _score;
        public int Score => _score;
        

        public event Action<int> OnScoreChanged;

        public void AddScore(int addedScore)
        {
            if (addedScore <= 0)
                return;
            _score += addedScore;
            OnScoreChanged?.Invoke(_score);
        }
    }
}