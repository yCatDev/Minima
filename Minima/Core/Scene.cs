using System.Collections.Generic;
using System.Linq;

namespace MinimaEngine
{
    public abstract class Scene
    {
        private HashSet<GameObject> _sceneGameObjects;
        public string Name;
        public bool loaded = false;

        protected Scene(string name)
        {
            this.Name = name;
            _sceneGameObjects = new HashSet<GameObject>();
        }
        

        public abstract void Start();

        public virtual void Unload()
        {
            Minima.engine.EntityManager.UnloadScene(_sceneGameObjects);
            _sceneGameObjects.Clear();
        }

        public void LoadAndRun()
        {
            Start();
            Run();
        }

        public virtual void Run()
        {
            Minima.engine.EntityManager.UploadScene(_sceneGameObjects);
            _sceneGameObjects.Clear();
        }

        public HashSet<GameObject> GetSceneGameObjects() => _sceneGameObjects;

        internal void RegisterGameObject<T>(T gameObject) where T : GameObject
        {
            _sceneGameObjects.Add(gameObject);
        }
    }
}