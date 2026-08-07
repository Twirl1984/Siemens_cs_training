public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        return operation switch
        {
            "+" => $"{operand1} + {operand2} = "+(operand1 + operand2).ToString(),
            "-" => $"{operand1} - {operand2} = "+(operand1 - operand2).ToString(),
            "*" => $"{operand1} * {operand2} = "+(operand1 * operand2).ToString(),
            "/" => operand2 == 0 ? "Division by zero is not allowed." : $"{operand1} / {operand2} = "+(operand1 / operand2).ToString(),
            null => throw new ArgumentNullException(nameof(operation)),
            "" => throw new ArgumentException("Operation cannot be empty.", nameof(operation)),
            _ => throw new ArgumentOutOfRangeException("Invalid operation")
        };

    }
}
