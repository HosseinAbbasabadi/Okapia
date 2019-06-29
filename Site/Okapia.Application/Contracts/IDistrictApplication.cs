using System.Collections.Generic;
using Okapia.Domain.ViewModels.City;

namespace Okapia.Application.Contracts
{
    public interface IDistrictApplication
    {
        List<PlaceViewModel> GetDistrictsBy(int cityId);
    }
}