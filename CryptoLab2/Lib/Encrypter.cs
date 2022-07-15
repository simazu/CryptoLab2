using System.Collections;
using System.IO;

namespace CryptoLab2.Lib
{
    public static class Encrypter
    {
        public static void Encrypt(string fileName, string sequence)
        {
            using FileStream fileStream = new(fileName, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fileStream.Length];
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
            toRead = bytes.Length;
            Registers register = new (sequence);
            BitArray fileBits = new (bytes);

            for (int i = 0; i < fileBits.Length; i += 8)
            {
                for (int j = 0; j < 4; j++)
                {
                    (fileBits[i + j], fileBits[i + 7 - j]) = (fileBits[i + 7 - j], fileBits[i + j]);
                }
            }
            BitArray MsequenceBits = Converter.StringToBitArray(register.GetKey(toRead * 8));
            BitArray encodedBits = fileBits.Xor(MsequenceBits);
            byte[] encodedBytes = Converter.BitArrayToByteArray(encodedBits);
            using FileStream fsNew = new ("encrypted.txt", FileMode.Create, FileAccess.Write);
            fsNew.Write(encodedBytes, 0, toRead);
        }

        public static void Decrypt(string filePath, string registerStartSequence)
        {
            using FileStream fileStream = new (filePath, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fileStream.Length];
            int toRead = (int)fileStream.Length;
            int Readed = 0;
            while (toRead > 0)
            {
                int n = fileStream.Read(bytes, Readed, toRead);
                if (n == 0)
                    break;
                Readed += n;
                toRead -= n;
            }
            toRead = bytes.Length;
            Registers register = new (registerStartSequence);
            BitArray bits = new (bytes);
            for (int i = 0; i < bits.Length; i += 8)
                for (int j = 0; j < 4; j++)
                    (bits[i + j], bits[i + 7 - j]) = (bits[i + 7 - j], bits[i + j]);
            BitArray sequenceBits = Converter.StringToBitArray(register.GetKey(toRead * 8));
            BitArray encodedBits = bits.Xor(sequenceBits);
            byte[] encodedBytes = Converter.BitArrayToByteArray(encodedBits);
            using FileStream writefs = new ("decrypted.txt", FileMode.Create, FileAccess.Write);
            writefs.Write(encodedBytes, 0, toRead);

        }
    }
}
