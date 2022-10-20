namespace Viewer.Models
{
    public class InputDataXml
    {
        public string infile { get; set; }
        public string machine { get; set; }
        public string outfile { get; set; }
        public string catpart { get; set; }

        public string xmlpart { get; set; }

        public string xlspart { get; set; }

        public string catpartfirst { get; set; }

        public string catpartend { get; set; }

        public string xmlpartfirst { get; set; }
        public string xmlpartend { get; set; }

        public string Clampingmethod { get; set; }

        public string pinwelding { get; set; }

        public string millshroud { get; set; }

        public string readxls { get; set; }
        public string runconfiguration { get; set; }

        public string runbm { get; set; }

        public string runcmm { get; set; }

        public string createvcproject { get; set; }

        public string selectlanguage { get; set; } //enum
        public string Prerawbox { get; set; }

        public string createraport { get; set; }

        public string RootMfgDir { get; set; }

        public string clickcancel { get; set; }

        public string BMTemplate { get; set; }

        public string BMTemplateFile { get; set; }

        public string IsXML { get; set; }

        public string TypeBlade { get; set; } //enum

        public string middleTol { get; set; }

        public string admin { get; set; }

        public string ClampFromTemplate { get; set; }

        public string FIG_N { get; set; }
    }
}