using System.Collections.Generic;
using Framework;
using Okapia.Domain.Commands.Faq;
using Okapia.Domain.Models;
using Okapia.Domain.SeachModels;
using Okapia.Domain.ViewModels.Faq;

namespace Okapia.Domain.Contracts
{
    public interface IFaqRepository : IRepository<long, Faq>
    {
        EditFaq GetDetails(long id);
        List<FaqViewModel> Search(FaqSearchModel searchModel, out int recordCount);
    }
}
