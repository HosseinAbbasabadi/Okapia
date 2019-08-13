using System.Collections.Generic;
using Okapia.Domain.Commands.User;

namespace Okapia.WebService.Adapter.Contracts
{
    public interface IPasargadService
    {
        /// <summary>
        /// Executes "Register" in web service
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool TryRegister(CreateUser user);

        /// <summary>
        /// Executes "EnquireMemebership" in web service
        /// </summary>
        /// <param name="nationalCode"></param>
        /// <returns></returns>
        bool IsAlreadyRegistered(string nationalCode);

        /// <summary>
        /// Executes "CardMembership" in web service
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        bool IsCardAleadyExists(List<string> cards);
    }
}