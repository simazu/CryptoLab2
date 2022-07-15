using System;
using System.Collections;
using System.IO;

namespace CryptoLab2.Lib
{
    public class Registers
    {
        BitArray RegistersState;
        public Registers(int length)
        {
            RegistersState = new BitArray(length);
            Random random = new Random();
            for (int i = 0; i < length - 1; i++)
                RegistersState[i] = random.Next(2) == 1;

            File.WriteAllText("key.txt", Converter.BitArrrayToString(RegistersState));
        }

        public Registers(string startState)
        {
            RegistersState = Converter.StringToBitArray(startState);
        }

        public string GetKey(int length)
        {
            string result = "";
            for (int i = 0; i < length; i++)
            {
                result += RegistersState[RegistersState.Length - 1] ? 1 : 0;
                SetNextState();
            }
            return result;
        }

        private void SetNextState()
        {
            RegistersState.LeftShift(1);
            RegistersState.Set(0, RegistersState[92] ^ RegistersState[90]);
        }
    }
}
