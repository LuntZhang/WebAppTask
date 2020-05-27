using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationTask.Business.IBusiness;

namespace WebApplicationTask.Business.IBusiness
{
    public interface IRepositoryWrapper
    {
        IBase_UserBusiness ibase_UserBusiness { get; }
    }
}
