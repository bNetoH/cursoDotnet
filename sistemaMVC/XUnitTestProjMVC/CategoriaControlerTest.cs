using Moq;
using sistemaMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProjMVC
{
    public class CategoriaControlerTest
    {

        private readonly Mock<Dbset<Categoria>> _mockset;
        private readonly Mock<Contexto> _mockContexto;
        private readonly Categoria _categoria;

        public CategoriaControlerTest()
        {
            _mockset = new Mock<Dbset<Categoria>>();
            _mockContexto = new Mock<Contexto>();
            _categoria = new Categoria { ID = 1, Descricao = "teste de categoria" };
            _mockContexto.Setup(m => m.Categorias).Returns(_mockset.Object );
            _mockContexto.Setup(m => m.Categorias).FindAsync(1)).ReturnsAsync(_categoria);
        }

        [Fact]
        public async Task Get_Categoria()
        {
            var service = new CateriasController(_mockContexto.Object);

            await service.GetCategoria(1);

            _mockset.Verify(m => m.FindAsync(1), Times.Once);
        }


    }
}
