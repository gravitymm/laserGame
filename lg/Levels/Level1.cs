using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using lg.objects;

namespace lg.Levels
{
    internal class Level1
    {
        public List<Level> levels;
        private Random random = new();

        public void Initialize()
        {
            levels = new List<Level>();
            levels.Add(new()
            {
                laserGun = new() { rectangle = new(740, 230, 60, 20)},
                reciver = new() { rectangle = new Rectangle(0, 230, 60, 20) },
                reflectors = new()
                {
                    new() { rectangle = new Rectangle(400, 240, 30, 30) }
                },
                walls = new()
                {
                    new() { rectangle = new Rectangle(0, 0, 0, 0) }
                },
                switches = new()
                {
                    //new() {rectangle = new Rectangle(580, 240, 20, 40)}
                    new() {rectangle = new Rectangle(0, 0, 0, 0)}
                }
            });
            
            levels.Add(new()
            {
                laserGun = new() { rectangle = new Rectangle(740, 120, 60, 20) },
                reciver = new() { rectangle = new Rectangle(0, 250, 60, 20) },
                reflectors = new()
                {
                    new() { rectangle = new Rectangle(400, 260, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(400, 130, 30, 30), route = random.Next(0, 4) }
                },
                walls = new()
                {
                    new() { rectangle = new Rectangle(0, 0, 0, 0) }
                },
                switches = new()
                {
                    new() {rectangle = new Rectangle(0, 0, 0, 0)}
                }
            });
            
            levels.Add(new()
            {
                laserGun = new() { rectangle = new Rectangle(740, 100, 60, 20) },
                reciver = new() { rectangle = new Rectangle(0, 280, 60, 20) },
                reflectors = new()
                {
                    new() { rectangle = new Rectangle(400, 110, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(400, 200, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(500, 200, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(500, 290, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(300, 290, 30, 30), route = random.Next(0, 4) }
                },
                walls = new()
                {
                    new() { rectangle = new Rectangle(0, 0, 0, 0) }
                },
                switches = new()
                {
                    new() {rectangle = new Rectangle(0, 0, 0, 0)}
                }
            });
            
            levels.Add(new()
            {
                laserGun = new() { rectangle = new Rectangle(740, 100, 60, 20) },
                reciver = new() { rectangle = new Rectangle(0, 140, 60, 20) },
                reflectors = new()
                {
                    new() { rectangle = new Rectangle(400, 110, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(400, 200, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(500, 200, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(500, 290, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(300, 290, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(450, 150, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(450, 290, 30, 30), route = random.Next(0, 4) }
                },
                walls = new()
                {
                    new() { rectangle = new Rectangle(0, 0, 0, 0) }
                },
                switches = new()
                {
                    new() {rectangle = new Rectangle(0, 0, 0, 0)}
                }
            });
            
            levels.Add(new()
            {
                laserGun = new() { rectangle = new Rectangle(740, 230, 60, 20) },
                reciver = new() { rectangle = new Rectangle(0, 230, 60, 20) },
                reflectors = new()
                {
                    new() { rectangle = new Rectangle(300, 110, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(500, 110, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(300, 240, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(500, 240, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(300, 370, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(500, 370, 30, 30), route = random.Next(0, 4) }
                },
                walls = new()
                {
                    new() { rectangle = new Rectangle(350, 150, 100, 190) }
                },
                switches = new()
                {
                    new() {rectangle = new Rectangle(0, 0, 0, 0)}
                }
            });
            
            levels.Add(new()
            {
                laserGun = new() { rectangle = new Rectangle(740, 230, 60, 20) },
                reciver = new() { rectangle = new Rectangle(0, 230, 60, 20) },
                reflectors = new()
                {
                    new() { rectangle = new Rectangle(450, 240, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(450, 80, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(170, 80, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(130, 240, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(130, 400, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(400, 400, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(400, 40, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(170, 440, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(600, 440, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(600, 40, 30, 30), route = random.Next(0, 4) }
                },
                walls = new()
                {
                    new() { rectangle = new Rectangle(300, 100, 10, 270) },
                    new() { rectangle = new Rectangle(500, 50, 10, 150) },
                    new() { rectangle = new Rectangle(200, 200, 170, 10) }
                },
                switches = new()
                {
                    new() {rectangle = new Rectangle(0, 0, 0, 0)}
                }
            });

            levels.Add(new()
            {
                laserGun = new() { rectangle = new Rectangle(740, 100, 60, 20) },
                reciver = new() { rectangle = new Rectangle(0, 70, 60, 20) },
                reflectors = new()
                {
                    new() { rectangle = new Rectangle(400, 110, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(400, 200, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(500, 200, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(500, 290, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(300, 290, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(450, 150, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(450, 290, 30, 30), route = random.Next(0, 4) },
                    new() { rectangle = new Rectangle(450, -100, 30, 30), route = 0 },
                    new() { rectangle = new Rectangle(250, -100, 30, 30), route = 3 },
                    new() { rectangle = new Rectangle(250, 80, 30, 30), route = random.Next(0, 4) }
                },
                walls = new()
                {
                    new() { rectangle = new Rectangle(0, 0, 0, 0) }
                },
                switches = new()
                {
                    new() {rectangle = new Rectangle(0, 0, 0, 0)}
                }
            });
        }

        public void LoadTexture(ContentManager content)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}