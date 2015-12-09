// REF: http://stackoverflow.com/questions/9255573/pfx-pkcs12-to-snk-conversion-for-mono
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Mono.Security;

namespace global {
  public static class SNKGen {
    public static void Main(string[] args) {
      string password = Console.ReadLine().Trim();
      GenerateSNK("omise-dotnet.pfx", "omise-dotnet.snk", password);
      GenerateSNK("omise-dotnet-tests.pfx", "omise-dotnet-tests.snk", password);
    }

    private static void GenerateSNK(string pfxSource, string outfile, string password) {
      X509Certificate2 cert = new X509Certificate2(pfxSource, password, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
      RSACryptoServiceProvider provider = (RSACryptoServiceProvider) cert.PrivateKey;

      byte[] array = provider.ExportCspBlob(!provider.PublicOnly);
      using (FileStream fs = new FileStream(outfile, FileMode.Create, FileAccess.Write)) {
        fs.Write(array, 0, array.Length);
      }
    }
  }
}
