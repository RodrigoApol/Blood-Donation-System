using System.Text.Json.Serialization;

namespace BloodDonationSystem.Core.Entities;

public record Address(
    string Street,
    string City,
    string State,
    string PostalCode);
