namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        /// Calculates specific volume from dry bulb temperature, relative humidity and atmospheric pressure.
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1 eqn. 26
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="relativeHumidity">Relative humidity [%]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>Specific Volume [m³/kg]</returns>
        public static double SpecificVolume(double dryBulbTemperature, double relativeHumidity, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            relativeHumidity = relativeHumidity / 100;
            double humidityRatio = psychrometrics.GetHumRatioFromRelHum(dryBulbTemperature, relativeHumidity, pressure);
            return psychrometrics.GetMoistAirVolume(dryBulbTemperature, humidityRatio, pressure);
        }

        /// <summary>
        /// Calculates moist air specific volume given dry-bulb temperature, humidity ratio, and atmospheric pressure.
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1 eqn. 26
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>Specific Volume [m³/kg]</returns>
        public static double SpecificVolume_ByHumidityRatio(double dryBulbTemperature, double humidityRatio, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetMoistAirVolume(dryBulbTemperature, humidityRatio, pressure);
        }

        /// <summary>
        /// Calculates specific volume from dry bulb temperature, wet bulb temperature and atmospheric pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="wetBulbTemperature">Wet bulb temperature [°C]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>Specific Volume [m³/kg]</returns>
        public static double SpecificVolume_ByWetBulbTemperature(double dryBulbTemperature, double wetBulbTemperature, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            double humidityRatio = psychrometrics.GetHumRatioFromTWetBulb(dryBulbTemperature, wetBulbTemperature, pressure);
            return psychrometrics.GetMoistAirVolume(dryBulbTemperature, humidityRatio, pressure);
        }
    }
}
