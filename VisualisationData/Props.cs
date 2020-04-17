using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VisualisationData
{
    public class PropsFields
    {
        public String XMLFileName = Environment.CurrentDirectory + "\\settings.xml";
        //Чтобы добавить настройку в программу просто добавьте туда строку вида -
        //public ТИП ИМЯ_ПЕРЕМЕННОЙ = значение_переменной_по_умолчанию;
        public string Host = "localhost";
        public int Port = 3306;
        public string Database = "profile";
        public string Username = "mysql";
        public string Password = "mysql";
    }

    class Props
    {
        public PropsFields Fields;

        public Props()
        {
            Fields = new PropsFields();
        }
        //Запись настроек в файл
        public void WriteXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(PropsFields));

            TextWriter writer = new StreamWriter(Fields.XMLFileName);
            ser.Serialize(writer, Fields);
            writer.Close();
        }
        //Чтение насроек из файла
        public void ReadXml()
        {
            if (File.Exists(Fields.XMLFileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(PropsFields));
                TextReader reader = new StreamReader(Fields.XMLFileName);
                Fields = ser.Deserialize(reader) as PropsFields;
                reader.Close();
            }
            else
            {
                throw new Exception("Ошибка при чтении настроек");
            }
        }
    }
}
