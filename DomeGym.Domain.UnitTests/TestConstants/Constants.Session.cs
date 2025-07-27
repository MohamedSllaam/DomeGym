using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DomeGym.Domain.UnitTests.TestConstants;

public static partial class Constants
{
    public static class Session
    {
        public static readonly Guid Id = Guid.NewGuid();
        public static readonly DateOnly Date =DateOnly.FromDateTime(DateTime.UtcNow);
        public static readonly TimeRange Time = new(
                                        TimeOnly.MinValue.AddHours(8),
                                        TimeOnly.MinValue.AddHours(9));

        public const int MaxParticipants = 10;

    }
}

 