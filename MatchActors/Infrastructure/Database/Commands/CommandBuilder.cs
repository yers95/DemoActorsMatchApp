using Dapper;

namespace MatchActors.Infrastructure.Database.Commands
{
    internal sealed class CommandBuilder : ICommandBuilder
    {
        private const string _baseQuery = "select actor_id as ActorId, name as Name from public.\"actors\" where lower(name) = @name;";
        public CommandDefinition BuildCommand(string name, CancellationToken cancellationToken)
        {
            return new CommandDefinition(_baseQuery, new { name = name.ToLower() }, cancellationToken: cancellationToken);
        }
    }
}
