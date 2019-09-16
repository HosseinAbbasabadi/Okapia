using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Box;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Box;

namespace Okapia.Application.Applications
{
    public class BoxApplication : IBoxApplication
    {
        private readonly IAuthHelper _authHelper;
        private readonly IBoxRepository _boxRepository;
        private readonly IBoxQuery _boxQuery;
        private readonly IJobRepository _jobRepository;

        public BoxApplication(IBoxRepository boxRepository, IAuthHelper authHelper, IBoxQuery boxQuery,
            IJobRepository jobRepository)
        {
            _boxRepository = boxRepository;
            _authHelper = authHelper;
            _boxQuery = boxQuery;
            _jobRepository = jobRepository;
        }

        public OperationResult Create(CreateBox command)
        {
            var result = new OperationResult("Boxes", "Create");
            try
            {
                if (_boxRepository.IsDuplicated(x => x.BoxTitle == command.BoxTitle))
                {
                    result.Message = ApplicationMessages.DuplicatedRecord;
                    return result;
                }

                var box = new Box
                {
                    BoxTitle = command.BoxTitle,
                    BoxBannerPicture = command.BoxBannerPicture,
                    BoxBannerPictureAlt = command.BoxBannerPictureAlt,
                    BoxBannerPictureIsEnabled = command.BoxBannerPictureIsEnabled,
                    BoxBannerPictureLink = command.BoxBannerPictureLink,
                    BoxBannerPictureTitle = command.BoxBannerPictureTitle,
                    BoxColor = command.BoxColor,
                    BoxIcon = command.BoxIcon,
                    BoxLink = command.BoxLink,
                    BoxLinkBtnText = command.BoxLinkBtnText,
                    BoxLinkText = command.BoxLinkText,
                    BoxCreationDate = DateTime.Now,
                    BoxCreatorAccountId = _authHelper.GetCurrnetUserInfo().AuthUserId,
                    BoxIsEnabled = true
                };

                _boxRepository.Create(box);
                _boxRepository.SaveChanges();
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

        public OperationResult Edit(EditBox command)
        {
            var result = new OperationResult("Boxes", "Edit");
            try
            {
                var box = _boxRepository.Get(command.BoxId);
                if (box == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                box.BoxTitle = command.BoxTitle;
                box.BoxColor = command.BoxColor;
                box.BoxIcon = command.BoxIcon;
                box.BoxLinkText = command.BoxLinkText;
                box.BoxLink = command.BoxLink;
                box.BoxLinkBtnText = command.BoxLinkBtnText;
                box.BoxIsEnabled = command.BoxIsEnabled;
                box.BoxBannerPicture = command.BoxBannerPicture;
                box.BoxBannerPictureAlt = command.BoxBannerPictureAlt;
                box.BoxBannerPictureLink = command.BoxBannerPictureLink;
                box.BoxBannerPictureTitle = command.BoxBannerPictureTitle;
                box.BoxBannerPictureIsEnabled = command.BoxBannerPictureIsEnabled;
                _boxRepository.SaveChanges();
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
            var result = new OperationResult("Boxes", "Edit");
            try
            {
                var box = _boxRepository.Get(id);
                if (box == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                box.BoxIsEnabled = true;
                _boxRepository.SaveChanges();
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

        public OperationResult Deactive(int id)
        {
            var result = new OperationResult("Boxes", "Edit");
            try
            {
                var box = _boxRepository.Get(id);
                if (box == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                box.BoxIsEnabled = false;
                _boxRepository.SaveChanges();
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

        public EditBox GetDetails(int id)
        {
            return _boxRepository.GetDetails(id);
        }

        public List<BoxViewModel> GetActiveBoxes()
        {
            return _boxRepository.Get(x => x.BoxIsEnabled).Select(x => new BoxViewModel
            {
                BoxId = x.BoxId,
                BoxTitle = x.BoxTitle
            }).ToList();
        }

        public OperationResult RemoveJobFromBox(int boxId, long jobId)
        {
            var result = new OperationResult("Boxes", "RemoveJobFromBox");
            try
            {
                if (!_jobRepository.Exists(x => x.JobId == jobId))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var box = _boxRepository.GetWithBoxJobs(boxId);
                if (box == null)
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var boxJob = box.BoxJobs.First(x => x.BoxId == boxId && x.JobId == jobId);
                box.BoxJobs.Remove(boxJob);
                _boxRepository.SaveChanges();
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

        public List<BoxViewModel> Search(BoxSearchModel searchModel, out int recordCount)
        {
            return _boxRepository.Search(searchModel, out recordCount);
        }
    }
}