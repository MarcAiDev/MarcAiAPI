using FluentValidation;
using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.Interfaces.Store;
using MarcAiAPI.Domain.Models;

namespace MarcAiAPI.Service.Service.Store
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IStoreAddressRepository _storeAdressRepository;
        private readonly IValidator<StoreEntity> _validator;

        public StoreService(IStoreRepository storeRepository, IStoreAddressRepository  storeAddressRepository, IValidator<StoreEntity> validator)
        {
            _storeRepository = storeRepository ?? throw new ArgumentNullException(nameof(storeRepository));
            _storeAdressRepository = storeAddressRepository ?? throw new ArgumentNullException(nameof(storeAddressRepository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }
        
        public async Task<List<StoreEntity>> GetStoreAsync(long? storeId, long? marketplaceId, long? sellerId)
        {
            return await _storeRepository.GetStore(storeId, marketplaceId, sellerId);
        }

        public async Task<StoreAddressEntity> GetAddressAsync(long storeId)
        {
            var address = await _storeAdressRepository.GetAddress(storeId);
            if (address == null)
                throw new Exception("Endereço não encontrado para esta loja.");

            return address;
        }


        public async Task CreateStoreAsync(CreateStoreRequest createStoreRequest)
        {
            await _storeRepository.InsertStore(createStoreRequest);;
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

    }
}