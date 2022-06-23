using Grasshopper.Kernel;
using SAM.Core.Grasshopper.Psychrometrics.Properties;
using System;

namespace SAM.Core.Grasshopper.Psychrometrics
{
    public class SAMPsychrometricsDryBulbTemperature : GH_SAMComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("7a795583-cabe-452e-864f-bce79135fd5c");

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
        public SAMPsychrometricsDryBulbTemperature()
          : base("SAMPsychrometrics.DryBulbTemperature", "SAMPsychrometrics.DryBulbTemperature",
              "Calculates dry bulb temperature [°C]",
              "SAM", "Psychrometrics")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_InputParamManager inputParamManager)
        {
            inputParamManager.AddNumberParameter("_density", "_density", "Density [kg/m3]", GH_ParamAccess.item);
            inputParamManager.AddNumberParameter("_humidityRatio_", "_humidityRatio_", "Humidty Ratio [kg/kg]", GH_ParamAccess.item);
            inputParamManager.AddNumberParameter("_relativeHumidity_", "_relativeHumidity_", "Relative Humidity (0 - 100) [%]", GH_ParamAccess.item);

            global::Grasshopper.Kernel.Parameters.Param_Number param_Number = new global::Grasshopper.Kernel.Parameters.Param_Number() { Name = "_pressure_", NickName = "_pressure_", Description = "Atmospheric pressure [Pa]", Access = GH_ParamAccess.item, Optional = true };
            param_Number.SetPersistentData(101325);
            inputParamManager.AddParameter(param_Number);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_OutputParamManager outputParamManager)
        {
            outputParamManager.AddNumberParameter("dryBulbTemperature", "dryBulbTemperature", "Dry Bulb Temperature [°C]", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess dataAccess)
        {
            int index = -1;

            double density = double.NaN;
            double humidityRatio = double.NaN;
            double relativeHumidity = double.NaN;
            double pressure = double.NaN;

            index = Params.IndexOfInputParam("_density");
            if (index == -1 || !dataAccess.GetData(index, ref density) || double.IsNaN(density))
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            index = Params.IndexOfInputParam("_humidityRatio_");
            if (index != -1)
            {
                dataAccess.GetData(index, ref humidityRatio);
            }

            index = Params.IndexOfInputParam("_relativeHumidity_");
            if (index != -1)
            {
                dataAccess.GetData(index, ref relativeHumidity);
            }

            if(double.IsNaN(relativeHumidity) && double.IsNaN(humidityRatio))
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            index = Params.IndexOfInputParam("_pressure_");
            if (index == -1 || !dataAccess.GetData(index, ref pressure) || double.IsNaN(pressure))
            {
                pressure = 101325;
            }

            double dryBulbTemperature = double.NaN;
            if (!double.IsNaN(relativeHumidity))
            {
                dryBulbTemperature = Core.Psychrometrics.Query.DryBulbTemperature_ByDensityAndRelativeHumidity(density, relativeHumidity, pressure);
            }
            else
            {
                dryBulbTemperature = Core.Psychrometrics.Query.DryBulbTemperature_ByDensityAndHumidityRatio(density, humidityRatio, pressure);
            }

            dataAccess.SetData(0, dryBulbTemperature);
        }
    }
}