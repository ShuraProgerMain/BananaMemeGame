using System.Collections.Generic;
using ShuraGames.BananaMeme.Gameplay.Pausing.Interfaces;

namespace ShuraGames.BananaMeme.Gameplay.Pausing
{
    public class Pauser : IPaused
    {
        private readonly List<IPaused> _pausing = new();
        
        public void Add(IPaused paused)
        {
            _pausing.Add(paused);
        }

        public void TurnOnPause()
        {
            foreach (var paused in _pausing)
            {
                paused.TurnOnPause();
            }
        }

        public void TurnOffPause()
        {
            foreach (var paused in _pausing)
            {
                paused.TurnOffPause();
            }
        }
    }
}