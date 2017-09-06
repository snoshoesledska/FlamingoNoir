using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game1
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite ArtRoom;
        Sprite ArtFurniture;
        Sprite Artie;
        Sprite False;
        Sprite True;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ArtRoom = new Sprite();
            ArtFurniture = new Sprite();
            Artie = new Sprite();
            False = new Sprite();
            True = new Sprite();


            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Vector2 DeadCenter = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + GraphicsDevice.Viewport.TitleSafeArea.Width/4, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height/4);
            Vector2 arb = new Vector2(600, 400);
            Vector2 Zero = new Vector2(0, 0);
            ArtRoom.Initialize(Content.Load<Texture2D>("RoomA/Arties-Room25"), DeadCenter);
            False.Initialize(Content.Load<Texture2D>("RoomA/false"), Zero);
            True.Initialize(Content.Load<Texture2D>("RoomA/true"), Zero);
            ArtFurniture.Initialize(Content.Load<Texture2D>("RoomA/Arties-Furniture25"), DeadCenter);
            Artie.Initialize(Content.Load<Texture2D>("RoomA/Art32"), Zero);
        }

        protected override void UnloadContent()
        {
            //texture.Dispose(); <-- Only directly loaded
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.
                Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (state.IsKeyDown(Keys.Right))
                Artie.Position.X += 8;

            if (state.IsKeyDown(Keys.Left))
                Artie.Position.X -= 8;

            if (state.IsKeyDown(Keys.Up))
                Artie.Position.Y -= 8;

            if (state.IsKeyDown(Keys.Down))
                Artie.Position.Y += 8;

            if (ArtRoom.CollidesWith(Artie))
            {
                False.Active = false;
                True.Active = true;
            }
            else
            {
                False.Active = true;
                True.Active = false;
            }
                


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            ArtRoom.Draw(spriteBatch);
            ArtFurniture.Draw(spriteBatch);
            Artie.Draw(spriteBatch);
            False.Draw(spriteBatch);
            True.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}