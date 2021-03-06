﻿using GraphicalUserInterfaceLib.Controls;
using Microsoft.Xna.Framework;

namespace SharedLib.Gui
{
    public class IconButton : Button
    {
        public IconButton(int index, int x, int y, float scale = 1)
            : base(SharedArt.Icons, CalculateSource(index), x, y, scale)
        {
        }

        private static Rectangle CalculateSource(int index)
        {
            return new Rectangle(32 * (index % 8), 32 * (index / 8), 32, 32);
        }
    }
}