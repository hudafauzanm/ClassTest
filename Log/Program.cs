using System;
using System.Text;
using System.IO;

namespace Log
{
    public class Log
    {
        private string _source;
        private StringBuilder _addFile = new StringBuilder();  

        private string _filePath = "D://";
        public void input()
        {
            string fileName ="log.txt";
            File.Delete(fileName);

            File.AppendAllText(_filePath+fileName, _addFile.ToString());
            _addFile.Clear();
        }
        public string TimeStamp()
        {   

            String timeStamp = DateTime.Now.ToString("[ "+"yyyy"+"-"+"MM"+"-"+"dd"+"T"+"hh"+":"+"mm"+":"+"ss"+"."+"fffZ"+" ]");
            return timeStamp;
        }
        public string emerg(string _source)
        {        
            string emerg = TimeStamp() + " " +" EMERGENCY : "+ Convert.ToString(_source) + "\n";
            _addFile.Append(emerg);
            return null;

        }
        public string alert(string _source)
        {
            string alert = TimeStamp() + " " +" ALERT : "+ Convert.ToString(_source) + "\n";
            _addFile.Append(alert);
            return null;
        }

        public string crit(string _source)
        {
            string crit = TimeStamp() + " " +" CRITICAL : "+ Convert.ToString(_source) + "\n";
            _addFile.Append(crit);
            return null;
        }

        public string err(string _source)
        {
            string err = TimeStamp() + " " +" ERROR : "+ Convert.ToString(_source) + "\n";
            _addFile.Append(err);
            return null;
        }

        public string warning(string _source)
        {
            string warning = TimeStamp() + " " +" WARNING : "+ _source + "\n";
            _addFile.Append(warning);
            return null;
        }

        public string notice(string _source)
        {
            string notice = TimeStamp() + " " +" NOTICE : "+ _source + "\n";
            _addFile.Append(notice);
            return null;
        }

        public string info(string _source)
        {
            string info = TimeStamp() + " " +" INFO : "+ _source + "\n";
            _addFile.Append(info);
            return null;
        }

        public string debug(string _source)
        {
            string debug = TimeStamp() + " " +" DEBUG : "+ _source + "\n";
            _addFile.Append(debug);
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {   
            Log log = new Log();
            log.emerg("Ini adalah");
            log.alert("Ini adalah alert");
            log.crit("Ini adalah Crit");
            log.debug("Ini adalah Debug");
            log.err("ini adalah error");
            log.warning("ini adalah warning");
            log.notice("ini adalah notice");
            log.info("Ini adalah Info");

            log.input();
        
        }
    }
}
