namespace GregslistSharp.Repositories;

public class HousesRepository
{
  private readonly IDbConnection _db;

  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<House> GetHouses()
  {
    var sql = "SELECT * FROM houses";
    List<House> houses = _db.Query<House>(sql).ToList();
    return houses;
  }

  public House CreateHouse(House houseData)
  {
    var sql = @"
    INSERT INTO houses(
      bedrooms,
      bathrooms,
      levels,
      year,
      price,
      description,
      imgUrl
    )
    VALUES(
      @Bedrooms,
      @Bathrooms,
      @Levels,
      @Year,
      @Price,
      @Description,
      @ImgUrl
    );
    SELECT LAST_INSERT_ID();
    ";
    houseData.Id = _db.ExecuteScalar<int>(sql, houseData);
    return houseData;
  }
}