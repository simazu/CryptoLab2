using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CryptoLab2.Lib
{
    public static class MSequenceTester
    {
        public static (double, double, double) SerialTest(string sequence, int lenght)
        {
            double refFrequency = sequence.Length / (lenght * Math.Pow(2, lenght));
            Dictionary<string, double> serialFrequencies = new Dictionary<string, double>();
            for (int i = 0; i < sequence.Length; i += lenght)
            {
                string serial;
                try
                {
                    serial = sequence.Substring(i, lenght);
                }
                catch
                {
                    continue;
                }
                if (serialFrequencies.Keys.Contains(serial))
                    serialFrequencies[serial]++;
                else
                    serialFrequencies.Add(serial, 1);
            }

            double criteria = 0;
            foreach (double frequency in serialFrequencies.Values)
                criteria += Math.Pow(frequency - refFrequency, 2) / refFrequency;
            double alphaMin, alphaMax;
            switch (lenght)
            {
                case 2:
                    alphaMin = 7.815;
                    alphaMax = 0.584;
                    break;
                case 3:
                    alphaMin = 14.067;
                    alphaMax = 2.833;
                    break;
                case 4:
                    alphaMin = 24.996;
                    alphaMax = 8.547;
                    break;
                default:
                    return (-1, -1, -1);
            }
            return (alphaMin, alphaMax, Math.Round(criteria, 5));
        }

        public static (double, double, double) PokerTest(string sequence)
        {
            double[] P = new double[7];
            double[] Pref = new double[7];
            double criteria = 0;
            int q = 10;
            int length = (int)sequence.Length / 32 / 5 + (sequence.Length % (32 * 5) > 0 ? 1 : 0);
            for (int i = 0;i < length; i++)
            {
                Dictionary<int, int> quentet = new Dictionary<int, int>();
                for (int j = 0;j < 5; j++)
                {
                    string subSequence;
                    try
                    {
                        subSequence = sequence.Substring(i * 32 * 5 + j * 32, 32);
                    }
                    catch
                    {
                        continue;
                    }

                    BitArray bitSubSequence = new BitArray(subSequence.Length);
                    for (int k = 0; k < subSequence.Length; k++)
                        bitSubSequence[k] = (subSequence[k] == '1' ? true : false);
                    uint uintSubSequence;
                    uintSubSequence = BitConverter.ToUInt32(Converter.BitArrayToByteArray(bitSubSequence),0);
                    int u = (int)(uintSubSequence / (Math.Pow(2, 32)-1) * q); 

                    if (quentet.Keys.Contains(u))
                        quentet[u]++;
                    else
                        quentet.Add(u, 1);
                }

                if (quentet.Count == 5)
                    P[0]++;
                if (quentet.Count == 4)
                    P[1]++;
                if (quentet.Count == 3 && !quentet.ContainsValue(3))
                    P[2]++;
                if (quentet.Count == 3 && quentet.ContainsValue(3))
                    P[3]++;
                if (quentet.Count == 2 && !quentet.ContainsValue(4))
                    P[4]++;
                if (quentet.Count == 2 && quentet.ContainsValue(4))
                    P[5]++;
                if (quentet.Count == 1)
                    P[6]++;
            }
            
            Pref[0] = (q - 1) * (q - 2) * (q - 3) * (q - 4) / Math.Pow(q, 4);
            Pref[1] = 10 * (q - 1) * (q - 2) * (q - 3) / Math.Pow(q, 4);
            Pref[2] = 15 * (q - 1) * (q - 2) / Math.Pow(q, 4);
            Pref[3] = 10 * (q - 1) * (q - 2) / Math.Pow(q, 4);
            Pref[4] = 10 * (q - 1) / Math.Pow(q, 4);
            Pref[5] = 5 * (q - 1) / Math.Pow(q, 4);
            Pref[6] = 1 / Math.Pow(q, 4);

            for (int i = 0; i < 7; i++)
            {
                Pref[i] = Math.Round(Pref[i] * length, 5);
                criteria += Math.Pow(P[i]-Pref[i], 2) / Pref[i];
            }

            return (11.07, 1.61, Math.Round(criteria, 5));
        }

        public static (double, double) CorrelationTest(string sequence, int k)
        {
            double sequenceLength = sequence.Length;
            List<int> bitSequence = new List<int>();
            for (int i = 0; i < sequence.Length; i++)
                bitSequence.Add(sequence[i] == '1' ? 1 : 0);

            double m1 = 0;
            for (int i = 0; i < sequenceLength - k; i++)
                m1 += bitSequence[i];
            m1 /= (sequenceLength - k);

            double m2 = 0;
            for (int i = k; i < sequenceLength; i++)
                m2 += bitSequence[i];
            m2 /= (sequenceLength - k);

            double d1 = 0;
            for (int i = 0; i < sequenceLength - k; i++)
                d1 += Math.Pow((bitSequence[i] - m1), 2);
            d1 /= (sequenceLength - k - 1);

            double d2 = 0;
            for (int i = k; i < sequenceLength; i++)
                d2 += Math.Pow((bitSequence[i] - m2), 2);
            d2 /= (sequenceLength - k - 1);

            double R = 0;
            for (int i = 0; i < sequenceLength - k; i++)
                R += (bitSequence[i] - m1) * (bitSequence[i + k] - m2);
            R = Math.Abs(R) / (sequenceLength - k);
            R /= Math.Sqrt(d1 * d2);
            double Rref = 1 / (sequenceLength - 1) + (2 / (sequenceLength - 1)) * Math.Sqrt(sequenceLength * (sequenceLength - 3) / (sequenceLength + 1));
            
            return (Math.Round(R, 5), Math.Round(Rref, 5));
        }
    }
}
