using MongoDB.Bson;
using MongoDB.Driver;
using Syncfusion.Maui.Calendar;
using Syncfusion.Maui.Inputs;
using System.ComponentModel;
using System.Data;
using System.Globalization;

namespace Prueba2;

public partial class registroPage : ContentPage
{
    Boolean bCond = false;
    public static Int32 iNumeroCarro;
    public static Int32 iCond;
    public static String sCliente;
    public static String sCarro;
    public static DateTime dtFechaP;
    public static DateTime dtFechaF;
    public registroPage()
	{
		InitializeComponent();
        
    }
    private void comboBox_SelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
    {
        IDCarro.Text = comboBox.SelectedIndex.ToString();
        if(IDCarro.Text == "0")
        {
            tbNombreCarro.Text = "Jetta";
            tbMarca.Text = "Volkswagen";
            tbModelo.Text = "2022";
            tbPrecioDia.Text = "1500";
        }
        else if (IDCarro.Text == "1")
        {
            tbNombreCarro.Text = "Camry";
            tbMarca.Text = "Toyota";
            tbModelo.Text = "2021";
            tbPrecioDia.Text = "1800";
        }
        else if (IDCarro.Text == "2")
        {
            tbNombreCarro.Text = "Mustang";
            tbMarca.Text = "Ford";
            tbModelo.Text = "2021";
            tbPrecioDia.Text = "2500";
        }
        else if (IDCarro.Text == "3")
        {
            tbNombreCarro.Text = "Wrangler";
            tbMarca.Text = "Jeep";
            tbModelo.Text = "2022";
            tbPrecioDia.Text = "2000";
        }
        else if (IDCarro.Text == "4")
        {
            tbNombreCarro.Text = "A3";
            tbMarca.Text = "Audi";
            tbModelo.Text = "2022";
            tbPrecioDia.Text = "2800";
        }
        else if (IDCarro.Text == "5")
        {
            tbNombreCarro.Text = "Kicks";
            tbMarca.Text = "Nissan";
            tbModelo.Text = "2021";
            tbPrecioDia.Text = "1200";
        }
        else if (IDCarro.Text == "6")
        {
            tbNombreCarro.Text = "Challenger";
            tbMarca.Text = "Dodge";
            tbModelo.Text = "2021";
            tbPrecioDia.Text = "2700";
        }
        else if (IDCarro.Text == "7")
        {
            tbNombreCarro.Text = "Tahoe";
            tbMarca.Text = "Chevrolet";
            tbModelo.Text = "2022";
            tbPrecioDia.Text = "2700";
        }
        else if (IDCarro.Text == "8")
        {
            tbNombreCarro.Text = "CX-5";
            tbMarca.Text = "Mazda";
            tbModelo.Text = "2021";
            tbPrecioDia.Text = "1700";
        }
        else if (IDCarro.Text == "9")
        {
            tbNombreCarro.Text = "X5";
            tbMarca.Text = "BMW";
            tbModelo.Text = "2022";
            tbPrecioDia.Text = "3500";
        }
        else if (IDCarro.Text == "10")
        {
            tbNombreCarro.Text = "Corvette";
            tbMarca.Text = "Chevrolet";
            tbModelo.Text = "2021";
            tbPrecioDia.Text = "3000";
        }
    }

