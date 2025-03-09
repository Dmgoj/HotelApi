public record HotelCreateDto
{
    public string Name { get; init; }
    public string StreetAddress { get; init; }
    public string City { get; init; }
    public string Country { get; init; }
    public string PostalCode { get; init; }
}

public record HotelReadDto
{
    public string Name { get; init; }
    public string StreetAddress { get; init; }
    public string City { get; init; }
    public string Country { get; init; }
    public string PostalCode { get; init; }
}

public record HotelUpdateDto
{
    public string? Name { get; init; }
    public string? StreetAddress { get; init; }
    public string? City { get; init; }
    public string? Country { get; init; }
    public string? PostalCode { get; init; }
}
