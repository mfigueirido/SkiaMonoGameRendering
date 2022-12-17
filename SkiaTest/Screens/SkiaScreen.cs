using FlatRedBall.Input;
using Microsoft.Xna.Framework;
using SkiaSharp;
using SkiaTest.Entities;
using SkiaTest.Factories;

namespace SkiaTest.Screens
{
    public partial class SkiaScreen
    {
        SKColor _entityColor = SKColors.Red;
        int _entityRadius = 300;

        void CustomInitialize()
        {
        }

        void CustomActivity(bool firstTimeCalled)
        {
            if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Add))
            {
                UpdateEntityProperties(SkiaEntityFactory.CreateNew());
            }
            else if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Subtract))
            {
                if (SkiaEntityListInstance.Count > 0)
                    SkiaEntityListInstance.Last.Destroy();
            }

            if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Back))
            {
                for (int i = SkiaEntityListInstance.Count - 1; i > -1; i--)
                    SkiaEntityListInstance[i].Destroy();
            }

            if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                _entityRadius += 25;
                UpdateAllEntitiesProperties();
            }
            else if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                _entityRadius -= 25;
                if (_entityRadius < 25)
                    _entityRadius = 25;
                UpdateAllEntitiesProperties();
            }

            if (InputManager.Keyboard.KeyPushed(Microsoft.Xna.Framework.Input.Keys.C))
            {
                if (_entityColor == SKColors.Red)
                    _entityColor = SKColors.Green;
                else if (_entityColor == SKColors.Green)
                    _entityColor = SKColors.Blue;
                else if (_entityColor == SKColors.Blue)
                    _entityColor = SKColors.Red;
                UpdateAllEntitiesProperties();
            }

            var debugText = "FPS: " + FrameRateCounter.FrameRate.ToString();
            debugText += "\n" + "Add/remove renderable (+, - keys): " + SkiaEntityListInstance.Count.ToString();
            debugText += "\n" + "Clear all (Back key)";
            debugText += "\n" + "Radius (Up, Down keys): " + _entityRadius.ToString();
            debugText += "\n" + "Color (C key): " + _entityColor.ToString();
            debugText += "\n" + "Move MG entity (WASD keys)";

            DebugTextInstance.Text = debugText;

            MonoGameSpriteInstance.Velocity = Vector3.Zero;

            if (InputManager.Keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.W))
            {
                MonoGameSpriteInstance.Velocity.Y = 200;
            }
            else if (InputManager.Keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.S))
            {
                MonoGameSpriteInstance.Velocity.Y = -200;
            }

            if (InputManager.Keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.D))
            {
                MonoGameSpriteInstance.Velocity.X = 200;
            }
            else if (InputManager.Keyboard.KeyDown(Microsoft.Xna.Framework.Input.Keys.A))
            {
                MonoGameSpriteInstance.Velocity.X = -200;
            }
        }

        private void UpdateAllEntitiesProperties()
        {
            for (int i = 0; i < SkiaEntityListInstance.Count; i++)
                UpdateEntityProperties(SkiaEntityListInstance[i]);
        }

        private void UpdateEntityProperties(SkiaEntity entity)
        {
            entity.Radius = _entityRadius;
            entity.Color = _entityColor;
        }

        void CustomDestroy()
        {
        }

        static void CustomLoadStaticContent(string contentManagerName)
        {
        }
    }
}
