using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MinimaEngine
{
    public class EntityManager
    {
        private HashSet<GameObject> Entities;

        public EntityManager()
        {
           Entities = new HashSet<GameObject>();
        }

        public void AddGameObject(GameObject gm)
        {
            Entities.Add(gm);
        }
        
        public HashSet<GameObject> GetEnitiesByComponent<T>() where T: IComponent
            => Entities.Where(x => x.HasComponent<T>()).ToHashSet();

        public HashSet<T> GetEnitiesComponents<T>() where T: IComponent
            => Entities.Where(x => x.HasComponent<T>())
                .Select(x => x.GetComponent<T>()).Cast<T>().ToHashSet();

        public void UnloadScene(HashSet<GameObject> sceneGameObjects)
            => Entities.ExceptWith(sceneGameObjects);

        public void UploadScene(HashSet<GameObject> sceneGameObjects)
            => Entities.UnionWith(sceneGameObjects);
    }
}