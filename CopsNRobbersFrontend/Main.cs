using System;
using System.Collections.Generic;
using CopsNRobbersFrontend.Events;
using RAGE;
using RAGE.Game;

namespace CopsNRobbersFrontend
{
    public class Main : RAGE.Events.Script
    {
        private const int TicksForAroundOneSecond = 80;

        private static int _resX;
        private static int _resY;

        private static int _tick;

        public Main()
        {
            Graphics.GetScreenResolution(ref _resX, ref _resY);
            RAGE.Events.Add("load_job_objective", LoadJobObjective);
            RAGE.Events.OnPlayerWeaponShot += PlayerWeaponShot.OnPlayerWeaponShot;
            RAGE.Events.Tick += OnTick;

            Chat.Output("Loaded Clientside");
        }

        private static MissionMarker NextObjective { get; set; }

        private static void LoadJobObjective(object[] args)
        {
            var markerPosition = (Vector3) args[0];
            var markerSize = Convert.ToSingle(args[1]);

            if (markerPosition == null) return;

            NextObjective?.Destroy();
            NextObjective = new MissionMarker(markerPosition, markerSize);
        }

        private void OnTick(List<RAGE.Events.TickNametagData> nametags)
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
                RAGE.Events.CallRemote("job_objective_completed");
            }
        }
    }
}