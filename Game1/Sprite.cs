using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game1
{
    class Sprite
    {

        // Animation representing the player
        public Texture2D Texture;

        // Position of the Player relative to the upper left side of the screen
        public Vector2 Position;

        // Get the width of the player ship
        public int Width
        {
            get { return Texture.Width; }
        }

        // Get the height of the player ship
        public int Height
        {
            get { return Texture.Height; }
        }


        public bool Active = true;

        public void Initialize(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            // Set the starting position of the player around the middle of the screen and to the back
            Position = position;

        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public bool CollidesWith(Sprite other)
        {
            // Default behavior uses per-pixel collision detection
            return CollidesWith(other, true);
        }

        public bool CollidesWith(Sprite other, bool calcPerPixel)
        {
            // Get dimensions of texture
            int widthOther = other.Texture.Width;
            int heightOther = other.Texture.Height;
            int widthMe = Texture.Width                                                                                                                                                                      ;
            int heightMe = Texture.Height;

            if (calcPerPixel && ((Math.Min(widthOther, heightOther) > 10) || (Math.Min(widthMe, heightMe) > 10)))          // for small sizes (nobody will notice :P)
            {
                return Bounds.Intersects(other.Bounds) && PerPixelCollision(this, other);
                
            }
            else
            {
                return Bounds.Intersects(other.Bounds);
            }
        }

        static bool PerPixelCollision(Sprite a, Sprite b)
        {
            // Calculate the intersecting rectangle
            int x1 = Math.Max(a.Bounds.X, b.Bounds.X);
            int x2 = Math.Min(a.Bounds.X + a.Bounds.Width, b.Bounds.X + b.Bounds.Width);


            int y1 = Math.Max(a.Bounds.Y, b.Bounds.Y);
            int y2 = Math.Min(a.Bounds.Y + a.Bounds.Height, b.Bounds.Y + b.Bounds.Height);

            int RecWidth = (x2 - x1);
            int RecHeight = (y2 - y1);
            
            // Get Color data of each Texture

            Rectangle Arect = new Rectangle(x1-a.Bounds.X, y1-a.Bounds.Y, RecWidth, RecHeight);
            Rectangle Brect = new Rectangle(x1 - b.Bounds.X, y1 - b.Bounds.Y, RecWidth, RecHeight);

            Color[] bitsA = new Color[RecWidth * RecHeight];
            a.Texture.GetData(0, Arect, bitsA, 0, RecWidth * RecHeight);

            Color[] bitsB = new Color[RecWidth * RecHeight];

            b.Texture.GetData(0, Brect, bitsB, 0, RecWidth * RecHeight);
            // For each single pixel in the intersecting rectangle


            for (int x = 0; x < bitsB.Length; ++x)
            {
                Color c = bitsA[x];
                Color d = bitsB[x];

                if (c.A != 0 && d.A != 0)
                {
                    System.Diagnostics.Debug.WriteLine("uuuuuuugh");
                    return true;
                }
            }
            return false;
        }


        public virtual Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    Texture.Width,
                    Texture.Height);
            }

        }
    }
}
