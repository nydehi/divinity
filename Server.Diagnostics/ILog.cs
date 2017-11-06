using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Diagnostics
{
    public delegate void MessageStatusEventHandler(string status);

    public interface ILog
    {
        event MessageStatusEventHandler StatusUpdated;
        void sendMessage(string message);
        /// <summary>
        /// Purpose: not send an ordinary message but something important and 
        /// central that is used through out the program. ie when
        /// scraping websites the actual html code to be sent as a billboard
        /// to being displayed 
        /// </summary>
        /// <param name="message"></param>
        void sendBillBoard(string message);
    }

    public class genericLog : ILog
    {

        public event MessageStatusEventHandler StatusUpdated;

        public void sendMessage(string message)
        {
            // OnThresholdReached(message);
        }
        public void sendBillBoard(string message)
        {
            // OnThresholdReached(message);
        }
        protected virtual void OnThresholdReached(string e)
        {
            //MessageStatusEventHandler handler = StatusUpdated;
            //if (handler != null)
            //{
            //    handler(e);
            //}
        }
    }

    public class consolelog : ILog
    {
        public event MessageStatusEventHandler StatusUpdated;
        public void sendMessage(string message)
        {
            Console.WriteLine(message);
        }
        public void sendBillBoard(string message)
        {
            Console.WriteLine(message);
        }
    }
    public class vslog : ILog
    {
        public event MessageStatusEventHandler StatusUpdated;
        public void sendMessage(string message)
        {
            Debug.Write(message);
        }
        public void sendBillBoard(string message)
        {
            Debug.Write(message);
        }
    }
}
