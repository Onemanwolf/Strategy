using System.Reflection.Metadata.Ecma335;

namespace StrategyPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Strategy Pattern!");
        var CustomerAccountService = new CustomerAccountService(new RegularCustomerCreationStrategy(), new PremiumCustomerCreationStrategy());

        var customer = new Customer
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "John.Doe@gmail.com",
            Phone = "1234567890",
            CustomerType = CustomerType.Premium
            };

            CustomerAccountService.CreateCustomerAccount(customer);
    }
}

//TODO: Move to separate class and implement the logic for customer account service
// CustomerAccountService class is responsible for creating customer account based on the customer type
public class CustomerAccountService
{
    private readonly ICustomerCreationStrategy<RegularCustomerAccount, Customer> _regularCustomerCreationStrategy;
    private readonly ICustomerCreationStrategy<PremiumCustomerAccount, Customer> _premiumCustomerCreationStrategy;

    public CustomerAccountService(ICustomerCreationStrategy<RegularCustomerAccount, Customer> regularCustomerCreationStrategy, ICustomerCreationStrategy<PremiumCustomerAccount, Customer> premiumCustomerCreationStrategy)
    {
        _regularCustomerCreationStrategy = regularCustomerCreationStrategy;
        _premiumCustomerCreationStrategy = premiumCustomerCreationStrategy;
    }

    public bool IsCustomerValid(Customer customer)
    {
        return !string.IsNullOrEmpty(customer.FirstName) && !string.IsNullOrEmpty(customer.LastName) && !string.IsNullOrEmpty(customer.Email) && !string.IsNullOrEmpty(customer.Phone);
    }

    //Given a customer object,
    //When this method creates a customer account based on the customer type
    //Then it should return true
    public bool CreateCustomerAccount(Customer customer)
    {
        if (!IsCustomerValid(customer))
        {
            throw new InvalidOperationException("Invalid customer details");
        }

        if (customer.CustomerType == CustomerType.Regular)
        {
            CreateRegularCustomerAccount(customer);
            Console.WriteLine("Regular customer account created successfully");
        }
        else if (customer.CustomerType == CustomerType.Premium)
        {
            CreatePremiumCustomerAccount(customer);
            Console.WriteLine("Premium customer account created successfully");
        }
        else
        {
            throw new InvalidOperationException("Invalid customer type");
        }

        return true;
    }



    public RegularCustomerAccount CreateRegularCustomerAccount(Customer customer)
    {
        return _regularCustomerCreationStrategy.CreateCustomerAccount(customer, CustomerType.Regular);
    }

    public PremiumCustomerAccount CreatePremiumCustomerAccount(Customer customer)
    {
        return _premiumCustomerCreationStrategy.CreateCustomerAccount(customer, CustomerType.Premium);
    }
}

//TODO: Move to separate interface file

public interface ICustomerCreationStrategy<T,C>
{
    T CreateCustomerAccount(C customer, CustomerType customerType);
}

//TODO: Move to separate class and implement the logic for regular customer creation
public class RegularCustomerCreationStrategy : ICustomerCreationStrategy<RegularCustomerAccount, Customer>
{
    public RegularCustomerAccount CreateCustomerAccount(Customer customer, CustomerType customerType)
    {

        if(customerType == CustomerType.Regular)
        {

        // Regular customer creation logic
        var customerAccount = new RegularCustomerAccount
        {
            Customer = customer,
            IsActive = true,
            CreatedDate = DateTime.Now,
            DiscountType = DiscountType.None,

        };

        return customerAccount;
        }
        else
        {
            throw new InvalidOperationException("Invalid customer type");

        }
    }
}
//TODO: Move to separate class and implement the logic for premium customer creation

public class PremiumCustomerCreationStrategy : ICustomerCreationStrategy<PremiumCustomerAccount, Customer>
{
    public PremiumCustomerAccount CreateCustomerAccount(Customer customer, CustomerType customerType)
    {

        if(customerType == CustomerType.Premium)
        {
        // Premium customer creation logic
        var customerAccount = new PremiumCustomerAccount
        {
            Customer = customer,
            IsActive = true,
            CreatedDate = DateTime.Now,
            DiscountType = DiscountType.Percentage,
            Rewards = new Rewards()
        };

             return customerAccount;
        }else
        {
            throw new InvalidOperationException("Invalid customer type");
        }

    }
}
//TODO: Move to separate class and implement the logic for validation

public class Customer
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public CustomerType CustomerType { get; set; }

}

//TODO: Move to separate class and implement the logic
public class RegularCustomerAccount
{
    public Customer? Customer { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DiscountType DiscountType { get; set; }

}

//TODO: Move to separate class and implement the logic

public class PremiumCustomerAccount
{
    public Customer? Customer { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DiscountType DiscountType { get; set; }

    public Rewards? Rewards { get; set; }

}

//TODO: Move to separate class and implement the logic

public class Rewards
{
}
//TODO: Move to separate enum file
public enum CustomerType
{
    Regular,
    Premium
}
//TODO: Move to separate enum file

public enum DiscountType
{
    None,
    Percentage,
    FixedAmount
}