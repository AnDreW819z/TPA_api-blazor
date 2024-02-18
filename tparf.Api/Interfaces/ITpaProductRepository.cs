using tparf.Api.Entities;
using tparf.Models.Dtos.Auth;
using tparf.Models.Dtos.TpaProducts;
using tparf.Models.Dtos.TpaProducts.Characteristic;
using tparf.Models.Dtos.TpaProducts.Images;

namespace tparf.Api.Interfaces
{
    public interface ITpaProductRepository
    {
        Task<IEnumerable<TpaProduct>> GetProducts();
        Task<TpaProduct> GetProduct(long id);
        public Task<TpaProduct> AddNewProduct(CreateTpaProductDto productDto);
        public Task<TpaProduct> UpdateProduct(long id, UpdateTpaProductDto productDto);
        public Task<Status> DeleteProduct(long id);

        Task<Characteristic> GetCharacteristic(long id);
        public Task<IEnumerable<Characteristic>> GetCharacteristicsFromProduct(long productId);
        public Task<Characteristic> AddNewCharacteristic(CharacteristicDto characteristic);
        public Task<Characteristic> UpdateCharacteristic(long charId, UpdateCharacteristicDto updateCharacteristic);
        public Task<Status> DeleteCharacteristic(long charId);

        public Task<ProductImage> GetImage(long id);
        public Task<IEnumerable<ProductImage>> GetImagesFromProduct(long productId);
        public Task<ProductImage> AddNewImage(ImageDto imageDto);
        public Task<ProductImage> UpdateImage(long imgId, UpdateImageDto updateImage);
        public Task<Status> DeleteImage(long charId);
    }
}
