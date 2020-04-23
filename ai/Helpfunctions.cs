using System;
using System.Collections.Generic;
using System.IO;
using log4net;
using Triton.Common.LogUtilities;

namespace HREngine.Bots
{
    /// <summary>
    ///     The helpfunctions.
    /// </summary>
    public class Helpfunctions
    {
        /// <summary>The logger for this type.</summary>
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        public List<Playfield> storedBoards = new List<Playfield>();


        public static List<T> TakeList<T>(IEnumerable<T> source, int limit)
        {
            var retlist = new List<T>();
            var i = 0;

            foreach (var item in source)
            {
                retlist.Add(item);
                i++;

                if (i >= limit)
                {
                    break;
                }
            }

            return retlist;
        }


        public bool runningbot = false;

        private static Helpfunctions instance;

        public static Helpfunctions Instance
        {
            get { return instance ?? (instance = new Helpfunctions()); }
        }

        private Helpfunctions()
        {
            //System.IO.File.WriteAllText(Settings.Instance.logpath + Settings.Instance.logfile, "");
        }

        private bool writelogg = true;

        public void loggonoff(bool onoff)
        {
            //writelogg = onoff;
        }

        public void createNewLoggfile()
        {
            //System.IO.File.WriteAllText(Settings.Instance.logpath + Settings.Instance.logfile, "");
        }

        public void logg(string s)
        {
            if (!this.writelogg)
            {
                return;
            }

            try
            {
                using (var sw = File.AppendText(Settings.Instance.logpath + Settings.Instance.logfile))
                {
                    sw.WriteLine(s);
                }
            }
            catch
            {
            }

            //Console.WriteLine(s);
        }

        public DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public void ErrorLog(string s)
        {
            //HREngine.API.Utilities.HRLog.Write(s);
            //Console.WriteLine(s);
            Log.Info(s);
        }

        private string sendbuffer = "";

        public void resetBuffer()
        {
            this.sendbuffer = "";
        }

        public void writeToBuffer(string data)
        {
            this.sendbuffer += $"\r\n{data}";
        }

        public void writeBufferToFile()
        {
            var writed = true;
            this.sendbuffer += "<EoF>";
            while (writed)
            {
                try
                {
                    File.WriteAllText($"{Settings.Instance.path}crrntbrd.txt", this.sendbuffer);
                    writed = false;
                }
                catch
                {
                    writed = true;
                }
            }

            this.sendbuffer = "";
        }

        public void writeBufferToActionFile()
        {
            var writed = true;
            this.sendbuffer += "<EoF>";
            this.ErrorLog($"write to action file: {this.sendbuffer}");
            while (writed)
            {
                try
                {
                    File.WriteAllText($"{Settings.Instance.path}actionstodo.txt", this.sendbuffer);
                    writed = false;
                }
                catch
                {
                    writed = true;
                }
            }

            this.sendbuffer = "";
        }
    }
}