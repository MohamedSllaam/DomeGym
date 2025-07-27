using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeGym.Domain.UnitTests.TestUnits
{
    public class TestDateTimeProvider : IDateTimeProvider
    {
        private DateTime? _fixedDateTime;
        public TestDateTimeProvider(DateTime? fixedDateTime = null)
        {
            _fixedDateTime = fixedDateTime;
        }

        public DateTime UtcNow => _fixedDateTime ?? DateTime.UtcNow;
    }
}
