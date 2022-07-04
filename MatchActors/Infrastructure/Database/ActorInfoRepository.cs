using Dapper;
using MatchActors.Infrastructure.Database.Commands;
using Npgsql;

namespace MatchActors.Infrastructure.Database
{
    internal sealed class ActorInfoRepository: IActorInfoRepository
    {
        private readonly string _connectionString;
        private readonly ICommandBuilder _commandBuilder;

        public ActorInfoRepository(IConfiguration configuration, ICommandBuilder commandBuilder)
        {
            _connectionString = configuration.GetConnectionString("PostgreConnectionString");
            _commandBuilder = commandBuilder;
        }

        public async Task<ActorInfo> GetActorInfo(string name, CancellationToken cancellationToken)
        {
            using var connection = new NpgsqlConnection(_connectionString);

            await connection.OpenAsync(cancellationToken);

            return await connection.QueryFirstOrDefaultAsync<ActorInfo>(_commandBuilder.BuildCommand(name, cancellationToken));    
        }
    }
}
