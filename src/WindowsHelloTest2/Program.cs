// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Hämmer Electronics">
// //   Copyright (c) All rights reserved.
// // </copyright>
// <summary>
//   This class decrypts some data with the Windows Hello API from a file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowsHelloTest2
{
    using System;
    using System.IO;

    using WindowsHello;

    /// <summary>
    /// This class decrypts some data with the Windows Hello API from a file.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Decrypts some data with the Windows Hello API from a file.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Starting");

            var handle = new IntPtr();
            var provider = WinHelloProvider.CreateInstance("Hello", handle);
            provider.SetPersistentKeyName("Test");
            var parentPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.FullName;

            if (parentPath == null)
            {
                Console.WriteLine("Some error occurred with the parent path...");
                return;
            }

            var path = Path.Combine(parentPath, "test.dat");
            var encryptedData = File.ReadAllBytes(path);
            var decryptedData = provider.PromptToDecrypt(encryptedData);

            Console.WriteLine($"Decrypted data: { BitConverter.ToString(decryptedData).Replace("-", " ")}");

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}