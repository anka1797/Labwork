namespace labworkWebApi.Services
{
    public class Transient2Service
    {
        public int Counter { get; set; }
        public Transient2Service(TransientService transientService)
            {
                transientService.Counter++;
            }
    }
}
