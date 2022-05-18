using DemoWebAPI.Models.ViewModels;

namespace DemoWebAPI.WorkerServices
{
    public interface ICategoriesWorkerService
    {
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel? GetLastAdded();
        void Add(CategoryCreateViewModel newCategory);
        CategoryViewModel? GetById(int id);
    }
}
