using MexicanBankTest.DAL.Entities;

namespace MexicanBankTest.DAL.Abstractions;

public interface IValueRepository
{
    Task<List<ValueEntity>> GetAllValuesAsync(int? code, string? value);
    Task SetValuesAsync(List<ValueEntity> values);
}