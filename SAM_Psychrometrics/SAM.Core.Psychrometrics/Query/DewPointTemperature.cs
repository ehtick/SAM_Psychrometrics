using System;

namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        ///// <summary>
        ///// Approximate Dew Point rom fdry-bulb temperature, relative humidity  [°C]
        ///// </summary>
        ///// <param name="temperature">Air Temperature [°C]</param>
        ///// <param name="relativeHumidity">Relative Humidity (0 - 100) [%]</param>
        ///// <returns>Dew Point Temperature [°C]</returns>
        //public static double DewPointTemperature(double temperature, double relativeHumidity)
        //{
        //    if (double.IsNaN(temperature) || double.IsNaN(relativeHumidity))
        //    {
        //        return double.NaN;
        //    }

        //    return Math.Pow(relativeHumidity / 100, 0.125) * (112 + (0.9 * temperature)) + (0.1 * temperature) - 112;
        //}

        /// <summary>
        /// Calculate dew-point temperature given dry-bulb temperature and relative humidity.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry Bulb Temperature [°C]</param>
        /// <param name="relativeHumidity">Relative Humidity (0 - 100) [%]</param>
        /// <returns>Dew Point Temperature [°C]</returns>
        public static double DewPointTemperature(double dryBulbTemperature, double relativeHumidity)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetTDewPointFromRelHum(dryBulbTemperature, relativeHumidity / 100);
        }

        /// <summary>
        /// Calculates dew point tempearture from dry-bulb temperature, relative humidity and pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry Bulb Temperature [°C]</param>
        /// <param name="relativeHumidity">Relative Humidity (0 - 100) [%]</param>
        /// <param name="pressure">Atmospheric Pressure [Pa]</param>
        /// <returns>Dew Point Temperature [°C]</returns>
        public static double DewPointTemperature(double dryBulbTemperature, double relativeHumidity, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            double humidityRatio = psychrometrics.GetHumRatioFromRelHum(dryBulbTemperature, relativeHumidity / 100, pressure);
            return psychrometrics.GetTDewPointFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
        }

        /// <summary>
        /// Calculates dew point tempearture from dry-bulb temperature, humidity ratio and pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry Bulb Temperature [°C]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <param name="pressure">Atmospheric Pressure [Pa]</param>
        /// <returns>Dew Point Temperature [°C]</returns>
        public static double DewPointTemperature_ByHumidityRatio(double dryBulbTemperature, double humidityRatio, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetTDewPointFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
        }

        /// <summary>
        /// Calculates dew point tempearture from dry-bulb temperature, wet bulb temperature and pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry Bulb Temperature [°C]</param>
        /// <param name="wetBulbTemperature">Wet Bulb Temperature [°C]</param>
        /// <param name="pressure">Atmospheric Pressure [Pa]</param>
        /// <returns>Dew Point Temperature [°C]</returns>
        public static double DewPointTemperature_ByWetBulbTemperature(double dryBulbTemperature, double wetBulbTemperature, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetTDewPointFromTWetBulb(dryBulbTemperature, wetBulbTemperature, pressure);
        }
    }
}
