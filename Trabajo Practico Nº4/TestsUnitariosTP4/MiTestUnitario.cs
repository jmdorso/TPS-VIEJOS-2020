using System;
using Archivos;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsUnitariosTP4
{
    [TestClass]
    public class MiTestUnitario
    {
        [TestMethod]
        [ExpectedException(typeof(Exceptions.ArchivosException))]
        public void TestValidarExceptionArchivos()
        {
            //Arrange
            Texto miTexto = new Texto();
            string misDatos = null;

            //Act
            //Guardo datos NULL en el archivo.
            miTexto.Guardar(miTexto.ToString(), misDatos);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.AgregarCalzadoException))]
        public void TestValidarAgregarCalzadoException()
        {
            Empresa empresa = new Empresa();
            Botin botin = new Botin(1, Calzado.EOrigen.Importado, 4000, 32, "ASD", Calzado.EMarca.Adidas, Botin.ETipoBotin.Cesped);
            botin.Estado = Calzado.EEstado.Vendido;

            //sumo calzado con ESTADO VENDIDO
            empresa.SumarCalzado<Botin>(empresa, botin);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.PrecioInvalidoException))]
        public void TestValidarPrecioException()
        {
            Empresa empresa = new Empresa();
            //cargo botin con precio inferior a 3mil
            Botin botin = new Botin(1, Calzado.EOrigen.Importado, 1000, 32, "ASD", Calzado.EMarca.Adidas, Botin.ETipoBotin.Cesped);
           
        }


    }
}
