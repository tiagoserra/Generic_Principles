using Data.Repositories;
using Domain.CoreDomain.Interfaces;
using Domain.CoreDomain.Services;
using Domain.Library.Interfaces;
using Domain.Library.Services;
using SimpleInjector;

namespace IoC
{
    public class InjectorDomain
    {
        public static void Register(Container container)
        {
            container.Register(typeof(IBaseService<>), typeof(BaseService<>), Lifestyle.Scoped);
            container.Register(typeof(IBaseRepository<>), typeof(BaseRepository<>), Lifestyle.Scoped);

            container.Register<IBookService, BookService>(Lifestyle.Scoped);
            container.Register<IBookRepository, BookRepository>(Lifestyle.Scoped);

        }
    }
}
