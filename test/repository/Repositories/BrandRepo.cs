using Domain.Entities;
using repository.Data;
using repository.Repositories.Interface;

namespace repository.Repositories;

public class BrandRepo:BaseRepo<Brand>,IBrandRepo
{
    public BrandRepo(AppDbContext context):base(context)
    {
        
    }
}
