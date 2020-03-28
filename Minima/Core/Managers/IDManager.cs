using System;
using System.Collections.Generic;

namespace MinimaFramework
{
    internal static class IDManager
    {
        private static int _lastId = -1;

        public static int GenNext() => ++_lastId;
    }

    public class ComponentID
    {
        private int id;

        public ComponentID()
            => id = IDManager.GenNext();
    }
    
    public class ObjectID
    {
        private int id;

        public ObjectID()
            => id = IDManager.GenNext();
    }

    public class SceneID
    {
        private static List<string> names = new List<string>();
        private int id;

        public SceneID(string name)
        {
            if (names.Contains(name))
                throw new Exception($"Scene with name: {name} already created");
            
            names.Add(name);
            id = IDManager.GenNext();
        }
    }
    
}