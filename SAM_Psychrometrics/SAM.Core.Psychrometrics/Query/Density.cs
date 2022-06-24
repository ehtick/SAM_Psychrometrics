namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        /// Calculates density from dry bulb temperature, relativeHumidity and pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="relativeHumidity">Relative humidity (0 - 100) [%]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>Density [kg/m3]</returns>
        public static double Density_ByRelativeHumidity(double dryBulbTemperature, double relativeHumidity, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            double humidityRatio = psychrometrics.GetHumRatioFromRelHum(dryBulbTemperature, relativeHumidity, pressure);

            return Density(dryBulbTemperature, humidityRatio, pressure);
        }

        /// <summary>
        /// Calculates density from dry bulb temperature, humidity ratio[kg_H₂O/kg_dryAir⁻¹] and pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>Density [kg/m3]</returns>
        public static double Density(double dryBulbTemperature, double humidityRatio, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetMoistAirDensity(dryBulbTemperature, humidityRatio, pressure);
        }

        /// <summary>
        /// Calculates density from dry-bulb temperature and humidity ratio and pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="wetBulbTemperature">Wet bulb temperature [°C]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>Density [kg/m3]</returns>
        public static double Density_ByWetBulbTemperature(double dryBulbTemperature, double wetBulbTemperature, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            double humidityRatio = psychrometrics.GetHumRatioFromTWetBulb(dryBulbTemperature, wetBulbTemperature, pressure);
            
            return Density(dryBulbTemperature, humidityRatio, pressure);
        }
    }
}
