using System.Collections.Generic;
using RAGE;

namespace CopsNRobbersFrontend
{
    public static class MissionMarkerHelper
    {
        public static readonly List<MissionMarker> Markers = new List<MissionMarker>();

        public static void ClearAllMarkers()
        {
            Markers.ForEach(marker => marker.Destroy());
        }
    }

    public class MissionMarker : Marker
    {
        public MissionMarker(Vector3 position, float size) : base(position, size)
        {
            MissionMarkerHelper.Markers.Add(this);
        }

        public override void Destroy()
        {
            Instance.Destroy();
            MissionMarkerHelper.Markers.Remove(this);
        }
    }
}