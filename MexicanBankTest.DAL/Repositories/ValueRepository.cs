using MexicanBankTest.DAL.Abstractions;
using MexicanBankTest.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace MexicanBankTest.DAL.Repositories;

public class ValueRepository (TestDbContext dbContext) : IValueRepository
{
    public async Task<List<ValueEntity>> GetAllValuesAsync(int? code, string? value)
    {
        var result = dbContext.Values.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(value))
            result = result.Where(x => x.Value == value);
        if (code.HasValue)
            result = result.Where(x => x.Code == code);
        
        return await result.ToListAsync();
    }

    public async Task SetValuesAsync(List<ValueEntity> values)
    {
        await dbContext.Values.ExecuteDeleteAsync();
        await dbContext.Values.AddRangeAsync(values
            .OrderBy(v=>v.Code));
        await dbContext.SaveChangesAsync();
    }
}