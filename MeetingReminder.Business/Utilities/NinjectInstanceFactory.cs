using MeetingReminder.Business.DependencyResorvers.Ninject;
using Ninject;

namespace MeetingReminder.Business.Utilities
{
    public class NinjectInstanceFactory
    {
        public static T GetInstance<T>()
        {
            IKernel kernel=new StandardKernel(new BusinessModule());
            return kernel.Get<T>();

        }
    }
}
