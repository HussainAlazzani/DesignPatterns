namespace CSharpDesignPatterns
{
    /// <summary>
    /// Client
    /// </summary>
    public class AdaptorTest
    {
         public static void Run()
        {
            var xmlGraphs = new XmlGraphs();
            var graphViewer = new JsonGraphs(xmlGraphs);

            var jsonData = "data in json text";

            graphViewer.DisplayBarChart(jsonData);
            graphViewer.DisplayPieChart(jsonData);
        }
    }

    /// <summary>
    /// Adapter interface - The target
    /// </summary>
    internal interface IGraphViewer
    {
        void DisplayBarChart(string data);
        void DisplayPieChart(string data);
    }

    /// <summary>
    /// Adapter - This class makes the adaptor interface compatible with the adaptee.
    /// In this example, it does so by converting the json text to xml text.
    /// </summary>
    internal class JsonGraphs : IGraphViewer
    {
        private XmlGraphs adaptee;

        internal JsonGraphs(XmlGraphs adaptee)
        {
            this.adaptee = adaptee;
        }

        public void DisplayBarChart(string data)
        {
            // Convert json file to xml file
            string xmlText = JsonTextToXmlText.Convert(data);
            adaptee.DisplayBarChart(xmlText);
        }

        public void DisplayPieChart(string data)
        {
            // Convert json file to xml file
            string xmlText = JsonTextToXmlText.Convert(data);
            adaptee.DisplayPieChart(xmlText);
        }
    }

    /// <summary>
    /// A utility to convert json string to xml string
    /// </summary>
    internal class JsonTextToXmlText
    {
        internal static string Convert(string jsonData)
        {
            // Convert data from json text to xml text and return result
            return "text in xml format...";
        }
    }

    /// <summary>
    /// Adaptee - Displays graphs when given data in xml text format.
    /// </summary>
    internal class XmlGraphs
    {   
        internal void DisplayBarChart(string xmlData)
        {
            System.Console.WriteLine("display bar chart of " + xmlData);
        }

        internal void DisplayPieChart(string xmlData)
        {
            System.Console.WriteLine("display pie chart of " + xmlData);
        }
    }
}