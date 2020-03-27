using System.Collections;
using System.Collections.Generic;

namespace MinimaFramework
{
    public class GameObjectManager
    {
        private Dictionary<ObjectID, GameObject> _gameObjects;

        public GameObjectManager()
        {
            _gameObjects = new Dictionary<ObjectID, GameObject>();
        }

        public void AddGameObject(GameObject gameObject)
        {
            _gameObjects.Add(gameObject.Id, gameObject);
        }

        public GameObject GetGameObjectByID(ObjectID id)
            => _gameObjects[id];

    }
}