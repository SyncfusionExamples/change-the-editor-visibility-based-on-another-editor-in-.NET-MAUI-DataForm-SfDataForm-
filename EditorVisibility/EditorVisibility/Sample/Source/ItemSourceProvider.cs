using Syncfusion.Maui.DataForm;

namespace EditorVisibility
{
    public class ItemSourceProvider : IDataFormSourceProvider
    {
        public object GetSource(string sourceName)
        {
            if (sourceName == "Country")
            {
                List<string> country = new List<string>() { "USA", "Italy", "India", "Indonesia", "Ireland" };
                return country;
            }

            return new List<string>();
        }
    }
}