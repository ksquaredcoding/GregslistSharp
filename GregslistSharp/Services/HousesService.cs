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

  public House EditHouse(House houseData)
  {
    House current = GetHouseById(houseData.Id);
    current.Bedrooms = houseData.Bedrooms ?? current.Bedrooms;
    current.Bathrooms = houseData.Bathrooms ?? current.Bathrooms;
    current.Levels = houseData.Levels ?? current.Levels;
    current.Year = houseData.Year ?? current.Year;
    current.Price = houseData.Price ?? current.Price;
    current.Description = houseData.Description ?? current.Description;
    current.ImgUrl = houseData.ImgUrl ?? current.ImgUrl;
    House house = _housesRepo.EditHouse(houseData);
    return house;
  }

  public House GetHouseById(int id)
  {
    House house = _housesRepo.GetHouseById(id);
    if (house == null)
    {
      throw new Exception("Bad/Invalid House Id");
    }
    return house;
  }

  public void RemoveHouse(int id)
  {
    House house = this.GetHouseById(id);
    _housesRepo.RemoveHouse(house.Id);
  }
}