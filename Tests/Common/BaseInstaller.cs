﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Moq;

namespace Tests.Common
{
    public class BaseInstaller<TClass> : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new AutoMoqServiceResolver(container.Kernel));
            container.Register(Component.For(typeof(Mock<>)));
            container.Register(Classes
                .FromAssemblyContaining<TClass>()
                .Pick()
                .WithServiceSelf()
                .LifestyleTransient());
        }
    }
}