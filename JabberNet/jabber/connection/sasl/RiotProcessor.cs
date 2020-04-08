using JabberNet.jabber.protocol.stream;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

namespace JabberNet.jabber.connection.sasl
{
    /// <summary>
    /// SASL Mechanism EXTERNAL as specified in XEP-0178.
    /// </summary>
    public class RiotProcessor : SASLProcessor
    {
        /// <summary>
        /// Perform the next step
        /// </summary>
        /// <param name="s">Null if it's the initial response</param>
        /// <param name="doc">Document to create Steps in</param>
        /// <returns></returns>
        public override Step step(Step s, XmlDocument doc)
        {
            Debug.Assert(s == null);
            Auth a = new Auth(doc)
            {
                Mechanism = MechanismType.X_RIOT_RSO
            };
            XmlElement rso_token = doc.CreateElement(string.Empty, "rso_token", string.Empty);
            a.AppendChild(rso_token);
            XmlElement pas_token = doc.CreateElement(string.Empty, "pas_token", string.Empty);
            a.AppendChild(pas_token);
            using (MemoryStream ms = new MemoryStream())
            {
                string u = this[USERNAME].Replace("\"", "");
                if ((u == null) || (u == ""))
                {
                    throw new SASLException("Username required (Username is AUTH Token)");
                }
                byte[] bu = Encoding.UTF8.GetBytes(u);
                ms.Write(bu, 0, bu.Length);
                rso_token.InnerText = Encoding.UTF8.GetString(ms.ToArray());
            }
            using (MemoryStream ms = new MemoryStream())
            {
                string u = this[PASSWORD].Replace("\"", "");
                if ((u == null) || (u == ""))
                {
                    throw new SASLException("Password required (Username is AUTH Token)");
                }
                byte[] bu = Encoding.UTF8.GetBytes(u);
                ms.Write(bu, 0, bu.Length);
                pas_token.InnerText = Encoding.UTF8.GetString(ms.ToArray());
            }
            return a;
        }
    }
}
