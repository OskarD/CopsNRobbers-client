using System.Collections.Generic;
using CopsNRobbers_shared.DataModels.Crimes;
using static RAGE.Events;

namespace CopsNRobbersFrontend.Crimes
{
    public static class Witness
    {
        public static List<Crime> CrimesCommitted { get; } = new List<Crime>();

        public static void AddCrimeCommitted(Crime crime)
        {
            CrimesCommitted.Add(crime);
            // TODO: If cop, don't
            CallRemote("crime_committed", crime.ToString());
        }
    }
}