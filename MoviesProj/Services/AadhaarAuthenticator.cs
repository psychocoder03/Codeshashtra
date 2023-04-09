using MongoDB.Bson.IO;
using MongoDB.Bson;
using MongoDB.Driver;
using MoviesProj.Models;
using System.Text;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;


namespace MoviesProj.Services
{
    public class AadhaarAuthenticator : IAadhaarAuthenticator
    {
        //private readonly HttpClient _httpClient;
        private readonly IMongoCollection<Aadhaar> _aadhaar;
        private readonly IMongoCollection<ResponseData> _actual;
        private readonly IMongoCollection<LastAadhaar> _last;

        public AadhaarAuthenticator(IMovieDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _actual = database.GetCollection<ResponseData>(settings.ActualCollectionName);
            _aadhaar = database.GetCollection<Aadhaar>(settings.AadhaarCollectionName);
            _last = database.GetCollection<LastAadhaar>(settings.LastAadhaarCollectionName);
        }

        public async Task CallExternalApiAndInsertDocumentAsync(string secretKey, string clientId, string aadhaarNumber,string email)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("secretKey", secretKey);
            client.DefaultRequestHeaders.Add("clientId", clientId);

            var data = new
            {
                aadhaarNumber
            };

            var response = await client.PostAsync("https://api.emptra.com/aadhaarVerification/requestOtp", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);

            var model = Newtonsoft.Json.JsonConvert.DeserializeObject<Aadhaar>(responseContent);
            Console.WriteLine(model.Result.Data.Client_Id);
            LastAadhaar last = await _last.Find(last => last.Id == "6432044b7eb5162865e8b661").FirstOrDefaultAsync();
            last.ClientId = model.Result.Data.Client_Id;
            last.Aadhaar = aadhaarNumber;
            _last.ReplaceOne(last => last.Id == "6432044b7eb5162865e8b661", last);
            Console.WriteLine(model.Result.Data.OtpSent);
            Console.WriteLine(model.Result.Data.IfNumber);
            // Insert document into MongoDB collection
            var aadhaar = new Aadhaar
            {
                Email = email,
                Code = model.Code,
                Result = new Result
                {
                    Data = new Data
                    {
                        Client_Id = model.Result.Data.Client_Id,
                        OtpSent = model.Result.Data.OtpSent,
                        IfNumber = model.Result.Data.IfNumber,
                        ValidAadhaar = model.Result.Data.ValidAadhaar,
                        Status = model.Result.Data.Status
                    },
                    StatusCode = model.Result.StatusCode,
                    MessageCode = model.Result.MessageCode,
                    Message = model.Result.Message,
                    Success = model.Result.Success
                }
            };
            await _aadhaar.InsertOneAsync(aadhaar);
        }

        //private async Task AadhaarClientValue()
        //{            
        //    { "_id":{ "$oid":"6432044b7eb5162865e8b661"},"aadhaar":"123456789123"}

        //}
        //aadhaar_v2_hktfNxeRude32GwNRzoqnc
        public async Task SubmitOtpAsync(string secretKey, string clientId,string otp,string email)
        {

            LastAadhaar last = await _last.Find(last => last.Id == "6432044b7eb5162865e8b661").FirstOrDefaultAsync();
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("secretKey", secretKey);
            client.DefaultRequestHeaders.Add("clientId", clientId);

            var content = new StringContent(
                $@"{{
                    ""client_id"": ""{last.ClientId}"",
                    ""otp"": ""{otp}""
                }}",
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync("https://api.emptra.com/aadhaarVerification/submitOtp", content);


            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response content into a ResponseData object
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
                var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseData>(responseContent);
                responseData.Email = email;
                // Insert the responseData into the collection
                await _actual.InsertOneAsync(responseData);
            }
        }
    }

}



//public async Task<Employee> Get(string email)
//{

//    return await _employee.Find(employee => employee.EmployeeEmail == email).FirstOrDefaultAsync();
//}
//public async Task<List<Employee>> GetEmployee(string email)
//{

//    return await _employee.Find(employee => employee.Email == email).ToListAsync();
//}
//public async Task<Employee> Create(Employee employee)
//{
//    await _employee.InsertOneAsync(employee);
//    return employee;
//}
//public async Task Delete(string email)
//{
//    await _employee.DeleteOneAsync(employee => employee.EmployeeEmail == email);
//}
//public async Task<Employee> Update(Employee employee)
//{
//    Employee existingEmployee = await Get(employee.EmployeeEmail);
//    employee.Id = existingEmployee.Id;
//    _employee.ReplaceOne(employee => employee.EmployeeEmail == existingEmployee.EmployeeEmail, employee);
//    return await _employee.Find(sp => sp.EmployeeEmail == employee.EmployeeEmail).FirstOrDefaultAsync();
//}
