using System;

public class LoanCalculator
{
    public static double CalculateEMI(double principal, double annualInterestRate, int termYears)
    {
        double monthlyInterestRate = annualInterestRate / 100 / 12;
        int totalPayments = termYears * 12;
        double pow = Math.Pow(1 + monthlyInterestRate, totalPayments);
        return principal * monthlyInterestRate * pow / (pow - 1);
    }

    public static double CalculateTermYears(double principal, double annualInterestRate, double targetMonthlyPayment)
    {
        double monthlyInterestRate = annualInterestRate / 100 / 12;
        int months = 0;
        double balance = principal;

        double minPayment = principal * monthlyInterestRate;
        if (targetMonthlyPayment <= minPayment)
        {
            throw new InvalidOperationException("The monthly payment is not sufficient to cover the interest accrued; it will never amortize the loan.");
        }

        while (balance > 0)
        {
            balance += balance * monthlyInterestRate - targetMonthlyPayment;
            if (balance < 0) break;
            months++;
            if (months > 600)
            {
                throw new InvalidOperationException("Payment plan exceeds practical limits.");
            }
        }
        return Math.Round((double)months / 12, 2);
    }

    public static double CalculatePrincipalForEMI(double targetMonthlyPayment, double annualInterestRate, int termYears)
    {
        double monthlyInterestRate = annualInterestRate / 100 / 12;
        int totalPayments = termYears * 12;
        double pow = Math.Pow(1 + monthlyInterestRate, totalPayments);
        return targetMonthlyPayment * (pow - 1) / (monthlyInterestRate * pow);
    }

    static void Main(string[] args)
    {
        // Task 1 (Basic)
        double loanAmount1 = 95000; // Principal amount
        double annualInterestRate1 = 6.5; // Annual interest rate
        int termYears1 = 5; // Loan term in years
        double emi1 = CalculateEMI(loanAmount1, annualInterestRate1, termYears1);
        Console.WriteLine($"Task 1 (Basic): Monthly Repayment for RM{loanAmount1} over {termYears1} years at {annualInterestRate1}% annual interest rate: RM{emi1:F2}");

        // Task 1 (Advance) - Part 1
        double targetMonthlyPayment2 = 1750; // Target monthly payment
        try
        {
            double termYears2 = CalculateTermYears(loanAmount1, annualInterestRate1, targetMonthlyPayment2);
            Console.WriteLine($"Task 1 (Advance) - Part 1: Loan term needed to pay RM{targetMonthlyPayment2} per month: {termYears2:F2} years");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Task 1 (Advance) - Part 2
        double targetMonthlyPayment3 = 750; // Target monthly payment
        int termYears3 = 20; // Loan term in years
        double loanAmount3 = CalculatePrincipalForEMI(targetMonthlyPayment3, annualInterestRate1, termYears3);
        Console.WriteLine($"Task 1 (Advance) - Part 2: Loan amount for monthly payment of RM{targetMonthlyPayment3} over {termYears3} years at {annualInterestRate1}% annual interest rate: RM{loanAmount3:F2}");
    }
}
