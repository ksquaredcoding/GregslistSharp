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

  public Car EditCar(Car carData)
  {
    Car current = GetCarById(carData.Id);
    current.Make = carData.Make ?? current.Make;
    current.Model = carData.Model ?? current.Model;
    current.Year = carData.Year ?? current.Year;
    current.Price = carData.Price ?? current.Price;
    current.Description = carData.Description ?? current.Description;
    current.ImgUrl = carData.ImgUrl ?? current.ImgUrl;
    return _carsRepo.EditCar(carData);
  }

  public Car GetCarById(int id)
  {
    Car car = _carsRepo.GetCarById(id);
    if (car == null)
    {
      throw new Exception("Bad/Invalid Car Id");
    }
    return car;
  }

  public void RemoveCar(int id)
  {
    Car car = this.GetCarById(id);
    _carsRepo.RemoveCar(car.Id);
  }
}