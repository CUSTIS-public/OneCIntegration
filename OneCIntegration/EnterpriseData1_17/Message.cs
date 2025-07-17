using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OneCIntegration.EnterpriseData1_17;

[XmlRoot(ElementName = "Message", Namespace = "")]
public partial class Message
{
    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();

    public Message()
    {
        xmlns.Add("msg", "http://www.1c.ru/SSL/Exchange/Message");
        xmlns.Add("xs", "http://www.w3.org/2001/XMLSchema");
        xmlns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
    }

    [XmlElement(ElementName = "Header", Namespace = "http://www.1c.ru/SSL/Exchange/Message")]
    public Header Header { get; set; } = null!;

    [XmlElement(ElementName = "Body", Namespace = "http://v8.1c.ru/edi/edi_stnd/EnterpriseData/1.17")]
    public Body Body { get; set; } = null!;
}

[XmlRoot(ElementName = "Body", Namespace = "http://v8.1c.ru/edi/edi_stnd/EnterpriseData/1.17")]
public class Body
{
    [XmlElement(ElementName = "Справочник.ЕдиницыИзмерения")]
    public List<СправочникЕдиницыИзмерения> ЕдиницыИзмерения { get; set; } = new List<СправочникЕдиницыИзмерения>();

    [XmlElement(ElementName = "Справочник.Номенклатура")]
    public List<СправочникНоменклатура> Номенклатура { get; set; } = new List<СправочникНоменклатура>();

    [XmlElement(ElementName = "Справочник.Склады")]
    public List<СправочникСклады> Склады { get; set; } = new List<СправочникСклады>();

    [XmlElement(ElementName = "Справочник.СтраныМира")]
    public List<СправочникСтраныМира> СтраныМира { get; set; } = new List<СправочникСтраныМира>();

    [XmlElement(ElementName = "Справочник.ТипыЦен")]
    public List<СправочникТипыЦен> ТипыЦен { get; set; } = new List<СправочникТипыЦен>();

    [XmlElement(ElementName = "Справочник.Валюты")]
    public List<СправочникВалюты> Валюты { get; set; } = new List<СправочникВалюты>();

    [XmlElement(ElementName = "Справочник.Пользователи")]
    public List<СправочникПользователи> Пользователи { get; set; } = new List<СправочникПользователи>();

    [XmlElement(ElementName = "Документ.ПересчетТоваров")]
    public List<ДокументПересчетТоваров> ПересчетыТоваров { get; set; } = new List<ДокументПересчетТоваров>();
}