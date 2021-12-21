using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Text;

namespace KeyVaultAppObject
{
    class Program
    {
        // Application Object in Azure AD
        private static string tenantid = "9ff21861-b439-46ef-9160-c9780676980d";
        private static string clientid = "194aeef7-466c-4bc4-9ac7-b76513ef81df";
        private static string clientsecret = "S_H8..E8DKRUps8tQ6.WO.z0E3UNk8~zNT";


        private static string _Keyvalulturl = "https://demovaultem.vault.azure.net/";
        private static string _secretname = "whizardname";
        private static string _KeyName = "demokey";

        static void Main(string[] args)
        {
            // [+] (A) Fetch Secret 

            // (1) Reference to the Application Object in Azure AD
            //ClientSecretCredential _client_credential = new ClientSecretCredential(tenantid, clientid, clientsecret);

            //SecretClient _secret = new SecretClient(new Uri(_Keyvalulturl), _client_credential);
            //Response<KeyVaultSecret> _response = _secret.GetSecret(_secretname);

            //Console.WriteLine("Secret Value --- " + _response.Value.Value  );
            //Console.ReadKey();

            // [-] ----------------



            // [+] (B) Fetch Key for Encrytion  

            ClientSecretCredential _client_credential = new ClientSecretCredential(tenantid, clientid, clientsecret);

            KeyClient _ketClient = new KeyClient(new Uri(_Keyvalulturl), _client_credential);
            var _key = _ketClient.GetKey(_KeyName);
            var crypto_client = new CryptographyClient(_key.Value.Id, _client_credential);

            byte[] text_to_bytes = Encoding.UTF8.GetBytes("Hello World");
            EncryptResult _result = crypto_client.Encrypt(EncryptionAlgorithm.RsaOaep, text_to_bytes);

            Console.WriteLine("The encrypted text");
            Console.WriteLine(Convert.ToBase64String(_result.Ciphertext));
            Console.ReadKey();
        }
    }
}
