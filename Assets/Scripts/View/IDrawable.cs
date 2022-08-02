﻿namespace View
{
    public interface IDrawable<in TView>
    {
        void Draw(TView view);
    }
}