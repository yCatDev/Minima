using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MinimaFramework
{

    public class ObjectBuffer
    {
        private Dictionary<Type, List<ObjectID>> _buffer;

        public ObjectBuffer()
        {
            _buffer = new Dictionary<Type, List<ObjectID>>();

        }

        public List<ObjectID> GetGameObjects(Type id) => _buffer[id];

        public List<ObjectID> GetGameObjects(params Type[] ids)
            => _buffer.Keys
                .Intersect(ids)
                .SelectMany(k => _buffer[k])
                .GroupBy(i => i)
                .Where(g => g.Count() == ids.Length)
                .Select(g => g.Key)
                .ToList();
        

        private void CreateBuffer(Type id) => _buffer.TryAdd(id, new List<ObjectID>());

        public void AddGameObject(Type componentId, GameObject gameObject)
        {
            if (!_buffer.ContainsKey(componentId))
                CreateBuffer(componentId);

            _buffer[componentId].Add(gameObject.Id);
        }
    }

}