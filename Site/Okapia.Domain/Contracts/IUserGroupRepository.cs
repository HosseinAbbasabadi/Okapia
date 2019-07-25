using System;
using System.Collections.Generic;
using System.Text;

namespace Okapia.Domain.Contracts
{
    public interface IUserGroupRepository
    {
        void Detach(int groupId, long userId);
    }
}
