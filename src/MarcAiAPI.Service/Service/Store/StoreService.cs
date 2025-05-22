using FluentValidation;
using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Interfaces.Store;

namespace MarcAiAPI.Service.Service.Store
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IValidator<StoreEntity> _validator;

        public StoreService(IStoreRepository storeRepository, IValidator<StoreEntity> validator)
        {
            _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task InsertStoreAsync(StoreEntity store)
        {
            var validationResult = await _validator.ValidateAsync(store);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            await _storeRepository.InsertStore(store);
        }

        public async Task UpdateStoreAsync(StoreEntity store)
        {
            var validationResult = await _validator.ValidateAsync(store);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            await _storeRepository.UpdateStore(store);
        }

        public async Task DeleteStoreAsync(long storeId)
        {
            if (storeId <= 0) throw new ValidationException("ID da loja deve ser maior que zero.");

            await _storeRepository.DeleteStore(storeId);
        }

        public async Task<StoreEntity> GetStoreAsync(long storeId)
        {
            if (storeId <= 0) throw new ValidationException("ID da loja deve ser maior que zero.");

            return await _storeRepository.GetStore(storeId);
        }

        public async Task<List<StoreEntity>> GetAllStoresAsync()
        {
            return await _storeRepository.GetAllStores();
        }
    }
}