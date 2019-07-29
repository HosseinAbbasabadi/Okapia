using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Commands.Modal;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Modal;

namespace Okapia.Repository.Repositories
{
    public class ModalRepository : BaseRepository<int, Modal>, IModalRepository
    {
        public ModalRepository(OkapiaContext context) : base(context)
        {
            _context = context;
        }

        public Modal GetModal(int id)
        {
            return _context.Modals.FirstOrDefault(x => x.ModalId == id);
        }

        public EditModal GetModalDetails(int id)
        {
            var query = from modal in _context.Modals
                join grp in _context.Groups
                    on modal.ModalGroupId equals grp.GroupId
                select new EditModal
                {
                    Id = modal.ModalId,
                    Title = modal.ModalTitle,
                    Message = modal.ModalMessage,
                    GroupId = grp.GroupId,
                    StartDate = modal.ModalStartDate.ToFarsi(),
                    EndDate = modal.ModalEndDate.ToFarsi(),
                    IsDeleted = modal.IsDeleted,
                    PicAlt = modal.ModalPicAlt,
                    PicTitle = modal.ModalPicTitle,
                    PageLink = modal.ModalPageLink,
                    PicName = modal.ModalPic,
                    PicDescription = modal.ModalPicDescription
                };
            return query.FirstOrDefault(x => x.Id == id);
        }

        public List<ModalViewModel> Search(ModalSearchModel searchModel, out int recordCount)
        {
            var query = from modal in _context.Modals
                join grp in _context.Groups
                    on modal.ModalGroupId equals grp.GroupId
                select new ModalViewModel
                {
                    ModalId = modal.ModalId,
                    ModalTitle = modal.ModalTitle,
                    ModalMessage = modal.ModalMessage,
                    ModalGroup = grp.GroupName,
                    ModalGroupId = grp.GroupId,
                    ModalStartDate = modal.ModalStartDate.ToFarsi(),
                    ModalStartDateG = modal.ModalStartDate,
                    ModalEndDate = modal.ModalEndDate.ToFarsi(),
                    ModalEndDateG = modal.ModalEndDate,
                    IsDeleted = modal.IsDeleted,
                    ModalPageLink = modal.ModalPageLink,
                    ModalPic = modal.ModalPic
                };

            if (!string.IsNullOrEmpty(searchModel.ModalTitle))
                query = query.Where(x => x.ModalTitle.Contains(searchModel.ModalTitle));
            if (searchModel.ModalStartDateG != default(DateTime))
                query = query.Where(x => x.ModalStartDateG >= searchModel.ModalStartDateG);
            if (searchModel.ModalEndDateG != default(DateTime))
                query = query.Where(x => x.ModalEndDateG <= searchModel.ModalEndDateG);
            if (searchModel.ModalGroupId != 0)
                query = query.Where(x => x.ModalGroupId == searchModel.ModalGroupId);
            query = query.Where(x => x.IsDeleted == searchModel.IsDeleted);
            query = query.OrderByDescending(x => x.ModalId).Skip(searchModel.PageSize * searchModel.PageIndex)
                .Take(searchModel.PageSize);
            recordCount = query.Count();
            return query.ToList();
        }
    }
}