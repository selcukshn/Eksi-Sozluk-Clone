using Common.Models.Command;
using Dapper;
using Microsoft.Data.SqlClient;

namespace FavoriteService.Service
{
    public class FavoriteDbService : IFavoriteDbService
    {
        private readonly IConfiguration Configuration;

        public FavoriteDbService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task EntryFavoriteProcessAsync(EntryFavoriteCommand command)
        {
            using var sql = new SqlConnection(Configuration.GetConnectionString("SQLServer"));
            var entity = await sql.ExecuteAsync("SELECT * FROM EntryFavorite WHERE EntryId = @EntryId and UserId = @UserId", new { EntryId = command.EntryId, UserId = command.UserId });
            if (entity == 0)
                await sql.ExecuteAsync("INSERT INTO EntryFavorite (EntryId,UserId) VALUES (@EntryId,@UserId)", new { EntryId = command.EntryId, UserId = command.UserId });
            else
                await sql.ExecuteAsync("DELETE FROM EntryFavorite WHERE EntryId = @EntryId and UserId = @UserId ", new { EntryId = command.EntryId, UserId = command.UserId });
        }
    }
}