using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationTask.Entity.Models;
using WebApplicationTask.Entity.Services;

namespace WebApplicationTask.Business.IBusiness
{
    public interface IBase_UserBusiness:IRepositoryBase<Base_User>, IRepositoryBaseById<Base_User,int>
    {

    }
}
