using MvcCoreApiClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MvcCoreApiClient.Services
{
    public class ServiceHospital
    {

        //clase para indicar el formato que estamos consumiendi
        private MediaTypeWithQualityHeaderValue header;

        //nuestra URL del servicio
        private string ApiUrl;

        public ServiceHospital()
        {
            this.ApiUrl =
                "https://apinetcorehospitalespaco.azurewebsites.net/";
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        //creamos un metodo asincrono para leer hospitales
        public async Task<List<Hospital>>
            GetHospitalesAsync()
        {
            //usamos la clase Httpclient para las peticiones
            using (HttpClient client = new HttpClient())
            {
                //necesitamos la peticion
                string request = "api/hospitales";
                //indicamos la url base de nuestro servicio
                client.BaseAddress = new Uri(this.ApiUrl);
                //como norma debemos limpiar las cabeceras en 
                //cada peticion por si en algun momento las 
                //mezclamos y nos daria error
                client.DefaultRequestHeaders.Clear();
                //indcamos el tipo de consulta a consumir
                client.DefaultRequestHeaders.Accept.Add
                    (this.header);
                //realizamos la peticion y almacenamos 
                //los resultados en una respuesta
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if(response.IsSuccessStatusCode)
                {
                    //primero vamos a realizar la peticion usando
                    //newtonsoft para que tengais un ejemplo si las
                    //propiedades del json y del model no fueran iguales
                    string json =
                        await response.Content.ReadAsStringAsync();
                    List<Hospital> data =
                        JsonConvert.DeserializeObject<List<Hospital>>(json);
                    return data;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
