using SaglikAsistanim.Application.Contracts.Persistence;
using SaglikAsistanim.Domain.Entities;
using SaglikAsistanim.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaglikAsistanim.Persistence.Medications;

public sealed class MedicationRepository(AppDbContext context):GenericRepository<Medication,int>(context), IMedicationRepository
{
}
