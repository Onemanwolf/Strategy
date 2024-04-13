# Strategy Pattern 

Strategy Pattern implementation pracitce ths not perfect by no means but an example of way to use a strategy I welcome your feedback

## Two Strategies in the example:

### Regular Customer Account Creation
- The `RegularCustomerAccountCreationStrategy` class is a concrete strategy in the Strategy Pattern. It implements the `ICustomerAccountCreationStrategy<RegularCustomerAccount, Customer>` interface, which defines a common method for creating a customer account.
- The `CreateCustomerAccount` method takes a `Customer` object and a `CustomerType` enum as parameters. It checks if the `CustomerType` is `Regular`, and if so, it creates a `RegularCustomerAccount`.
- The `RegularCustomerAccount` is created with the `Customer` object passed in, `IsActive` set to `true`, `CreatedDate` set to the current date and time, and `DiscountType` set to `None`.
-
### Premium Customer Account Creation

- The `PremiumCustomerAccountCreationStrategy`, implements the same `ICustomerAccountCreationStrategy<PremiomCustomerAccount, Customer>` interface but provide different implementations of the `CreateCustomerAccount` method.
- These classes would encapsulate the behavior for creating other types of customer accounts.
- - The `CreateCustomerAccount` method takes a `Customer` object and a `CustomerType` enum as parameters. It checks if the `CustomerType` is `Regular`, and if so, it creates a `PremiumCustomerAccount`.
- The `PremiumCustomerAccountCreationStrategy` is created with the `Customer` object passed in, `IsActive` set to `true`, `CreatedDate` set to the current date and time, and `DiscountType` set to `Percentage`.
- 

