namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        /// Calculates humidity ratio from dry bulb temperature, relative humidity and pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="relativeHumidity">Relative humidity (0 - 100)[%]</param>
        /// <param name="pressure">Atmospheric pressure [Pa</param>
        /// <returns>Humidity Ratio [kg_waterVapor/kg_dryAir]</returns>
        public static double HumidityRatio(double dryBulbTemperature, double relativeHumidity, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            relativeHumidity = relativeHumidity / 100;
            return psychrometrics.GetHumRatioFromRelHum(dryBulbTemperature, relativeHumidity, pressure);
        }

        /// <summary>
        /// Calculates humidity ratio from dry bulb temperature, wet bulb temperature and pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="wetBulbTemperature">Wet bulb temperature [°C]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>Humidity Ratio [kg_waterVapor/kg_dryAir]</returns>
        public static double HumidityRatio_ByWetBulbTemperature(double dryBulbTemperature, double wetBulbTemperature, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetHumRatioFromTWetBulb(dryBulbTemperature, wetBulbTemperature, pressure);
        }
    }
}
