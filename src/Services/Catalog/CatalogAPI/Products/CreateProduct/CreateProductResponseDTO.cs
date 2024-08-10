public class CreateProductResponseDTO
{
    public Guid Id { get; set; }

    // Constructor to initialize the Guid
    public CreateProductResponseDTO(Guid id)
    {
        Id = id;
    }
}
