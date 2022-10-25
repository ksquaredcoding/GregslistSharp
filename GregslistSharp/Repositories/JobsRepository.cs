namespace GregslistSharp.Repositories;

public class JobsRepository
{
  private readonly IDbConnection _db;

  public JobsRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<Job> GetJobs()
  {
    var sql = "SELECT * FROM jobs";
    List<Job> jobs = _db.Query<Job>(sql).ToList();
    return jobs;
  }

  public Job CreateJob(Job jobData)
  {
    var sql = @"
    INSERT INTO jobs(
      company,
      jobTitle,
      hours,
      rate,
      description
    )
    VALUES(
      @Company,
      @JobTitle,
      @Hours,
      @Rate,
      @Description
    );
    SELECT LAST_INSERT_ID();
    ";
    jobData.Id = _db.ExecuteScalar<int>(sql, jobData);
    return jobData;
  }
}