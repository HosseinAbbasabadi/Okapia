using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Slide;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Slide;

namespace Okapia.Application.Contracts
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Edit(EditSlide command);
        OperationResult Delete(int id);
        OperationResult Activate(int id);
        EditSlide GetSlideDetails(int id);
        List<SlideViewModel> Search(SlideSearchModel searchModel, out int recordCount);

        //
        List<SliderViewModel> GetSlideShow();
    }
}