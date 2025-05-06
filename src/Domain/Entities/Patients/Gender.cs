using CrossCutting.Extensions;
using Domain.Entities.Patients.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities.Patients;

public class Gender
{
    public GenderEnum TypeId { get; private set; }
    public string TypeName => TypeId.TryGetDescription();
    
    private Gender()
    {
    }

    public Gender(ushort typeId)
    {
        TypeId = (GenderEnum)typeId;
    }
    
    [JsonConstructor]
    private Gender(GenderEnum typeId)
    {
        TypeId = typeId;
    }
    
    public static Gender ManCis => new(GenderEnum.ManCis);
    public static Gender WomanCis => new(GenderEnum.WomanCis);
    public static Gender WomanTrans => new(GenderEnum.WomanTrans);
    public static Gender ManTrans => new(GenderEnum.ManTrans);
    public static Gender NonBinary => new(GenderEnum.NonBinary);
    public static Gender PreferNotToSay => new(GenderEnum.PreferNotToSay);
    public static Gender Other => new(GenderEnum.Other);
}