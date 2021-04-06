using Core.Entites.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
       
        void Add(User user);
     
   
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
    }
}
