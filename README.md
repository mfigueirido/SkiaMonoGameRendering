# Skia-MonoGame Rendering

This library allows a MonoGame application to use SkiaSharp's GPU rendering without interfering with regular MonoGame rendering.
It comes with a sample application.


## Requirements

Visual Studio 2022 and .NET 6.

## Setup
Reference the library and place the next lines of code on your MonoGame project.

In your **game file** on the **Initialize()** method:
```
SkiaGlManager.Initialize(GraphicsDevice);
```
And also on the **Draw()** method before *base.Draw()*:
```
SkiaRenderer.Draw();
```
## Implement ISkiaRenderable on your game classes

These are the required *ISkiaRenderable* members:

**TargetWidth**: Width of the output texture.

**TargetHeight**: Height of the output texture.

**TargetColorFormat**: Format of the output texture.

**ShouldRender**: Whether the texture is being updated. Set this to false when you don't need to update your texture.

**DrawToSurface(SKSurface surface)**: This will be called if *ShouldRender* is *true*. This is the place to apply your SkiaSharp drawing commands to the argument *SKSurface*.

**NotifyDrawnTexture(Texture2D texture)**: The resulting texture will be delivered here. It's a regular MonoGame texture ready to be painted to the screen.

## Add your ISkiaRenderable's to the rendering list
To add a renderable:
```
SkiaRenderer.AddRenderable(renderable);
```
To remove it:
```
SkiaRenderer.RemoveRenderable(renderable);
```
An exception will be thrown whether you try to add an already present renderable or you try to remove a renderable which hasn't been added. Be careful.
