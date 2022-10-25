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

  public House GetHouseById(int id)
  {
    var sql = @"
    SELECT * FROM houses
    WHERE id = @id
    ";
    House house = _db.Query<House>(sql, new { id }).FirstOrDefault();
    return house;
  }

  public void RemoveHouse(int id)
  {
    var sql = @"
    DELETE FROM houses WHERE id = @id;
    ";
    _db.Execute(sql, new { id });
  }

  public House Edithouse(House houseData)
  {
    var sql = @"
        UPDATE houses SET
                bedrooms = @Bedrooms
                bathrooms = @Bathrooms
                levels = @Levels
                year = @Year
                price = @Price
                description = @Description
                imgUrl = @ImgUrl
            WHERE id = @id;
        ";
    int edited = _db.Execute(sql, houseData);
    if (edited == 0)
    {
      throw new Exception("No changes made to house");
    }
    return houseData;
  }
}