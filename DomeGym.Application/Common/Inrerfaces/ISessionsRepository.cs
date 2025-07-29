using DomeGym.Domain.SessionAggregate;

namespace DomeGym.Application.Common.Inrerfaces
{
    public interface ISessionsRepository
    {
        Task AddSessionAsyn(Session session);
        Task UpdateSessionAsyn(Session session);

    }
}
