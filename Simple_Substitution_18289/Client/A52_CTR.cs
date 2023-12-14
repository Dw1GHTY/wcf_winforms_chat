using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class A52_CTR
    {
        private const uint R1MASK = 0x07FFFF; // 19 bits, numbered 0..18
        private const uint R2MASK = 0x3FFFFF; // 22 bits, numbered 0..21
        private const uint R3MASK = 0x7FFFFF; // 23 bits, numbered 0..22
        private const uint R4MASK = 0x01FFFF; // 17 bits, numbered 0..16

        private const uint R4TAP1 = 0x000400; // bit 10
        private const uint R4TAP2 = 0x000008; // bit 3
        private const uint R4TAP3 = 0x000080; // bit 7

        private const uint R1TAPS = 0x072000; // bits 18,17,16,13
        private const uint R2TAPS = 0x300000; // bits 21,20
        private const uint R3TAPS = 0x700080; // bits 22,21,20,7
        private const uint R4TAPS = 0x010800; // bits 16,11

        private byte[] key = new byte[8];
        private uint frame;
        private uint R1, R2, R3, R4;

        private uint counter; // CTR MOD counter

        private static uint parity(uint x)
        {
            x ^= x >> 16;
            x ^= x >> 8;
            x ^= x >> 4;
            x ^= x >> 2;
            x ^= x >> 1;
            return x & 1;
        }

        private uint ClockOne(uint reg, uint mask, uint taps, uint loadedBit)
        {
            uint t = reg & taps;
            reg = (reg << 1) & mask;
            reg |= parity(t);
            reg |= loadedBit;
            return reg;
        }

        private uint Majority(uint w1, uint w2, uint w3)
        {
            int sum = (w1 != 0 ? 1 : 0) + (w2 != 0 ? 1 : 0) + (w3 != 0 ? 1 : 0);
            return (sum >= 2) ? 1u : 0u;
        }

        private void Clock(bool allP, uint loaded)
        {
            uint maj = Majority(R4 & R4TAP1, R4 & R4TAP2, R4 & R4TAP3);
            if (allP || ((R4 & R4TAP1) != 0 && maj != 0))
                R1 = ClockOne(R1, R1MASK, R1TAPS, loaded << 15);
            if (allP || ((R4 & R4TAP2) != 0 && maj != 0))
                R2 = ClockOne(R2, R2MASK, R2TAPS, loaded << 16);
            if (allP || ((R4 & R4TAP3) != 0 && maj != 0))
                R3 = ClockOne(R3, R3MASK, R3TAPS, loaded << 18);
            R4 = ClockOne(R4, R4MASK, R4TAPS, loaded << 10);
        }

        private uint GetBit()
        {
            uint topBits = (((R1 >> 18) ^ (R2 >> 21) ^ (R3 >> 22)) & 0x01);

            uint delayBit = 0;
            delayBit = (topBits ^
                Majority(R1 & 0x8000, (~R1) & 0x4000, R1 & 0x1000) ^
                Majority((~R2) & 0x10000, R2 & 0x2000, R2 & 0x200) ^
                Majority(R3 & 0x40000, R3 & 0x10000, (~R3) & 0x2000));

            uint nowBit = delayBit;

            return nowBit;
        }

        public void KeySetup(byte[] keyBytes, uint frameNumber)
        {
            Array.Copy(keyBytes, key, keyBytes.Length);
            frame = frameNumber;

            R1 = R2 = R3 = R4 = 0;

            for (int i = 0; i < 64; i++)
            {
                Clock(true, 0);
                uint keyBit = (uint)((key[i / 8] >> (i % 8)) & 1);
                R1 ^= keyBit; R2 ^= keyBit; R3 ^= keyBit;
                R4 ^= keyBit;
            }

            for (int i = 0; i < 22; i++)
            {
                Clock(true, i == 21 ? 1u : 0u);
                uint frameBit = (frame >> i) & 1;
                R1 ^= frameBit; R2 ^= frameBit; R3 ^= frameBit;
                R4 ^= frameBit;
            }

            for (int i = 0; i < 100; i++)
            {
                Clock(false, 0);
            }

            GetBit();
        }

        public void Run(out byte[] AtoBkeystream, out byte[] BtoAkeystream)
        {
            AtoBkeystream = new byte[15];
            BtoAkeystream = new byte[15];

            for (int i = 0; i <= 113 / 8; i++)
            {
                AtoBkeystream[i] = BtoAkeystream[i] = 0;
            }

            for (int i = 0; i < 114; i++)
            {
                Clock(false, 0);
                AtoBkeystream[i / 8] |= (byte)(GetBit() << (7 - (i % 8)));
            }

            for (int i = 0; i < 114; i++)
            {
                Clock(false, 0);
                BtoAkeystream[i / 8] |= (byte)(GetBit() << (7 - (i % 8)));
            }
        }

        public void Test()
        {
            byte[] keyBytes = { 0x00, 0xfc, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff };
            uint frameNumber = 0x21;

            byte[] goodAtoB = { 0xf4, 0x51, 0x2c, 0xac, 0x13, 0x59, 0x37, 0x64, 0x46, 0x0b, 0x72, 0x2d, 0xad, 0xd5, 0x00 };
            byte[] goodBtoA = { 0x48, 0x00, 0xd4, 0x32, 0x8e, 0x16, 0xa1, 0x4d, 0xcd, 0x7b, 0x97, 0x22, 0x26, 0x51, 0x00 };

            byte[] AtoB, BtoA;
            KeySetup(keyBytes, frameNumber);
            Run(out AtoB, out BtoA);

            Console.WriteLine("key: 0x" + BitConverter.ToString(key));
            Console.WriteLine("frame number: 0x" + frame.ToString("X6"));
            Console.WriteLine("known good output:");
            Console.Write(" A->B: 0x" + BitConverter.ToString(goodAtoB));
            Console.Write("  B->A: 0x" + BitConverter.ToString(goodBtoA));
            Console.WriteLine("\nobserved output:");
            Console.Write(" A->B: 0x" + BitConverter.ToString(AtoB));
            Console.Write("  B->A: 0x" + BitConverter.ToString(BtoA));

            if (ArraysEqual(AtoB, goodAtoB) && ArraysEqual(BtoA, goodBtoA))
            {
                Console.WriteLine("\nSelf-check succeeded: everything looks ok.");
            }
            else
            {
                Console.WriteLine("\nCODE IS NOT WORKING PROPERLY");
            }
        }

        private static bool ArraysEqual(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                    return false;
            }

            return true;
        }

        public byte[] Encrypt(string message)
        {
            byte[] plaintext = Encoding.UTF8.GetBytes(message);
            byte[] ciphertext = new byte[plaintext.Length];

            byte[] keyStream;
            GetKeystream(out keyStream, plaintext.Length * 8); // Uzmi dovoljan broj bitova za enkripciju

            for (int i = 0; i < plaintext.Length; i++)
            {
                ciphertext[i] = (byte)(plaintext[i] ^ keyStream[i]);
            }

            return ciphertext;
        }
        public string Decrypt(byte[] ciphertext)
        {
            byte[] decrypted = new byte[ciphertext.Length];

            byte[] keyStream;
            GetKeystream(out keyStream, ciphertext.Length * 8); // Uzmi dovoljan broj bitova za dekripciju

            for (int i = 0; i < ciphertext.Length; i++)
            {
                decrypted[i] = (byte)(ciphertext[i] ^ keyStream[i]);
            }

            return Encoding.UTF8.GetString(decrypted);
        }
        public byte[] EncryptCTR(string message)
        {
            byte[] plaintext = Encoding.UTF8.GetBytes(message);
            byte[] ciphertext = new byte[plaintext.Length];
            byte[] counterBlock = new byte[8];
            counter = 0; // Resetuj brojač

            for (int i = 0; i < plaintext.Length; i++)
            {
                GetKeystream(out counterBlock, 8); // Generiši keystream za 8 bitova
                ciphertext[i] = (byte)(plaintext[i] ^ counterBlock[0]);
                counter++; // Povećaj brojač za sledeći blok
            }

            return ciphertext;
        }
        public string DecryptCTR(byte[] ciphertext)
        {
            byte[] decrypted = new byte[ciphertext.Length];
            byte[] counterBlock = new byte[8];
            counter = 0; // Resetuj brojač

            for (int i = 0; i < ciphertext.Length; i++)
            {
                GetKeystream(out counterBlock, 8); // Generiši keystream za 8 bitova
                decrypted[i] = (byte)(ciphertext[i] ^ counterBlock[0]);
                counter++; // Povećaj brojač za sledeći blok
            }

            return Encoding.UTF8.GetString(decrypted);
        }


        public void GetKeystream(out byte[] keyStream, int length)
        {
            keyStream = new byte[length];

            for (int i = 0; i < length; i++)
            {
                Clock(false, 0);
                keyStream[i] = (byte)GetBit();
            }

            counter++; // inkrementiranje brojaca
        }
    }
}
