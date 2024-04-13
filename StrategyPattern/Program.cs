using System.Reflection.Metadata.Ecma335;

namespace StrategyPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Strategy Pattern!");
        var CustomerAccountService = new CustomerAccountService(new RegularCustomerAccountCreationStrategy(), new PremiumCustomerAccountCreationStrategy());

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
    private readonly ICustomerAccountCreationStrategy<RegularCustomerAccount, Customer> _regularCustomerCreationStrategy;
    private readonly ICustomerAccountCreationStrategy<PremiumCustomerAccount, Customer> _premiumCustomerCreationStrategy;

    public CustomerAccountService(ICustomerAccountCreationStrategy<RegularCustomerAccount, Customer> regularCustomerCreationStrategy, ICustomerAccountCreationStrategy<PremiumCustomerAccount, Customer> premiumCustomerCreationStrategy)
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

        // here we are checking if the customer is valid or not
        if (!IsCustomerValid(customer))
        {
            throw new InvalidOperationException("Invalid customer details");
        }

        // here we are implementing the strategy pattern to create customer account
        // based on the customer type

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

public interface ICustomerAccountCreationStrategy<T,C>
{
    T CreateCustomerAccount(C customer, CustomerType customerType);
}

//TODO: Move to separate class and implement the logic for regular customer creation
public class RegularCustomerAccountCreationStrategy : ICustomerAccountCreationStrategy<RegularCustomerAccount, Customer>
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

public class PremiumCustomerAccountCreationStrategy : ICustomerAccountCreationStrategy<PremiumCustomerAccount, Customer>
{
    public PremiumCustomerAccount CreateCustomerAccount(Customer customer, CustomerType customerType)
    {

        if(customerType == CustomerType.Premium)
        {
            // Premium customer creation logic
            //Focus Unit Testing here
            var customerAccount = new PremiumCustomerAccount();
            customerAccount = customerAccount.PremiumCustomerAccountFactory(customer);

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

    public PremiumCustomerAccount PremiumCustomerAccountFactory(Customer customer)
    {


        if(!IsCustomerValid(customer))
        {
            throw new InvalidOperationException("Invalid customer details");
        }
        // TODO: Implement the logic for creating premium customer account
        //       like does customer already exist, is customer valid, etc.
        var rewards = new Rewards{
            Points = 0,
            Description = "Premium Customer Rewards",
            ExpiryDate = DateTime.Now.AddYears(1),
            IsActive = true
        };

        return new PremiumCustomerAccount{

            Customer = customer,
            IsActive = true,
            CreatedDate = DateTime.Now,
            DiscountType = DiscountType.Percentage,
            Rewards = rewards

        };
    }

    public bool IsCustomerValid(Customer customer)
    {
        return !string.IsNullOrEmpty(customer.FirstName) && !string.IsNullOrEmpty(customer.LastName) && !string.IsNullOrEmpty(customer.Email) && !string.IsNullOrEmpty(customer.Phone);
    }

}

//TODO: Move to separate class and implement the logic

public class Rewards
{
    public int Points { get; set; }
    public string? Description { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsExpired { get; set; }
    public bool IsRedeemed { get; set; }
    public bool IsCancelled { get; set; }
    public bool IsSuspended { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsUpdated { get; set; }
    public bool IsCreated { get; set; }
    public bool IsSaved { get; set; }
    public bool IsLoaded { get; set; }
    public bool IsUnloaded { get; set; }
    public bool IsDisposed { get; set; }
    public bool IsInitialized { get; set; }
    public bool IsFinalized { get; set; }
    public bool IsStarted { get; set; }
    public bool IsStopped { get; set; }
    public bool IsPaused { get; set; }
    public bool IsResumed { get; set; }
    public bool IsCompleted { get; set; }
    public bool IsFailed { get; set; }
    public bool IsSucceeded { get; set; }

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