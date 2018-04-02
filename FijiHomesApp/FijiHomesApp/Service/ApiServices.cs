using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using FijiHomesApp.Model;

namespace FijiHomesApp.Service
{
    public class ApiServices
    {
        public async Task<bool> RegisterAsync(string email, string password, string confirmPassword, string firstname, string lastname, string gender, string street, string city,int phonenum, DateTime birthdate)
        {
            var client = new HttpClient();
            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword,
                FirstName = firstname,
                LastName = lastname,
                Gender = gender,
                Street = street,
                Çity = city,
                PhoneNum = phonenum,
                BirthDate = birthdate


            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://localhost:54874/Account/Register", content);

            return response.IsSuccessStatusCode;

        }
    }
}
