namespace MatchActors.Infrastructure.Database
{
    internal interface IActorInfoRepository
    {
        Task<ActorInfo> GetActorInfo(string name, CancellationToken cancellationToken);
    }
}
