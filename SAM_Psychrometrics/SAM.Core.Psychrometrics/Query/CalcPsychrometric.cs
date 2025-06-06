
namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        ///Utility function to calculate humidity ratio, wet-bulb temperature, dew-point temperature,
        /// vapour pressure, moist air enthalpy, moist air volume, and degree of saturation of air given
        /// dry-bulb temperature, relative humidity and pressure.
        /// *The degree of saturation (i.e humidity ratio of the air / humidity ratio of the air at saturationat the same temperature and pressure)
        /// The degree of saturation is defined as the ratio of the humidity ratio of the air to the humidity ratio 
        /// of the air at saturation at the same temperature and pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="relativeHumidity">Relative humidity (0 - 100) [%]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <param name="humidityRatio">Output: Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <param name="wetBulbTemperature">Output: Wet bulb temperature [°C]</param>
        /// <param name="dewPointTemperature">Output: Dew Point Temperature [°C]</param>
        /// <param name="vapourPressure">Output: Partial Vapour Pressure [Pa]</param>
        /// <param name="enthalpy">Output: Enthalpy [J/kg]</param>
        /// <param name="specificVolume">Output: Specific Volume [m³/kg]</param>
        /// <param name="degreeSaturation">Output: Degree of saturation [unitless]</param>
        /// <param name="density">Output: Air density [kg/m³]</param>
        /// <returns>Boolean indicating if the calculation was successful</returns>
        public static bool CalcPsychrometrics_ByRelativeHumidity(double dryBulbTemperature, double relativeHumidity, double pressure, out double humidityRatio, out double saturationHumidityRatio, out double wetBulbTemperature, out double dewPointTemperature, out double saturationVapourPressure,out double vapourPressure, out double enthalpy, out double specificVolume, out double degreeSaturation, out double density)
        {
            humidityRatio = double.NaN;
            wetBulbTemperature = double.NaN;
            dewPointTemperature = double.NaN;
            //relativeHumidity = double.NaN;
            saturationVapourPressure = double.NaN;
            vapourPressure = double.NaN;
            enthalpy = double.NaN;
            specificVolume = double.NaN;
            degreeSaturation = double.NaN;
            density = double.NaN;
            saturationHumidityRatio = double.NaN;

            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            if (psychrometrics == null)
            {
                return false;
            }

            humidityRatio = psychrometrics.GetHumRatioFromRelHum(dryBulbTemperature, relativeHumidity/100, pressure);
            saturationHumidityRatio = psychrometrics.GetSatHumRatio(dryBulbTemperature, pressure);
            wetBulbTemperature = psychrometrics.GetTWetBulbFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
            dewPointTemperature = psychrometrics.GetTDewPointFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
            saturationVapourPressure = psychrometrics.GetSatVapPres(dryBulbTemperature);
            vapourPressure = psychrometrics.GetVapPresFromHumRatio(humidityRatio, pressure);
            enthalpy = psychrometrics.GetMoistAirEnthalpy(dryBulbTemperature, humidityRatio);
            specificVolume = psychrometrics.GetMoistAirVolume(dryBulbTemperature, humidityRatio, pressure);
            degreeSaturation = psychrometrics.GetDegreeOfSaturation(dryBulbTemperature, humidityRatio, pressure);
            density = psychrometrics.GetMoistAirDensity(dryBulbTemperature, humidityRatio, pressure);

            return true;
        }

        /// <summary>
        ///Utility function to calculate humidity ratio, dew-point temperature, relative humidity,
        /// vapour pressure, moist air enthalpy, moist air volume, and degree of saturation of air given
        /// dry-bulb temperature, wet-bulb temperature, and pressure.
        /// *The degree of saturation (i.e humidity ratio of the air / humidity ratio of the air at saturationat the same temperature and pressure)
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="wetBulbTemperature">Wet bulb temperature [°C]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <param name="relativeHumidity">Relative humidity (0 - 100) [%]</param>
        /// <param name="dewPointTemperature">Dew Point Temperature [°C]</param>
        /// <param name="vapourPressure">Saturation Vapour Pressure [Pa]</param>
        /// <param name="enthalpy">Enthalpy [J/kg]</param>
        /// <param name="specificVolume">Specific Volume [m³/kg]</param>
        /// <param name="degreeSaturation">Degree of saturation [unitless]</param>
        /// <param name="density">Air density [kg/m³]</param>
        /// <returns>list</returns>
        public static bool CalcPsychrometrics_ByWetBulbTemperature(double dryBulbTemperature, double wetBulbTemperature, double pressure, out double humidityRatio, out double saturationHumidityRatio, out double relativeHumidity, out double dewPointTemperature, out double saturationVapourPressure, out double vapourPressure, out double enthalpy, out double specificVolume, out double degreeSaturation, out double density)
        {
            humidityRatio = double.NaN;
            relativeHumidity = double.NaN;
            dewPointTemperature = double.NaN;
            saturationVapourPressure = double.NaN;
            vapourPressure = double.NaN;
            enthalpy = double.NaN;
            specificVolume = double.NaN;
            degreeSaturation = double.NaN;
            density = double.NaN;
            saturationHumidityRatio = double.NaN;

            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            if (psychrometrics == null)
            {
                return false;
            }

            humidityRatio = psychrometrics.GetHumRatioFromTWetBulb(dryBulbTemperature, wetBulbTemperature, pressure);
            saturationHumidityRatio = psychrometrics.GetSatHumRatio(dryBulbTemperature, pressure);
            relativeHumidity = psychrometrics.GetRelHumFromHumRatio(dryBulbTemperature, humidityRatio, pressure) * 100;
            dewPointTemperature = psychrometrics.GetTDewPointFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
            saturationVapourPressure = psychrometrics.GetSatVapPres(dryBulbTemperature);
            vapourPressure = psychrometrics.GetVapPresFromHumRatio(humidityRatio, pressure);
            enthalpy = psychrometrics.GetMoistAirEnthalpy(dryBulbTemperature, humidityRatio);
            specificVolume = psychrometrics.GetMoistAirVolume(dryBulbTemperature, humidityRatio, pressure);
            degreeSaturation = psychrometrics.GetDegreeOfSaturation(dryBulbTemperature, humidityRatio, pressure);
            density = psychrometrics.GetMoistAirDensity(dryBulbTemperature, humidityRatio, pressure);

            return true;
        }

        /// <summary>
        ///Utility function to calculate humidity ratio, wet-bulb temperature, relative humidity,
        /// vapour pressure, moist air enthalpy, moist air volume, and degree of saturation of air given
        /// ry-bulb temperature, dew-point temperature, and pressure.
        /// *The degree of saturation (i.e humidity ratio of the air / humidity ratio of the air at saturationat the same temperature and pressure)
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="dewPointTemperature">ew Point Temperature [°C]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <param name="wetBulbTemperature">Wet bulb temperature [°C]</param>
        /// <param name="relativeHumidity">Relative humidity (0 - 100) [%]</param>
        /// <param name="vapourPressure">Saturation Vapour Pressure [Pa]</param>
        /// <param name="enthalpy">Enthalpy [J/kg]</param>
        /// <param name="specificVolume">Specific Volume [m³/kg]</param>
        /// <param name="degreeSaturation">Degree of saturation [unitless]</param>
        /// <param name="density">Air density [kg/m³]</param>
        /// <returns>list</returns>
        public static bool CalcPsychrometrics_ByDewPointTemperature(double dryBulbTemperature, double dewPointTemperature, double pressure, out double humidityRatio, out double saturationHumidityRatio, out double wetBulbTemperature, out double relativeHumidity, out double saturationVapourPressure, out double vapourPressure, out double enthalpy, out double specificVolume, out double degreeSaturation, out double density)
        {
            humidityRatio = double.NaN;
            relativeHumidity = double.NaN;
            wetBulbTemperature = double.NaN;
            saturationVapourPressure = double.NaN;
            vapourPressure = double.NaN;
            enthalpy = double.NaN;
            specificVolume = double.NaN;
            degreeSaturation = double.NaN;
            density = double.NaN;
            saturationHumidityRatio = double.NaN;

            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            if (psychrometrics == null)
            {
                return false;
            }

            humidityRatio = psychrometrics.GetHumRatioFromTDewPoint(dewPointTemperature, pressure);
            saturationHumidityRatio = psychrometrics.GetSatHumRatio(dryBulbTemperature, pressure);
            wetBulbTemperature = psychrometrics.GetTWetBulbFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
            relativeHumidity = psychrometrics.GetRelHumFromHumRatio(dryBulbTemperature, humidityRatio, pressure) * 100;
            saturationVapourPressure = psychrometrics.GetSatVapPres(dryBulbTemperature);
            vapourPressure = psychrometrics.GetVapPresFromHumRatio(humidityRatio, pressure);
            enthalpy = psychrometrics.GetMoistAirEnthalpy(dryBulbTemperature, humidityRatio);
            specificVolume = psychrometrics.GetMoistAirVolume(dryBulbTemperature, humidityRatio, pressure);
            degreeSaturation = psychrometrics.GetDegreeOfSaturation(dryBulbTemperature, humidityRatio, pressure);
            density = psychrometrics.GetMoistAirDensity(dryBulbTemperature, humidityRatio, pressure);

            return true;
        }

        /// <summary>
        ///Utility function to calculate humidity ratio, wet-bulb temperature, relative humidity,
        /// vapour pressure, moist air enthalpy, moist air volume, and degree of saturation of air given
        /// ry-bulb temperature, dew-point temperature, and pressure.
        /// *The degree of saturation (i.e humidity ratio of the air / humidity ratio of the air at saturationat the same temperature and pressure)
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="dewPointTemperature">ew Point Temperature [°C]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <param name="wetBulbTemperature">Wet bulb temperature [°C]</param>
        /// <param name="relativeHumidity">Relative humidity (0 - 100) [%]</param>
        /// <param name="vapourPressure">Saturation Vapour Pressure [Pa]</param>
        /// <param name="enthalpy">Enthalpy [J/kg]</param>
        /// <param name="specificVolume">Specific Volume [m³/kg]</param>
        /// <param name="degreeSaturation">Degree of saturation [unitless]</param>
        /// <param name="density">Air density [kg/m³]</param>
        /// <returns>list</returns>
        public static bool CalcPsychrometrics_ByEnthalpy(double enthalpy, double humidityRatio, double pressure, out double dewPointTemperature, out double wetBulbTemperature, out double relativeHumidity, out double vapourPressure, out double dryBulbTemperature, out double specificVolume, out double degreeSaturation, out double density)
        {
            relativeHumidity = double.NaN;
            wetBulbTemperature = double.NaN;
            vapourPressure = double.NaN;
            specificVolume = double.NaN;
            degreeSaturation = double.NaN;
            dryBulbTemperature = double.NaN;
            dewPointTemperature = double.NaN;
            density = double.NaN;

            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            if (psychrometrics == null)
            {
                return false;
            }

            dryBulbTemperature = psychrometrics.GetTDryBulbFromEnthalpyAndHumRatio(enthalpy, humidityRatio);
            dewPointTemperature = psychrometrics.GetTDewPointFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
            wetBulbTemperature = psychrometrics.GetTWetBulbFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
            relativeHumidity = psychrometrics.GetRelHumFromHumRatio(dryBulbTemperature, humidityRatio, pressure) * 100;
            vapourPressure = psychrometrics.GetVapPresFromHumRatio(humidityRatio, pressure);
            specificVolume = psychrometrics.GetMoistAirVolume(dryBulbTemperature, humidityRatio, pressure);
            degreeSaturation = psychrometrics.GetDegreeOfSaturation(dryBulbTemperature, humidityRatio, pressure);
            density = psychrometrics.GetMoistAirDensity(dryBulbTemperature, humidityRatio, pressure);

            return true;
        }

        /// <summary>
        ///Utility function to calculate humidity ratio, wet-bulb temperature, dew-point temperature,
        /// vapour pressure, moist air enthalpy, moist air volume, and degree of saturation of air given
        /// dry-bulb temperature, relative humidity and pressure.
        /// *The degree of saturation (i.e humidity ratio of the air / humidity ratio of the air at saturationat the same temperature and pressure)
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="relativeHumidity">Relative humidity (0 - 100) [%]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <param name="wetBulbTemperature">>Wet bulb temperature [°C]</param>
        /// <param name="dewPointTemperature">Dew Point Temperature [°C]</param>
        /// <param name="vapourPressure">Saturation Vapour Pressure [Pa]</param>
        /// <param name="enthalpy">Enthalpy [J/kg]</param>
        /// <param name="specificVolume">Specific Volume [m³/kg]</param>
        /// <param name="degreeSaturation">Degree of saturation [unitless]</param>
        /// <param name="density">Air density [kg/m³]</param>
        /// <returns>list</returns>
        public static bool CalcPsychrometrics_ByHumidityRatio(double dryBulbTemperature, double humidityRatio, double pressure, out double saturationHumidityRatio, out double relativeHumidity, out double wetBulbTemperature, out double dewPointTemperature, out double saturationVapourPressure, out double vapourPressure, out double enthalpy, out double specificVolume, out double degreeSaturation, out double density)
        {
            relativeHumidity = double.NaN;
            wetBulbTemperature = double.NaN;
            dewPointTemperature = double.NaN;
            vapourPressure = double.NaN;
            enthalpy = double.NaN;
            specificVolume = double.NaN;
            degreeSaturation = double.NaN;
            density = double.NaN;
            saturationVapourPressure = double.NaN;
            saturationHumidityRatio = double.NaN;

            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            if (psychrometrics == null)
            {
                return false;
            }

            saturationHumidityRatio = psychrometrics.GetSatHumRatio(dryBulbTemperature, pressure);
            relativeHumidity = psychrometrics.GetRelHumFromHumRatio(dryBulbTemperature, humidityRatio, pressure) * 100;
            wetBulbTemperature = psychrometrics.GetTWetBulbFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
            dewPointTemperature = psychrometrics.GetTDewPointFromHumRatio(dryBulbTemperature, humidityRatio, pressure);
            saturationVapourPressure = psychrometrics.GetSatVapPres(dryBulbTemperature);
            vapourPressure = psychrometrics.GetVapPresFromHumRatio(humidityRatio, pressure);
            enthalpy = psychrometrics.GetMoistAirEnthalpy(dryBulbTemperature, humidityRatio);
            specificVolume = psychrometrics.GetMoistAirVolume(dryBulbTemperature, humidityRatio, pressure);
            degreeSaturation = psychrometrics.GetDegreeOfSaturation(dryBulbTemperature, humidityRatio, pressure);
            density = psychrometrics.GetMoistAirDensity(dryBulbTemperature, humidityRatio, pressure);

            return true;
        }


    }
}
