# Strategy Pattern 

The Strategy Pattern is a behavioral design pattern that enables selecting an algorithm at runtime. Instead of implementing a single algorithm directly, code receives run-time instructions as to which in a family of algorithms to use.
- In this project, the Strategy Pattern is used to create different types of customer accounts. The `ICustomerAccountCreationStrategy<T, C>` interface defines a common method for creating a customer account.
- This setup allows the behavior of the context class to change at runtime based on the strategy used, and it makes it easy to add new types of customers in the future without modifying the context class.
- The Strategy Pattern promotes open/closed principle, making the code more flexible and easier to extend, maintain, and test.



Strategy Pattern implementation pracitce this example isn't perfect by no means but an example of way to use a strategy.  I welcome your feedback

## Two Strategies in the example:
- Regular Customer Account Creation
    - Implements the business rules and invariants for Regular account creation 
- Premium Customer Account Creation
    -  Implements the business rules and invariants for Regular account creation.
    -  This customer account type is more complex and has more business rules to enforce.
    -  Has a Reward class that has all the business rules for rewards.

Let's take a look at these two strategies we wil start out with the Regular account type.

### Regular Customer Account Creation Strategy:
- The `RegularCustomerAccountCreationStrategy` class is a concrete strategy in the Strategy Pattern. It implements the `ICustomerAccountCreationStrategy<RegularCustomerAccount, Customer>` interface, which defines a common method for creating a customer account.
- The `CreateCustomerAccount` method takes a `Customer` object and a `CustomerType` enum as parameters. It checks if the `CustomerType` is `Regular`, and if so, it creates a `RegularCustomerAccount`.
- The `RegularCustomerAccount` is created with the `Customer` object passed in, `IsActive` set to `true`, `CreatedDate` set to the current date and time, and `DiscountType` set to `None`.

### The interface that defines the contract:
We are using a generic implementation of the Interface with will support two types `T` is for the target type and `C` is for the Customer in this scenario. 

```CSharp

public interface ICustomerAccountCreationStrategy<T, C>
{
    T CreateCustomerAccount(C customer, CustomerType customerType);
}


```

### Example code for Regualar Account Creation Strategy:

Here is where we implement the interface for a concrete type of RegularCustomerAccountCreationStrategy which implements the contracts `CreateCustomerAccount` Method.


```CSharp


//implement the logic for regular customer creation
public class RegularCustomerAccountCreationStrategy : ICustomerAccountCreationStrategy<RegularCustomerAccount, Customer>
{
    public RegularCustomerAccount CreateCustomerAccount(Customer customer, CustomerType customerType)
    {

        if (customerType == CustomerType.Regular)
        {

            // Regular customer creation logic
            var customerAccount = new RegularCustomerAccount();
            customerAccount = customerAccount.RegularCustomerAccountFactory(customer);
            return customerAccount;
        }
        else
        {
            throw new InvalidOperationException("Invalid customer type");

        }
    }
}

```


### Premium Customer Account Creation Strategy

- The `PremiumCustomerAccountCreationStrategy`, implements the same `ICustomerAccountCreationStrategy<PremiomCustomerAccount, Customer>` interface but provide different implementations of the `CreateCustomerAccount` method.
- These classes would encapsulate the behaviors for creating a premium customer accounts.
- The `CreateCustomerAccount` method takes a `Customer` object and a `CustomerType` enum as parameters. It checks if the `CustomerType` is `Premium`, and if so, it creates a `PremiumCustomerAccount`.
- The `PremiumCustomerAccountCreationStrategy` is created with the `Customer` object passed in, `IsActive` set to `true`, `CreatedDate` set to the current date and time, and `DiscountType` set to `Percentage`.

### Example Code for Premium Account Creation Strategy:
```Csharp

//implement the logic for premium customer creation
public class PremiumCustomerAccountCreationStrategy : ICustomerAccountCreationStrategy<PremiumCustomerAccount, Customer>
{
    public PremiumCustomerAccount CreateCustomerAccount(Customer customer, CustomerType customerType)
    {

        if (customerType == CustomerType.Premium)
        {
            // Premium customer creation logic
            //Focus Unit Testing here
            var customerAccount = new PremiumCustomerAccount();
            customerAccount = customerAccount.PremiumCustomerAccountFactory(customer);

            return customerAccount;
        }
        else
        {
            throw new InvalidOperationException("Invalid customer type");
        }

    }
}



```

