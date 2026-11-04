using ERP.Simulado.Models;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Simulado.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{

private static readonly List<Produto> Produtos = new List<Produto>
{
    new Produto
    {
        Id = 1,
        Nome = "Caderno universitário",
        Marca = "Tilibra",
        Preco = 35.00m
    },

    new Produto
    {
        Id = 2,
        Nome = "Caneta azul",
        Marca = "BIC",
        Preco = 2.50m
    },

    new Produto
    {
        Id = 3,
        Nome = "Borracha branca",
        Marca = "Mercur",
        Preco = 1.50m
    }
};
        [HttpGet]
         public IActionResult Get()
          {
              return Ok(Produtos);
          } 

              [HttpGet("{id}")]
              public IActionResult GetById(int id)
           {
          var produto = Produtos.FirstOrDefault(p => p.Id == id);

    if (produto == null)
    {
        return NotFound();
    }

        return Ok(produto);
}

          [HttpPost]
          public IActionResult Post([FromBody] Produto novoProduto)
    {
      novoProduto.Id = Produtos.Max(p => p.Id) + 1;

      Produtos.Add(novoProduto);

      return CreatedAtAction(
        nameof(GetById),
        new { id = novoProduto.Id },
         novoProduto
    );
}
}