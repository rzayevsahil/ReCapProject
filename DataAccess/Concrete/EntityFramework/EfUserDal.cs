using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,ReCapDbContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim 
                             { 
                                 Id = operationClaim.Id, 
                                 Name = operationClaim.Name 
                             };
                return result.ToList();

            }
        }
    }
}
