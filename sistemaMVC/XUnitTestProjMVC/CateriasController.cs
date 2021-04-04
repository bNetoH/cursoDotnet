using sistemaMVC.Models;
using System;
using System.Threading.Tasks;

namespace XUnitTestProjMVC
{
    internal class CateriasController
    {
        private Contexto @object;

        public CateriasController(Contexto @object)
        {
            this.@object = @object;
        }

        internal Task GetCategoria(int v)
        {
            throw new NotImplementedException();
        }
    }
}