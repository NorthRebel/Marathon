using Autofac;
using Marathon.DAL.UnitOfWork;

namespace Marathon.Tests.DAL.Infrastructure.IoC
{
    public abstract class BootStrapper
    {

        protected IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.Register(x => ConfigureUoWFactory()).As<IUnitOfWorkFactory>()
                .InstancePerDependency();

            return builder.Build();
        }

        protected abstract IUnitOfWorkFactory ConfigureUoWFactory();
    }
}
