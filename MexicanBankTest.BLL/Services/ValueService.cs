using MexicanBankTest.BLL.Abstractions;
using MexicanBankTest.BLL.Mappers;
using MexicanBankTest.BLL.Models.Value;
using MexicanBankTest.DAL.Abstractions;
using MexicanBankTest.DAL.Entities;

namespace MexicanBankTest.BLL.Services;

public class ValueService (IValueRepository valueRepository) : IValueService
{
    public async Task<List<ValueDto>> GetValueAsync(int? code, string? value)
    {
        var result = new List<ValueDto>();

        var entities = await valueRepository.GetAllValuesAsync(code, value);
        foreach (var entity in entities)
            result.Add(entity.ToDto());
        
        return result;
    }

    public async Task CreateValueAsync(Dictionary<int,string> values)
    {
        var result = new List<ValueEntity>();
        foreach (var value in values)
            result.Add(new ValueEntity()
            {
                Code = value.Key,
                Value = value.Value
            });
        
        await valueRepository.SetValuesAsync(result);
    }
}