using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace StaffManagers
{
    public class Crypto
    {
        private byte[] key;
        public byte[] Key
        {
            get { return key; }
            set { key = value; }
        }

        private byte[] iv;

        public byte[] Iv
        {
            get { return iv; }
            set { iv = value; }
        }

        public static string Base64Encode(string plainText)
        {
            // Encode the input string
            UIntPtr encodedSize = NativeHandler.b64_encoded_size((UIntPtr)plainText.Length);
            byte[] encoded = new byte[(int)encodedSize];
            IntPtr encodedPtr = NativeHandler.b64_encode(System.Text.Encoding.ASCII.GetBytes(plainText), (UIntPtr)plainText.Length);
            Marshal.Copy(encodedPtr, encoded, 0, (int)encodedSize);
            string encodedString = System.Text.Encoding.ASCII.GetString(encoded);
            Console.WriteLine("Encoded: " + encodedString);

            return encodedString;
        }
        public static string Base64Decode(string base64EncodedData)
        {
            UIntPtr decodedSize = NativeHandler.b64_decoded_size(base64EncodedData);
            byte[] decoded = new byte[(int)decodedSize];
            int decodeResult = NativeHandler.b64_decode(base64EncodedData, decoded, decodedSize);

            if (decodeResult == 1)
            {
                // Convert the decoded byte array to a string
                string decodedString = Encoding.ASCII.GetString(decoded).TrimEnd('\0');
                Console.WriteLine("Decoded: " + decodedString);

                return decodedString;
            }
            else
            {
                return "";
            }
        }

        public static string GenerateUUID()
        {
            return Guid.NewGuid().ToString();
        }

        public static byte[] EncryptStringToBytes_Aes(byte[] input, int len, byte[] key, byte[] iv)
        {
            if (NativeHandler.IsInitialized() == 1) NativeHandler.Init();

            // Encrypt the input data
            IntPtr encryptedPtr = NativeHandler.encrypt_aes(Marshal.UnsafeAddrOfPinnedArrayElement(input, 0), input.Length, key, iv);
            byte[] encryptedData = new byte[input.Length];
            Marshal.Copy(encryptedPtr, encryptedData, 0, input.Length);

            return encryptedData;
        }

        public static string DecryptStringFromBytes_Aes(byte[] input, int len, byte[] key, byte[] iv)
        {
            //if (NativeHandler.IsInitialized() == 1) NativeHandler.Init();

            //IntPtr decryptedPtr = NativeHandler.decrypt_aes(Marshal.UnsafeAddrOfPinnedArrayElement(input, 0), input.Length, key, iv);
            //byte[] decryptedData = new byte[input.Length];
            //Marshal.Copy(decryptedPtr, decryptedData, 0, input.Length);

            //return Encoding.ASCII.GetString(decryptedData);

            return "";
        }
    }
}
