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

            builder.Register(x => ConfigureUoW()).As<IUnitOfWork>()
                .InstancePerDependency();

            return builder.Build();
        }

        protected abstract IUnitOfWorkFactory ConfigureUoWFactory();

        protected abstract IUnitOfWork ConfigureUoW();
    }
}
