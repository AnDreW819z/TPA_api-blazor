using System.Runtime.CompilerServices;
using tparf.Api.Entities;
using tparf.Models.Dtos;
using tparf.Models.Dtos.CartItems;
using tparf.Models.Dtos.Categories;
using tparf.Models.Dtos.Manufacturers;
using tparf.Models.Dtos.Orders;
using tparf.Models.Dtos.Products;
using tparf.Models.Dtos.Subcategories;
using tparf.Models.Dtos.TpaProducts;
using tparf.Models.Dtos.TpaProducts.Characteristic;
using tparf.Models.Dtos.TpaProducts.Images;

namespace tparf.Api.Extensions
{
    public static class DtoConvensions
    {
        public static IEnumerable<CategoryDto> ConvertToDto(this IEnumerable<Category> categories)
        {
            if(categories != null)
            {
                return (from category in categories
                        select new CategoryDto
                        {
                            Id = category.Id,
                            Name = category.Name,
                            IconCSS = category.IconCSS,
                            ManufacturerId = category.Manufacturer.Id,
                            ManufacturerName = category.Manufacturer.Name
                        }).ToList();
            }
            return null;
        }

        public static IEnumerable<OrderItemDto> ConvertToDto(this IEnumerable<OrderItem> orderItems)
        {
            return (from orderItem in orderItems
                    select new OrderItemDto
                    {
                        Id = orderItem.Id,
                        OrderId = orderItem.OrderId,
                        ProductId = orderItem.ProductId,
                        ProductName = orderItem.ProductName,
                        Qty = orderItem.Qty,
                        Price = orderItem.Price,
                        TotalPriceByOrderItem = orderItem.TotalPriceByOrderItem,
                    });
        }

        public static IEnumerable<OrderDto> ConvertToDto(this IEnumerable<Order> orders)
        {
            return(from order in orders
                   select new OrderDto
                   {
                       Id = order.Id,
                       CartId = order.CartId,
                       Email = order.Email,
                       PhoneNumber = order.PhoneNumber,
                       FirstName = order.FirstName,
                       LastName = order.LastName,
                       TotalPrice = order.TotalPrice,
                       Adress = order.Adress,
                       StatusId = order.StatusId,
                   });

        }

        public static IEnumerable<CharacteristicDto> ConvertToDto(this IEnumerable<Characteristic> characteristics)
        {
            return (from characteristic in characteristics
                    select new CharacteristicDto
                    {
                        Id = characteristic.Id,
                        Name = characteristic.Name,
                        Value = characteristic.Value,
                        ProductId = characteristic.ProductId
                    });
        }

        public static ImageDto ConvertToDto(this ProductImage image)
        {
            return new ImageDto
            {
                Id = image.Id,
                Value = image.Value,
                ProductId = image.ProductId,
            };
        }

        public static IEnumerable<SubcategoryDto> ConvertToDto(this IEnumerable<Subcategory> subcategories)
        {
            return (from subcategory in subcategories
                    select new SubcategoryDto
                    {
                        Id = subcategory.Id,
                        Name = subcategory.Name,
                        IconCSS = subcategory.IconCSS,
                        CategoryId = subcategory.Category.Id,
                        CategoryName= subcategory.Category.Name,
                    }).ToList();
        }

        public static IEnumerable<ManufacturerDto> ConvertToDto(this IEnumerable<Manufacturer> manufacturers)
        {
            return (from manufacturer in manufacturers
                    select new ManufacturerDto
                    {
                        Id = manufacturer.Id,
                        Name = manufacturer.Name,
                        ImageUrl = manufacturer.ImageUrl,
                    }).ToList();
        }

        public static IEnumerable<TpaProductDto> ConvertToDto(this IEnumerable<TpaProduct> products)
        {
            return (from product in products
                    select new TpaProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Article = product.Article,
                        ImageUrl = product.ImageUrl,
                        Price = product.Price,
                        Discount = product.Discount,
                        //ManufacturerId= product.Manufacturer.Id,
                        //ManufacturerName= product.Manufacturer.Name,
                        //CategoryId= product.Category.Id,
                        //CategoryName= product.Category.Name,
                        SubcategoryId = product.Subcategory.Id,
                        SubcategoryName= product.Subcategory.Name
                    }).ToList();
        }

        public static ManufacturerDto ConverToDto(this Manufacturer manufacturer)
        {
            return new ManufacturerDto
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
                ImageUrl = manufacturer.ImageUrl,
            };
        }

        public static OrderDto ConvertToDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                CartId = order.CartId,
                Email = order.Email,
                PhoneNumber = order.PhoneNumber,
                FirstName = order.FirstName,
                LastName = order.LastName,
                TotalPrice = order.TotalPrice,
                Adress = order.Adress,
                StatusId = order.StatusId,
            };

        }


        public static CategoryDto ConverToDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                IconCSS = category.IconCSS,
                ManufacturerName = category.Manufacturer.Name,
                ManufacturerId= category.Manufacturer.Id
            };
        }

        public static CharacteristicDto ConvertToDto(this Characteristic characteristic)
        {
            return new CharacteristicDto
            {
                Id = characteristic.Id,
                Name = characteristic.Name,
                Value = characteristic.Value,
                ProductId = characteristic.ProductId,
            };
        }

        public static IEnumerable<ImageDto> ConvertToDto(this IEnumerable<ProductImage> images)
        {
            return (from image in images
                    select new ImageDto
                    {
                        Id = image.Id,
                        Value = image.Value,
                        ProductId = image.ProductId
                    });
        }

        public static SubcategoryDto ConverToDto(this Subcategory subcategory)
        {
            return new SubcategoryDto
            {
                Id = subcategory.Id,
                Name = subcategory.Name,
                IconCSS = subcategory.IconCSS,
                CategoryId= subcategory.Category.Id,
                CategoryName = subcategory.Category.Name
            };
        }

        public static TpaProductDto ConvertToDto(this TpaProduct product)
        {
            return new TpaProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Article = product.Article,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Discount= product.Discount,
                //ManufacturerId= product.Manufacturer.Id,
                //ManufacturerName= product.Manufacturer.Name,
                //CategoryId= product.Category.Id,
                //CategoryName = product.Category.Name,
                SubcategoryId = product.Subcategory.Id,
                SubcategoryName= product.Subcategory.Name

            };
        }

        //------------------------------------------------------------------------------------------------------------------------


        public static IEnumerable<CartItemDto> ConvertToDto(this IEnumerable<CartItem> cartItems,
                                                           IEnumerable<TpaProduct> products)
        {
            return (from cartItem in cartItems
                    join product in products
                    on cartItem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        ProductId = cartItem.ProductId,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        ProductImageUrl = product.ImageUrl,
                        Price = product.Price,
                        CartId = cartItem.CartId,
                        Qty = cartItem.Qty,
                        TotalPrice = product.Price * cartItem.Qty
                    }).ToList();
        }

        public static CartItemDto ConvertToDto(this CartItem cartItem,
                                                    TpaProduct product)
        {
            return new CartItemDto
            {
                Id = cartItem.Id,
                ProductId = cartItem.ProductId,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductImageUrl = product.ImageUrl,
                Price = product.Price,
                CartId = cartItem.CartId,
                Qty = cartItem.Qty,
                TotalPrice = product.Price * cartItem.Qty
            };
        }
    }
}
