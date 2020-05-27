using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplicationTask.Business.IBusiness;
using WebApplicationTask.Entity.Models;
using WebApplicationTask.Entity.Services;

namespace WebApplicationTask.Business.Business
{
    public class Base_UserBusiness : RepositoryBase<Base_User, int>,IBase_UserBusiness 
    {
        public Base_UserBusiness(DbContext dbContext) : base(dbContext) { }
    }
}
