using Abp.Dependency;

namespace CerZen.Web.Authentication.External
{
    public class ExternalLoginInfoManagerFactory : ITransientDependency
    {
        private readonly IIocManager _iocManager;

        public ExternalLoginInfoManagerFactory(IIocManager iocManager)
        {
            _iocManager = iocManager;
        }

        public IDisposableDependencyObjectWrapper<IExternalLoginInfoManager> GetExternalLoginInfoManager(string loginProvider)
        {


            return _iocManager.ResolveAsDisposable<DefaultExternalLoginInfoManager>();
        }
    }
}
