using System;
using System.Collections.Generic;
using System.Text;

namespace SonarSweep
{
    public class Sonar1
    {
        protected readonly List<int> _measurements;

        public Sonar1(List<int> measurements)
        {
            _measurements = measurements;
        }

        public virtual int GetIncreasesCount()
        {
            if (_measurements == null)
                return 0;

            var countOfIncreases = 0;

            for (int i = 1; i < _measurements.Count; i++)
            {
                if (_measurements[i - 1] < _measurements[i])
                    countOfIncreases++;
            }

            return countOfIncreases;
        }
    }
}
