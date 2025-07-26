using DomeGym.Domain.UnitTests.TestUnits.Participants;
using DomeGym.Domain.UnitTests.TestUnits.Sessions;
using FluentAssertions;
namespace DomeGym.UnitTests;

public class SeesionTests
{
    [Fact]
    public void ReserveSpot_WhenNoMoreRoom_ShouldFailResvation()
    {
        //Arrange
        var session     = SessionFactory.CreateSession(maxParticipants:1);
        var particpant1 = ParticipantFactory.CreateParticipant(id: Guid.NewGuid());
        var particpant2 = ParticipantFactory.CreateParticipant(id: Guid.NewGuid());

        // Act
        session.ReserveSpot(particpant1);
        var action =()=>  session.ReserveSpot(particpant2);
        ///Assert
        ///participant 2 reservation Failed
        action.Should().Throw<InvalidOperationException>();

    }
}
