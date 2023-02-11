using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Microsoft.Extensions.Options;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private readonly AppSettings _appSettings;
        public ProductService(IHttpClientFactory clientFactory, IOptions<AppSettings> appsettingsOptions) : base(clientFactory)
        {
            _ClientFactory = clientFactory;
            _appSettings = appsettingsOptions.Value;
        }

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = _appSettings.ProductAPI + "/api/products",
                AccessToken = ""

            });
        }

        public async Task<T> DeleteProductAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Data = "",
                Url = _appSettings.ProductAPI + "/api/products/" + id,
                AccessToken = ""

            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,

                Url = _appSettings.ProductAPI + "/api/products",
                AccessToken = ""

            });
        }

        public async Task<T> GetAllProductsByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,

                Url = _appSettings.ProductAPI + "/api/products/" + id,
                AccessToken = ""

            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                Url = _appSettings.ProductAPI + "/api/products",
                AccessToken = ""

            });
        }
    }
}
