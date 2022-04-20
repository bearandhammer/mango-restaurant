﻿using AutoMapper;
using MongoRestaurant.ShoppingCart.API.Context;
using MongoRestaurant.ShoppingCart.API.Models.Entity;
using MongoRestaurant.ShoppingCart.API.Repositories.Interfaces;

namespace MongoRestaurant.ShoppingCart.API.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ShoppingCartDbContext dbContext;

        private readonly IMapper mapper;

        public CartRepository(ShoppingCartDbContext dbContextType, IMapper mapperType)
        {
            dbContext = dbContextType;
            mapper = mapperType;
        }

        public async Task<bool> ClearCart(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> GetCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(int cartDetailsId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> UpsertCart(CartDto cartDto)
        {
            Cart cart = mapper.Map<Cart>(cartDto);

            await CreateProductIfMissing(cartDto, cart);

            CartHeader existingCartHeader = dbContext.CartHeaders
                .FirstOrDefault(cartHeader => cartHeader.UserId == cart.CartHeader.UserId);

            if (existingCartHeader == null)
            {
                dbContext.CartHeaders.Add(cart.CartHeader);
                await dbContext.SaveChangesAsync();

                cart.CartDetails.First().CartHeaderId = cart.CartHeader.Id;
                cart.CartDetails.First().Product = null;

                dbContext.CartDetails.Add(cart.CartDetails.First());
                await dbContext.SaveChangesAsync();
            }
            else
            {
                CartDetails existingCartDetails = dbContext.CartDetails
                    .FirstOrDefault(cartDetail => cartDetail.ProductId == cart.CartDetails.First().ProductId
                        && cartDetail.CartHeaderId == existingCartHeader.Id);

                // TODO: flesh out logic
                if (existingCartDetails == null)
                {
                    
                }
            }


            // TODO: Fix return type
            return null;
        }

        private async Task CreateProductIfMissing(CartDto cartDto, Cart cart)
        {
            Product existingProduct = dbContext.Products
                .FirstOrDefault(product => product.Id == cartDto.CartDetails.First().ProductId);

            if (existingProduct == null)
            {
                dbContext.Products.Add(cart.CartDetails.First().Product);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
