using Microsoft.Xna.Framework;
using System;

namespace SkiaTest
{
    internal static class FrameRateCounter
    {
        public static int FrameRate = 0;
        private static int frameCounter = 0;
        private static TimeSpan elapsedTime = TimeSpan.Zero;

        public static void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime;

            if (elapsedTime > TimeSpan.FromSeconds(1))
            {
                elapsedTime -= TimeSpan.FromSeconds(1);
                FrameRate = frameCounter;
                frameCounter = 0;
            }
        }

        public static void Draw()
        {
            frameCounter++;
        }
    }
}
