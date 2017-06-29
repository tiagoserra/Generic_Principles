using Domain.CoreDomain.Services;
using Domain.Library.Entities;
using Domain.Library.Interfaces;

namespace Domain.Library.Services
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IBookRepository _Repository;
        
        public BookService(IBookRepository repository) : base(repository)
        {
            _Repository = repository;
        }
    }
}
