using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Microsoft.Extensions.Options;

namespace Mango.Web.Services
{
    public class CartService : BaseService, ICartService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private readonly AppSettings _appSettings;
        public CartService(IHttpClientFactory clientFactory, IOptions<AppSettings> appsettingsOptions) : base(clientFactory)
        {
            _ClientFactory = clientFactory;
            _appSettings = appsettingsOptions.Value;
        }
        public async Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = _appSettings.ShoppingCartAPI + "/api/cart/AddCart",
                AccessToken = token

            });
        }

        public async Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = _appSettings.ShoppingCartAPI + "/api/cart/GetCart/" +userId,
                AccessToken = token

            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartId, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = cartId,
                Url = _appSettings.ShoppingCartAPI + "/api/cart/RemoveCart",
                AccessToken = token

            });
        }

        public async Task<T> UpdateToCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = _appSettings.ShoppingCartAPI + "/api/cart/UpdateCart",
                AccessToken = token

            });
        }
    }
}
