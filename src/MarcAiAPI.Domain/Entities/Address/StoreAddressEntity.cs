using MarcAiAPI.Domain.Entities.Person;
using MarcAiAPI.Domain.Entities.Store;

namespace MarcAiAPI.Domain.Entities.Address;

public class StoreAddressEntity
{
    public long AddressId { get; set; }
    public long StoreId { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public StoreEntity Store { get; set; }
}