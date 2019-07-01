using Okapia.Domain.SeachModels;

namespace Okapia.Application.Utilities
{
    public static class Pager
    {
        public static BaseSerachModel PreparePager(BaseSerachModel searchModel, int recordCount)
        {
            if (recordCount % searchModel.PageSize == 0)
            {
                searchModel.PageCount = recordCount / searchModel.PageSize;
            }
            else
            {
                searchModel.PageCount = (recordCount / searchModel.PageSize) + 1;
            }

            searchModel.RecordCount = recordCount;
            return searchModel;
        }
    }
}
