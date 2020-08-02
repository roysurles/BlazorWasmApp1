using System;

using BlazorWasmApp1.Client.Features.ParentChild;

using Microsoft.Extensions.DependencyInjection;

namespace BlazorWasmApp1.UnitTests
{
    public class ServiceCollectionFixture : IDisposable
    {
        public ServiceCollectionFixture()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IParentChildService, ParentChildService>();
            serviceCollection.AddTransient<IParentChildViewModel, ParentChildViewModel>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;

            if (disposing)
            {
                ServiceProvider?.Dispose();
            }

            IsDisposed = true;
        }

        public bool IsDisposed { get; private set; }


        public ServiceProvider ServiceProvider { get; }
    }
}
