using System.Collections.Generic;
using RAGE;
using RAGE.Elements;

namespace CopsNRobbersFrontend.Crimes
{
    public class Witness
    {
        public Witness()
        {
            CrimesCommitted = new List<Crime>();
        }

        public List<Crime> CrimesCommitted { get; }

        public List<Crime> CrimesWitnessed { get; }

        public void OnPlayerWeaponShot(Vector3 targetPos, Player target, Events.CancelEventArgs cancel)
        {
            var crime = GetCrime(target);
            AddCrimeCommitted(crime);

            var targetName = target != null ? target.Name : "nobody";
            Chat.Output($"You shot a weapon at {targetName}. You committed {crime}!");
        }

        private void AddCrimeCommitted(Crime crime)
        {
            CrimesCommitted.Add(crime);
            Events.CallRemote("crime_committed", crime);
        }

        private Crime GetCrime(Player target)
        {
            if (target == null)
                return Crime.UnlawfulDischargeOfWeapon;
            if (target.IsDeadOrDying(true))
                return Crime.Murder;
            return Crime.AssaultWithADeadlyWeapon;
        }
    }
}