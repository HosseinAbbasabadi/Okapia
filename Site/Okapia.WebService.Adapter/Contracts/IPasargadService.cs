using System.Collections.Generic;
using Okapia.Domain.Commands.User;
using Okapia.Domain.Models;

namespace Okapia.WebService.Adapter.Contracts
{
    public interface IPasargadService
    {
        /// <summary>
        /// Executes "Register" in web service
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userCards"></param>
        /// <returns></returns>
        bool TryRegister(CreateUser user, List<UserCard> userCards);

        /// <summary>
        /// Executes "EnquireMemebership" in web service
        /// </summary>
        /// <param name="nationalCode"></param>
        /// <returns></returns>
        bool IsAlreadyApiMember(string nationalCode);

        /// <summary>
        /// Executes "CardMembership" in web service
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        bool IsCardAleadyExists(List<string> cards);

        /// <summary>
        /// Execuutes "MapCards" in web service
        /// </summary>
        /// <param name="nationalCode">user national code</param>
        /// <param name="concatedCards">user cards seperated by ','</param>
        /// <returns></returns>
        bool MapCards(string nationalCode, string concatedCards);
    }
}