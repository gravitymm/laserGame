using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace lg.objects;

public class Timer
{
    Texture2D texture;
    public Rectangle rectangle = new Rectangle(10, 10, 50, 50);
    public string textureName = "timer";
    public int time;
    private int i = 0;
    public Color mainColor = Color.White;
    public void LoadTexture(ContentManager content)
    {
        texture = content.Load<Texture2D>(textureName);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, rectangle, Color.White);
    }
    public void Update(GameTime gameTime)
    {
        i += 1;
        if (i == 60)
        {
            i = 0;
            time -= 1;
        }
    }

    public bool CheckTime()
    {
        if (time == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}