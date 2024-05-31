using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using WebApplication1.ResponseModels;

namespace WebApplication1.Services;

public interface IAccountService
{
    Task<GetAccountWithCart> GetAccountWithIdAsync(int id);
    // Task InsertProduct();
}



public class AccountService(DatabaseContext databaseContext) : IAccountService
{
    public async Task<GetAccountWithCart> GetAccountWithIdAsync(int id)
    {
        var result = await databaseContext.Carts.Where(e => e.IdAccount == id)
            .Select(e => new GetAccountWithCart
            {
                FirstNameAccount = e.Account.FirstName,
                SecondNameAccount = e.Account.SecondName,
                EmailAccount = e.Account.Email,
                PhoneAccount = e.Account.Phone,
                RoleAccount = e.Account.Role.Name,
                cart = new GetCart()
                {
                    productId = e.IdProduct,
                    productName = e.Product.Name,
                    amount = e.Amount
                }
                
            }).FirstOrDefaultAsync();

        if (result is null)
        {
            throw new NotFoundException($"Account with id {id} not found");
        }

        return result;
    }

    // public async Task InsertProduct()
    // {
    //     var result = await databaseContext.ProductsCategories.AddAsync(e => new InsertProduct(){})
    //     {
    //         
    //     })
    //
    //     
    // }
}