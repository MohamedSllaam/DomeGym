using DomeGym.Domain.UnitTests.TestUnits.Sessions;

namespace DomeGym.UnitTests;

public class SeesionTests
{
    [Fact]
    public void ReserveSpot_WhenNoMoreRoom_ShouldFailResvation()
    {
        //Arrange
        var session     = SessionFactory.CreateSession(maxParticipants:1);
        var particpant1 = ParticipantFactory.CreateParticipant(IDictionary: Guid.NewGuid());
        var particpant2 = ParticipantFactory.CreateParticipant(IDictionary: Guid.NewGuid());

        // Act
        Session.ResrveSpot(particpant1);
        ///Assert
        ///participant 2 reservation Failed
        

    }
}
