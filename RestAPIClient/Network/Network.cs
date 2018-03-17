using Newtonsoft.Json;
using RestAPIClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIClient.Network
{
    static class Network
    {
        public static async Task<ObservableCollection<User>> Get(String url)
        {
            HttpClient client = new HttpClient();


            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = await client.GetAsync(new Uri(url));
            if (response.IsSuccessStatusCode)
            {
                String json = await response.Content.ReadAsStringAsync();
                try
                {
                    var result = JsonConvert.DeserializeObject<User>(json);
                    var collection = new ObservableCollection<User>();
                    collection.Add(result);
                    return collection;
                }catch(Exception e) { }
                try
                {
                    return JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
                }catch(Exception e) { }
                return new ObservableCollection<User>();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public static async Task<ObservableCollection<User>> Post(String url, String content)
        {
            HttpClient client = new HttpClient();


            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsync(new Uri(url),new StringContent(content));
            if (response.IsSuccessStatusCode)
            {
                String json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static async Task<ObservableCollection<User>> Put(String url,String content)
        {
            HttpClient client = new HttpClient();


            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = await client.PutAsync(new Uri(url), new StringContent(content));
            if (response.IsSuccessStatusCode)
            {
                String json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        public static async Task<ObservableCollection<User>> Delete(String url)
        {
            HttpClient client = new HttpClient();


            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = await client.DeleteAsync(new Uri(url));
            if (response.IsSuccessStatusCode)
            {
                String json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ObservableCollection<User>>(json);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
    }
}
