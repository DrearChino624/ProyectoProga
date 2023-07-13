using MVCproyecto.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MVCproyecto
{
    public class APIGateway
    {

        private string _url = "http://localhost:5289/api/v4/Usuario";
        private HttpClient _client = new HttpClient();

        public List<Cliente> ListCliente()
        {
            List<Cliente> clientes = new List<Cliente>();

        }

            if(_url.Trim().Substring(0,5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            try
            {
                HttpResponseMessage respuesta = _client.GetAsync(_url).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;

                    var datallama = JsonConvert.DeserializeObject<List<Cliente>>(resultado);

                    if (datallama != null)
                    {
                        clientes = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido " + resultado);
                }
            }
            catch (Exception)
            {
                throw;
            }

            finally { }

            return clientes;
        }

        //crear cliente
        public Cliente CrearCliente(Cliente cliente)
        {
            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            string json = JsonConvert.SerializeObject(cliente);
            try
            {
                HttpResponseMessage respuesta = _client.PostAsync(_url, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    var datallama = JsonConvert.DeserializeObject<Cliente>(resultado);
                    if (datallama != null)
                    {
                        cliente = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido en crear el dato en API: " + resultado);
                }
            }
            catch (Exception e)
            {
                throw new Exception ("Error a aparecido: "+e.Message);
            }

            finally { }
            return cliente;
        }

        //Get cliente
        public Cliente GetCliente(int id)
        {
            Cliente cliente = new Cliente();
            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            try
            {
                HttpResponseMessage respuesta = _client.GetAsync(_url + "/" + id).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    var datallama = JsonConvert.DeserializeObject<Cliente>(resultado);
                    if (datallama != null)
                    {
                        cliente = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido " + resultado);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { }
            return cliente;
        }

        //actualizar  cliente
        public Cliente ActualizarCliente(Cliente cliente)
        {
            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            string json = JsonConvert.SerializeObject(cliente);
            try
            {
                HttpResponseMessage respuesta = _client.PutAsync(_url + "/" + cliente.id, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    var datallama = JsonConvert.DeserializeObject<Cliente>(resultado);
                    if (datallama != null)
                    {
                        cliente = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido en actualizar el dato en API: " + resultado);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error a aparecido: " + e.Message);
            }

            finally { }
            return cliente;
        }

        //eliminar cliente
        public bool EliminarCliente(int id)
        {
            bool respuesta = false;
            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            try
            {
                HttpResponseMessage respuesta2 = _client.DeleteAsync(_url + "/" + id).Result;
                if (respuesta2.IsSuccessStatusCode)
                {
                    string resultado = respuesta2.Content.ReadAsStringAsync().Result;
                    var datallama = JsonConvert.DeserializeObject<bool>(resultado);
                    if (datallama != null)
                    {
                        respuesta = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta2.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido " + resultado);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { }
            return respuesta;
        }

        private string _url2 = "http://localhost:5289/api/v4/Producto";
        private HttpClient _producto = new HttpClient();

        //Parte de productos
        public List<Producto> ListProducto()
        {
            List<Producto> producto = new List<Producto>();

            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            try
            {
                HttpResponseMessage respuesta = _producto.GetAsync(_url2).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;

                    var datallama = JsonConvert.DeserializeObject<List<Producto>>(resultado);

                    if (datallama != null)
                    {
                        producto = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido " + resultado);
                }
            }
            catch (Exception)
            {
                throw;
            }

            finally { }

            return producto;
        }

        //crear producto
        public Producto CrearProducto(Producto producto)
        {
            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            string json = JsonConvert.SerializeObject(producto);
            try
            {
                HttpResponseMessage respuesta = _producto.PostAsync(_url2, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    var datallama = JsonConvert.DeserializeObject<Producto>(resultado);
                    if (datallama != null)
                    {
                        producto = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido en crear el dato en API: " + resultado);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error a aparecido: " + e.Message);
            }
            finally { }
            return producto;
        }

        //Get producto
        public Producto GetProducto(int id)
        {
            Producto producto = new Producto();
            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            try
            {
                HttpResponseMessage respuesta = _producto.GetAsync(_url2 + "/" + id).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    var datallama = JsonConvert.DeserializeObject<Producto>(resultado);
                    if (datallama != null)
                    {
                        producto = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido " + resultado);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { }
            return producto;
        }

        //actualizar producto
        public Producto ActualizarProducto(Producto producto)
        {
            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            string json = JsonConvert.SerializeObject(producto);
            try
            {
                HttpResponseMessage respuesta = _producto.PutAsync(_url2 + "/" + producto.id, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    var datallama = JsonConvert.DeserializeObject<Producto>(resultado);
                    if (datallama != null)
                    {
                        producto = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido en actualizar el dato en API: " + resultado);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error a aparecido: " + e.Message);
            }

            finally { }
            return producto;
        }

        //eliminar producto
        public bool EliminarProducto(int id)
        {
            bool respuesta = false;
            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            try
            {
                HttpResponseMessage respuesta2 = _producto.DeleteAsync(_url2 + "/" + id).Result;
                if (respuesta2.IsSuccessStatusCode)
                {
                    string resultado = respuesta2.Content.ReadAsStringAsync().Result;
                    var datallama = JsonConvert.DeserializeObject<bool>(resultado);
                    if (datallama != null)
                    {
                        respuesta = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta2.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido " + resultado);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { }
            return respuesta;
        }

        //parte de compra
        private string _url3 = "http://localhost:5289/api/Compra";
        private HttpClient _compra = new HttpClient();

        //listar compra
        public List<Compra> ListCompra()
        {
            List<Compra> compra = new List<Compra>();

            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }

            try
            {
                HttpResponseMessage respuesta = _compra.GetAsync(_url3).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;

                    var datallama = JsonConvert.DeserializeObject<List<Compra>>(resultado);

                    if (datallama != null)
                    {
                        compra = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido " + resultado);
                }
            }
            catch (Exception)
            {
                throw;
            }

            finally { }

            return compra;
        }

        //crear compra
        public Compra CrearCompra(Compra compra)
        {
            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            string json = JsonConvert.SerializeObject(compra);
            try
            {
                HttpResponseMessage respuesta = _compra.PostAsync(_url3, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    var datallama = JsonConvert.DeserializeObject<Compra>(resultado);
                    if (datallama != null)
                    {
                        compra = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido en crear el dato en API: " + resultado);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error a aparecido: " + e.Message);
            }
            finally { }
            return compra;
        }

        //Get compra
        public Compra GetCompra(int id)
        {
            Compra compra = new Compra();
            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            try
            {
                HttpResponseMessage respuesta = _compra.GetAsync(_url3 + "/" + id).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    var datallama = JsonConvert.DeserializeObject<Compra>(resultado);
                    if (datallama != null)
                    {
                        compra = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido " + resultado);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { }
            return compra;
        }

        //actualizar compra
        public Compra ActualizarCompra(Compra compra)
        {
            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            string json = JsonConvert.SerializeObject(compra);
            try
            {
                HttpResponseMessage respuesta = _compra.PutAsync(_url3 + "/" + compra.id, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    var datallama = JsonConvert.DeserializeObject<Compra>(resultado);
                    if (datallama != null)
                    {
                        compra = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido en actualizar el dato en API: " + resultado);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error a aparecido: " + e.Message);
            }

            finally { }
            return compra;
        }

        //eliminar compra
        public bool EliminarCompra(int id)
        {
            bool respuesta = false;
            if (_url.Trim().Substring(0, 5).ToLower() == "https")
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            }
            try
            {
                HttpResponseMessage respuesta2 = _compra.DeleteAsync(_url3 + "/" + id).Result;
                if (respuesta2.IsSuccessStatusCode)
                {
                    string resultado = respuesta2.Content.ReadAsStringAsync().Result;
                    var datallama = JsonConvert.DeserializeObject<bool>(resultado);
                    if (datallama != null)
                    {
                        respuesta = datallama;
                    }
                }
                else
                {
                    string resultado = respuesta2.Content.ReadAsStringAsync().Result;
                    throw new Exception("Un error a ocurrido " + resultado);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { }
            return respuesta;
        }
    }
}
