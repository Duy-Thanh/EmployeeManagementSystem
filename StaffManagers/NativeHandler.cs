using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagers
{
    public class NativeHandler
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern UIntPtr b64_encoded_size(UIntPtr inlen);

        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr b64_encode(byte[] input, UIntPtr len);

        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern UIntPtr b64_decoded_size(string input);

        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void b64_generate_decode_table();

        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int b64_isvalidchar(char c);

        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int b64_decode(string input, [Out] byte[] output, UIntPtr len);

        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Init();

        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Close();

        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void generate_random_iv(byte[] iv, int len);

        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void generate_random_key(byte[] key, int len);

        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr encrypt_aes(IntPtr input, int len, byte[] key, byte[] iv);

        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr decrypt_aes(IntPtr input, int len, byte[] key, byte[] iv);
        [DllImport("crypt64.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int IsInitialized();
    }
}
