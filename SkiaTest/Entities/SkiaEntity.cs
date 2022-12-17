using Microsoft.Xna.Framework.Graphics;
using SkiaMonoGameRendering;
using SkiaSharp;

namespace SkiaTest.Entities
{
    public partial class SkiaEntity : ISkiaRenderable
    {
        public int TargetWidth { get => (int)Radius * 2; }
        public int TargetHeight { get => (int)Radius * 2; }
        public SKColorType TargetColorFormat { get => SKColorType.Rgba8888; }
        public bool ShouldRender { get => true; }
        public float Radius { get; set; } = 300;

        bool _paintNeedsUpdate;
        SKColor _color = SKColors.Red;
        public SKColor Color { get { return _color; } set { _color = value; _paintNeedsUpdate = true; } }

        SKPaint _paint;

        static SkiaEntity()
        {
        }

        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize()
        {
            SkiaRenderer.AddRenderable(this);
        }

        private void CustomActivity()
        {
        }

        private void CustomDestroy()
        {
            SkiaRenderer.RemoveRenderable(this);
        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {
        }

        public void Update()
        {
        }

        public void DrawToSurface(SKSurface surface)
        {
            // Try to avoid instancing classes every frame to avoid GC collections
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
            SpriteInstance.Texture = texture;
        }
    }
}
