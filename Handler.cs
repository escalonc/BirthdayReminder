using System.Linq;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace BirthdayReminder
{
    public class Handler
    {
       public async Task Reminder()
       {
           var employeeService = new EmployeeService();
           var employeesBirthdays = employeeService.FindBirthdays();
           await employeeService.SendEmails(employeesBirthdays.ToList());
       }
    }

    public class Response
    {
      public string Message {get; set;}

      public Response(string message){
        Message = message;
      }
    }
}
