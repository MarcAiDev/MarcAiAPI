using FluentValidation;
using MarcAiAPI.Domain.Entities;
using MarcAiAPI.Domain.Interfaces;

namespace MarcAiAPI.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _repository.Insert(obj);
            return obj;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<TEntity> Get()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.Find(id);
            
        }

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _repository.Update(obj);
            return obj;
        }

        private static void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
            {
                throw new Exception("Null Object on validation");
            }

            validator.ValidateAndThrow(obj);
        }
    }
}
