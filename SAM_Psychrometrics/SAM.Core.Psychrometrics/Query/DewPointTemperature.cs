using System;

namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {


        /// <summary>
        /// Dew Point Tempearture [C]
        /// </summary>
        /// <param name="dryBulbTemperature">Dry Bulb Temperature [C]</param>
        /// <param name="wetBulbTemperature">Wet Bulb Temperature [C]</param>
        /// <param name="pressure">Atmospheric Pressure [Pa]</param>
        /// <returns></returns>
        public static double DewPointTemperature_ByWetBulbTemperature(double dryBulbTemperature, double wetBulbTemperature, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetTDewPointFromTWetBulb(dryBulbTemperature, wetBulbTemperature, pressure);
        }

        /// <summary>
        /// Approximate Dew Point Tempearture [C]
        /// </summary>
        /// <param name="temperature">Air Temperature [C]</param>
        /// <param name="relativeHumidity">Relative Humidity (0 - 100) [%]</param>
        /// <returns>Dew Point Temperature [C]</returns>
        public static double DewPointTemperature(double temperature, double relativeHumidity)
        {
            if (double.IsNaN(temperature) || double.IsNaN(relativeHumidity))
            {
                return double.NaN;
            }

            return Math.Pow(relativeHumidity / 100, 1 / 8) * (112 + 0.9 * temperature) + (0.1 * temperature) - 112;
        }

        /// <summary>
        /// Dew Point Tempearture [C]
        /// </summary>
        /// <param name="dryBulbTemperature">Dry Bulb Temperature [C]</param>
        /// <param name="relativeHumidity">Relative Humidity (0 - 100) [%]</param>
        /// <param name="pressure">Atmospheric Pressure [Pa]</param>
        /// <returns></returns>
        public static double DewPointTemperature(double dryBulbTemperature, double relativeHumidity, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            double humidityRatio = psychrometrics.GetHumRatioFromRelHum(dryBulbTemperature, relativeHumidity / 100, pressure);
            return psychrometrics.GetTDewPointFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
        }
    }
}
