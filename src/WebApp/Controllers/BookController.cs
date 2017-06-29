using Domain.CoreDomain.Interfaces;
using Domain.Library.Entities;
using WebApp.Generics;

namespace WebApp.Controllers
{
    public class BookController : BaseController<Book>
    {
        public BookController(IBaseRepository<Book> repository, IBaseService<Book> service) : base(repository, service)
        {

        }
    }
}