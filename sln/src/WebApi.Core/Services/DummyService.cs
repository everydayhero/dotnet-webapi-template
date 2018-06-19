namespace WebApi.Core.Services
{
    using System;
    
    public class DummyService : IDummyService
    {
        public long SomeAction()
        {
            return DateTime.Now.Ticks;
        }
    }
}