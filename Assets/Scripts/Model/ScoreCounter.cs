using System;

namespace Model
{
    public class ScoreCounter
    {
        private static ScoreCounter _instance;
        public static ScoreCounter Instance => _instance;

        private int _score;
        public int Score => _score;
        

        public event Action<int> OnScoreChanged;

        public ScoreCounter()
        {
            _instance = this;
        }

        public void AddScore(int addedScore)
        {
            if (addedScore <= 0)
                return;
            _score += addedScore;
            OnScoreChanged?.Invoke(_score);
        }
    }

    public static class ScoreCounterFacade
    {
        public static ScoreCounter ScoreCounterI => ScoreCounter.Instance;
    }
}