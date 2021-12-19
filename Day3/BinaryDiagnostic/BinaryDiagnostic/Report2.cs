using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryDiagnostic
{
    public class Report2 : Report1
    {
        public Report2(List<string> reportData)
            : base(reportData)
        {
        }

        public string GetOxygenGeneratorRate()
        {
            var data = new List<string>(_reportData);

            var index = 0;
            while(data.Count > 1)
            {
                var frequencies = GetPositiveFrequencies(data);

                if (frequencies[index] >= data.Count - frequencies[index])
                    data = data.Where(x => x[index] == '1').ToList();
                else
                    data = data.Where(x => x[index] != '1').ToList();

                index++;
            }

            return data[0];
        }

        public string GetCO2ScrubberRate()
        {
            var data = new List<string>(_reportData);

            var index = 0;
            while (data.Count > 1)
            {
                var frequencies = GetPositiveFrequencies(data);

                if (frequencies[index] < data.Count - frequencies[index])
                    data = data.Where(x => x[index] == '1').ToList();
                else
                    data = data.Where(x => x[index] != '1').ToList();

                index++;
            }

            return data[0];
        }

        public long GetLifeSupportRate()
        {
            var oxygenGeneratorRate = Convert.ToInt32(GetOxygenGeneratorRate(), 2);
            var CO2ScrubberRate = Convert.ToInt32(GetCO2ScrubberRate(), 2);

            return oxygenGeneratorRate * CO2ScrubberRate;
        }
    }
}
