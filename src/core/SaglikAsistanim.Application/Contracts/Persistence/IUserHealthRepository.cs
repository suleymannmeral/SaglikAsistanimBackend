using SaglikAsistanim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Application.Contracts.Persistence;

public interface IUserHealthRepository:IGenericRepository<UserHealth,int>
{
}
