using System;
using System.Collections.Generic;
using MinimaFramework;
using SFML.System;

namespace YetAnotherSnake
{
    public class MoveSystem: GameSystem
    {
        public MoveSystem(params Type[] Components) : base(Components)
        {
            
        }

        public override void OnUpdateStart()
        {
            
        }

        public override void OnUpdate(GameObject gameObject)
        {
            var a = gameObject.GetComponent<TransformComponent>();
            var b = gameObject.GetComponent<MoveComponent>();
            a.LocalRotation += 10f;
        }

        public override void OnUpdateEnd(IEnumerable<ObjectID> objectIds)
        {
            
        }
    }

    public class MoveComponent: GameComponent
    {
        public Vector2f Direction;

        public void GenDir()
        {
            Random random = new Random();
            Direction = new Vector2f(random.Next(1,5),random.Next(1,5));
        }
    }
}