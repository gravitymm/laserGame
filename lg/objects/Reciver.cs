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
    public class Reciver
    {
        Texture2D texture;
        public Rectangle rectangle = new Rectangle(10, 10, 50, 50);
        public string textureName = "reciver";
        public Color mainColor = Color.White;
        public Rectangle colision;
        public void LoadTexture(ContentManager content)
        {
            texture = content.Load<Texture2D>(textureName);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, rectangle, Color.White);
            spriteBatch.End();
        }
        public void Update(GameTime gameTime)
        {

        }
        public void SerColision()
        {
            colision = new Rectangle(rectangle.X + 57, rectangle.Y + 5, 3, 10);
        }
    }
}
