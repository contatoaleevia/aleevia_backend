using CrossCutting.Repositories;
using Domain.Contracts.Repositories;
using Domain.Entities.IaChats;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class IaChatRatingRepository(ApiDbContext context) : Repository<IaChatRating>(context), IIaChatRatingRepository
{
} 