namespace GregslistSharp.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Car> GetCars()
  {
    var sql = "SELECT * FROM cars";

    List<Car> cars = _db.Query<Car>(sql).ToList();
    return cars;
  }

  public Car CreateCar(Car carData)
  {
    var sql = @"
    INSERT INTO cars(
      make,
      model,
      year,
      price,
      description,
      imgUrl
    )
    VALUES(
      @Make,
      @Model,
      @Year,
      @Price,
      @Description,
      @ImgUrl
    );
    SELECT LAST_INSERT_ID();
    ";

    carData.Id = _db.ExecuteScalar<int>(sql, carData);
    return carData;
  }
}