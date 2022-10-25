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

  public Job GetJobById(int id)
  {
    var sql = @"
    SELECT * FROM jobs
    WHERE id = @id
    ";
    Job job = _db.Query<Job>(sql, new { id }).FirstOrDefault();
    return job;
  }

  public void RemoveJob(int id)
  {
    var sql = @"
    DELETE FROM jobs WHERE id = @id;
    ";
    _db.Execute(sql, new { id });
  }

  public Job EditJob(Job jobData)
  {
    var sql = @"
        UPDATE jobs SET
                company = @Company,
                jobTitle = @JobTitle,
                hours = @Hours,
                rate = @Rate,
                description = @Description
            WHERE id = @id;
        ";
    int edited = _db.Execute(sql, jobData);
    if (edited == 0)
    {
      throw new Exception("No changes made to job");
    }
    return jobData;
  }
}