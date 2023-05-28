using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2
{
    public class CarrosView
    {
        public ObservableCollection<Carros> DatosCarros { get; set; }
        public CarrosView() 
        {
            this.DatosCarros = new ObservableCollection<Carros>();
            this.DatosCarros.Add(new Carros() { Name = "Jetta", ID = 0 });
            this.DatosCarros.Add(new Carros() { Name = "Camry", ID = 1 });
            this.DatosCarros.Add(new Carros() { Name = "Mustang", ID = 2 });
            this.DatosCarros.Add(new Carros() { Name = "Wrangler", ID = 3 });
            this.DatosCarros.Add(new Carros() { Name = "A3", ID = 4 });
            this.DatosCarros.Add(new Carros() { Name = "Kicks", ID = 5 });
            this.DatosCarros.Add(new Carros() { Name = "Challenger", ID = 6 });
            this.DatosCarros.Add(new Carros() { Name = "Tahoe", ID = 7 });
            this.DatosCarros.Add(new Carros() { Name = "CX-5", ID = 8 });
            this.DatosCarros.Add(new Carros() { Name = "BMW X5", ID = 9 });
            this.DatosCarros.Add(new Carros() { Name = "Corvette", ID = 10 });
        }
    }
    public class Carros
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
