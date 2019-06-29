using System.Collections.Generic;
using Okapia.Domain.ViewModels.City;

namespace Okapia.Application.Contracts
{
    public interface ICityApplication
    {
        List<PlaceViewModel> GetCitiesBy(int provintId);
    }
}