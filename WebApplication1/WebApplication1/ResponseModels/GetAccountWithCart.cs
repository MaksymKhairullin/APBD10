using WebApplication1.Models;

namespace WebApplication1.ResponseModels;

public class GetAccountWithCart
{
    public string FirstNameAccount { get; set; }
    public string SecondNameAccount { get; set; }
    public string EmailAccount { get; set; }
    public string PhoneAccount { get; set; }
    public string RoleAccount { get; set; }

    public GetCart cart { get; set; }
}

public class GetCart
{
    public int productId { get; set; }
    public string productName { get; set; }
    public int amount { get; set; }
}