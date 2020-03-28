using System;
using System.Collections.Generic;
using SFML.System;

namespace MinimaFramework
{
    
    public class TransformSystem: GameSystem
    {
        public TransformSystem(params Type[] Components) : base(Components)
        {
            
        }

        public override void OnUpdateStart()
        {
            
        }

        public override void OnUpdate(GameObject gameObject)
        {
            var a = gameObject.GetComponent<TransformComponent>();
            a._it.Position = a.LocalPosition + a._parent.Position;
            a._it.Rotation = a.LocalRotation;
            a._it.Scale = a.Scale;
        }

        public override void OnUpdateEnd(IEnumerable<ObjectID> objectIds)
        {
            
        }
    }
}