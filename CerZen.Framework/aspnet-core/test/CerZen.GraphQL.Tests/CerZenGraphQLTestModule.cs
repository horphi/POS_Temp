using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using CerZen.Configure;
using CerZen.Startup;
using CerZen.Test.Base;

namespace CerZen.GraphQL.Tests
{
    [DependsOn(
        typeof(CerZenGraphQLModule),
        typeof(CerZenTestBaseModule))]
    public class CerZenGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CerZenGraphQLTestModule).GetAssembly());
        }
    }
}