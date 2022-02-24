using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace testSerializacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream file = new FileStream("/Users/yeder/OneDrive/Escritorio/.NET/testSerializacion/testSerializacion/application.ttf", FileMode.Open);
            Stream file1 = new FileStream("/Users/yeder/OneDrive/Escritorio/.NET/testSerializacion/testSerializacion/application3.ttf", FileMode.Open);
            Stream file2 = new FileStream("/Users/yeder/OneDrive/Escritorio/.NET/testSerializacion/testSerializacion/application2.ttf", FileMode.Open);

            byte[] arreglo = LeerArchivoBinario(file);
            byte[] arreglo1 = LeerArchivoBinario(file1);
            byte[] arreglo2 = LeerArchivoBinario(file2);

            Animal tortuga = AObjeto(arreglo);
            Animal teenNinjaTurtle = AObjeto(arreglo1);
            Animal liebre = AObjeto(arreglo2);

            List<Animal> animales = new List<Animal>();
            animales.Add(tortuga);
            animales.Add(liebre);
            animales.Add(teenNinjaTurtle);

            
            Thread t1 = new Thread( ()=> Correr(animales[1]));
            Thread t2 = new Thread(() => Correr(animales[2]));
            Console.WriteLine("Inicia la competencia");
            t1.Start();
            t2.Start();
            

        }


        public static byte[] LeerArchivoBinario(Stream archivo)
        {
            MemoryStream ms = new MemoryStream();
            archivo.CopyTo(ms);
            return ms.ToArray();

        }

        public static Animal AObjeto(byte[] array)
        {
            MemoryStream ms = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            ms.Write(array, 0, array.Length);
            ms.Seek(0, SeekOrigin.Begin);
            Animal animal = (Animal)formatter.Deserialize(ms);



            return animal;
        }

        public static void Correr(Animal animal)
        {
            Char[] nombre = animal.Nombre.ToCharArray();
            Char inicial = nombre[0];
            int velocidad = 100 - animal.Velocidad;

            for (int i = 1; i <= 800; i++)
            {
                Console.WriteLine(inicial);
                Thread.Sleep(velocidad);

                if (i == 400){
                    if (animal.SeDuerme == true) { 
                        Console.WriteLine(animal.Nombre+" se durmio");
                        Thread.Sleep(10 * animal.Velocidad);
                        Console.WriteLine("\t zzzzzzzzzzz");
                        Console.WriteLine("\n"+animal.Nombre+" ha despertado");
                    }
                }

                if (i == 800) {
                    Console.WriteLine("Ha ganado " + animal.Nombre);
                    Environment.Exit(-1);
                }

            }

            



        }


    }
}
