using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationTask.Business.Business;
using WebApplicationTask.Business.IBusiness;
using WebApplicationTask.Entity;

namespace WebApplicationTask.Business.Business
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public BaseDbContext BaseDbContext { get; }
        public RepositoryWrapper(BaseDbContext baseDbContext)
        {
            BaseDbContext = baseDbContext;
        }
        private IBase_UserBusiness _UserBusiness = null;
        public IBase_UserBusiness ibase_UserBusiness => _UserBusiness?? new Base_UserBusiness(BaseDbContext);
    }
}
