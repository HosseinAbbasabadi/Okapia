using System;
using System.Collections.Generic;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Modal;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Modal;
using Okapia.Repository;

namespace Okapia.Application.Applications
{
    public class ModalApplication : IModalApplication
    {
        private readonly IModalRepository _modalRepository;

        public ModalApplication(IModalRepository modalRepository)
        {
            _modalRepository = modalRepository;
        }

        public OperationResult Create(CreateModal command)
        {
            var result = new OperationResult("Modal", "Create");
            try
            {
                if (_modalRepository.IsDuplicated(x => x.ModalTitle == command.Title))
                {
                    result.Message = ApplicationMessages.DuplicatedRecord;
                    return result;
                }

                if (!string.IsNullOrEmpty(command.StartDate))
                    command.StartDateG = command.StartDate.ToGeorgianDateTime();
                if (!string.IsNullOrEmpty(command.EndDate))
                    command.EndDateG = command.EndDate.ToGeorgianDateTime();
                var modal = new Modal
                {
                    ModalTitle = command.Title,
                    ModalMessage = command.Message,
                    ModalGroupId = command.GroupId,
                    ModalStartDate = command.StartDateG,
                    ModalEndDate = command.EndDateG,
                    IsDeleted = false,
                    ModalPicAlt = command.PicAlt,
                    ModalPicTitle = command.PicTitle,
                    ModalCreationDate = DateTime.Now,
                    ModalPageLink = command.PageLink,
                    ModalPic = command.PicName,
                    ModalPicDescription = command.PicDescription
                };
                _modalRepository.Create(modal);
                _modalRepository.SaveChanges();
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

        public OperationResult Edit(EditModal command)
        {
            var result = new OperationResult("Modal", "Edit");
            try
            {
                if (!_modalRepository.Exists(x => x.ModalId == command.Id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                if (!string.IsNullOrEmpty(command.StartDate) && !string.IsNullOrEmpty(command.EndDate))
                {
                    command.StartDateG = command.StartDate.ToGeorgianDateTime();
                    command.EndDateG = command.EndDate.ToGeorgianDateTime();
                }
                else
                {
                    result.Message = ApplicationMessages.StartEndDateIsRequired;
                    return result;
                }

                var modal = new Modal
                {
                    ModalId = command.Id,
                    ModalTitle = command.Title,
                    ModalMessage = command.Message,
                    ModalGroupId = command.GroupId,
                    ModalStartDate = command.StartDateG,
                    ModalEndDate = command.EndDateG,
                    IsDeleted = command.IsDeleted,
                    ModalPicAlt = command.PicAlt,
                    ModalPicTitle = command.PicTitle,
                    ModalCreationDate = DateTime.Now,
                    ModalPageLink = command.PageLink,
                    ModalPic = command.PicName,
                    ModalPicDescription = command.PicDescription
                };
                _modalRepository.Update(modal);
                _modalRepository.SaveChanges();
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
            var result = new OperationResult("Modal", "Delete");
            try
            {
                var modal = _modalRepository.GetModal(id);
                modal.IsDeleted = true;
                _modalRepository.SaveChanges();
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
            var result = new OperationResult("Modal", "Activate");
            try
            {
                var modal = _modalRepository.GetModal(id);
                modal.IsDeleted = false;
                _modalRepository.SaveChanges();
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

        public EditModal GetModalDetails(int id)
        {
            var modalDetails = _modalRepository.GetModalDetails(id);
            return modalDetails;
        }

        public List<ModalViewModel> Search(ModalSearchModel searchModel, out int recordCount)
        {
            if (!string.IsNullOrEmpty(searchModel.ModalStartDate))
                searchModel.ModalStartDateG = searchModel.ModalStartDate.ToGeorgianDateTime();
            if (!string.IsNullOrEmpty(searchModel.ModalEndDate))
                searchModel.ModalEndDateG = searchModel.ModalEndDate.ToGeorgianDateTime();
            return _modalRepository.Search(searchModel, out recordCount);
        }
    }
}