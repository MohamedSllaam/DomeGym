namespace DomeGym.Domain.Common.Inrerfaces;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}