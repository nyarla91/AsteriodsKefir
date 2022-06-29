using System;
using System.Threading.Tasks;

namespace Model
{
    public class Timer
    {
        public float Duration { get; set; }

        private float _timeElapsed;

        public event Action OnExpired; 

        public Timer(float duration)
        {
            Duration = duration;
        }

        public void Update(float deltaTime)
        {
            _timeElapsed += deltaTime;
            if (!(_timeElapsed >= Duration))
                return;
            
            OnExpired?.Invoke();
            _timeElapsed -= Duration;
        }
    }
}