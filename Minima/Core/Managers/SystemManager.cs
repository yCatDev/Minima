using System;
using System.Collections.Generic;

namespace MinimaFramework
{
    public class SystemManager
    {
        private List<GameSystem> _gameSystems;

        public SystemManager()
        {
            _gameSystems = new List<GameSystem>();
        }

        public void RegSystem(GameSystem system) => _gameSystems.Add(system);

        public void Update()
        {
            for (var index = 0; index < _gameSystems.Count; index++)
            {
                var gameSystem = _gameSystems[index];
                gameSystem.Update();
            }
        }

    }
}