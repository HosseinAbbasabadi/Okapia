using System;
using System.Collections.Generic;
using System.Text;
using Framework;
using Okapia.Domain.Commands.User;

namespace Okapia.Application.Contracts
{
    public interface IUserApplication
    {
        OperationResult RegisterUser(CreateUser command);
    }
}
