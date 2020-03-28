using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MinimaFramework
{
    public class SystemManager
    {
        private List<GameSystem> _gameSystems;
        
        
        public SystemManager()
        {
                _gameSystems = new List<GameSystem>();
        }

        public void RegSystem(GameSystem system, bool reg = true)
        {
            if (reg)
                _gameSystems.Add(system);
        }

        public void Update()
        {
            foreach (var t in _gameSystems)
            {
                 t.Update();
            }
        }

     

    }
}