using System.Net.Mail;
using Nasher.Prep.Application.Data;
using Nasher.Prep.Application.Models;

namespace Nasher.Prep.Application.Srp;

/// <summary>
/// Bad implementation of SRP.
/// </summary>
public class BadEmployeeService
{
    public async Task RegisterEmployee(Employee employee)
    {
        // Does multiple actions on unrelated entities
        EmployeeData.Employees.Add(employee);
        await SendEmailAsync(employee.Email, "Registered!", "Thanks for registering");
    }

    private async Task SendEmailAsync(string email, string subject, string message)
    {
        using var client = new SmtpClient();
        await client.SendMailAsync(new MailMessage("bad-ju-ju@gmail.com", email, subject, message));
    }
}