using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.ViewModels.Modal;

namespace Okapia.Query.Query
{
    public class ModalQuery : BaseViewRepository<int, Modal>, IModalQuery
    {
        public ModalQuery(OkapiaViewContext context) : base(context)
        {
        }

        public List<ModalShowViewModel> GetUserModals(long userId)
        {
            var userGroups = (from user in _context.Users
                join userGroup in _context.UserGroups
                    on user.UserId equals userGroup.UserId
                where user.UserId == userId
                select new
                {
                    userGroup.GroupId
                }).ToList();
            var result = new List<ModalShowViewModel>();
            userGroups.ForEach(userGroup =>
            {
                var modals = _context.Modals.Where(x => x.IsDeleted == false)
                    .Where(x => x.ModalStartDate <= DateTime.Now).Where(x => x.ModalEndDate >= DateTime.Now)
                    .Where(x => x.ModalGroupId == userGroup.GroupId).Select(modal => new ModalShowViewModel
                    {
                        ModalId = modal.ModalId,
                        ModalMessage = modal.ModalMessage,
                        ModalPageLink = modal.ModalPageLink,
                        ModalPic = modal.ModalPic,
                        ModalPicAlt = modal.ModalPicAlt,
                        ModalPicDescription = modal.ModalPicDescription,
                        ModalPicTitle = modal.ModalPicTitle,
                        ModalTitle = modal.ModalTitle
                    });
                result.AddRange(modals);
            });
            return result;
        }
    }
}