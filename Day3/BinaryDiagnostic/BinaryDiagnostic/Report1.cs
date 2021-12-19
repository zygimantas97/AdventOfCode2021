using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryDiagnostic
{
    public class Report1
    {
        protected readonly List<string> _reportData;

        public Report1(List<string> reportData)
        {
            _reportData = reportData;
        }

        public virtual string GetEpsilonRate()
        {
            var frequencies = GetPositiveFrequencies(_reportData);

            var epsilonRate = "";
            foreach (var f in frequencies)
            {
                if (f < _reportData.Count - f)
                    epsilonRate += "1";
                else
                    epsilonRate += "0";
            }

            return epsilonRate;
        }

        public string GetGammaRate()
        {
            var frequencies = GetPositiveFrequencies(_reportData);

            var gammaRate = "";
            foreach (var f in frequencies)
            {
                if (f >= _reportData.Count - f)
                    gammaRate += "1";
                else
                    gammaRate += "0";
            }

            return gammaRate;
        }

        public long GetPowerConsumption()
        {
            var gammaRate = Convert.ToInt32(GetGammaRate(), 2);
            var epsilonRate = Convert.ToInt32(GetEpsilonRate(), 2);

            return gammaRate * epsilonRate;
        }

        protected List<int> GetPositiveFrequencies(List<string> data)
        {
            var frequencies = new List<int>();
            for (var i = 0; i < data[0].Length; i++)
                frequencies.Add(0);

            foreach (var entry in data)
            {
                for (var i = 0; i < entry.Length; i++)
                {
                    if (entry[i] == '1')
                        frequencies[i]++;
                    else if (entry[i] != '0')
                        throw new FormatException("Report data entry is not of binnary format");
                }
            }

            return frequencies;
        }
    }
}
