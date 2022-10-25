namespace GregslistSharp.Services;

public class CarsService
{
  private readonly CarsRepository _carsRepo;

  public CarsService(CarsRepository carsRepo)
  {
    _carsRepo = carsRepo;
  }

  public List<Car> GetCars()
  {
    return _carsRepo.GetCars();
  }
  public Car CreateCar(Car carData)
  {
    return _carsRepo.CreateCar(carData);
  }
}