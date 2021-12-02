using System;

namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        /// Saturation Vapour Pressure [Pa] given dry-bulb temperature.
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1 eqn. 5 &amp; 6
        /// Important note: the ASHRAE formulae are defined above and below the freezing point but have
        /// a discontinuity at the freezing point. This is a small inaccuracy on ASHRAE's part: the formulae
        /// should be defined above and below the triple point of water (not the feezing point) in which case
        /// the discontinuity vanishes. It is essential to use the triple point of water otherwise function
        /// GetTDewPointFromVapPres, which inverts the present function, does not converge properly around
        /// the freezing point.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry Bulb Temperature [°C]</param>
        /// <returns>Saturation Vapour Pressure [Pa]</returns>
        public static double SaturationVapourPressure(double dryBulbTemperature)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetSatVapPres(dryBulbTemperature);
        }
    }
}
