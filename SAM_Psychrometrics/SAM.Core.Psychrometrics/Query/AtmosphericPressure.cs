using System;

namespace SAM.Core.Psychrometrics
{
    public static partial class Query
    {
        /// <summary>
        /// Calculates standard atmospheric barometric pressure, given the elevation (altitude).
        /// Atmospheric pressure, also known as barometric pressure (after the barometer), 
        /// is the pressure within the atmosphere of Earth. The standard atmosphere (symbol: atm) is a unit of pressure defined as 101325 [Pa]
        /// Reference: ASHRAE Handbook - Fundamentals (2017) ch. 1 eqn 3
        /// </summary>
        /// <param name="altitude">Altitude [m]</param>
        /// <returns>Atmospheric Pressure [Pa]</returns>
        public static double AtmosphericPressure(double altitude)
        {
            PsychroLib.Psychrometrics psychrometrics = new PsychroLib.Psychrometrics(PsychroLib.UnitSystem.SI);
            return psychrometrics.GetStandardAtmPressure(altitude);
        }
    }
}
