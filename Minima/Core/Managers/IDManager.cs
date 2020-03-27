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
}