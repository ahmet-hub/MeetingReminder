using MeetingReminder.Business.Abstract;
using MeetingReminder.Business.Concrete;
using MeetingReminder.DataAccess.Abstract;
using MeetingReminder.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace MeetingReminder.Business.DependencyResorvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonService>().To<PersonManager>();
            Bind<IMeetingService>().To<MeetingManager>();
            Bind<IMeetingControlService>().To<MeetingControlManager>();

            Bind<IPersonDal>().To<EfPersonDal>();
            Bind<IMeetingDal>().To<EfMeetingDal>();
            Bind<IMeetingControlDal>().To<EfMeetingControlDal>();
           




        }
    }
}
