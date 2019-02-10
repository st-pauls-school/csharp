using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Lib
{
    public class ExamScore
    {
        readonly int _score;
        readonly int _total;

        public ExamScore(int s, int t)
        {
            if (s < 0)
                throw new ExamScoreException(1, "Cannot have a negative score");
            _score = s;

            if (t <= 0)
                throw new ExamScoreException(2, "Must have a positive, non-zero total");

            _total = t;
        }

        public decimal Percentage
        {
            get
            {
                return _score / _total;
            }
        }
    }
}
