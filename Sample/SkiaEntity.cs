using Microsoft.Xna.Framework.Graphics;
using SkiaMonoGameRendering;
using SkiaSharp;

namespace Sample
{
    internal class SkiaEntity : ISkiaRenderable
    {
        public Texture2D Texture { get; private set; }
        public int TargetWidth { get => (int)Radius * 2; }
        public int TargetHeight { get => (int)Radius * 2; }
        public SKColorType TargetColorFormat { get => SKColorType.Rgba8888; }
        public bool ShouldRender { get => true; }
        public bool ClearCanvasOnRender { get => true; }
        public float Radius { get; set; } = 300;

        bool _paintNeedsUpdate;
        SKColor _color = SKColors.Red;
        public SKColor Color { get { return _color; } set { _color = value; _paintNeedsUpdate = true; } }

        SKPaint _paint;

        public void Initialize()
        {
            SkiaRenderer.AddRenderable(this);
        }

        public void Destroy()
        {
            SkiaRenderer.RemoveRenderable(this);
        }

        public void DrawToSurface(SKSurface surface)
        {
            // Avoid instancing classes every frame to avoid GC collections
            if (_paint == null)
            {
                _paint = new SKPaint
                {
                    Color = Color,
                    Style = SKPaintStyle.Fill,
                    IsAntialias = true
                };
            }

            if (_paintNeedsUpdate)
            {
                _paint.Color = Color;
                _paintNeedsUpdate = false;
            }

            surface.Canvas.DrawCircle(Radius, Radius, Radius, _paint);
        }

        public void NotifyDrawnTexture(Texture2D texture)
        {
            Texture = texture;
        }
    }
}
