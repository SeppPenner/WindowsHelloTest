
namespace WindowsHelloTest2
{
    using System;

    using WindowsHello;

    public class Program
    {
        public static void Main(string[] args)
        {
            var handle = new IntPtr();
            var data = new byte[] { 0x32, 0x32 };
            IAuthProvider provider = new WinHelloProvider("Hello", handle);
            var encryptedData = provider.Encrypt(data);
            var decryptedData = provider.PromptToDecrypt(encryptedData);
        }
    }
}