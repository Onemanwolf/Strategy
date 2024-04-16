using System.Reflection.Metadata.Ecma335;

namespace StrategyPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Strategy Pattern!");



        var templateService = new TemplateService(new StandardTemplateCreationStrategy(), new CustomeTemplateCreationStrategy());
        var listNewTemplates = new List<Template>
        { new Template
        {
            Name = "1099 Form",
            Description = "1099 Form for the year 2023",
            FilePath = "./file.pdf",
            Data = "EntityId",
            TemplateType = TemplateType.Standard

            },
          new Template
            {
                Name = "1099 Form",
            Description = "1099 Form for the year 2023",
            FilePath = "./file.pdf",
            Data = "EntityId",
            TemplateType = TemplateType.Custom
                }
        };
        foreach (var customer in listNewTemplates)

            templateService.CreateTemplate(customer);
    }
}

//TODO: Move to separate class and implement the logic for customer account service
// CustomerAccountService class is responsible for creating customer account based on the customer type
public class TemplateService
{
    private readonly ITemplateCreationStrategy<StandardTemplate, Template> _regularCustomerCreationStrategy;
    private readonly ITemplateCreationStrategy<CustomTemplate, Template> _premiumCustomerCreationStrategy;

    public TemplateService(ITemplateCreationStrategy<StandardTemplate, Template> regularCustomerCreationStrategy, ITemplateCreationStrategy<CustomTemplate, Template> premiumCustomerCreationStrategy)
    {
        _regularCustomerCreationStrategy = regularCustomerCreationStrategy;
        _premiumCustomerCreationStrategy = premiumCustomerCreationStrategy;
    }

    public bool IsCustomerValid(Template template)
    {
        return !string.IsNullOrEmpty(template.Name) && !string.IsNullOrEmpty(template.Description) && !string.IsNullOrEmpty(template.FilePath) && !string.IsNullOrEmpty(template.Data);
    }

    //Given a customer object,
    //When this method creates a customer account based on the customer type
    //Then it should return true
    public bool CreateTemplate(Template template)
    {

        // here we are checking if the customer is valid or not
        if (!IsCustomerValid(template))
        {
            throw new InvalidOperationException("Invalid customer details");
        }

        // here we are implementing the strategy pattern to create customer account
        // based on the customer type

        if (template.TemplateType == TemplateType.Standard)
        {
            CreateRegularCustomerAccount(template);
            Console.WriteLine("Standard Template created successfully");
        }
        else if (template.TemplateType == TemplateType.Custom)
        {
            CreatePremiumCustomerAccount(template);
            Console.WriteLine("Custom Template created successfully");
        }
        else
        {
            throw new InvalidOperationException("Invalid customer type");
        }

        return true;
    }



    public StandardTemplate CreateRegularCustomerAccount(Template customer)
    {
        return _regularCustomerCreationStrategy.CreateFormTemplate(customer, TemplateType.Standard);
    }

    public CustomTemplate CreatePremiumCustomerAccount(Template customer)
    {
        return _premiumCustomerCreationStrategy.CreateFormTemplate(customer, TemplateType.Custom);
    }
}

//TODO: Move to separate interface file

public interface ITemplateCreationStrategy<T, C>
{
    T CreateFormTemplate(C customer, TemplateType customerType);
}

//TODO: Move to separate class and implement the logic for regular customer creation
public class CustomeTemplateCreationStrategy : ITemplateCreationStrategy<CustomTemplate, Template>
{
    public CustomTemplate CreateFormTemplate(Template template, TemplateType templateType)
    {

        if (templateType == TemplateType.Custom)
        {

            // Regular customer creation logic
            var customTemplate = new CustomTemplate();
            customTemplate = customTemplate.CustomTemplateFactory(template);
            return customTemplate;
        }
        else
        {
            throw new InvalidOperationException("Invalid template type");

        }
    }
}
//TODO: Move to separate class and implement the logic for premium customer creation

public class StandardTemplateCreationStrategy : ITemplateCreationStrategy<StandardTemplate, Template>
{
    public StandardTemplate CreateFormTemplate(Template template, TemplateType templateType)
    {

        if (templateType == TemplateType.Standard)
        {
            // Premium customer creation logic
            //Focus Unit Testing here
            var standardTemplate = new StandardTemplate();
            standardTemplate = standardTemplate.StandardTemplateFactory(template);

            return standardTemplate;
        }
        else
        {
            throw new InvalidOperationException("Invalid customer type");
        }

    }
}
//TODO: Move to separate class and implement the logic for validation

public class Template
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? FilePath { get; set; }
    public string? Data { get; set; }
    public TemplateType TemplateType { get; set; }

}

//TODO: Move to separate class and implement the logic
public class StandardTemplate
{
    public Template? Customer { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedDate { get; set; }


    public StandardTemplate StandardTemplateFactory(Template customer)
    {
        if (!IsCustomerValid(customer))
        {
            throw new InvalidOperationException("Invalid customer details");
        }
        // Regular customer creation logic
        return new StandardTemplate
        {
            Customer = customer,
            IsActive = true,
            CreatedDate = DateTime.Now,

        };


    }

    public bool IsCustomerValid(Template template)
    {
        return !string.IsNullOrEmpty(template.Name) && !string.IsNullOrEmpty(template.Description) && !string.IsNullOrEmpty(template.FilePath) && !string.IsNullOrEmpty(template.Data);
    }

}

//TODO: Move to separate class and implement the logic

public class CustomTemplate
{
    public Template? Customer { get; set; }
    public bool IsActive { get; set; }
    public DateTime? CreatedDate { get; set; }


    public CustomTemplate CustomTemplateFactory(Template customer)
    {


        if (!IsCustomerValid(customer))
        {
            throw new InvalidOperationException("Invalid customer details");
        }
        // TODO: Implement the logic for creating premium customer account
        //       like does customer already exist, is customer valid, etc.


        return new CustomTemplate
        {

            Customer = customer,
            IsActive = true,
            CreatedDate = DateTime.Now,


        };
    }

    public bool IsCustomerValid(Template template)
    {
        return !string.IsNullOrEmpty(template.Name) && !string.IsNullOrEmpty(template.Description) && !string.IsNullOrEmpty(template.FilePath) && !string.IsNullOrEmpty(template.Data);
    }

}




//TODO: Move to separate enum file
public enum TemplateType
{
    Custom,
    Standard
}


