using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using web_ecommerce_maxima_tech.Models;


namespace web_ecommerce_maxima_tech.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoService _produtoService;
        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.GetProdutosAsync();
            var departamentos = await _produtoService.GetDepartamentosAsync();

            var departamentoDescricaoMap = departamentos.ToDictionary(d => d.Id, d => d.Descricao);

            var produtosComDepartamento = produtos.Select(p => new
            {
                Produto = p,
                DepartamentoDescricao = departamentoDescricaoMap.ContainsKey(p.DepartamentoId) ? departamentoDescricaoMap[p.DepartamentoId] : "Não encontrado"
            }).ToList();

            ViewBag.ProdutosComDepartamento = produtosComDepartamento;

            return View();
        }

        public async Task<IActionResult> Create()
        {
            var departamentos = await _produtoService.GetDepartamentosAsync();
            ViewBag.DepartamentoIds = departamentos;
            return View(new ProdutoModel());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoModel produtoModel)
        {
            if (ModelState.IsValid)
            {
                await _produtoService.CreateProdutoAsync(produtoModel);
                TempData["SuccessMessage"] = "Produto criado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            var departamentos = await _produtoService.GetDepartamentosAsync();
            ViewBag.DepartamentoIds = departamentos;
            return View(produtoModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            ViewBag.DepartamentoIds = await _produtoService.GetDepartamentosAsync();
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoModel produtoModel)
        {
            if (id != produtoModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.DepartamentoIds = await _produtoService.GetDepartamentosAsync();
                return View(produtoModel);
            }

            await _produtoService.UpdateProdutoAsync(produtoModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _produtoService.DeleteProdutoAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
