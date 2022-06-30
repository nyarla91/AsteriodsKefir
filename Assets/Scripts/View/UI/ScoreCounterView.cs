using Model;
using TMPro;
using UnityEngine;

namespace View.UI
{
    public class ScoreCounterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counter;
        [SerializeField] private string _prefix = "Score: ";
        
        public ScoreCounter Model { get; private set; }

        private void Awake()
        {
            Model = new ScoreCounter();
            Model.OnScoreChanged += UpdateScore;
            UpdateScore(0);
        }

        private void UpdateScore(int score)
        {
            _counter.text = $"{_prefix}{score}";
        }
    }
}