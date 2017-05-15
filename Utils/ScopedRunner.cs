using System;
using Microsoft.Extensions.DependencyInjection;

namespace ApcUpsLogger.Utils
{
    public class ScopedRunner
    {
        private readonly IServiceProvider applicationServices;
        public ScopedRunner(IServiceProvider applicationServices)
        {
            this.applicationServices = applicationServices;
        }

        public T2 Run<T1, T2>(Func<T1, T2> func)
        {
            using(var scope = applicationServices.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<T1>();
                return func(service);
            }
        }
    }
}