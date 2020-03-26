﻿﻿using System;
using SFML.Graphics;

namespace Minima.SFML.Graphics
{
    public interface IDrawObject
    {
        public FloatRect GetGlobalBounds();
        public Texture Texture { get; set; }
    }
}