using System.Threading.Tasks;

namespace PgdemoApp.DataWorker
{
    /// <summary>
    /// This service has skelton if we wanted to do some db opeartions.
    /// but due to remove dependency to data-layer, i removed the reference for here.
    /// 
    /// </summary>
    public class LogService : ILogService
    {
        //private readonly AppDbContext _db;

        //public LogService(AppDbContext db)
        //{
        //    _db = db;
        //}

        //public async Task<LogRecord> InsertRecord(LogRecord logRecord)
        //{
        //    _db.LogRecords.Add(logRecord);
        //    await _db.SaveChangesAsync();
        //    return logRecord;


        //}
    }
}
