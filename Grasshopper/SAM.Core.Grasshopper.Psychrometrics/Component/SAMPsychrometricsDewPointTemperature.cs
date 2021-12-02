using Grasshopper.Kernel;
using SAM.Core.Grasshopper.Psychrometrics.Properties;
using System;

namespace SAM.Core.Grasshopper.Psychrometrics
{
    public class SAMPsychrometricsDewPointTemperature : GH_SAMComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("e9bf471d-4ca5-4847-b5b9-bb3fbf712e41");

        /// <summary>
        /// The latest version of this component
        /// </summary>
        public override string LatestComponentVersion => "1.0.0";

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Resources.SAM_Psychrometrics;

        /// <summary>
        /// Initializes a new instance of the SAM_point3D class.
        /// </summary>
        public SAMPsychrometricsDewPointTemperature()
          : base("SAMPsychrometrics.DewPointTemperature", "SAMPsychrometrics.DewPointTemperature",
              "Calculates DewPointTemperature by Relative Humidity(0 - 100)[%] and Dry Bulb Temperature [°C] optionally Atmospheric Pressure [Pa] |101325 Pa ",
              "SAM", "Psychrometrics")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager inputParamManager)
        {
            inputParamManager.AddNumberParameter("_dryBulbTemperature", "_dryBulbTemperature", "Dry Bulb Temperature [°C]", GH_ParamAccess.item);
            inputParamManager.AddNumberParameter("_relativeHumidity", "_relativeHumidity", "Relative Humidity (0 - 100) [%]", GH_ParamAccess.item);

            int index = inputParamManager.AddNumberParameter("_pressure_", "_pressure_", "optional Atmospheric Pressure [Pa]", GH_ParamAccess.item);
            inputParamManager[index].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager outputParamManager)
        {
            outputParamManager.AddNumberParameter("dewPointTemperature", "dewPointTemperature", "Dew Point Temperature [°C]", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess dataAccess)
        {
            //double DewPointTemperature(double dryBulbTemperature, double relativeHumidity, double pressure)

            double dryBulbTemperature = double.NaN;
            double relativeHumidity = double.NaN;
            double pressure = double.NaN;

            if (!dataAccess.GetData(0, ref dryBulbTemperature) || double.IsNaN(dryBulbTemperature))
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            if (!dataAccess.GetData(1, ref relativeHumidity) || double.IsNaN(relativeHumidity))
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            double dewPointTemperature = double.NaN;
            if (dataAccess.GetData(2, ref pressure) && !double.IsNaN(pressure))
            {
                dewPointTemperature = Core.Psychrometrics.Query.DewPointTemperature(dryBulbTemperature, relativeHumidity, pressure);
            }
            else
            {
                dewPointTemperature = Core.Psychrometrics.Query.DewPointTemperature(dryBulbTemperature, relativeHumidity);
            }

            dataAccess.SetData(0, dewPointTemperature);

        }
    }
}