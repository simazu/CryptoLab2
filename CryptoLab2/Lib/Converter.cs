using System.Collections;
using System.IO;

namespace CryptoLab2.Lib
{
    public static class Converter
    {
        private static byte[] FileToBytes(string fileName)
        {
            byte[] bytes;
            FileStream fileStream = new(fileName, FileMode.Open, FileAccess.Read);
            bytes = new byte[fileStream.Length];
            int toRead = (int)fileStream.Length;
            int readed = 0;
            while (toRead > 0)
            {
                int n = fileStream.Read(bytes, readed, toRead);
                if (n == 0)
                    break;
                readed += n;
                toRead -= n;
            }
            return bytes;
        }
        public static BitArray FileToBitArray(string fileName)
        {
            byte[] bytes = FileToBytes(fileName);
            BitArray bits = new(bytes);
            for (int i = 0; i < bits.Length; i += 8)
                for (int j = 0; j < 4; j++)
                    (bits[i + j], bits[i + 7 - j]) = (bits[i + 7 - j], bits[i + j]);
            return bits;
        }
        public static string BitArrrayToString(BitArray sequence)
        {
            var res = "";
            for (int i = 0; i < sequence.Length; i++)
                res += sequence[i] ? "1" : "0";
            return res;
        }

        public static BitArray StringToBitArray(string sequence)
        {
            BitArray res = new (sequence.Length);
            for (int i = 0; i < sequence.Length; i++)
                res[i] = sequence[i] == '1';
            return res;
        }

        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            int bytesCount = bits.Count / 8;
            if (bits.Count % 8 != 0) bytesCount++;
            byte[] bytes = new byte[bytesCount];
            int byteNdx = 0, bitNdx = 0;
            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                    bytes[byteNdx] |= (byte)(1 << (7 - bitNdx));
                bitNdx++;
                if (bitNdx == 8)
                {
                    bitNdx = 0;
                    byteNdx++;
                }
            }
            return bytes;
        }
    }
}
