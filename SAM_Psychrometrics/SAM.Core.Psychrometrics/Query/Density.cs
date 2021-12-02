namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        /// Calculates density from dry-bulb temperature and humidity ratio.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [C]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_water/kg_dryair]</param>
        /// <param name="pressure">Pressure [Pa]</param>
        /// <returns>Density [kg/m3]</returns>
        public static double Density(double dryBulbTemperature, double humidityRatio, double pressure)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetMoistAirDensity(dryBulbTemperature, humidityRatio, pressure);
        }
    }
}
