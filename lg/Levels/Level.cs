using System.Collections.Generic;
using lg.objects;

namespace lg.Levels;

public class Level
{
    public List<Reflector> reflectors;
    public List<Wall> walls;
    public LaserGun laserGun;
    public Reciver reciver;
    public List<Switch> switches;
}