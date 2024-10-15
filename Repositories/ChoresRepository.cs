using chorescore_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace chorescore_api.Repository;

public class ChoresRepository
{
  public ChoresRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal List<Chore> getChores()
  {
    string sql = "SELECT * FROM chores";

    List<Chore> chores = _db.Query<Chore>(sql).ToList();

    return chores;

  }

  internal Chore getChoreById(int choreId)
  {
    string sql = "Select * from chores where id = @choreId";
    Chore chore = _db.Query<Chore>(sql, new { choreId }).FirstOrDefault();
    return chore;
  }

  internal Chore createChore(Chore choreData)
  {
    string sql = @"
    INSERT INTO
    chores (name, description, isComplete, BrowniePoints)
    VALUES(@Name, @Description, @isComplete, @BrowniePoints);
    
    SELECT * FROM chores WHERE id = LAST_INSERT_ID()";

    Chore chore = _db.Query<Chore>(sql, choreData).FirstOrDefault();
    return chore;
  }

  internal string deleteChore(int choreId)
  {
    string sql = @"DELETE FROM chores WHERE id = @choreId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { choreId });

    if (rowsAffected == 0)
    {
      throw new Exception("No Chores Deleted, Delete Failed");
    }
    if (rowsAffected > 1)
    {
      throw new Exception("More than one chore was Deleted, NOT GOOD");
    }
    return "Chore was Deleted";
  }
}