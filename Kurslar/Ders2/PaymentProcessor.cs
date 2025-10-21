// 1. ABSTRACT CLASS (Abstraction)

public abstract class PaymentProcessor
{
    // abstract property must be derrived bu derived clasees(creditcard class)
    public abstract string Name { get; }

    // virtual method: Provides a default behavior, but can be OVERRIDDEN.
    public virtual bool AuthorizeTransaction(decimal amount)
    {
        Console.WriteLine($"Default Authorization Check: Checking funds for {amount:C}.");
        // Simple default logic: assume authorization passes
        return true;
    }

    //abstract methods :must be implemented by derived classes.
    public abstract void Process(decimal amount);

}

//standart inheritance (polimorphism via override )

public class CreditCardProcessor : PaymentProcessor
{
    //overrride abstract class
    public override string Name => "Credit card";

    //lets override abstract method as well

    public override void Process(decimal amount)
    {
        Console.WriteLine($"Processing {amount:C} via Credit Card (3% fee applied).");
    }

}
//inheretance (controlling polymorphism) with sealed so you can change once no more
public class PremiumCardProcessor : CreditCardProcessor
{
    public override string Name => "Premium Card";
    //here we addded sealed to override it once 
    public sealed override bool AuthorizeTransaction(decimal amount)
    {
        Console.WriteLine("Premium Authorization: Skipping lengthy checks for VIP client.");
        return true;
    }

}
//interface is (The Contract to implement)

public interface ICurrencyConverter
{
    //required property
    decimal ConversionRate { get; }

    //interface method
    decimal ConverToUSD(decimal localAmount)
    {
        //provides a default implementation, which can be overriden but can be skip as it is 
        return Math.Round(localAmount / ConversionRate, 2);
        //what does the final 2 mean iki sonky sana cenly togalayar

    }
}

public class EuroConverter : ICurrencyConverter
{
    //must be implemented interface 
    public decimal ConversionRate => 0.92m;//1 USD =0.92 EUR

}
public static class PaymentRunner
{
   

    public  static void RunExample()
    {
        PaymentProcessor card = new CreditCardProcessor();
        PaymentProcessor premium = new PremiumCardProcessor();
        
        decimal purchaseAmount = 500.00m;

        // Using Polymorphism: The same method call executes different logic.
        card.AuthorizeTransaction(purchaseAmount);    
        premium.AuthorizeTransaction(purchaseAmount); // Uses the sealed override

        // Using a modern switch expression to check the TYPE of the object
        string typeDescription = GetProcessorDescription(premium);
        Console.WriteLine($"\nProcessor Type: {typeDescription}");
    }

    // Switch Expression (Pattern Matching)
    public static string GetProcessorDescription(PaymentProcessor processor) => processor switch
    {
        // Pattern match on the object type
        PremiumCardProcessor => "VIP-level payment processor.",
        CreditCardProcessor => "Standard credit/debit card processor.",
        _ => "Unidentified Processor."
    };
}