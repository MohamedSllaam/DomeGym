using DomeGym.Domain;
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
       var reserveParticipant1Result=  session.ReserveSpot(particpant1);
       var reserveParticipant2Result = session.ReserveSpot(particpant2);
   ///    var action =()=>  session.ReserveSpot(particpant2);
        ///Assert
        ///participant 2 reservation Failed
     //   action.Should().Throw<InvalidOperationException>();
      
        reserveParticipant1Result.IsError.Should().BeFalse();    
        reserveParticipant2Result.IsError.Should().BeTrue();
        reserveParticipant2Result
            .FirstError.Should()
            .Be(SessionErrors.CannotHaveMoreReservationsThanParticipants);
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

       

        var cancellationDateTime = Constants.Session.Date.ToDateTime(TimeOnly.MinValue);

        var reserveSpotResult = session.ReserveSpot(participant);
        var cancelReservationResult = session.CancelReservation(
            participant,
            new TestDateTimeProvider(fixedDateTime: cancellationDateTime)
            );

        //Assert 
        reserveSpotResult.IsError.Should().BeFalse();

        cancelReservationResult.IsError.Should().BeTrue();
        cancelReservationResult.FirstError.Should().Be(SessionErrors.CannotCancelReservationTooCloseToSession);
        //var action = () => session.CancelReservation(
        //    participant,
        //    new TestDateTimeProvider(fixedDateTime: cancellationDateTime)
        //    );

        // Assert
        //  action.Should().ThrowExactly<Exception>();
    }
}
