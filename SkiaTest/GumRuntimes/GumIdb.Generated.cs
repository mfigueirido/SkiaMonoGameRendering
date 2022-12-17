namespace FlatRedBall.Gum
{
    public  class GumIdbExtensions
    {
        public static void RegisterTypes () 
        {
            GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Circle", typeof(SkiaTest.GumRuntimes.CircleRuntime));
            GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("ColoredRectangle", typeof(SkiaTest.GumRuntimes.ColoredRectangleRuntime));
            GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Container", typeof(SkiaTest.GumRuntimes.ContainerRuntime));
            GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Container<T>", typeof(SkiaTest.GumRuntimes.ContainerRuntime<>));
            GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("NineSlice", typeof(SkiaTest.GumRuntimes.NineSliceRuntime));
            GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Polygon", typeof(SkiaTest.GumRuntimes.PolygonRuntime));
            GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Rectangle", typeof(SkiaTest.GumRuntimes.RectangleRuntime));
            GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Sprite", typeof(SkiaTest.GumRuntimes.SpriteRuntime));
            GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Text", typeof(SkiaTest.GumRuntimes.TextRuntime));
            GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("SkiaGumScreen", typeof(SkiaTest.GumRuntimes.SkiaGumScreenRuntime));
        }
    }
}
