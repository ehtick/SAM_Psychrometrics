namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        /// Calculates standard atmosphere temperature, given the elevation (altitude).
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1 eqn 4
        /// </summary>
        /// <param name="altitude">Altitude [m]</param>
        /// <returns>Standard atmosphere dry-bulb temperature [°C]</returns>
        public static double DryBulbTemperature_ByAltitude(double altitude)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetStandardAtmTemperature(altitude);
        }

        /// <summary>
        /// Calculates dry bulb temperature from enthalpy and humidity ratio.
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1 eqn 30.
        /// </summary>
        /// <param name="enthalpy">Moist air Enthalpy[J / kg]</param>
        /// <param name="humidityRatio">Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <returns>Dry-bulb temperature [°C]</returns>
        public static double DryBulbTemperature_ByHumidityRatio(double enthalpy, double humidityRatio)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetTDryBulbFromEnthalpyAndHumRatio(enthalpy, humidityRatio);
        }

        /// <summary>
        /// Calculates dry bulb temperature from density, humidity ratio and pressure
        /// </summary>
        /// <param name="humidityRatio">Humidity Ratio [kg_waterVapor/kg_dryAir]</param>
        /// <param name="density">Density [kg/m3]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>Dry-bulb temperature [°C]</returns>
        public static double DryBulbTemperature_ByDensityAndHumidityRatio(double density, double humidityRatio, double pressure)
        {
            if(double.IsNaN(density) || double.IsNaN(humidityRatio) || double.IsNaN(pressure))
            {
                return double.NaN;
            }

            return Core.Query.Calculate((double x) => Density(x, humidityRatio, pressure), density, -20, 100);

            //double result = 110;
            //double density_Temp = double.NaN;
            //do
            //{
            //    result -= 10;
            //    density_Temp = Density(result, humidityRatio, pressure);

            //} while (!double.IsNaN(density_Temp) && density_Temp <= density && result > -20);

            //do
            //{
            //    result += 0.005;
            //    density_Temp = Density(result, humidityRatio, pressure);

            //} while (!double.IsNaN(density_Temp) && density_Temp > density && result <= 100);

            //if (result > 100)
            //{
            //    return double.NaN;
            //}

            //return result;
        }

        /// <summary>
        /// Calculates dry bulb temperature from humidity ratio, relative humidity and pressure
        /// </summary>
        /// <param name="relativeHumidity">Relative humidity [%]</param>
        /// <param name="density">Density [kg/m3]</param>
        /// <param name="pressure">Atmospheric pressure [Pa]</param>
        /// <returns>Dry-bulb temperature [°C]</returns>
        public static double DryBulbTemperature_ByDensityAndRelativeHumidity(double density, double relativeHumidity, double pressure)
        {
            if (double.IsNaN(density) || double.IsNaN(relativeHumidity) || double.IsNaN(pressure))
            {
                return double.NaN;
            }

            return Core.Query.Calculate((double x) => Density_ByRelativeHumidity(x, relativeHumidity, pressure), density, -20, 100);

            //PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);

            //double result = 110;
            //double density_Temp = double.NaN;
            //do
            //{
            //    result -= 10;
            //    density_Temp = Density_ByRelativeHumidity(result, relativeHumidity, pressure);

            //} while (!double.IsNaN(density_Temp) && density_Temp > density && result > -20);

            //do
            //{
            //    result += 0.005;
            //    density_Temp = Density_ByRelativeHumidity(result, relativeHumidity, pressure);

            //} while (!double.IsNaN(density_Temp) && density_Temp <= density && result <= 100);

            //if (result > 100)
            //{
            //    return double.NaN;
            //}

            //return result;
        }
    }
}
