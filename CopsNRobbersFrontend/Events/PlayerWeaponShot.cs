using CopsNRobbersFrontend.Crimes;
using CopsNRobbers_shared.DataModels.Crimes;
using RAGE;
using RAGE.Elements;
using static RAGE.Events;

namespace CopsNRobbersFrontend.Events
{
    public static class PlayerWeaponShot
    {
        public static void OnPlayerWeaponShot(Vector3 targetPos, Player target, CancelEventArgs cancel)
        {
            var crime = GetCrime(target);
            Witness.AddCrimeCommitted(crime);
        }

        private static Crime GetCrime(Player target)
        {
            if (target == null)
                return Crime.UnlawfulDischargeOfWeapon;
            return Crime.AssaultWithADeadlyWeapon;
        }
    }
}