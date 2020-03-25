namespace Minima.Core
{
    public static class Utils
    {

        public class Union<T1, T2>
        {
            protected extern Union();

            public static extern implicit operator Union<T1, T2>(T1 t);

            public static extern implicit operator Union<T1, T2>(T2 t);

            public static extern explicit operator T1(Union<T1, T2> value);

            public static extern explicit operator T2(Union<T1, T2> value);
        }
    }
}