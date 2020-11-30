using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Exceptions;
using Entidades;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Empresa empresa = new Empresa("NetShoes",12);
            Botin botin1 = new Botin(Calzado.EOrigen.Importado, 10999, 44, "Botines de Futsal con increíble agarre", Calzado.EMarca.Adidas,Botin.ETipoBotin.Pista);
            Zapatilla zapa1 = new Zapatilla(Calzado.EOrigen.Nacional, 6000, 39, "Zapatillas comodas para ejercitar", Calzado.EMarca.Nike, Zapatilla.ETipoZapatilla.Running);
            Botin botin2 = new Botin(Calzado.EOrigen.Importado, 3000, 44, "Botines de Futsal con increíble agarre", Calzado.EMarca.Adidas, Botin.ETipoBotin.Pista);
            Zapatilla zapa2 = new Zapatilla(2,Calzado.EOrigen.Nacional, 20000, 42, "Zapatillas para bailar", Calzado.EMarca.Nike, Zapatilla.ETipoZapatilla.Moda);

            empresa.SumarCalzado<Calzado>(empresa, botin1);
            empresa.SumarCalzado<Calzado>(empresa, zapa1);
            empresa.SumarCalzado<Calzado>(empresa, botin2);
            empresa.SumarCalzado<Calzado>(empresa, zapa2);
          
            empresa.GenerarVenta(empresa, 3);
            try
            {
                Zapatilla zapa3 = new Zapatilla(Calzado.EOrigen.Nacional, 2500, 35, "Zapatilla demasiado barata", Calzado.EMarca.Reebok, Zapatilla.ETipoZapatilla.Sport);
            }
            catch (PrecioInvalidoException e)
            {
                Console.WriteLine("Error al agregar Zapa 3, porque el precio es menor a 3000\n");
            }

            Console.WriteLine(empresa.ToString());
            Empresa.GuardarTexto(empresa, "EmpresaConsola.txt");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Se va mostrar la empresa de botines del form. Presione cualquier tecla");
            Console.ReadKey();
            Console.Clear();
            try
            {
                string datos = Empresa.LeerTexto("EmpresaBotin.txt");

                Console.WriteLine($"{datos}");
            }
            catch (ArchivosException e)
            {
                Console.WriteLine("Archivo inexistente, se crea al cerrar el proyecto del form\n");
            }
            Console.ReadKey();
        }

    }

}
