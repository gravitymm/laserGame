using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lg.objects
{
    public class Wall
    {
        Texture2D texture;
        public Rectangle rectangle = new Rectangle(10, 10, 50, 50);
        public Color mainColor = Color.Black;

        public void LoadTexture(ContentManager content)
        {
            texture = new Texture2D(Game1.Instance.GraphicsDevice, 1, 1);
            texture.SetData<Color>(new Color[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, rectangle, mainColor);
            spriteBatch.End();
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}