namespace GregslistSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController : ControllerBase
{
  private readonly JobsService _jobsService;

  public JobsController(JobsService jobsService)
  {
    _jobsService = jobsService;
  }

  [HttpGet]
  public ActionResult<List<Job>> GetJobs()
  {
    try
    {
      List<Job> jobs = _jobsService.GetJobs();
      return Ok(jobs);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpPost]
  public ActionResult<Job> Createjob([FromBody] Job jobData)
  {
    try
    {
      Job job = _jobsService.CreateJob(jobData);
      return Ok(job);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}