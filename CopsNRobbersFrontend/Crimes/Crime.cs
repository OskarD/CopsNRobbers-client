using System.Collections.Generic;

namespace CopsNRobbersFrontend.Crimes
{
    public enum Crime
    {
        UnlawfulDischargeOfWeapon,
        AssaultWithADeadlyWeapon,
        Murder
    }

    internal static class TypeMethods
    {
        private static readonly Dictionary<Crime, int> Cost = new Dictionary<Crime, int>
        {
            {Crime.UnlawfulDischargeOfWeapon, 100},
            {Crime.AssaultWithADeadlyWeapon, 1_000},
            {Crime.Murder, 10_000}
        };
    }
}