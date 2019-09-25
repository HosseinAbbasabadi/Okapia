using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.PageCategory;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.PageCategory;

namespace Okapia.Application.Contracts
{
    public interface IPageCategoryApplication
    {
        OperationResult Create(CreatePageCategory command);
        OperationResult Edit(EditPageCategory command);
        OperationResult Delete(int id);
        OperationResult Activate(int id);
        EditPageCategory GetPageCategoryDetails(int id);
        List<PageCategoryViewModel> GetPageCategories();
        List<PageCategoryViewModel> Search(PageCategorySearchModel searchModel, out int recordCount);
        OperationResult CheckSlugDuplication(string slug);

        //
        List<PageCategoryItemViewModel> GetPageCategoriesForFooter();
        PageCategoryBlogViewModel GetPageCategoryForBlog(string categorySlug);
    }
}