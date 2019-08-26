using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
using Okapia.Application.Contracts;
using Okapia.Application.Utilities;
using Okapia.Domain.Commands.Link;
using Okapia.Domain.Contracts;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Link;
using Remotion.Linq.Clauses.StreamedData;

namespace Okapia.Application.Applications
{
    public class LinkApplication : ILinkApplication
    {
        private readonly ILinkRepository _linkRepository;
        private readonly ILinkQuery _linkQuery;

        public LinkApplication(ILinkRepository linkRepository, ILinkQuery linkQuery)
        {
            _linkRepository = linkRepository;
            _linkQuery = linkQuery;
        }

        public OperationResult Create(CreateLink command)
        {
            var result = new OperationResult("Links", "Create");
            try
            {
                if (_linkRepository.IsDuplicated(x => x.LinkLabel == command.Label))
                {
                    result.Message = ApplicationMessages.DuplicatedRecord;
                    return result;
                }

                var link = new Link
                {
                    LinkLabel = command.Label,
                    LinkTarget = command.Target,
                    LinkCreationDate = DateTime.Now,
                    LinkCategory = command.Category,
                    LinkIsDeleted = false
                };

                _linkRepository.Create(link);
                _linkRepository.SaveChanges();
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

        public OperationResult Update(EditLink command)
        {
            var result = new OperationResult("Links", "Create");
            try
            {
                if (!_linkRepository.Exists(x => x.LinkId == command.Id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var link = _linkRepository.Get(command.Id);
                link.LinkLabel = command.Label;
                link.LinkTarget = command.Target;
                link.LinkIsDeleted = command.IsDeleted;
                link.LinkCategory = command.Category;
                _linkRepository.SaveChanges();
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
            var result = new OperationResult("Links", "Create");
            try
            {
                if (!_linkRepository.Exists(x => x.LinkId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var link = _linkRepository.Get(id);

                link.LinkIsDeleted = true;

                _linkRepository.SaveChanges();
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
            var result = new OperationResult("Links", "Create");
            try
            {
                if (!_linkRepository.Exists(x => x.LinkId == id))
                {
                    result.Message = ApplicationMessages.EntityNotExists;
                    return result;
                }

                var link = _linkRepository.Get(id);

                link.LinkIsDeleted = false;

                _linkRepository.SaveChanges();
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

        public EditLink GetLinkDetails(int id)
        {
            return _linkRepository.GetDetails(id);
        }

        public List<LinkSiteViewModel> GetLinksForSite()
        {
            return _linkQuery.GetLinks();
        }

        public List<LinkViewModel> Search(LinkSearchModel searchModel, out int recordCount)
        {
            return _linkRepository.Search(searchModel, out recordCount);
        }
    }
}