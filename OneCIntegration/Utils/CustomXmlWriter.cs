using System.Globalization;
using System.Xml;

namespace OneCIntegration.Utils;

public class CustomXmlWriter : XmlWriter
{
    private readonly XmlWriter _innerWriter;

    public CustomXmlWriter(XmlWriter innerWriter)
    {
        _innerWriter = innerWriter;
    }

    public override WriteState WriteState => _innerWriter.WriteState;

    public override void Flush()
    {
        _innerWriter.Flush();
    }

    public override string? LookupPrefix(string ns)
    {
        return _innerWriter.LookupPrefix(ns);
    }

    public override void WriteBase64(byte[] buffer, int index, int count)
    {
        _innerWriter.WriteBase64(buffer, index, count);
    }

    public override void WriteCData(string? text)
    {
        _innerWriter.WriteCData(text);
    }

    public override void WriteCharEntity(char ch)
    {
        _innerWriter.WriteCharEntity(ch);
    }

    public override void WriteChars(char[] buffer, int index, int count)
    {
        _innerWriter.WriteChars(buffer, index, count);
    }

    public override void WriteComment(string? text)
    {
        _innerWriter.WriteComment(text);
    }

    public override void WriteDocType(string name, string? pubid, string? sysid, string? subset)
    {
        _innerWriter.WriteDocType(name, pubid, sysid, subset);
    }

    public override void WriteEndAttribute()
    {
        _innerWriter.WriteEndAttribute();
    }

    public override void WriteEndDocument()
    {
        _innerWriter.WriteEndDocument();
    }

    public override void WriteEndElement()
    {
        _innerWriter.WriteEndElement();
    }

    public override void WriteEntityRef(string name)
    {
        _innerWriter.WriteEntityRef(name);
    }

    public override void WriteFullEndElement()
    {
        _innerWriter.WriteFullEndElement();
    }

    public override void WriteProcessingInstruction(string name, string? text)
    {
        _innerWriter.WriteProcessingInstruction(name, text);
    }

    public override void WriteRaw(char[] buffer, int index, int count)
    {
        _innerWriter.WriteRaw(buffer, index, count);
    }

    public override void WriteRaw(string data)
    {
        if (DateTime.TryParse(data, out DateTime dt))
        {
            // Форматируем дату как нужно
            _innerWriter.WriteRaw(dt.ToString("yyyy-MM-ddTHH:mm:ss"));
        }
        else
        {
            _innerWriter.WriteRaw(data);
        }
    }

    public override void WriteStartAttribute(string? prefix, string localName, string? ns)
    {
        _innerWriter.WriteStartAttribute(prefix, localName, ns);
    }

    public override void WriteStartDocument()
    {
        _innerWriter.WriteStartDocument();
    }

    public override void WriteStartDocument(bool standalone)
    {
        _innerWriter.WriteStartDocument(standalone);
    }

    public override void WriteStartElement(string? prefix, string localName, string? ns)
    {
        _innerWriter.WriteStartElement(prefix, localName, ns);
    }

    public override void WriteString(string? text)
    {
        _innerWriter.WriteString(text);
    }

    public override void WriteSurrogateCharEntity(char lowChar, char highChar)
    {
        _innerWriter.WriteSurrogateCharEntity(lowChar, highChar);
    }

    // Перехватываем запись DateTime и форматируем
    public override void WriteValue(DateTime value)
    {
        string formattedDate = value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
        _innerWriter.WriteValue(formattedDate);
    }

    public override void WriteWhitespace(string? ws)
    {
        _innerWriter.WriteWhitespace(ws);
    }
}