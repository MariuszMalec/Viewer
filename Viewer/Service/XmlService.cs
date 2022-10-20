namespace Viewer.Service
{
    public class XmlService
    {
        private readonly IXmlService _xmlService;

        public XmlService(IXmlService xmlService)
        {
            _xmlService = xmlService;
        }

        public string GetFromFileValue(string findtxt)
        {
            return _xmlService.GetFromFileValue(findtxt);
        }
    }
}
