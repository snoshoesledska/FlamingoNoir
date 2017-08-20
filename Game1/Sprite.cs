﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Sprite
    {
        public int arty;

       public int artx;

        // Animation representing the player
        public Texture2D PlayerTexture;

        // Position of the Player relative to the upper left side of the screen
        public Vector2 Position;


        // Get the width of the player ship
        public int Width
        {
            get { return PlayerTexture.Width; }
        }

        // Get the height of the player ship
        public int Height
        {
            get { return PlayerTexture.Height; }
        }

        public void Initialize(Texture2D texture, Vector2 position)
        {
            PlayerTexture = texture;

            // Set the starting position of the player around the middle of the screen and to the back
            Position = position;

        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlayerTexture, Position, null, Color.White, 0f, Vector2.Zero, 1f / 4, SpriteEffects.None, 0f);
        }
    }
}
