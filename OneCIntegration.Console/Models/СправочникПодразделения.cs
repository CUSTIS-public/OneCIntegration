using System.Xml.Serialization;

namespace OneCIntegration.Console.Models;

// здесь добавляем новое св-во (не забываем правильный Namespace)
// имена типов не должны совпадать с существующими (от которых наследуемся)
// внимание! обратите внимание на переопределение св-тв через new, это не наследование, а сокрытие
public partial class КлючевыеСвойстваПодразделениеCustom : EnterpriseData1_19.КлючевыеСвойстваПодразделение
{
    [System.Xml.Serialization.XmlElementAttribute("Код", Namespace = "http://v8.1c.ru/edi/zis/EnterpriseData/1.19")]
    public string? Code { get; set; }
}

// далее переопределяем все остальные св-ва по дереву вверх до корня, все xml-атрибуты копируем с родителя
public partial class СправочникПодразделенияCustom : EnterpriseData1_19.СправочникПодразделения
{
    [System.ComponentModel.DataAnnotations.RequiredAttribute(AllowEmptyStrings = true)]
    [System.Xml.Serialization.XmlElementAttribute("КлючевыеСвойства")]
    public new КлючевыеСвойстваПодразделениеCustom КлючевыеСвойства { get; set; }
}

public partial class BodyCustom : EnterpriseData1_19.Body
{
    [XmlElement(ElementName = "Справочник.Подразделения")]
    public new List<СправочникПодразделенияCustom> Подразделения { get; set; } = new List<СправочникПодразделенияCustom>();
}

[XmlRoot(ElementName = "Message", Namespace = "")]
public partial class MessageCustom : EnterpriseData1_19.Message
{
    [XmlElement(ElementName = "Body", Namespace = "http://v8.1c.ru/edi/edi_stnd/EnterpriseData/1.19")]
    public new BodyCustom Body
    {
        get => (BodyCustom)base.Body;
        set => base.Body = value;
    }
}