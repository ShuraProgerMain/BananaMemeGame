using System.Collections.Generic;
using ShuraGames.BananaMeme.Gameplay.Updating.Interfaces;

namespace ShuraGames.BananaMeme.Gameplay.Updating
{
    public sealed class Updater : IUpdated
    {
        private readonly List<IUpdated> _updaters = new(); // Нужно ли их отсюда удалять? Наверное нужно, а может и нет.

        public void AddUpdater(IUpdated updater)
        {
            _updaters.Add(updater);
        }
        
        public void Update()
        {
            foreach (var updater in _updaters)
            {
                updater.Update();
            }
        }
    }
}