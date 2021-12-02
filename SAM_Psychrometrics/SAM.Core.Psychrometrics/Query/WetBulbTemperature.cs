using System;

namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        /// Wet Bulb Temperature [C]
        /// </summary>
        /// <param name="dryBulbTemperature">Dry Bulb Temperature [C]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_water/kg_dryair]</param>
        /// <param name="pressure">Pressure [Pa]</param>
        /// <returns>Wet Bulb Temperature [C]</returns>
        public static double WetBulbTemperature(double dryBulbTemperature, double humidityRatio, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetTWetBulbFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
        }
    }
}
