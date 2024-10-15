using chorescore_api.Models;
using chorescore_api.Repository;

namespace chorescore_api.Services;

public class ChoresService
{

  public ChoresService(ChoresRepository choresRepository)
  {
    _choreRepository = choresRepository;
  }
  ChoresRepository _choreRepository;
  internal List<Chore> GetChores()
  {
    List<Chore> chores = _choreRepository.getChores();

    return chores;
  }

  internal Chore getChoreById(int choreId)
  {
    Chore chore = _choreRepository.getChoreById(choreId);
    if (chore == null)
    {
      throw new Exception($"Invalid Id: {choreId}");
    }
    return chore;
  }

  internal Chore createChore(Chore choreData)
  {
    Chore chore = _choreRepository.createChore(choreData);
    return chore;
  }

  internal string deleteChore(int choreId)
  {
    string message = _choreRepository.deleteChore(choreId);
    return message;
  }
}