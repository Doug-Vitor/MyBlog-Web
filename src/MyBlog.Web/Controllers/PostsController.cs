using Microsoft.AspNetCore.Mvc;

public class PostsController : Controller
{
    private readonly IPostServices _postServices;

    public PostsController(IPostServices postServices) => _postServices = postServices;

    [HttpPost]
    public async Task<RedirectToActionResult> Create(CreatePostInputModel inputModel)
    {
        HttpResponseViewModel<PostViewModel> viewModel = await _postServices.InsertAsync(inputModel);
        if (viewModel.Success)
            return RedirectToAction(nameof(GetById), new { id = viewModel.ViewModel.Id });
        else return RedirectToAction("Error", "Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> GetById(int? id)
    {
        HttpResponseViewModel<PostViewModel> viewModel = await _postServices.GetByIdAsync(id);
        if (viewModel.Success) 
            return PartialView("_FullPostsPartial", new Tuple<CreatePostInputModel, IEnumerable<PostViewModel>>(new(), new List<PostViewModel>() { viewModel.ViewModel }));
        else return RedirectToAction("Error", "Home", viewModel.ErrorViewModel);
    }

    public async Task<RedirectToActionResult> Edit(int? id, CreatePostInputModel updatedInputModel)
    {
        ErrorViewModel viewModel = await _postServices.UpdateAsync(id, updatedInputModel);
        if (viewModel is null) return RedirectToAction(nameof(GetById), new { id = id });
        else return RedirectToAction("Error", "Home", viewModel);
    }

    public async Task<RedirectToActionResult> Delete(int? id)
    {
        ErrorViewModel viewModel = await _postServices.RemoveAsync(id);
        if (viewModel is null) return RedirectToAction("Index", "Home");
        else return RedirectToAction("Error", "Home", viewModel);
    }
}
