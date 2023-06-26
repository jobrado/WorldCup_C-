using DAL.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace DAL
{
    internal class JSONRepository<T> : IRepository<T>
    {
        public Task<List<T>> GetAll(string path)
        {
            try
            {
                return Task.Run(() =>
                {

                    using (StreamReader r = new StreamReader(path))
                    {
                        string json = r.ReadToEnd();
                        List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
                        return items;
                    }


                });
            }
            catch (Exception ex)
            {
                 Console.WriteLine(ex.Message);
            
                return null;
            }

        }



    }
}
