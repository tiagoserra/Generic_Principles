using Domain.CoreDomain.Entities;
using Domain.CoreDomain.Interfaces;
using System;
using System.Web.Mvc;

namespace WebApp.Generics
{
    public class BaseController<TEntity> : Controller where TEntity : Entity<TEntity> 
    {
        protected readonly IBaseRepository<TEntity> _repository;

        protected readonly IBaseService<TEntity> _service;

        public BaseController(IBaseRepository<TEntity> repository, IBaseService<TEntity> service)
        {
            _repository = repository;
            _service = service;
        }
        
        [HttpGet]
        public virtual ActionResult List()
        {
            return View(_repository.GetAll());
        }
        
        [HttpGet]
        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TEntity entity)
        {
            try
            {
                var result = _service.Insert(entity);

                if(result != null)
                {
                    ViewBag.Erros = result.Errors;
                    return View(entity);
                }

                return RedirectToAction("Edit", new { Id = entity.Id });
            }
            catch(Exception e)
            {
                ViewBag.Error = e.ToString();
                return View();
            }
        }

        [HttpGet]
        public virtual ActionResult Edit(Guid id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(Guid id, TEntity entity)
        {
            try
            {
                var result = _service.Update(entity);

                if (result != null)
                {
                    ViewBag.Erros = result.Errors;
                    return View(entity);
                }

                return RedirectToAction("Edit", new { Id = entity.Id });
            }
            catch(Exception e)
            {
                ViewBag.Error = e.ToString();
                return View();
            }
        }

        [HttpGet]
        public virtual ActionResult Delete(Guid id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(Guid id, TEntity entity)
        {
            try
            {
                _service.Delete(id);

                return RedirectToAction("List");
            }
            catch(Exception e)
            {
                return Content(e.ToString());
            }
        }
    }
}