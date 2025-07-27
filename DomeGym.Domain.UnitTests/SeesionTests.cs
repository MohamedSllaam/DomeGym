using DomeGym.Domain.UnitTests.TestConstants;
using DomeGym.Domain.UnitTests.TestUnits;
using DomeGym.Domain.UnitTests.TestUnits.Participants;
using DomeGym.Domain.UnitTests.TestUnits.Sessions;
using FluentAssertions;
using FluentAssertions.Common;
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

    [Fact]
    public void CancelReservation_WhenCancellationIsToolCloseToSessio_ShouldFailCancellation()
    {
        //Arrange 
        var session = SessionFactory.CreateSession
            (date: Constants.Session.Date,
              time: Constants.Session.Time
            );
        var participant= ParticipantFactory
            .CreateParticipant();

        session.ReserveSpot(participant);

        var cancellationDateTime = Constants.Session.Date.ToDateTime(TimeOnly.MinValue);

        var action = () => session.CancelReservation(
            participant,
            new TestDateTimeProvider(fixedDateTime: cancellationDateTime)
            );

        // Assert
        action.Should().ThrowExactly<Exception>();
    }
}
