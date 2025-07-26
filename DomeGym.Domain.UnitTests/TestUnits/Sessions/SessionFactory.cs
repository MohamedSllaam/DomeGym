using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
namespace DomeGym.Domain.UnitTests.TestUnits.Sessions;
public static class SessionFactory
{
    public static Session CreateSession( 
         int maxParticipants,
         Guid? id = null
        ) 
    {
        return new Session(maxParticipants,
           trainerId: TestConstants.Constants.Trainer.Id,
           id : id?? TestConstants.Constants.Session.Id
            );
    } 
}
