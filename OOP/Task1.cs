using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Task1
    {

    }

    class Cliente
    {
        private string nombre;
        private string ci;

        public Cliente(string nombre, string ci)
        {
            this.nombre = nombre;
            this.ci = ci;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Ci { get => ci; set => ci = value; }
    }

    class Barco
    {
        private string matricula;
        private double eslora;

        public Barco(string matricula, double eslora)
        {
            this.matricula = matricula;
            this.eslora = eslora;
        }

        public string Matricula { get => matricula; set => matricula = value; }
        public double Eslora { get => eslora; set => eslora = value; }

        public virtual double modulo()
        {
            return 10 * this.eslora;
        }

        public override string ToString()
        {
            return "Barco";
        }


    }
    class Velero : Barco 
    {
        private int mastiles;

        public Velero(string matricula, double eslora, int mastiles) : base(matricula, eslora)
        {
            this.mastiles = mastiles;
        }

        public int Mastiles { get => mastiles; set => mastiles = value; }

        public override double modulo()
        {
            return base.modulo()+this.mastiles;
        }

        public override string ToString()
        {
            return "Velero";
        }
    }

    class Deportivo : Barco 
    {
        private double potencia;

        public Deportivo(string matricula, double eslora, int potencia) : base(matricula, eslora)
        {
            this.potencia = potencia;
        }

        public double Potencia { get => potencia; set => potencia = value; }

        public override double modulo()
        {
            return base.modulo() + this.potencia;
        }

        public override string ToString()
        {
            return "Deportiva a motor";
        }
    }
    class Yate : Barco 
    { 
        public int camarotes;
        public double potencia;

        public Yate(string matricula, double eslora, double potencia, int camarotes) : base(matricula, eslora)
        {
            this.camarotes = camarotes;
            this.potencia = potencia;
        }

        public override double modulo()
        {
            return base.modulo() + this.potencia + this.camarotes;
        }

        public override string ToString()
        {
            return "Yate de lujo";
        }
    }
    class Alquiler
    {
        private readonly DateTime fecha_inicio;
        private readonly DateTime fecha_fin;
        private readonly double precio_base = 12;
        private readonly string posicion;
        private readonly Barco barco;
        private readonly Cliente cliente;

        public Alquiler(DateTime inicio, DateTime fin, string posicion, Barco barco, Cliente cliente)
        {

            this.fecha_inicio = inicio;
            this.fecha_fin = fin;
            this.posicion = posicion;
            this.barco = barco;
            this.cliente = cliente;
        }

        public DateTime Fecha_inicio => fecha_inicio;

        public DateTime Fecha_fin => fecha_fin;

        public double Precio_base => precio_base;

        public string Posicion => posicion;

        internal Barco Barco => barco;

        internal Cliente Cliente => cliente;

        public void calcularAlquiler() 
        {
            int diasOcupacion = (this.fecha_fin - this.fecha_inicio).Days+1;
            double precio = diasOcupacion*this.barco.modulo()*this.precio_base;
            Console.WriteLine(
                $"Precio de alquiler: {precio} $us \n" +
                $"Tipo Barco : { this.barco.ToString()} \n" +
                $"Matricula :  { this.barco.Matricula }  \n" +
                $"Cliente : { this.cliente.Nombre }"
            );
        }
    }
    
}
