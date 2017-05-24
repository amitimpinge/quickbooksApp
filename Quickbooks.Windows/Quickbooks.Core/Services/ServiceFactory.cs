using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quickbooks.Core.Services
{
    public class ServiceFactory
    {
        private static Dictionary<string, ServiceBase> _loadedServices;
        public ServiceFactory()
        {
            if (_loadedServices == null)
            {
                _loadedServices = new Dictionary<string, ServiceBase>();
            }
        }

        private T LoadService<T>() where T : ServiceBase
        {
            Type myType = typeof(T);
            string name = myType.FullName;
            T repository = null;

            if (_loadedServices.ContainsKey(name))
            {
                repository = _loadedServices[name] as T;
            }

            if (repository == null)
            {
                repository = Activator.CreateInstance(myType) as T;
                _loadedServices.Add(name, repository);
            }

            return repository;
        }

        public CustomerService Customer
        {
            get { return LoadService<CustomerService>(); }
        }

        public PaymentsService Payment
        {
            get { return LoadService<PaymentsService>(); }
        }
    }

    public class ServiceBase
    {

    }
}
