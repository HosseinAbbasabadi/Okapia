using Okapia.Domain.SeachModels;

namespace Okapia.Application.Utilities
{
    public static class Pager
    {
        public static BaseSerachModel PreparePager(BaseSerachModel searchModel, int rc)
        {
            if (rc % searchModel.PageSize == 0)
            {
                searchModel.PageCount = rc / searchModel.PageSize;
            }
            else
            {
                searchModel.PageCount = (rc / searchModel.PageSize) + 1;
            }

            return searchModel;
        }
    }
}