    private void tbPrecioTotal_Focused(object sender, FocusEventArgs e)
    {
        DateTime Inicio = dtFechaInicio.Date;
        DateTime Final = dtFechaFinal.Date;
        TimeSpan resultado = Final - Inicio;
        int dias = resultado.Days; 
        int total = dias * Convert.ToInt32(tbPrecioDia.Text);
        tbPrecioTotal.Text = $"{total}";
    }
    void LimpiarCampos()
    {
        tbIdRenta.Text = "";
        tbNombre.Text = "";
        tbTelefono.Text = "";
        tbDomicilio.Text = "";
        tbNombreCarro.Text = "";
        tbMarca.Text = "";
        tbModelo.Text = "";
        tbPrecioDia.Text = "";
        tbPrecioTotal.Text = "";
    }
    private async void btnRegistrar_Clicked_1(object sender, EventArgs e)
    {
        opMongo InsertMongo = new opMongo();

        String IdRenta = tbIdRenta.Text;
        String Nombre = tbNombre.Text;
        String Telefono = tbTelefono.Text;
        String Domicilio = tbDomicilio.Text;
        String NombreCarro = tbNombreCarro.Text;
        String Marca = tbMarca.Text;
        Int32 Modelo = Convert.ToInt32(tbModelo.Text);
        Int32 PrecioDia = Convert.ToInt32(tbPrecioDia.Text);
        Int32 PrecioTotal  = Convert.ToInt32(tbPrecioTotal.Text);

        if(IdRenta!= null || Nombre != null || Telefono != null || Domicilio != null || NombreCarro != null || Marca != null || tbModelo.Text != null || tbPrecioDia.Text != null || tbPrecioTotal.Text != null) 
        {
            if(InsertMongo.InsertDocuments(IdRenta, Nombre, Telefono, Domicilio, NombreCarro, Marca, Modelo, PrecioDia, dtFechaInicio.Date, dtFechaFinal.Date, PrecioTotal))
            {
                await DisplayAlert("Correcto", "Registrado correctamente", "Aceptar");
                LimpiarCampos();

            }
            else
            {
                await DisplayAlert("Upss", InsertMongo.sLastError, "Aceptar");
            }
            
        }
        else
        {
            await DisplayAlert("Incorrecto", "Favor de llenar todos los campos", "Aceptar");
        }
    }

    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        opMongo DeleteMongo = new opMongo();
        if (tbIdRenta.Text != null)
        {
            if(DeleteMongo.Delete(tbIdRenta.Text))
            {
                await DisplayAlert("Correcto", "Eliminado correctamente", "Aceptar");
                LimpiarCampos();
            }
            else
            {
                await DisplayAlert("Upss", DeleteMongo.sLastError, "Aceptar");
            }
        }
        else
        {
            await DisplayAlert("Incorrecto", "Ingrese el IDRenta que desea eliminar", "Aceptar");
        }
    }

    private void btnCancelar_Clicked(object sender, EventArgs e)
    {
        LimpiarCampos();
    }

    private async void tbNombre_Completed(object sender, EventArgs e)
    {
        MongoClient cliente = new MongoClient("mongodb://192.168.8.157:27017/");
        IMongoDatabase db = cliente.GetDatabase("RentaDeAutos");
        var cars = db.GetCollection<BsonDocument>("Renta");

        var filtro = Builders<BsonDocument>.Filter.Eq("Nombre", tbNombre.Text);
        var resultado = cars.Find(filtro).FirstOrDefault();

        if (resultado != null)
        {
            tbIdRenta.Text = resultado["IdRenta"].ToString();
            tbTelefono.Text = resultado["Telefono"].ToString();
            tbDomicilio.Text = resultado["Direccion"].ToString();
            tbNombreCarro.Text = resultado["NombreCarro"].ToString();
            tbMarca.Text = resultado["Marca"].ToString();
            tbModelo.Text = resultado["Modelo"].ToString();
            tbPrecioDia.Text = resultado["PrecioDia"].ToString();
            //string fechaInicio = resultado["FechaInio"].ToString();
            //DateTime fechaIncio = DateTime.ParseExact(fechaInicio, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            dtFechaInicio.Date = Convert.ToDateTime(resultado["FechaInio"]);
            //string fechaFinal = resultado["FechaFin"].ToString();
            //DateTime fechaF = DateTime.ParseExact(fechaFinal, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            dtFechaFinal.Date = Convert.ToDateTime(resultado["FechaFin"]);
            tbPrecioTotal.Text = resultado["PrecioTotal"].ToString();
        }
        else
        {
            await DisplayAlert("Incorrecto", "Algo salio mal", "Aceptar");
        }
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        if (iCond == 1)
        {
            comboBox.SelectedIndex = iNumeroCarro;

            iCond = 0;
        }
        else
        {
            if (iCond == 2)
            {
                opMongo op = new opMongo();
                DataTable dataTable = new DataTable();
                dataTable = op.ConsultarRegistroHistorial(sCliente, sCarro, dtFechaP, dtFechaF);

                foreach (DataRow dr in dataTable.Rows)
                {
                    tbIdRenta.Text = Convert.ToString(dr["IdRenta"]);
                    tbNombre.Text = Convert.ToString(dr["Nombre"]);
                    tbTelefono.Text = Convert.ToString(dr["Telefono"]);
                    tbDomicilio.Text = Convert.ToString(dr["Direccion"]);
                    if (Convert.ToString(dr["NombreCarro"]) == "Jetta")
                    {
                        tbNombreCarro.Text = "Jetta";
                        tbMarca.Text = "Volkswagen";
                        tbModelo.Text = "2022";
                        tbPrecioDia.Text = "1500";
                    }
                    else
                    {
                        if (Convert.ToString(dr["NombreCarro"]) == "Camry")
                        {
                            tbNombreCarro.Text = "Camry";
                            tbMarca.Text = "Toyota";
                            tbModelo.Text = "2021";
                            tbPrecioDia.Text = "1800";
                        }
                        else
                        {
                            if (Convert.ToString(dr["NombreCarro"]) == "Mustang")
                            {
                                tbNombreCarro.Text = "Mustang";
                                tbMarca.Text = "Ford";
                                tbModelo.Text = "2021";
                                tbPrecioDia.Text = "2500";
                            }
                            else
                            {
                                if (Convert.ToString(dr["NombreCarro"]) == "Wrangler")
                                {
                                    tbNombreCarro.Text = "Wrangler";
                                    tbMarca.Text = "Jeep";
                                    tbModelo.Text = "2022";
                                    tbPrecioDia.Text = "2000";
                                }
                                else
                                {
                                    if (Convert.ToString(dr["NombreCarro"]) == "A3")
                                    {
                                        tbNombreCarro.Text = "A3";
                                        tbMarca.Text = "Audi";
                                        tbModelo.Text = "2022";
                                        tbPrecioDia.Text = "2800";
                                    }
                                    else
                                    {
                                        if (Convert.ToString(dr["NombreCarro"]) == "Kicks")
                                        {
                                            tbNombreCarro.Text = "Kicks";
                                            tbMarca.Text = "Nissan";
                                            tbModelo.Text = "2021";
                                            tbPrecioDia.Text = "1200";
                                        }
                                        else
                                        {
                                            if (Convert.ToString(dr["NombreCarro"]) == "Challenger")
                                            {
                                                tbNombreCarro.Text = "Challenger";
                                                tbMarca.Text = "Dodge";
                                                tbModelo.Text = "2021";
                                                tbPrecioDia.Text = "2700";
                                            }
                                            else
                                            {
                                                if (Convert.ToString(dr["NombreCarro"]) == "Tahoe")
                                                {
                                                    tbNombreCarro.Text = "Tahoe";
                                                    tbMarca.Text = "Chevrolet";
                                                    tbModelo.Text = "2022";
                                                    tbPrecioDia.Text = "2700";
                                                }
                                                else
                                                {
                                                    if (Convert.ToString(dr["NombreCarro"]) == "CX-5")
                                                    {
                                                        tbNombreCarro.Text = "CX-5";
                                                        tbMarca.Text = "Mazda";
                                                        tbModelo.Text = "2021";
                                                        tbPrecioDia.Text = "1700";
                                                    }
                                                    else
                                                    {
                                                        if (Convert.ToString(dr["NombreCarro"]) == "X5")
                                                        {
                                                            tbNombreCarro.Text = "X5";
                                                            tbMarca.Text = "BMW";
                                                            tbModelo.Text = "2022";
                                                            tbPrecioDia.Text = "3500";
                                                        }
                                                        else
                                                        {
                                                            if (Convert.ToString(dr["NombreCarro"]) == "Corvette")
                                                            {
                                                                tbNombreCarro.Text = "Corvette";
                                                                tbMarca.Text = "Chevrolet";
                                                                tbModelo.Text = "2021";
                                                                tbPrecioDia.Text = "3000";
                                                            }
                                                            else
                                                            {

                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    dtFechaInicio.Date = Convert.ToDateTime(dr["FechaInio"]);
                    dtFechaFinal.Date = Convert.ToDateTime(dr["FechaFin"]);
                    tbPrecioTotal.Text = Convert.ToString(dr["PrecioTotal"]);
                }

                iCond = 0;
            }
            else
            {
                iCond = 0;
            }
        }
        
    }

    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        opMongo InsertMongo = new opMongo();

        String IdRenta = tbIdRenta.Text;
        String Nombre = tbNombre.Text;
        String Telefono = tbTelefono.Text;
        String Domicilio = tbDomicilio.Text;
        String NombreCarro = tbNombreCarro.Text;
        String Marca = tbMarca.Text;
        Int32 Modelo = Convert.ToInt32(tbModelo.Text);
        Int32 PrecioDia = Convert.ToInt32(tbPrecioDia.Text);
        Int32 PrecioTotal = Convert.ToInt32(tbPrecioTotal.Text);

        if (IdRenta != null || Nombre != null || Telefono != null || Domicilio != null || NombreCarro != null || Marca != null || tbModelo.Text != null || tbPrecioDia.Text != null || tbPrecioTotal.Text != null)
        {
            if (InsertMongo.UpdateDocuments(IdRenta, Nombre, Telefono, Domicilio, NombreCarro, Marca, Modelo, PrecioDia, dtFechaInicio.Date, dtFechaFinal.Date, PrecioTotal))
            {
                await DisplayAlert("Correcto", "Registrado correctamente", "Aceptar");
                LimpiarCampos();

            }
            else
            {
                await DisplayAlert("Upss", InsertMongo.sLastError, "Aceptar");
            }

        }
        else
        {
            await DisplayAlert("Incorrecto", "Favor de llenar todos los campos", "Aceptar");
        }
    }
}




















