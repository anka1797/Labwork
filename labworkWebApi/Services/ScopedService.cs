namespace labworkWebApi.Services
{
    public class ScopedService(SingletonService singletonService)
    {
        public int Counter { get; set; }
    }
}
