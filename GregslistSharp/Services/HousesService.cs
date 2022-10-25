namespace GregslistSharp.Services;

public class HousesService
{
  private readonly HousesRepository _housesRepo;

  public HousesService(HousesRepository housesRepo)
  {
    _housesRepo = housesRepo;
  }

  public List<House> GetHouses()
  {
    return _housesRepo.GetHouses();
  }
  public House CreateHouse(House houseData)
  {
    return _housesRepo.CreateHouse(houseData);
  }
}