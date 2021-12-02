using System;
using System.Collections.Generic;

namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        ///Utility function to calculate humidity ratio, dew-point temperature, relative humidity,
        /// vapour pressure, moist air enthalpy, moist air volume, and degree of saturation of air given
        /// dry-bulb temperature, wet-bulb temperature, and pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="wetBulbTemperature">Wet bulb temperature [°C]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>list</returns>
        public static List<double> CalcPsychrometrics_ByTWetBulb(double dryBulbTemperature, double wetBulbTemperature, double pressure)
        {
            List<double> result = new List<double>();
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);

            double HumRatio = psychrometrics.GetHumRatioFromTWetBulb(dryBulbTemperature,wetBulbTemperature,pressure);
            double TDewPoint = psychrometrics.GetTDewPointFromHumRatio(dryBulbTemperature, HumRatio, pressure);
            double RelHum = psychrometrics.GetRelHumFromHumRatio(dryBulbTemperature, HumRatio, pressure);
            double VapPres = psychrometrics.GetVapPresFromHumRatio(HumRatio, pressure);
            double MoistAirEnthalpy = psychrometrics.GetMoistAirEnthalpy(dryBulbTemperature, HumRatio);
            double MoistAirVolume  = psychrometrics.GetMoistAirVolume(dryBulbTemperature, HumRatio, pressure);
            double DegreeOfSaturation  = psychrometrics.GetDegreeOfSaturation(dryBulbTemperature, HumRatio, pressure);

            result.AddRange(new List<double>() { HumRatio, TDewPoint, RelHum, VapPres, MoistAirEnthalpy, MoistAirVolume, DegreeOfSaturation });

            return result; 
        }

        /// <summary>
        ///Utility function to calculate humidity ratio, wet-bulb temperature, relative humidity,
        /// vapour pressure, moist air enthalpy, moist air volume, and degree of saturation of air given
        /// dry-bulb temperature, dew-point temperature, and pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="dewPointTemperature">Dew point temperature [°C]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>list</returns>
        public static List<double> CalcPsychrometrics_ByTDewPoint(double dryBulbTemperature, double dewPointTemperature, double pressure)
        {
            List<double> result = new List<double>();
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);

            double HumRatio = psychrometrics.GetHumRatioFromTDewPoint(dewPointTemperature, pressure);
            double TWetBulb = psychrometrics.GetTWetBulbFromHumRatio(dryBulbTemperature, HumRatio, pressure);
            double RelHum = psychrometrics.GetRelHumFromHumRatio(dryBulbTemperature, HumRatio, pressure);
            double VapPres = psychrometrics.GetVapPresFromHumRatio(HumRatio, pressure);
            double MoistAirEnthalpy = psychrometrics.GetMoistAirEnthalpy(dryBulbTemperature, HumRatio);
            double MoistAirVolume = psychrometrics.GetMoistAirVolume(dryBulbTemperature, HumRatio, pressure);
            double DegreeOfSaturation = psychrometrics.GetDegreeOfSaturation(dryBulbTemperature, HumRatio, pressure);

            result.AddRange(new List<double>() { HumRatio, TWetBulb, RelHum, VapPres, MoistAirEnthalpy, MoistAirVolume, DegreeOfSaturation });

            return result;
        }

        /// <summary>
        ///Utility function to calculate humidity ratio, wet-bulb temperature, relative humidity,
        /// vapour pressure, moist air enthalpy, moist air volume, and degree of saturation of air given
        /// dry-bulb temperature, dew-point temperature, and pressure.
        /// </summary>
        /// <param name="dryBulbTemperature">Dry bulb temperature [°C]</param>
        /// <param name="relativeHumidity">Relative humidity (0 - 100) [%]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>list</returns>
        public static List<double> CalcPsychrometrics_ByRelativeHumidity(double dryBulbTemperature, double relativeHumidity, double pressure)
        {
            List<double> result = new List<double>();
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);

            double HumRatio = psychrometrics.GetHumRatioFromRelHum(dryBulbTemperature, relativeHumidity / 100, pressure);
            double TWetBulb = psychrometrics.GetTWetBulbFromHumRatio(dryBulbTemperature, HumRatio, pressure);
            double TDewPoint = psychrometrics.GetTDewPointFromHumRatio(dryBulbTemperature, HumRatio, pressure);
            double VapPres = psychrometrics.GetVapPresFromHumRatio(HumRatio, pressure);
            double MoistAirEnthalpy = psychrometrics.GetMoistAirEnthalpy(dryBulbTemperature, HumRatio);
            double MoistAirVolume = psychrometrics.GetMoistAirVolume(dryBulbTemperature, HumRatio, pressure);
            double DegreeOfSaturation = psychrometrics.GetDegreeOfSaturation(dryBulbTemperature, HumRatio, pressure);

            result.AddRange(new List<double>() { HumRatio, TWetBulb, TDewPoint, VapPres, MoistAirEnthalpy, MoistAirVolume, DegreeOfSaturation });

            return result;
        }
    }
}
