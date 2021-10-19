using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PruebasTareas
    {
        [TestMethod]
        public void ValidarConsultaTareas()
        {
            API_GestionTareas.Controllers.TareasController tareasController = new API_GestionTareas.Controllers.TareasController();

            API_GestionTareas.Models.TareasFilter filter = new API_GestionTareas.Models.TareasFilter();

            var resultado = tareasController.Get(filter);

            Assert.IsTrue(resultado.Value.Valido);
        }
    }
}
