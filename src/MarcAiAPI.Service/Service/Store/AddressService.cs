using FluentValidation;
using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Interfaces.Store;

namespace MarcAiAPI.Service.Service.Store
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IValidator<StoreAddressEntity> _validator;

        public AddressService(IAddressRepository addressRepository, IValidator<StoreAddressEntity> validator)
        {
            _addressRepository = addressRepository ?? throw new ArgumentNullException(nameof(addressRepository));
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task InsertStoreAddressAsync(StoreAddressEntity address)
        {
            var validationResult = await _validator.ValidateAsync(address);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            await _addressRepository.InsertStoreAddress(address);
        }

        public async Task UpdateStoreAddressAsync(StoreAddressEntity address)
        {
            var validationResult = await _validator.ValidateAsync(address);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            await _addressRepository.UpdateStoreAddress(address);
        }

        public async Task DeleteStoreAddressAsync(long storeId)
        {
            if (storeId <= 0) throw new ValidationException("ID do endereço deve ser maior que zero.");

            await _addressRepository.DeleteStoreAddress(storeId);
        }

        public async Task<StoreAddressEntity> GetStoreAddressAsync(long storeId)
        {
            if (storeId <= 0) throw new ValidationException("ID do endereço deve ser maior que zero.");

            return await _addressRepository.GetStoreAddress(storeId);
        }

        public async Task<List<StoreAddressEntity>> GetAllStoresAddressAsync()
        {
            return await _addressRepository.GetAllStoresAddress();
        }
    }
}