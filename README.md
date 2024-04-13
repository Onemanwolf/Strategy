# Strategy Pattern 

Strategy Pattern implementation pracitce this example isn't perfect by no means but an example of way to use a strategy.  I welcome your feedback

## Two Strategies in the example:

### Regular Customer Account Creation Strategy:
- The `RegularCustomerAccountCreationStrategy` class is a concrete strategy in the Strategy Pattern. It implements the `ICustomerAccountCreationStrategy<RegularCustomerAccount, Customer>` interface, which defines a common method for creating a customer account.
- The `CreateCustomerAccount` method takes a `Customer` object and a `CustomerType` enum as parameters. It checks if the `CustomerType` is `Regular`, and if so, it creates a `RegularCustomerAccount`.
- The `RegularCustomerAccount` is created with the `Customer` object passed in, `IsActive` set to `true`, `CreatedDate` set to the current date and time, and `DiscountType` set to `None`.

## Strategy Code Examples:


### The interface that defines the contract:
We are using a generic implementation of the Interface with will support two types `T` is for the target type and `C` is for the Customer in this scenario. 

```CSharp

public interface ICustomerAccountCreationStrategy<T, C>
{
    T CreateCustomerAccount(C customer, CustomerType customerType);
}


```

### Example code for Regualar Account Creationn Strategy:

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


### Premium Customer Account Creation

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

