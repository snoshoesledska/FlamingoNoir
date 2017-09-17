using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Game1
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite ArtRoom;
        Sprite ArtFurniture;
        Sprite Artie;
        Sprite ArtRoomoutline;
        int momt = 8;



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
            ArtRoomoutline = new Sprite();


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
            Vector2 Zero = new Vector2(600, 600);
            ArtRoom.Initialize(Content.Load<Texture2D>("RoomA/Arties-Room25"), DeadCenter);
            ArtRoomoutline.Initialize(Content.Load<Texture2D>("RoomA/Arties-Room25outline"), DeadCenter);
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
            Vector2 prevLoc = Artie.Position;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.
                Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (state.IsKeyDown(Keys.Right) && (state.IsKeyDown(Keys.Left) == false))
            {
                Artie.Position.X += 8;
                while (ArtRoomoutline.CollidesWith(Artie))
                {
                    Artie.Position.X -= 4;
                }
            }

            if (state.IsKeyDown(Keys.Left) && (state.IsKeyDown(Keys.Right) == false))
            {
                
                Artie.Position.X -= 8;
                while (ArtRoomoutline.CollidesWith(Artie))
                {
                    Artie.Position.X += 4;
                }
            }

            if (state.IsKeyDown(Keys.Down) && (state.IsKeyDown(Keys.Up) == false))
            {
                Artie.Position.Y += 8;
                while (ArtRoomoutline.CollidesWith(Artie))
                {
                    Artie.Position.Y -= 8;
                }
            }

            if (state.IsKeyDown(Keys.Up) && (state.IsKeyDown(Keys.Down) == false))
            {
                Artie.Position.Y -= 8;
                while (ArtRoomoutline.CollidesWith(Artie))
                {
                    Artie.Position.Y += 8;
                }
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
            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}