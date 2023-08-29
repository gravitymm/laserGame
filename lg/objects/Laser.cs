using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace lg.objects
{
    public class Laser
    {
        Texture2D texture;
        public Rectangle rectangle = new Rectangle(0, 0, 10, -2);
        public string textureName = "";
        public Color mainColor = Color.White;
        public int route = 0;
        public int reflectorIndex = -1;

        public Laser() { }

        public void LoadTexture(ContentManager content)
        {
            texture = new Texture2D(Game1.Instance.GraphicsDevice, 1, 1);
            texture.SetData<Color>(new Color[] { Color.White });
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, rectangle, Color.Red);
            spriteBatch.End();
        }
        public void Update(GameTime gameTime)
        {
            if (route == 0)
            {
                rectangle.X -= 3;
                rectangle.Width += 3;
                rectangle.Height = 10;
            }
            if (route == 1)
            {
                rectangle.Y -= 3;
                rectangle.Height += 3;
                rectangle.Width = 10;
            }
            if (route == 2)
            {
                rectangle.Width += 3;
                rectangle.Height = 10;
            }
            if (route == 3)
            { 
                rectangle.Height += 3;
                rectangle.Width = 10;
            }
        }
        public bool CheckColisionReflector(Reflector reflectors)
        {
            for (int i = 0; i < reflectors.colisions.Length; i++)
            {
                if (rectangle.Intersects(reflectors.colisions[i]) && reflectors.route != i)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckColisionWall(List<Wall> walls)
        {
            foreach (var wall in walls)
            {
                if (rectangle.Intersects(wall.rectangle))
                { 
                    return false;
                }
            }
            return true;
        }
        public bool CheckColisionReciver(Reciver reciver)
        {
            if (rectangle.Intersects(reciver.colision))
            {
                return false;
            }
            return true;
        }
    }
}
