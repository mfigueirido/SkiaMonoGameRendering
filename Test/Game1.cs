using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SkiaMonoGameRendering;
using SkiaSharp;
using System;
using System.Collections.Generic;

namespace Test
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        SpriteFont _font;
        Texture2D _regularTexture;
        List<SkiaEntity> _skiaEntities = new List<SkiaEntity>();
        SKColor _skiaEntityColor = SKColors.Red;
        int _skiaEntityRadius = 300;
        Entity _regularEntity = new Entity();
        TimeSpan _lastTimeRegularEntityMoved;
        string _debugText;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // This unlocks frame syncronization so
            // we can measure frames per second:
            _graphics.SynchronizeWithVerticalRetrace = false;
            IsFixedTimeStep = false;
        }

        protected override void Initialize()
        {
            SkiaGlManager.Initialize(GraphicsDevice);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("DefaultFont");
            _regularTexture = Content.Load<Texture2D>("Doge");
        }

        protected override void Update(GameTime gameTime)
        {
            InputManager.Update();

            Activity(gameTime);

            FrameRateCounter.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            SkiaRenderer.Draw();

            GraphicsDevice.Clear(Color.Black);

            DrawEntities();

            DrawText();

            FrameRateCounter.AddDrawCall();

            base.Draw(gameTime);
        }

        void Activity(GameTime gameTime)
        {
            if (InputManager.KeyPushed(Keys.Escape))
                Exit();

            if (InputManager.KeyPushed(Keys.Add))
            {
                var newEntity = new SkiaEntity();
                _skiaEntities.Add(newEntity);
                newEntity.Initialize();
                UpdateEntityProperties(newEntity);
            }
            else if (InputManager.KeyPushed(Keys.Subtract))
            {
                if (_skiaEntities.Count > 0)
                {
                    var entityToRemove = _skiaEntities[_skiaEntities.Count - 1];
                    entityToRemove.Destroy();
                    _skiaEntities.Remove(entityToRemove);
                }
            }

            if (InputManager.KeyPushed(Keys.Back))
            {
                for (int i = _skiaEntities.Count - 1; i > -1; i--)
                {
                    var entityToRemove = _skiaEntities[i];
                    entityToRemove.Destroy();
                    _skiaEntities.Remove(entityToRemove);
                }
            }

            if (InputManager.KeyPushed(Keys.Up))
            {
                _skiaEntityRadius += 25;
                UpdateAllEntitiesProperties();
            }
            else if (InputManager.KeyPushed(Keys.Down))
            {
                _skiaEntityRadius -= 25;
                if (_skiaEntityRadius < 25)
                    _skiaEntityRadius = 25;
                UpdateAllEntitiesProperties();
            }

            if (InputManager.KeyPushed(Keys.C))
            {
                if (_skiaEntityColor == SKColors.Red)
                    _skiaEntityColor = SKColors.Green;
                else if (_skiaEntityColor == SKColors.Green)
                    _skiaEntityColor = SKColors.Blue;
                else if (_skiaEntityColor == SKColors.Blue)
                    _skiaEntityColor = SKColors.Red;
                UpdateAllEntitiesProperties();
            }

            if (_regularEntity.Texture == null)
                _regularEntity.Texture = _regularTexture;

            if (gameTime.TotalGameTime.Subtract(_lastTimeRegularEntityMoved).Milliseconds > 1)
            {
                _lastTimeRegularEntityMoved = gameTime.TotalGameTime;

                if (InputManager.KeyDown(Keys.W))
                    _regularEntity.Position = new Vector3(_regularEntity.Position.X, _regularEntity.Position.Y - 1, 0);
                else if (InputManager.KeyDown(Keys.S))
                    _regularEntity.Position = new Vector3(_regularEntity.Position.X, _regularEntity.Position.Y + 1, 0);

                if (InputManager.KeyDown(Keys.D))
                    _regularEntity.Position = new Vector3(_regularEntity.Position.X + 1, _regularEntity.Position.Y, 0);
                else if (InputManager.KeyDown(Keys.A))
                    _regularEntity.Position = new Vector3(_regularEntity.Position.X - 1, _regularEntity.Position.Y, 0);
            }

            _debugText = "FPS: " + FrameRateCounter.FrameRate.ToString();
            _debugText += "\n" + "Add/remove renderable (+, - keys): " + _skiaEntities.Count.ToString();
            _debugText += "\n" + "Clear all (Back key)";
            _debugText += "\n" + "Radius (Up, Down keys): " + _skiaEntityRadius.ToString();
            _debugText += "\n" + "Color (C key): " + _skiaEntityColor.ToString();
            _debugText += "\n" + "Move MG entity (WASD keys)";
        }

        void UpdateAllEntitiesProperties()
        {
            for (int i = 0; i < _skiaEntities.Count; i++)
                UpdateEntityProperties(_skiaEntities[i]);
        }

        void UpdateEntityProperties(SkiaEntity entity)
        {
            entity.Radius = _skiaEntityRadius;
            entity.Color = _skiaEntityColor;
        }

        void DrawEntities()
        {
            int centerScreenX = _graphics.GraphicsDevice.Viewport.Width / 2;
            int centerScreenY = _graphics.GraphicsDevice.Viewport.Height / 2;

            _spriteBatch.Begin(SpriteSortMode.Deferred);

            // Draw Skia entities
            for (int i = 0; i < _skiaEntities.Count; i++)
            {
                var entity = _skiaEntities[i];
                DrawEntity(entity, centerScreenX, centerScreenY, 1f);
            }

            // Draw regular entity
            DrawEntity(_regularEntity, centerScreenX, centerScreenY, 0.1f);

            _spriteBatch.End();
        }

        void DrawEntity(Entity entity, int centerScreenX, int centerScreenY, float scale)
        {
            int width = (int)(entity.Texture.Width * scale);
            int height = (int)(entity.Texture.Height * scale);
            int xPosition = centerScreenX - (width / 2) + (int)entity.Position.X;
            int yPosition = centerScreenY - (height / 2) + (int)entity.Position.Y;
            var destinationRectangle = new Rectangle(xPosition, yPosition, width, height);
            _spriteBatch.Draw(entity.Texture, destinationRectangle, Color.White);
        }

        void DrawText()
        {
            if (!string.IsNullOrEmpty(_debugText))
            {
                _spriteBatch.Begin();
                _spriteBatch.DrawString(_font, _debugText, new Vector2(40, 40), Color.White);
                _spriteBatch.End();
            }
        }
    }
}