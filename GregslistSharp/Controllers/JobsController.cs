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

  [HttpGet("{id}")]
  public ActionResult<Job> GetJobById(int id)
  {
    try
    {
      Job job = _jobsService.GetJobById(id);
      return Ok(job);
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

  [HttpPut("{id}")]
  public ActionResult<Job> EditJob(int id, [FromBody] Job jobData)
  {
    try
    {
      jobData.Id = id;
      Job job = _jobsService.EditJob(jobData);
      return Ok(job);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  public ActionResult<Job> RemoveJob(int id)
  {
    try
    {
      _jobsService.RemoveJob(id);
      return Ok("Job Deleted");
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
}