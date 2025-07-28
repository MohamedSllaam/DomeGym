using DomeGym.Domain.ParticipantAggregate;

namespace DomeGym.Domain.UnitTests.TestUnits.Participants;
public static class ParticipantFactory
{
    public static Participant CreateParticipant(Guid? id = null)
    {
        return new Participant(
            userId: TestConstants.Constants.User.Id,
            id: id ?? TestConstants.Constants.Participant.Id);
    }
}
