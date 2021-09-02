using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AdminDashboard.Wasm.Models;
using AdminDashboard.Wasm.Models.BusinessPartner;
using AdminDashboard.Wasm.Models.Contract;
using AdminDashboard.Wasm.Models.Employee;
using AdminDashboard.Wasm.Models.User;
using AdminDashboard.Wasm.Services;

namespace AdminDashboard.Wasm.Helpers
{
    public class FakeBackendHandler : HttpClientHandler
    {
        private readonly ILocalStorageService _localStorageService;

        public FakeBackendHandler(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // array in local storage for registered users
            var usersKey = "blazor-registration-login-example-users";
            var users = await _localStorageService.GetItem<List<UserRecord>>(usersKey) ?? new List<UserRecord>();
            var method = request.Method;
            var path = request.RequestUri.AbsolutePath;

            return await handleRoute();

            async Task<HttpResponseMessage> handleRoute()
            {
                if (path == "/users/authenticate" && method == HttpMethod.Post)
                    return await authenticate();
                if (path == "/users/register" && method == HttpMethod.Post)
                    return await register();
                if (path == "/users" && method == HttpMethod.Get)
                    return await getUsers();
                if (Regex.Match(path, @"\/users\/\d+$").Success && method == HttpMethod.Get)
                    return await getUserById();
                if (Regex.Match(path, @"\/users\/\d+$").Success && method == HttpMethod.Put)
                    return await updateUser();
                if (Regex.Match(path, @"\/users\/\d+$").Success && method == HttpMethod.Delete)
                    return await deleteUser();
                if (path == "/sample-data/contractsListing.json")
                    return await getContracts();
                if (path == "/sample-data/contracts.json")
                    return await getContractByAddress();
                if (path == "/companies/index")
                    return await getCompanies();
                if (path == "/employees/index")
                    return await getEmployees();

                try
                {
                    return await base.SendAsync(request, cancellationToken);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            // route functions
            async Task<HttpResponseMessage> getEmployees()
            {
                var employees = new List<EmployeeDetails>
                {
                    new EmployeeDetails
                    {
                        Id = 1,
                        Name = "Aris",
                        Surname = "Fanaras",
                        //DateOfBirth = "27/07/1987",
                        Email = "arisfan87@gmail.com",
                        Nationality = "Greek",
                        //PlaceOfWork = "Greece",
                        WalletAddress = "0x45316062B2347889F19A01765f0e7af05ED34e8f"
                    },
                    new EmployeeDetails
                    {
                        Id = 2,
                        Name = "Panagiotis",
                        Surname = "Mavrothallasiti",
                        //DateOfBirth = "01/01/1990",
                        Email = "panamavro@gmail.com",
                        Nationality = "Greek",
                        //PlaceOfWork = "UK",
                        WalletAddress = "0x45316062B2347889F19A01765f0e7af05ED34a3c"
                    }
                };

                return await ok(employees);
            }

            async Task<HttpResponseMessage> getCompanies()
            {
                var companies = new List<BusinessPartnerDetails>
                {
                    new BusinessPartnerDetails
                    {
                        Id = 1,
                        Name = "Sonovate",
                        Address = "Cardiff",
                        Email = "sono@sono.co.uk",
                        WalletAddress = "0x3hi12h3i1u3h1i2u3b313vg1v2",
                        ContactNumber = "+4413231231"
                    },
                    new BusinessPartnerDetails
                    {
                        Id = 2,
                        Name = "Just Eat",
                        Address = "Bristol",
                        Email = "justeat@je.co.uk",
                        WalletAddress = "0x3hi12h3i1u3h1i2u333f3fg3f3fg3",
                        ContactNumber = "+4482872762"
                    }
                };

                return await ok(companies);
            }

            async Task<HttpResponseMessage> getContractByAddress()
            {
                var contracts = new List<Contract>
                {
                    new Contract
                    {
                        EmployeeId = 1,
                        EmployeeName = "Aris",
                        EmployeeSurname = "Fanaras",
                        Address = "0x9646fc6ee1b3bf193ca2bcd0d167e0aa2c6244b0",
                        Email = "arisfan87@gmail.com",
                        CountryOfResidence = "Greece",
                        PhoneNumber = "313213123",
                        EmployeeWalletAddress = "0xCF6999A79411D4Ed73aA0cCa43fE2982cFA68e65",
                        CompanyWalletAddress = "0x45316062B2347659F19A01765f0e7af05ED34a3d",
                        ContractDetails = new ContractDetails
                        {
                            ContractExpiry2 = "2025-01-01T17:16:40",
                            GrossSalary = "60.000",
                            RemoteLocation = "Greece",
                            PaymentInstallments = 10,
                            PaymentTerm = "Term 1",
                            BalanceUnit = "USD_TETHER"
                        }
                    },
                    new Contract
                    {
                        EmployeeId = 2,
                        EmployeeName = "Panagiotis",
                        EmployeeSurname = "Mavrothallasitis",
                        Address = "0x45316062B2347889F19A01765f0e7af05ED34a3c",
                        Email = "panamavro@hotmail.com",
                        CountryOfResidence = "UK",
                        EmployeeWalletAddress = "0x45316062B123659F19A01765f0e7af05ED34a3f",
                        CompanyWalletAddress = "0x45316062B3217659F19A01765f0e7af05ED34a3f",
                        PhoneNumber = "13123123",
                        ContractDetails = new ContractDetails
                        {
                            ContractExpiry2 = "2022-01-01T17:16:40",
                            GrossSalary = "10.000",
                            RemoteLocation = "UK",
                            PaymentInstallments = 10,
                            PaymentTerm = "Term 1",
                            BalanceUnit = "USD_TETHER"
                        }
                    }
                };

                return await ok(contracts);
            }

            ;

            async Task<HttpResponseMessage> getContracts()
            {
                var contracts = new List<Contract>
                {
                    new Contract
                    {
                        EmployeeId = 1,
                        EmployeeName = "Aris",
                        EmployeeSurname = "Fanaras",
                        Address = "0x9646fc6ee1b3bf193ca2bcd0d167e0aa2c6244b0",
                        CountryOfResidence = "Greece",
                        Email = "arisfan87@gmail.com",
                        RemainingBalance = 1200
                    },
                    new Contract
                    {
                        EmployeeId = 2,
                        EmployeeName = "Panagiotis",
                        EmployeeSurname = "Mavro",
                        Address = "0x45316062B2347889F19A01765f0e7af05ED34a3c",
                        CountryOfResidence = "UK",
                        Email = "panamavr@gmail.com",
                        RemainingBalance = 10
                    }
                };

                return await ok(contracts);
            }

            async Task<HttpResponseMessage> authenticate()
            {
                var bodyJson = await request.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions();
                options.Converters.Add(new JsonStringEnumConverter());

                var body = JsonSerializer.Deserialize<Login>(bodyJson, options);
                var user = users.FirstOrDefault(x => x.Username == body.Username && x.Password == body.Password);

                if (user == null)
                    return await error("Username or password is incorrect");

                return await ok(
                    new
                    {
                        Id = user.Id.ToString(),
                        Username = user.Username,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Token = "fake-jwt-token",
                        Role = user.Role
                    });
            }

            async Task<HttpResponseMessage> register()
            {
                var bodyJson = await request.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions();
                options.Converters.Add(new JsonStringEnumConverter());

                var body = JsonSerializer.Deserialize<AddUser>(bodyJson, options);

                if (users.Any(x => x.Username == body.Username))
                    return await error($"Username '{body.Username}' is already taken");

                var user = new UserRecord
                {
                    Id = users.Count > 0 ? users.Max(x => x.Id) + 1 : 1,
                    Username = body.Username,
                    Password = body.Password,
                    FirstName = body.FirstName,
                    LastName = body.LastName,
                    Role = users.Count < 1 ? Role.SuperAdmin : Role.Partner
                };

                users.Add(user);

                await _localStorageService.SetItem(usersKey, users);

                return await ok();
            }

            async Task<HttpResponseMessage> getUsers()
            {
                if (!isLoggedIn()) return await unauthorized();
                return await ok(users.Select(x => basicDetails(x)));
            }

            async Task<HttpResponseMessage> getUserById()
            {
                if (!isLoggedIn()) return await unauthorized();

                var user = users.FirstOrDefault(x => x.Id == idFromPath());
                return await ok(basicDetails(user));
            }

            async Task<HttpResponseMessage> updateUser()
            {
                if (!isLoggedIn()) return await unauthorized();

                var bodyJson = await request.Content.ReadAsStringAsync();
                var body = JsonSerializer.Deserialize<EditUser>(bodyJson);
                var user = users.FirstOrDefault(x => x.Id == idFromPath());

                // if username changed check it isn't already taken
                if (user.Username != body.Username && users.Any(x => x.Username == body.Username))
                    return await error($"Username '{body.Username}' is already taken");

                // only update password if entered
                if (!string.IsNullOrWhiteSpace(body.Password))
                    user.Password = body.Password;

                // update and save user
                user.Username = body.Username;
                user.FirstName = body.FirstName;
                user.LastName = body.LastName;
                await _localStorageService.SetItem(usersKey, users);

                return await ok();
            }

            async Task<HttpResponseMessage> deleteUser()
            {
                if (!isLoggedIn()) return await unauthorized();

                users.RemoveAll(x => x.Id == idFromPath());
                await _localStorageService.SetItem(usersKey, users);

                return await ok();
            }

            // helper functions

            async Task<HttpResponseMessage> ok(object body = null)
            {
                return await jsonResponse(HttpStatusCode.OK, body ?? new { });
            }

            async Task<HttpResponseMessage> error(string message)
            {
                return await jsonResponse(HttpStatusCode.BadRequest, new { message });
            }

            async Task<HttpResponseMessage> unauthorized()
            {
                return await jsonResponse(HttpStatusCode.Unauthorized, new { message = "Unauthorized" });
            }

            async Task<HttpResponseMessage> jsonResponse(HttpStatusCode statusCode, object content)
            {
                var response = new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json")
                };

                // delay to simulate real api call
                //await Task.Delay(200);

                return response;
            }

            bool isLoggedIn()
            {
                return request.Headers.Authorization?.Parameter == "fake-jwt-token";
            }

            int idFromPath()
            {
                return int.Parse(path.Split('/').Last());
            }

            dynamic basicDetails(UserRecord user)
            {
                return new
                {
                    Id = user.Id.ToString(),
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
            }
        }
    }

    // class for user records stored by fake backend
    public class UserRecord
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Role Role { get; set; }
    }

    public enum Role
    {
        SuperAdmin,
        Partner,
        User
    }
}