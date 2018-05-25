using System;
using System.Net;
using System.IO;


namespace Voicent
{
    /// <summary>
    /// Interface class for making telephone calls using the simple
    /// API of Voicent Gateway.
    /// </summary>
    public class Voicent
    {
        /// <summary>
        /// Default constructor use http://localhost
        /// </summary>
        public Voicent()
        {
            m_host = "localconnectapi";
            m_port = 443;
        }

        /// <summary>
        /// Constructor with host and port
        /// </summary>
        /// <param name="host">Hostname of Voicent Gateway</param>
        /// <param name="port">port number of Voicent Gateway</param>
        public Voicent(string host, int port)
        {
            m_host = host;
            m_port = port;
        }

        /// <summary>
        /// Call the specified phone number and play the text using
        /// text-to-speech engine
        /// </summary>
        /// <param name="phoneno">telephone number to call</param>
        /// <param name="text">text message to play</param>
        /// <param name="selfdelete">if set to one, automatically remove call record on 
        /// gateway after the call is made</param>
        /// <returns>Call Request ID on gateway</returns>
        public string CallText(string phoneno, string text, bool selfdelete)
        {
            // call request url
            string urlstr = "/ocall/callreqHandler.jsp";

            // setting the http post string
            string poststr = "info=Simple Text Call " + phoneno;

            poststr += "&phoneno=" + phoneno;
            poststr += "&firstocc=10";
            poststr += "&selfdelete=";
            poststr += (selfdelete ? "1" : "0");

            poststr += "&txt=" + text;

            // Send Call Request
            String rcstr = PostToGateway(urlstr, poststr);
            return GetRequestID(rcstr);
        }

        /// <summary>
        /// Call the specified phone number and play the audio file
        /// </summary>
        /// <param name="phoneno">telephone number to call</param>
        /// <param name="filename">audio file path name</param>
        /// <param name="selfdelete">if set to one, automatically remove call record on 
        /// gateway after the call is made</param>
        /// <returns>Call Request ID on gateway</returns>
        public string CallAudio(string phoneno, string filename, bool selfdelete)
        {
            // call request url
            string urlstr = "/ocall/callreqHandler.jsp";

            // setting the http post string
            string poststr = "info=Simple Audio Call " + phoneno;

            poststr += "&phoneno=" + phoneno;
            poststr += "&firstocc=10";
            poststr += "&selfdelete=";
            poststr += (selfdelete ? "1" : "0");

            poststr += "&audiofile=" + filename;

            // Send Call Request
            String rcstr = PostToGateway(urlstr, poststr);
            return GetRequestID(rcstr);
        }

        /// <summary>
        /// Get call request status
        /// </summary>
        /// <param name="reqID">Call request ID</param>
        /// <returns>status code</returns>
        public string CallStatus(string reqID)
        {
            // call status url
            string urlstr = "/ocall/callstatusHandler.jsp";
            string poststr = "reqid=" + reqID;

            // Send Call Request
            String rcstr = PostToGateway(urlstr, poststr);

            if (rcstr.IndexOf("^made^") != -1)
                return "Call Made";

            if (rcstr.IndexOf("^failed^") != -1)
                return "Call Failed";

            if (rcstr.IndexOf("^retry^") != -1)
                return "Call Will Retry";

            return "";
        }

        /// <summary>
        /// Remove the call request on the gateway
        /// </summary>
        /// <param name="reqID">Call Request ID</param>
        public void CallRemove(string reqID)
        {
            // call status url
            string urlstr = "/ocall/callremoveHandler.jsp";
            string poststr = "reqid=" + reqID;

            // Send Call Request
            PostToGateway(urlstr, poststr);
        }

        /// <summary>
        /// Invoke Voicent BroadcastByPhone and start the call-till-confirm escalation process
        /// </summary>
        /// <param name="vcastexe">BroadcastByPhone executable file path</param>
        /// <param name="vocfile">BroadcastByPhone call list file path</param>
        /// <param name="wavfile">Audio file, must be PCM 8KHz, 16bit, mono wave file format</param>
        /// <param name="ccode">Confirmation code, numbers only</param>
        public void CallTillConfirm(string vcastexe, string vocfile, string wavfile, string ccode)
        {
            // call request url
            string urlstr = "/ocall/callreqHandler.jsp";

            // setting the http post string
            string poststr = "info=Simple Call till Confirm";
            poststr += "&phoneno=1111111"; // any number
            poststr += "&firstocc=10";
            poststr += "&selfdelete=0";
            poststr += "&startexec=" + vcastexe;

            string cmdline = "\"" + vocfile + "\" -startnow";
            cmdline += " -confirmcode " + ccode;
            cmdline += " -wavfile " + "\"" + wavfile + "\"";

            // add -cleanstatus if necessary

            poststr += "&cmdline=" + cmdline;

            PostToGateway(urlstr, poststr);
        }


        protected string PostToGateway(string urlstr, string poststr)
        {
            Uri url = new Uri("http://" + m_host + ":" + m_port.ToString() + urlstr);
            HttpWebRequest HttpWRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWRequest.Headers.Set("Pragma", "no-cache");
            HttpWRequest.Timeout = 60000;
            HttpWRequest.Method = "POST";
            HttpWRequest.ContentType = "application/x-www-form-urlencoded";

            byte[] PostData = System.Text.Encoding.ASCII.GetBytes(poststr);
            HttpWRequest.ContentLength = PostData.Length;
            Stream tempStream = HttpWRequest.GetRequestStream();
            tempStream.Write(PostData, 0, PostData.Length);
            tempStream.Close();

            HttpWebResponse HttpWResponse = (HttpWebResponse)HttpWRequest.GetResponse();
            Stream receiveStream = HttpWResponse.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream);

            string rcstr = "";
            Char[] read = new Char[256];
            int count = 0;
            while ((count = readStream.Read(read, 0, 256)) > 0)
            {
                rcstr += new String(read, 0, count);
            }
            HttpWResponse.Close();
            readStream.Close();

            return rcstr;
        }

        protected string GetRequestID(string rcstr)
        {
            int index1 = rcstr.IndexOf("[ReqId=");
            if (index1 == -1)
                return "";
            index1 += 7;

            int index2 = rcstr.IndexOf("]", index1);
            if (index2 == -1)
                return "";

            return rcstr.Substring(index1, index2 - index1);
        }


        private string m_host;
        private int m_port;
    }
}