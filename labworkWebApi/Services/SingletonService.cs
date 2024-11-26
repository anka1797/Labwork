namespace labworkWebApi.Services
{
    public class SingletonService
    {
        public int Counter { get; set; }
        public List<DateTime> UserVisits { get; set; } = new();
    }
}
