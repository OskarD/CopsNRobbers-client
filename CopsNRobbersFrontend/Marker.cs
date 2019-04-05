using System;
using RAGE;
using RAGE.Game;
using Player = RAGE.Elements.Player;

namespace CopsNRobbersFrontend
{
    public class Marker
    {
        public float Size;

        public Marker(Vector3 position, float size)
        {
            Instance = new RAGE.Elements.Marker(1, position.Subtract(new Vector3(0, 0, 1)), size, new Vector3(),
                new Vector3(),
                new RGBA(255, 255, 255, 100));
            Size = size;
        }

        public RAGE.Elements.Marker Instance { get; }

        public bool PlayerIsOnMarker =>
            Player.LocalPlayer.Position.DistanceTo2D(Instance.Position) <= Size
            && Math.Abs(Player.LocalPlayer.Position.Z) - Math.Abs(Instance.Position.Z) < Size;

        public virtual void Destroy()
        {
            Instance.Destroy();
        }

        public void Complete()
        {
            Audio.PlaySoundFrontend(1, "Beep_Red", "DLC_HEIST_HACKING_SNAKE_SOUNDS", true);
            Destroy();
        }
    }
}