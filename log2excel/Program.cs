using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace log2excel
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 1) throw new Exception("usage: log2csv.exe filename");
                //
                if (!File.Exists(args[0])) throw new Exception("File " + args[0] + " not found.");
                //
                processLogFile(args[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void processLogFile(string fileName)
        {
            string outFileName = fileName + ".csv";
            string[] lines = File.ReadAllLines(fileName);
            List<string> outLines = new List<string>();
            foreach (string line in lines) outLines.Add(processLine(line));
            File.WriteAllLines(outFileName, outLines.ToArray());
        }

        private static string processLine(string line)
        {
            List<string> values = createValues(line);
            //
            StringBuilder sb = new StringBuilder();
            foreach (string value in values)
            {
                if (sb.Length > 0) sb.Append(";");
                sb.Append(processValue(value));
            }
            //
            return sb.ToString();
        }

        private static List<string> createValues(string line)
        {
            List<string> values = new List<string>();
            Parser parser = new Parser(line);
            //
            parser.ReadSpace();
            while (!parser.Ended)
            {
                switch (parser.Current)
                {
                    case '\"': values.Add(parser.ReadEnclosed('\"')); break;
                    case '[': values.Add(parser.ReadEnclosed(']')); break;
                    default: values.Add(parser.ReadNonSpace()); break;
                }
                parser.ReadSpace();
            }
            //
            return values;
        }

        private static string processValue(string value)
        {
            bool containsSpecChar = value.Contains("\"") || value.Contains(",") || value.Contains(";");
            value = value.Replace("\"", "\"\"");
            if (containsSpecChar) return '\"' + value + '\"';
            return value;
        }

    }
}

