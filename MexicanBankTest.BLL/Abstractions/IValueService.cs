using MexicanBankTest.BLL.Models.Value;

namespace MexicanBankTest.BLL.Abstractions;

public interface IValueService
{
    Task<List<ValueDto>> GetValueAsync(int? code, string? value);
    Task CreateValueAsync(Dictionary<int,string> values);
}