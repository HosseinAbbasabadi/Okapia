namespace Okapia.WebService.Adapter.Contracts
{
    public interface IPasargadService
    {
        /// <summary>
        /// Executes "EnquireMemebership" in web service
        /// </summary>
        /// <param name="nationalCode"></param>
        /// <returns></returns>
        bool IsAlreadyRegistered(string nationalCode);
    }
}
