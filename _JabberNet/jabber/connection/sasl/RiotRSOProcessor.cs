using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;
using JabberNet.jabber.protocol.stream;

namespace JabberNet.jabber.connection.sasl
{
    /// <summary>
    /// SASL Mechanism RIOT RSO
    /// </summary>
    public class RiotRSOProcessor : SASLProcessor
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
            MemoryStream ms = new MemoryStream();
            string u = this[USERNAME].Replace("\"", "");
            if ((u == null) || (u == ""))
            {
                throw new SASLException("Username required (Username is AUTH Token)");
            }
            byte[] bu = Encoding.UTF8.GetBytes(u);
            ms.Write(bu, 0, bu.Length);
            a.Bytes = ms.ToArray();
            return a;
        }
    }
}
