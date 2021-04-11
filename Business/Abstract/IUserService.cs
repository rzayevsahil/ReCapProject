using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void ADD(User user);
        User GetByMail(string email);
        IDataResult<User> GetLastUser();
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
