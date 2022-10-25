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

  public Car GetCarById(int id)
  {
    var sql = @"
    SELECT * FROM cars
    WHERE id = @id
    ";
    Car car = _db.Query<Car>(sql, new { id }).FirstOrDefault();
    return car;
  }

  public void RemoveCar(int id)
  {
    var sql = @"
    DELETE FROM cars WHERE id = @id;
    ";
    _db.Execute(sql, new { id });
  }

  public Car EditCar(Car carData)
  {
    var sql = @"
        UPDATE cars SET
                make = @Make,
                model = @Model,
                year = @Year,
                price = @Price,
                imgUrl = @ImgUrl,
                description = @Description,
            WHERE id = @id;
        ";
    int edited = _db.Execute(sql, carData);
    if (edited == 0)
    {
      throw new Exception("No changes made to car");
    }
    return carData;
  }
}