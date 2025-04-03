using System.ComponentModel;

namespace Equipment.Domain.Entities.OldEnums
{


    //public enum StageType
    //{
    //    [Description("Не выбрано")]
    //    None = 0,
    //    [Description("Решетка")]
    //    Lattice,
    //    [Description("Жироуловитель")]
    //    GreaseTrap,
    //    [Description("Песколовка")]
    //    SandTrap,
    //    [Description("Отстойник")]
    //    Septic,
    //    [Description("Флотатор")]
    //    Flotator,
    //    [Description("Механический фильтр")]
    //    MechFilter,
    //    [Description("Сорбционный фильтр")]
    //    SorptionFilter

    //}
    public enum EquipmentType
    {
        [Description("Не выбрано")]
        None = 0,
        [Description("Решетка")]
        Lattice,
        [Description("Жироуловитель")]
        GreaseTrap,
        [Description("Песколовка")]
        SandTrap,
        [Description("Отстойник")]
        Septic,
        [Description("Флотатор")]
        Flotator,
        [Description("Механический фильтр")]
        MechFilter,
        [Description("Сорбционный фильтр")]
        SorptionFilter

    }


    public static class Helper
    {
        static public string GetDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (field == null)
                return enumValue.ToString();

            object[] attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }

            return enumValue.ToString();
        }
    }

}
