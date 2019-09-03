using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Slide;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Slide;

namespace Okapia.Application.Applications
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly ISlideQuery _slideQuery;

        public SlideApplication(ISlideRepository slideRepository, ISlideQuery slideQuery)
        {
            _slideRepository = slideRepository;
            _slideQuery = slideQuery;
        }

        public OperationResult Create(CreateSlide command)
        {
            var result = new OperationResult("Slides", "Create");
            try
            {
                var slide = new Slide
                {
                    SlideTitleText = command.SlideTitleText,
                    SlideDescriptionText = command.SlideDescriptionText,
                    SlideLink = command.SlideLink,
                    SlideName = command.NameImage,
                    SlideTitle = command.TitleImage,
                    SlideAlt = command.AltImage,
                    SlideDescription = command.DescImage,
                    SlideBtnIsVisible = command.SlideBtnIsVisible,
                    SlideBtnText = command.SlideBtnText,
                    SlideIsDeleted = false,
                    SlideCreationDate = DateTime.Now
                };

                _slideRepository.Create(slide);
                _slideRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult Edit(EditSlide command)
        {
            var result = new OperationResult("Slides", "Create");
            try
            {
                if (!_slideRepository.Exists(x => x.SlideId == command.SlideId))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var slide = _slideRepository.Get(command.SlideId);
                slide.SlideTitleText = command.SlideTitleText;
                slide.SlideDescriptionText = command.SlideDescriptionText;
                slide.SlideIsDeleted = command.SlideIsDeleted;
                slide.SlideLink = command.SlideLink;
                slide.SlideName = command.NameImage;
                slide.SlideTitle = command.TitleImage;
                slide.SlideAlt = command.AltImage;
                slide.SlideDescription = command.DescImage;
                slide.SlideBtnIsVisible = command.SlideBtnIsVisible;
                slide.SlideBtnText = command.SlideBtnText;
                _slideRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult Delete(int id)
        {
            var result = new OperationResult("Slides", "Create");
            try
            {
                if (!_slideRepository.Exists(x => x.SlideId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var slide = _slideRepository.Get(id);
                slide.SlideIsDeleted = true;
                _slideRepository.SaveChanges();
                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public OperationResult Activate(int id)
        {
            var result = new OperationResult("Slides", "Create");
            try
            {
                if (!_slideRepository.Exists(x => x.SlideId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var slide = _slideRepository.Get(id);
                slide.SlideIsDeleted = false;
                _slideRepository.SaveChanges();

                result.Message = ApplicationMessages.OperationSuccess;
                result.Success = true;
                return result;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                result.Message = ApplicationMessages.SystemFailure;
                return result;
            }
        }

        public EditSlide GetSlideDetails(int id)
        {
            return _slideRepository.GetSlideDetails(id);
        }

        public List<SlideViewModel> Search(SlideSearchModel searchModel, out int recordCount)
        {
            if (!string.IsNullOrEmpty(searchModel.SlideFromCreationDate))
                searchModel.SlideFromCreationDateG = searchModel.SlideFromCreationDate.ToGeorgianDateTime();
            if (!string.IsNullOrEmpty(searchModel.SlideToCreationDate))
                searchModel.SlideToCreationDateG = searchModel.SlideToCreationDate.ToGeorgianDateTime();
            return _slideRepository.Search(searchModel, out recordCount);
        }

        public List<SliderViewModel> GetSlideShow()
        {
            return _slideQuery.GetSlideShow();
        }
    }
}