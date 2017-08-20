using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Levelbase ArtRoom;
        Levelbase ArtFurniture;
        Sprite Artie;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            ArtRoom = new Levelbase();
            ArtFurniture = new Levelbase();
            Artie = new Sprite();
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Vector2 playerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X + GraphicsDevice.Viewport.TitleSafeArea.Width / 4, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 4);
            Vector2 ArtPosition = new Vector2(Artie.artx, Artie.arty);
            ArtRoom.Initialize(Content.Load<Texture2D>("RoomA/Arties-Room"), playerPosition);
            ArtFurniture.Initialize(Content.Load<Texture2D>("RoomA/Arties-Furniture"), playerPosition);
            Artie.Initialize(Content.Load<Texture2D>("RoomA/Art"), ArtPosition);
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
                Artie.Position.X += 10;

            if (state.IsKeyDown(Keys.Left))
                Artie.Position.X -= 10;

            if (state.IsKeyDown(Keys.Up))
                Artie.Position.Y -= 10;

            if (state.IsKeyDown(Keys.Down))
                Artie.Position.Y += 10;
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