using System;

namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        /// Calculates standard atmosphere temperature, given the elevation (altitude).
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1 eqn 4
        /// </summary>
        /// <param name="altitude">Altitude [m]</param>
        /// <returns>Standard atmosphere dry-bulb temperature [°C]</returns>
        public static double DryBulbTemperature_ByAltitude(double altitude)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetStandardAtmTemperature(altitude);
        }

        /// <summary>
        /// Calculates dry bulb temperature from enthalpy and humidity ratio.
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1 eqn 30.
        /// </summary>
        /// <param name="enthalpy">Moist air Enthalpy[J / kg]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <returns>Dry-bulb temperature [°C]</returns>
        public static double DryBulbTemperature_ByHumidityRatio(double enthalpy, double humidityRatio)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetTDryBulbFromEnthalpyAndHumRatio(enthalpy, humidityRatio);
        }
    }
}
