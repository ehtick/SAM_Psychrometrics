using System;

namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        /// Calculate wet-bulb temperature given dry-bulb temperature, relative humidity, and pressure.
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1
        /// </summary>
        /// <param name="dryBulbTemperature">Dry Bulb Temperature [°C]</param>
        /// <param name="relativeHumidity">Relative humidity (0 - 100) [%]</param>
        /// <param name="pressure">Atmospheric Pressure [Pa]</param>
        /// <returns>Wet Bulb Temperature [°C]</returns>
        public static double WetBulbTemperature(double dryBulbTemperature, double relativeHumidity, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            relativeHumidity = relativeHumidity / 100;
            return psychrometrics.GetTWetBulbFromRelHum(dryBulbTemperature, relativeHumidity, pressure);
        }

        /// <summary>
        /// Calculate wet-bulb temperature given dry-bulb temperature, humidity ratio, and pressure.
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1 eqn 33 and 35 solved for Tstar
        /// </summary>
        /// <param name="dryBulbTemperature">Dry Bulb Temperature [°C]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <param name="pressure">Atmospheric Pressure [Pa]</param>
        /// <returns>Wet Bulb Temperature [°C]</returns>
        public static double WetBulbTemperature_ByHumidityRatio(double dryBulbTemperature, double humidityRatio, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetTWetBulbFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
        }

        /// <summary>
        /// Calculate wet-bulb temperature given dry-bulb temperature, dew-point temperature, and pressure.
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1
        /// </summary>
        /// <param name="dryBulbTemperature">Dry Bulb Temperature [°C]</param>
        /// <param name="dewPointTemperature">Dew Point Temperature [°C]</param>
        /// <param name="pressure">Atmospheric Pressure [Pa]</param>
        /// <returns>Wet Bulb Temperature [°C]</returns>
        public static double WetBulbTemperature_ByDewPointTemperature(double dryBulbTemperature, double dewPointTemperature, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetTWetBulbFromTDewPoint(dryBulbTemperature, dewPointTemperature, pressure);
        }
    }
}
