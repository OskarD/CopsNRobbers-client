using System;
using System.Collections.Generic;
using CopsNRobbersFrontend.Crimes;
using RAGE;
using RAGE.Game;

namespace CopsNRobbersFrontend
{
    public class Main : Events.Script
    {
        private const int TicksForAroundOneSecond = 80;

        private static int _resX;
        private static int _resY;

        private static int _tick;

        public Main()
        {
            Graphics.GetScreenResolution(ref _resX, ref _resY);
            Events.Add("load_job_objective", LoadJobObjective);
            Events.OnPlayerWeaponShot += new Witness().OnPlayerWeaponShot;
            Events.Tick += OnTick;

            Chat.Output("Loaded Clientside");
        }

        private static MissionMarker NextObjective { get; set; }

        private void OnTick(List<Events.TickNametagData> nametags)
        {
            _tick++;

            if (_tick >= TicksForAroundOneSecond) HeartBeat();

            if (_tick == 40)
                CompleteObjective();
        }

        private void HeartBeat()
        {
            _tick = 0;
        }

        private static void CompleteObjective()
        {
            if (NextObjective == null) return;

            if (NextObjective.PlayerIsOnMarker)
            {
                NextObjective.Complete();
                NextObjective = null;
                Events.CallRemote("job_objective_completed");
            }
        }

        private static void LoadJobObjective(object[] args)
        {
            var markerPosition = (Vector3) args[0];
            var markerSize = Convert.ToSingle(args[1]);

            if (markerPosition == null) return;

            NextObjective?.Destroy();
            NextObjective = new MissionMarker(markerPosition, markerSize);
        }
    }
}