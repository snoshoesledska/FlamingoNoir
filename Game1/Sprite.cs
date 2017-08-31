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
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, 1f/4, SpriteEffects.None, 0f);
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
            int widthMe = Texture.Width;
            int heightMe = Texture.Height;

            if (calcPerPixel && ((Math.Min(widthOther, heightOther) > 100) || (Math.Min(widthMe, heightMe) > 100)))          // for small sizes (nobody will notice :P)
            {
                return Bounds.Intersects(other.Bounds) // If simple intersection fails, don't even bother with per-pixel
                    && PerPixelCollision(this, other);
            }
            else
            {
                return Bounds.Intersects(other.Bounds);
            }
        }

        static bool PerPixelCollision(Sprite a, Sprite b)
        {
            // Get Color data of each Texture
            Color[] bitsA = new Color[a.Texture.Width * a.Texture.Height];
            a.Texture.GetData(bitsA);
            Color[] bitsB = new Color[b.Texture.Width * b.Texture.Height];
            b.Texture.GetData(bitsB);

            // Calculate the intersecting rectangle
            int x1 = Math.Max(a.Bounds.X, b.Bounds.X);
            int x2 = Math.Min(a.Bounds.X + a.Bounds.Width, b.Bounds.X + b.Bounds.Width);

            int y1 = Math.Max(a.Bounds.Y, b.Bounds.Y);
            int y2 = Math.Min(a.Bounds.Y + a.Bounds.Height, b.Bounds.Y + b.Bounds.Height);

            // For each single pixel in the intersecting rectangle
            for (int y = y1; y < y2; ++y)
            {
                for (int x = x1; x < x2; ++x)
                {
                    // Get the color from each texture
                    Color c = bitsA[(x - a.Bounds.X) + (y - a.Bounds.Y) * a.Texture.Width];
                    Color d = bitsB[(x - b.Bounds.X) + (y - b.Bounds.Y) * b.Texture.Width];

                    if (c.A != 0 && d.A != 0) // If both colors are not transparent (the alpha channel is not 0), then there is a collision
                    {
                        return true;
                    }
                }
            }
            // If no collision occurred by now, we're clear.
            return false;
        }

        private Rectangle bounds = Rectangle.Empty;
        public virtual Rectangle Bounds
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    Texture.Width/4,
                    Texture.Height/4);
            }

        }
    }
}
