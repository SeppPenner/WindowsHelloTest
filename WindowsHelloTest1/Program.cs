
namespace WindowsHelloTest1
{
    using System;
    using System.IO;

    using WindowsHello;

    /// <summary>
    /// This class encrypts some data with the Windows Hello API and writes the encrypted data to a file.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Encrypts some data with the Windows Hello API and writes the encrypted data to a file.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Starting.");

            var handle = new IntPtr();
            var data = new byte[] { 0x32, 0x32 };
            Console.WriteLine($"Decrypted data: { BitConverter.ToString(data).Replace("-", " ")}");
            var provider = WinHelloProvider.CreateInstance("Hello", handle);
            provider.SetPersistentKeyName("Test");
            var encryptedData = provider.Encrypt(data);
            Console.WriteLine($"Encrypted data: { BitConverter.ToString(encryptedData).Replace("-", " ")}");
            var parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.FullName;
            if (parentPath == null)
            {
                Console.WriteLine("Some error occurred with the parent path...");
            }
        }
    }
}
