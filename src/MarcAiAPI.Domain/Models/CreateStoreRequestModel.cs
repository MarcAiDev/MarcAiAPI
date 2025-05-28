using MarcAiAPI.Domain.Entities.Address;
using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Domain.Models
{
    public class CreateStoreRequest
    {
        public required StoreEntity Store { get; set; }
        public required StoreAddressEntity Address { get; set; }
    }
}