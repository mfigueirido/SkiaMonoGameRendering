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

## Example usage

There's a project called **Sample** already set up with everything needed but if you wish to set it up yourself, these are the steps:

1. Add **SkiaMonoGameRendering** project to your solution.
2. Add a **SkiaMonoGameRendering** project reference to your MonoGame project.
3. Paste [SkiaEntity.cs ](https://github.com/mfigueirido/SkiaMonoGameRendering/blob/master/Sample/SkiaEntity.cs) into your MonoGame project root folder.
4. Change the namespace of the file you just pasted to match your project namespace, so it can be easily found.
5. Next you'll need to change your game class. This file is called **Game1.cs** by default in the MonoGame sample. You can follow this one as an example [Game1.cs ](https://github.com/mfigueirido/SkiaMonoGameRendering/blob/master/Sample/Game1.cs) or follow the next steps:

You need to add this at **class scope**:
```
        private SkiaEntity _entity;

        void DrawSkiaEntity()
        {
            var destinationRectangle = new Rectangle(0, 0, _entity.Texture.Width, _entity.Texture.Height);

            _spriteBatch.Begin(SpriteSortMode.Deferred);
            _spriteBatch.Draw(_entity.Texture, destinationRectangle, Color.White);
            _spriteBatch.End();
        }
```
Your **Initialize** method should look like this:
```
        protected override void Initialize()
        {
            SkiaGlManager.Initialize(GraphicsDevice);

            _entity = new SkiaEntity();
            _entity.Initialize();

            base.Initialize();
        }
```
And your **Draw** method should look like this:
```
        protected override void Draw(GameTime gameTime)
        {
            SkiaRenderer.Draw();

            GraphicsDevice.Clear(Color.Black);

            DrawSkiaEntity();

            base.Draw(gameTime);
        }
```

Run your project and you're done. One beautiful big red circle rendered by Skia should show up:
![imaxe](https://github.com/mfigueirido/SkiaMonoGameRendering/assets/24922404/01595870-08af-4a3a-b1f5-d4fed8516a5b)
