using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Id4Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            var certPath = Path.Combine(@"C:\siva\samples\Id4Sample\Cert\CA.pfx");
            var cert = new X509Certificate2(certPath);
            var certValue = ExportToPEM(cert);


        }


        public static string ExportToPEM(X509Certificate cert)
        {
            var builder = new StringBuilder();

            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            builder.AppendLine(Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.None));
            builder.AppendLine("-----END CERTIFICATE-----");

            return builder.ToString();
        }
    }
}
