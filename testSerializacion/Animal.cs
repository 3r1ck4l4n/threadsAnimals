using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testSerializacion
{
    [Serializable]
    class Animal
    {
        private string nombre;
        private int velocidad;
        private bool seDuerme;

        public Animal()
        {

        }

        public Animal(string nombre, int velocidad, bool seDuerme)
        {
            this.Nombre = nombre;
            this.Velocidad = velocidad;
            this.SeDuerme = seDuerme;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public bool SeDuerme { get => seDuerme; set => seDuerme = value; }

        public override string ToString()
        {
            return string.Format("El animal es: {0}, con una velocidad: {1}. ¿Esta dormido? {2} ",nombre, velocidad, seDuerme);
        }
    }
}
