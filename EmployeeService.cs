using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BirthdayReminder
{
    public class EmployeeService
    {
        private readonly IEnumerable<Employee> _employees;

        public EmployeeService()
        {
            _employees = new []
            {
                new Employee(1, "Chris", new DateTime(1997,4,23), "escalonchristopher@gmail.com")
            };
        }

        public IEnumerable<Employee> FindBirthdays()
        {
            return _employees.Where(employee => employee.Birthday.Date == DateTime.Now.Date);
        }

        public async Task SendEmails(List<Employee> employeesBirthdays)
        {
            var recipients = employeesBirthdays.Select(e => new EmailAddress(e.Email, e.Name)).ToList();
            var employeeNames = employeesBirthdays.Select(e => e.Name).ToList();
            
            
            var apiKey = Environment.GetEnvironmentVariable("EmailSenderKey");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("escalonchristopher@gmail.com", "Chris Coder");
            var subject = "Feliz cumpleaños";
            var plainTextContent = $"Feliz cumpleaños a {string.Join(", ", employeeNames)}";
            var htmlContent = "<strong>Feliz Cumpleaños</strong>";
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, recipients, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}