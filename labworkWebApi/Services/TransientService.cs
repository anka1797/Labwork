namespace labworkWebApi.Services
{
    public class TransientService
    {
        public int Counter { get; set; }
        public TransientService(ScopedService scopedService, SingletonService singletonService)
            {
                scopedService.Counter++;

            }
    }
}
