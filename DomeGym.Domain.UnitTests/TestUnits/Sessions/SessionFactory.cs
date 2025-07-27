using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
namespace DomeGym.Domain.UnitTests.TestUnits.Sessions;
public static class SessionFactory
{
    public static Session CreateSession(
      DateOnly? date = null,
      TimeRange? time = null,
     int maxParticipants = TestConstants.Constants.Session.MaxParticipants,
      Guid? id = null)
    {
        return new Session(
            date ?? TestConstants.Constants.Session.Date,
            time ?? TestConstants.Constants.Session.Time,
             maxParticipants,
           trainerId: TestConstants.Constants.Trainer.Id,
            id: id ?? TestConstants.Constants.Session.Id);
    }
}
