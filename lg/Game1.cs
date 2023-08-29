using lg.objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Win32;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using lg.Levels;

namespace lg
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static Game1 Instance { get; private set; }

        private Level1 levels = new Level1();
        private int levelIndex = 0;
        private Level level => levels.levels[levelIndex];

        private List<Laser> lasers = new();

        int i = 0;
        int lasercount;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Instance = this;
            
        }

        protected override void Initialize()
        {
            levels.Initialize();
            lasers.Add(new Laser() { rectangle = new Rectangle(level.laserGun.rectangle.X - 2, level.laserGun.rectangle.Y + 5, 10, 2) });
            foreach (var reflector in level.reflectors) { reflector.Initialize(); reflector.SerColision(); }
            foreach (var _switch in level.switches) { _switch.Initialize(); _switch.SerColision(); }
            level.reciver.SerColision();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach (var reflector in level.reflectors) { reflector.LoadTexture(Content); }
            level.laserGun.LoadTexture(Content);
            foreach (var wall in level.walls) { wall.LoadTexture(Content); }
            level.reciver.LoadTexture(Content);
            foreach (var _switch in level.switches) { _switch.LoadTexture(Content); }
            foreach (var laser in lasers) { laser.LoadTexture(Content); }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            foreach (var reflector in level.reflectors) { reflector.Update(gameTime); }
            foreach (var _switch in level.switches) { _switch.CheckColision(lasers);}

            foreach (var laser in lasers)
            {
                if (laser.reflectorIndex >= 0)
                {
                    if (laser.route != level.reflectors[laser.reflectorIndex].route)
                    {
                        lasercount = lasers.Count;
                        for (int j = i; j < lasercount; j++)
                        {
                            lasers.RemoveAt(i);
                        }
                        break;
                    }
                }
                i++;
            }
            i = 0;

            level.laserGun.Update(gameTime);

            foreach (var reflector in level.reflectors)
            {
                if (!lasers[lasers.Count - 1].CheckColisionReflector(reflector))
                {
                    lasers.Add(new Laser() { rectangle = new Rectangle(reflector.colisions[reflector.route].X, reflector.colisions[reflector.route].Y, 10, 10), route = reflector.route });
                    lasers[lasers.Count - 1].reflectorIndex = i;
                    lasers[lasers.Count - 1].LoadTexture(Content);
                }
                i++;
            }
            i = 0;

            if (lasers[lasers.Count - 1].CheckColisionWall(level.walls))
            {
                lasers[lasers.Count - 1].Update(gameTime);
            }
            
            if (!lasers[lasers.Count - 1].CheckColisionReciver(level.reciver))
            {
                levelIndex += 1;
                levels.Initialize();
                foreach (var _switch in level.switches) { _switch.Initialize(); _switch.SerColision(); }
                foreach (var _switch in level.switches) { _switch.LoadTexture(Content); }
                foreach (var reflector in level.reflectors) { reflector.LoadTexture(Content); }
                level.laserGun.LoadTexture(Content);
                foreach (var wall in level.walls) { wall.LoadTexture(Content); }
                level.reciver.LoadTexture(Content);
                lasers.Clear();
                lasers.Add(new Laser() { rectangle = new Rectangle(level.laserGun.rectangle.X - 2, level.laserGun.rectangle.Y + 5, 10, 2) });
                foreach (var laser in lasers) { laser.LoadTexture(Content); }
                foreach (var reflector in level.reflectors) { reflector.Initialize(); reflector.SerColision(); }
                level.reciver.SerColision();
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (var laser in lasers) { laser.Draw(_spriteBatch); }
            foreach (var reflector in level.reflectors) { reflector.Draw(_spriteBatch); }
            foreach (var _switch in level.switches) { _switch.Draw(_spriteBatch); }
            level.laserGun.Draw(_spriteBatch);
            foreach (var wall in level.walls) { wall.Draw(_spriteBatch); }
            level.reciver.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}