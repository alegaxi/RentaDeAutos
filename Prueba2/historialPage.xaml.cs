
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data;

namespace Prueba2;

public partial class historialPage : ContentPage
{
	public historialPage()
	{
		InitializeComponent();
    }
    Boolean bCond = false;
    Int32 iGanancias = 0;
    string nombreCarro = "";
    private void comboBoxGanancia_SelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
    {
        String IDCarro = comboBoxGanancia.SelectedIndex.ToString();
        if (IDCarro == "0")
        {
            nombreCarro = "Jetta";
        }
        else if (IDCarro == "1")
        {
            nombreCarro = "Camry";
        }
        else if (IDCarro == "2")
        {
            nombreCarro = "Mustang";
        }
        else if (IDCarro == "3")
        {
            nombreCarro = "Wrangler";
        }
        else if (IDCarro == "4")
        {
            nombreCarro = "A3";
        }
        else if (IDCarro == "5")
        {
            nombreCarro = "Kicks";
        }
        else if (IDCarro == "6")
        {
            nombreCarro = "Challenger";
        }
        else if (IDCarro == "7")
        {
            nombreCarro = "Tahoe";
        }
        else if (IDCarro == "8")
        {
            nombreCarro = "CX-5";
        }
        else if (IDCarro == "9")
        {
            nombreCarro = "X5";
        }
        else if (IDCarro == "10")
        {
            nombreCarro = "Corvette";
        }
    }
    private void ConsultarGananciasCarro_Clicked(object sender, EventArgs e)
    {
        string NombreCarro = nombreCarro;
        repositorioGaleria ob = new repositorioGaleria(nombreCarro, dtFechaGanancia1.Date, dtFechaGanancia2.Date, true);
        dataGrid.ItemsSource = ob.OrderInfoCollection;

        iGanancias = 0;
        opMongo op = new opMongo();

        DataTable dtTabla = new DataTable();
        dtTabla = op.ConsultarRegistroCarro(nombreCarro);

        foreach (DataRow dr in dtTabla.Rows)
        {
            iGanancias += (Convert.ToInt32(dr[11]));
        }

        tbGanancias.Text = iGanancias.ToString();
    }

    private void ConsultarGananciasFecha_Clicked(object sender, EventArgs e)
    {
        string NombreCarro = nombreCarro;
        repositorioGaleria ob = new repositorioGaleria(NombreCarro, dtFechaGanancia1.Date, dtFechaGanancia2.Date, false);
        dataGrid.ItemsSource = ob.OrderInfoCollection;

        iGanancias = 0;
        opMongo op = new opMongo();

        DataTable dtTabla = new DataTable();
        dtTabla = op.ConsultarRegistroFecha(dtFechaGanancia1.Date, dtFechaGanancia2.Date);

        foreach (DataRow dr in dtTabla.Rows)
        {
            iGanancias += (Convert.ToInt32(dr[11]));
        }

        tbGanancias.Text = iGanancias.ToString();

    }

    private void dataGrid_CellDoubleTapped(object sender, Syncfusion.Maui.DataGrid.DataGridCellDoubleTappedEventArgs e)
    {
        var selectedRow = e.RowData;

        if (selectedRow != null)
        {
            var columna1 = selectedRow.GetType().GetProperty("Cliente").GetValue(selectedRow, null);
            var columna2 = selectedRow.GetType().GetProperty("Carro").GetValue(selectedRow, null);
            var columna3 = selectedRow.GetType().GetProperty("FechaInicio").GetValue(selectedRow, null);
            var columna4 = selectedRow.GetType().GetProperty("FechaFin").GetValue(selectedRow, null);

            registroPage.sCliente = Convert.ToString(columna1);
            registroPage.sCarro = Convert.ToString(columna2);
            registroPage.dtFechaP = Convert.ToDateTime(columna3);
            registroPage.dtFechaF = Convert.ToDateTime(columna4);

            registroPage.iCond = 2;

            var pantalla = (TabbedPage)Application.Current.MainPage;
            pantalla.CurrentPage = pantalla.Children[1];
        }
    }
}