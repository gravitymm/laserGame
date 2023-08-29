using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using lg.objects;

namespace lg.objects;

public class Switch
{
    Texture2D[] texture = new Texture2D[2];
    Texture2D texture2;
    private Timer timer;
    public Rectangle rectangle = new(10, 10, 50, 50);
    public Rectangle colision;
    private string[] textureName = new[] { "switch_off", "switch_on" };
    public Color mainColor = Color.White;
    public int route = 0;
    private bool timer_on = false;
    float rotation;
    SpriteEffects spriteEffects = SpriteEffects.None;
    Vector2 vector2;
    private int state = 0;
    private int state2 = 1;

    public Switch()
    {
    }

    public void Initialize()
    {
        rotation = MathHelper.ToRadians(90 * route);
        vector2 = new Vector2(rectangle.Width / 2, rectangle.Height / 2);
    }

    public void LoadTexture(ContentManager content)
    {
        texture2 = new Texture2D(Game1.Instance.GraphicsDevice, 1, 1);
        texture2.SetData<Color>(new Color[] { Color.White });
        
        texture[0] = content.Load<Texture2D>(textureName[0]);
        texture[1] = content.Load<Texture2D>(textureName[1]);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(texture[state], rectangle, null, Color.White, rotation, vector2, spriteEffects, 0);
        if (timer_on)
        {
            timer.Draw(spriteBatch);
        }
        spriteBatch.End();
    }

    public void Update(GameTime gameTime)
    {
        if (timer_on)
        {
            timer.Update(gameTime);
            if (timer.CheckTime())
            {
                timer_on = false;
            }
        }
        
    }

    public void SerColision()
    {
        colision = new(rectangle.X - 10, rectangle.Y - 5, rectangle.Width, rectangle.Height / 4);
    }

    public void CheckColision(List<Laser> lasers)
    {
        foreach (var laser in lasers)
        {
            if (laser.rectangle.Intersects(colision))
            {
                state = 1;
                if (state == state2)
                {
                    state2 = 0;
                    timer_on = true;
                    timer = new Timer() { time = 8, rectangle = new(750, 20, 30, 30) };
                    timer.LoadTexture(Game1.Instance.Content);
                }
                break;
            }
            else
            {
                state = 0;
                state2 = 1;
            }
        }
    }
}