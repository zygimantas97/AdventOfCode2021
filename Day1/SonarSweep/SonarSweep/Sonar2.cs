using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SonarSweep
{
    public class Sonar2 : Sonar1
    {
        public Sonar2(List<int> measurements)
            : base(measurements)
        {
        }

        public override int GetIncreasesCount()
        {
            if (_measurements == null)
                return 0;

            var countOfIncreases = 0;

            for (int i = 3; i < _measurements.Count; i++)
            {
                if (_measurements.Skip(i-3).Take(3).Sum() < _measurements.Skip(i - 2).Take(3).Sum())
                    countOfIncreases++;
            }

            return countOfIncreases;
        }
    }
}
