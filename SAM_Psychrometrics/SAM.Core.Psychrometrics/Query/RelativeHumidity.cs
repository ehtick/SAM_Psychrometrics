namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        /// Calculates relative humidity from dry bulb temperature, humidity ratio and pressure.
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <param name="pressure">Atmospheric pressure [Pa</param>
        /// <returns>Relative Humidity (0 - 100) [%]</returns>
        public static double RelativeHumidity(double dryBulbTemperature, double humidityRatio, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetRelHumFromHumRatio(dryBulbTemperature, humidityRatio, pressure) * 100;
        }

        /// <summary>
        /// Calculates relative humidity from dry bulb temperature, wet bulb temperature and pressure.
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="wetBulbTemperature">Wet bulb temperature [°C]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>Relative Humidity (0 - 100) [%]</returns>
        public static double RelativeHumidity_ByWetBulbTemperature(double dryBulbTemperature, double wetBulbTemperature, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetRelHumFromTWetBulb(dryBulbTemperature, wetBulbTemperature, pressure) * 100;
        }
    }
}
