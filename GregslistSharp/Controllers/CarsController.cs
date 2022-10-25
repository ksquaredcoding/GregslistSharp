namespace GregslistSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
  private readonly CarsService _carsService;

  public CarsController(CarsService carsService)
  {
    _carsService = carsService;
  }
  [HttpGet]
  public ActionResult<List<Car>> GetCars()
  {
    try
    {
      List<Car> cars = _carsService.GetCars();
      return Ok(cars);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("{id}")]
  public ActionResult<Car> GetCarById(int id)
  {
    try
    {
      Car car = _carsService.GetCarById(id);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpPost]
  public ActionResult<Car> CreateCar([FromBody] Car carData)
  {
    try
    {
      Car car = _carsService.CreateCar(carData);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{id}")]
  public ActionResult<Car> EditCar(int id, [FromBody] Car carData)
  {
    try
    {
      carData.Id = id;
      Car car = _carsService.EditCar(carData);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<Car> RemoveCar(int id)
  {
    try
    {
      _carsService.RemoveCar(id);
      return Ok("Car Deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}
