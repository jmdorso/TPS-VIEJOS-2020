using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Archivos;
using Excepciones;
using Clases_Instanciables;
using EntidadesAbstractas;
using System.Collections.Generic;

namespace TestUnitariosTP3JuanMartinDorso
{
    [TestClass]
    public class TestUnitarioTP3JuanMartinDorso
    {
        #region Test Excepciones Lanzadas
        [TestMethod][ExpectedException(typeof(Excepciones.AlumnoRepetidoException))]
        public void TestValidarExceptionAlumnoRepetido()
        {
            //Arrange
            Universidad u1 = new Universidad();
            Alumno a1 = new Alumno(77,"Juan Martin","Dorso","40714971",Persona.ENacionalidad.Argentino,Universidad.EClases.Laboratorio);
            //repito el mismo alumno, cambiando ID (x operador == de Universitario, si tiene mismo ID o DNI, ademas del tipo, es igual)
            Alumno a2 = new Alumno(10, "Juan Martin", "Dorso", "40714971", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            //repito el mismo alumno, cambiando DNI (x operador == de Universitario, si tiene mismo ID o DNI, ademas del tipo, es igual)
            Alumno a3 = new Alumno(77, "Juan Martin", "Dorso", "18", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno a4 = new Alumno();
            
            //Act
            u1 += a1;
            u1 += a1;
            u1 += a2;
            u1 += a3;
            u1 += a4;
        }

        [TestMethod]
        [ExpectedException(typeof(Excepciones.ArchivosException))]
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
        [ExpectedException(typeof(Excepciones.DniInvalidoException))]
        public void TestValidarExceptionDniInvalido()
        {
            //Arrange
            string miDniInvalido = "4OTI49TI";

            //Act
            //Pongo un DNI alfanumerico
            Alumno a1 = new Alumno(77, "Juan Martin", "Dorso", miDniInvalido, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(Excepciones.NacionalidadInvalidaException))]
        public void TestValidarExceptionNacionalidadInvalida()
        {
            //Arrange
            string miDniExtranjero = "90714971";
            //Act
            ///Dni extranjero con nacionalidad Argentina
            Alumno a1 = new Alumno(77, "Juan Martin", "Dorso", miDniExtranjero, Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(Excepciones.SinProfesorException))]
        public void TestValidarExceptionSinProfesor()
        {
            //Arrange
            Universidad u1 = new Universidad();
            Profesor p1 = new Profesor();

            //Act
            //No existe ningun profesor en la facultad, por ende, devuelve la excepcion
            p1 = u1 == Universidad.EClases.Laboratorio;
        }
        #endregion

        #region Test de Coleeciones
        [TestMethod]
        public void TestInstanciaDeColeccionesOfType()
        {
            //Arrange
            Universidad u1;

            //Act
            u1 = new Universidad();
            
            //Assert
            Assert.IsInstanceOfType(u1.Instructores,typeof(List<Profesor>));

        }
        [TestMethod]
        public void TestInstanciaDeColeccionesIsNotNull()
        {
            //Arrange
            Universidad u1;

            //Act
            u1 = new Universidad();

            //Assert
            Assert.IsNotNull(u1.Instructores);

        }

        [TestMethod]
        public void TestInstanciaDeColeccionesIsNull()
        {
            //Arrange
            Universidad u1;

            //Act
            u1 = new Universidad();
            u1.Instructores = null;

            //Assert
            Assert.IsNull(u1.Instructores);

        }

        #endregion
    }
}
