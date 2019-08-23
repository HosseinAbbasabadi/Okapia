using Okapia.Domain.Commands.Setting;
using Okapia.Domain.Models;
using Okapia.Domain.QueryContracts;

namespace Okapia.Query.Query
{
    public class SettingQuery : BaseViewRepository<int, Setting>, ISettingQuery
    {
        public SettingQuery(OkapiaViewContext context) : base(context)
        {
        }
    }
}