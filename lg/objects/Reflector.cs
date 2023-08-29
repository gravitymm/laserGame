using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct3D9;
using SharpDX.MediaFoundation;
using Microsoft.Xna.Framework.Input;

namespace lg.objects
{
    public class Reflector
    {
        Texture2D texture;
        Texture2D texture2;
        public Rectangle rectangle = new Rectangle(10, 10, 50, 50);
        private Rectangle rectangle2;
        public Rectangle[] colisions = new Rectangle[4];
        private string textureName = "reflector";
        public Color mainColor = Color.White;
        public int route = 0;
        float rotation;
        SpriteEffects spriteEffects = SpriteEffects.None;
        Vector2 vector2;
        int[] rect = new int[4];
        private MouseState mouse_prev;
        private MouseState mouse_curr;

        public Reflector() { }

        public void Initialize()
        {
            rotation = MathHelper.ToRadians(90 * route);
            rect[0] = rectangle.X; rect[1] = rectangle.Y; rect[2] = rectangle.Width; rect[3] = rectangle.Height;
            rectangle2 = new Rectangle(rectangle.X - rectangle.Width / 2, rectangle.Y - rectangle.Height / 2, rectangle.Width, rectangle.Height);
        }
        public void LoadTexture(ContentManager content)
        {
            vector2 = new Vector2(rectangle.Width / 2, rectangle.Height / 2);
            texture2 = new Texture2D(Game1.Instance.GraphicsDevice, 1, 1);
            texture2.SetData<Color>(new Color[] { Color.White });
            texture = content.Load<Texture2D>(textureName);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, rectangle, null, Color.White, rotation, vector2, spriteEffects, 0);
            //foreach (var i in colisions)
            //{
            //    spriteBatch.Draw(texture2, i, mainColor);
            //}
            spriteBatch.End();
        }
        public void Update(GameTime gameTime)
        {
            mouse_prev = mouse_curr;
            mouse_curr = Mouse.GetState();
            if (rectangle2.Contains(mouse_curr.Position))
            {
                if (mouse_prev.LeftButton == ButtonState.Released && mouse_curr.LeftButton == ButtonState.Pressed)
                {
                    route += 1;
                    route = route % 4;
                    rotation = MathHelper.ToRadians(90 * route);
                }
            }
            
        }
        public void SerColision()
        {
            colisions[0] = new Rectangle(rect[0] - rect[2] / 2, rect[1] - 5, rect[2] / 10, (int)(rect[2] / 3));
            colisions[1] = new Rectangle(rect[0] - 5, rect[1] - rect[3] / 2, (int)(rect[2] / 3), rect[2] / 10);
            colisions[2] = new Rectangle(rect[0] + rect[2] / 2 - rect[2] / 10, rect[1] - 5, rect[2] / 10, (int)(rect[2] / 3));
            colisions[3] = new Rectangle(rect[0] - 5, rect[1] + rect[3] / 2 - rect[2] / 10, (int)(rect[2] / 3), rect[2] / 10);
        }
    }
}
