﻿using System;

namespace AspectOriented
{
    public class Mathematic:MarshalByRefObject
    {
        public int Sum(int x, int y) => x + y;
        public int Substract(int x, int y) => x - y;
        public int Divide(int x, int y) => x / y;
        public int Multiple(int x, int y) => x * y;

        public static Mathematic Create()
        {
            Mathematic mathematic = new Mathematic();

            return (Mathematic)new MathematicProxy(mathematic).GetTransparentProxy();
        }
    }
}
