﻿﻿using System;
using SFML.Graphics;

namespace MinimaFramework
{
    public interface IDrawObject
    {
        public FloatRect GetGlobalBounds();
        public Texture Texture { get; set; }
    }
}