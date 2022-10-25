namespace GregslistSharp.Services;

public class JobsService
{
  private readonly JobsRepository _jobsRepo;

  public JobsService(JobsRepository jobsRepo)
  {
    _jobsRepo = jobsRepo;
  }

  public List<Job> GetJobs()
  {
    return _jobsRepo.GetJobs();
  }

  public Job CreateJob(Job jobData)
  {
    return _jobsRepo.CreateJob(jobData);
  }

  public Job EditJob(Job jobData)
  {
    Job current = GetJobById(jobData.Id);
    current.Company = jobData.Company ?? current.Company;
    current.JobTitle = jobData.JobTitle ?? current.JobTitle;
    current.Hours = jobData.Hours ?? current.Hours;
    current.Rate = jobData.Rate ?? current.Rate;
    current.Description = jobData.Description ?? current.Description;
    Job job = _jobsRepo.EditJob(jobData);
    return job;
  }

  public Job GetJobById(int id)
  {
    Job job = _jobsRepo.GetJobById(id);
    if (job == null)
    {
      throw new Exception("Bad/Invalid Job Id");
    }
    return job;
  }

  public void RemoveJob(int id)
  {
    Job job = this.GetJobById(id);
    _jobsRepo.RemoveJob(job.Id);
  }

}