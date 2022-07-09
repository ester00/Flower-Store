// See https://aka.ms/new-console-template for more information
using ApplicationService.DTOs;
using WcfService;

UserService service = new UserService();
Console.WriteLine(service.Login(new UserLoginDTO() { UserName = "ester", Password = "asd" }));