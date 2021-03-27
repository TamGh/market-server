namespace Market.Applictaion.DTOs
{
    public class UpdateProductDTO : ProductDTO
    {
        public UpdateProductDTO()
        {

        }
        public UpdateProductDTO(long id, string name, decimal price, bool available, string description): base(name, price, available, description)
        {
            Id = id;
        }
        public long Id { get; set; }
    }
}
