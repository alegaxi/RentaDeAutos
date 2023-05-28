using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Prueba2
{
    public class opMongo
    {
        public Boolean bAllOk = false;
        public String sLastError = "";
        static MongoClient cliente = new MongoClient("mongodb://192.168.8.157:27017/");

        public Boolean InsertDocuments(String IdRenta, String Nombre, String Telefono, String Direccion, String NombreCarro, String Marca, Int32 Modelo, Int32 PrecioDia, DateTime FechaInicio, DateTime FechaFin, Int32 PrecioTotal)
        {
            bAllOk = false;
            try
            {
                IMongoDatabase db = cliente.GetDatabase("RentaDeAutos");
                var cars = db.GetCollection<BsonDocument>("Renta");

                var doc = new BsonDocument
                {
                    {"IdRenta", IdRenta },
                    {"Nombre", Nombre },
                    {"Telefono", Telefono },
                    {"Direccion", Direccion },
                    {"NombreCarro", NombreCarro },
                    {"Marca", Marca },
                    {"Modelo", Modelo },
                    {"PrecioDia", PrecioDia },
                    {"FechaInio", FechaInicio },
                    {"FechaFin", FechaFin },
                    {"PrecioTotal", PrecioTotal }
                };
                cars.InsertOne(doc);
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.ToString();
                bAllOk = false;
            }
            return bAllOk;
        }
        public Boolean UpdateDocuments(String IdRenta, String Nombre, String Telefono, String Direccion, String NombreCarro, String Marca, Int32 Modelo, Int32 PrecioDia, DateTime FechaInicio, DateTime FechaFin, Int32 PrecioTotal)
        {
            bAllOk = false;
            try
            {
                IMongoDatabase db = cliente.GetDatabase("RentaDeAutos");
                var cars = db.GetCollection<BsonDocument>("Renta");
                var filter = Builders<BsonDocument>.Filter.Eq("Nombre", Nombre);

                var doc = new BsonDocument
                {
                    {"IdRenta", IdRenta },
                    {"Nombre", Nombre },
                    {"Telefono", Telefono },
                    {"Direccion", Direccion },
                    {"NombreCarro", NombreCarro },
                    {"Marca", Marca },
                    {"Modelo", Modelo },
                    {"PrecioDia", PrecioDia },
                    {"FechaInio", FechaInicio },
                    {"FechaFin", FechaFin },
                    {"PrecioTotal", PrecioTotal }
                };
                cars.UpdateOne(filter, doc);
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.ToString();
                bAllOk = false;
            }
            return bAllOk;
        }
        public Boolean Delete(String IdRenta)
        {
            bAllOk = false;
            try
            {
                IMongoDatabase db = cliente.GetDatabase("RentaDeAutos");
                var cars = db.GetCollection<BsonDocument>("Renta");

                var builder = Builders<BsonDocument>.Filter;
                var filter = Builders<BsonDocument>.Filter.Eq("IdRenta", IdRenta);
                cars.DeleteMany(filter);
                bAllOk = true;
            }
            catch (Exception ex)
            {
                sLastError = ex.ToString();
                bAllOk = false;
            }
            return bAllOk;
        }
        public DataTable ConsultarRegistroFecha(DateTime fechainicio, DateTime fechafinal)
        {
            DataTable datos = new DataTable();

            IMongoDatabase db = cliente.GetDatabase("RentaDeAutos");
            var consultar = db.GetCollection<BsonDocument>("Renta");

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.And(builder.Gte("FechaInio", fechainicio),
                builder.Lte("FechaFin", fechafinal));

            var docs = consultar.Find(filter).ToList();

            if (docs.Count > 0)
            {
                foreach (var document in docs)
                {
                    var row = datos.NewRow();

                    foreach (var element in document.Elements)
                    {
                        if (datos.Columns[element.Name] == null)
                        {
                            datos.Columns.Add(element.Name);
                        }

                        row[element.Name] = element.Value;
                    }

                    datos.Rows.Add(row);
                }

                bAllOk = true;
            }
            else
            {
                bAllOk = false;
            }

            return datos;
        }
        public DataTable ConsultarRegistroHistorial(string scliente, string carro, DateTime fechainicio, DateTime fechafinal)
        {
            DataTable datos = new DataTable();

            IMongoDatabase db = cliente.GetDatabase("RentaDeAutos");
            var consultar = db.GetCollection<BsonDocument>("Renta");

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.And(builder.Eq("Nombre", scliente),
                builder.Eq("NombreCarro", carro),
                builder.Eq("FechaInio", fechainicio),
                builder.Eq("FechaFin", fechafinal));

            var docs = consultar.Find(filter).ToList();

            if (docs.Count > 0)
            {
                foreach (var document in docs)
                {
                    var row = datos.NewRow();

                    foreach (var element in document.Elements)
                    {
                        if (datos.Columns[element.Name] == null)
                        {
                            datos.Columns.Add(element.Name);
                        }

                        row[element.Name] = element.Value;
                    }

                    datos.Rows.Add(row);
                }

                bAllOk = true;
            }
            else
            {
                bAllOk = false;
            }

            return datos;
        }
        public DataTable ConsultarRegistroCarro(string carro)
        {
            DataTable datos = new DataTable();

            IMongoDatabase db = cliente.GetDatabase("RentaDeAutos");
            var consultar = db.GetCollection<BsonDocument>("Renta");

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("NombreCarro", carro);

            var docs = consultar.Find(filter).ToList();

            if (docs.Count > 0)
            {
                foreach (var document in docs)
                {
                    var row = datos.NewRow();

                    foreach (var element in document.Elements)
                    {
                        if (datos.Columns[element.Name] == null)
                        {
                            datos.Columns.Add(element.Name);
                        }

                        row[element.Name] = element.Value;
                    }

                    datos.Rows.Add(row);
                    
                }

                bAllOk = true;
            }
            else
            {
                bAllOk = false;
            }

            return datos;
        }

    }

}
