using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;
using SaglikAsistanim.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Persistence.Measurements;

public sealed class MeasurementRepository(AppDbContext context):GenericRepository<Measurement,int>(context), IMeasurementRepository
{
}
