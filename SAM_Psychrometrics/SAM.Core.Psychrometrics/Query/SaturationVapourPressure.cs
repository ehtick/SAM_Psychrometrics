using System;

namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        /// Saturation Vapour Pressure [Pa]
        /// </summary>
        /// <param name="dryBulbTemperature">Dry Bulb Temperature [C]</param>
        /// <returns>Saturation Vapour Pressure [Pa]</returns>
        public static double SaturationVapourPressure(double dryBulbTemperature)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetSatVapPres(dryBulbTemperature);
        }
    }
}
