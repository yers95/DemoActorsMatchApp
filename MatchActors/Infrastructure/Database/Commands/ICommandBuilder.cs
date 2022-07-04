using Dapper;

namespace MatchActors.Infrastructure.Database.Commands
{
    internal interface ICommandBuilder
    {
        public CommandDefinition BuildCommand(string name, CancellationToken cancellationToken);
    }
}
