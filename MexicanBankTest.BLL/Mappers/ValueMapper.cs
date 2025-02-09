using MexicanBankTest.BLL.Models.Value;
using MexicanBankTest.DAL.Entities;

namespace MexicanBankTest.BLL.Mappers;

public static class ValueMapper
{
    public static ValueDto ToDto(this ValueEntity valueEntity)
    {
        ValueDto result = new()
        {
            Id = valueEntity.Id,
            Code = valueEntity.Code,
            Value = valueEntity.Value
        };
        
        return result;
    }
}