using System;

namespace LegacySecurityManager;

public class SecurityManager
{
    public void CreateValidUser()
    {
        Print("Enter a username");
        var username = ReadUserInput();
        Print("Enter your full name");
        var fullName = ReadUserInput();
        Print("Enter your password");
        var password = ReadUserInput();
        Print("Re-enter your password");
        var confirmPassword = ReadUserInput();

        if (password != confirmPassword)
        {
            Print("The passwords don't match");
            return;
        }

        if (password.Length < 8)
        {
            Print("Password must be at least 8 characters in length");
            return;
        }

        // Encrypt the password (just reverse it, should be secure)
        char[] array = password.ToCharArray();
        Array.Reverse(array);

        Print($"Saving Details for User ({username}, {fullName}, {new string(array)})\n");
    }

    protected virtual void Print(string message)
    {
        Console.WriteLine(message);
    }

    protected virtual string ReadUserInput()
    {
        return Console.ReadLine();
    }

    public static void CreateUser()
    {
        new SecurityManager().CreateValidUser();
    }
}