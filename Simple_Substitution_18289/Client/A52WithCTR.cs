//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Security.Cryptography;

//namespace Client
//{

//    public class A52WithCTR
//    {
//        private ulong key; // Ključ za A5/2 algoritam
//        private ulong frameNumber; // Broj okvira za A5/2 algoritam
//        private CTRMode ctrMode; // CTR režim rada blok šifre

//        public A52WithCTR(ulong key, ulong frameNumber)
//        {
//            this.key = key;
//            this.frameNumber = frameNumber;
//            this.ctrMode = new CTRMode();
//        }

//        public byte[] Encrypt(string plaintext)
//        {
//            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
//            byte[] keystream = GenerateA52Keystream(plaintextBytes.Length);

//            byte[] ciphertext = new byte[plaintextBytes.Length];

//            for (int i = 0; i < plaintextBytes.Length; i++)
//            {
//                ciphertext[i] = (byte)(plaintextBytes[i] ^ keystream[i]);
//            }

//            return ciphertext;
//        }

//        private byte[] GenerateA52Keystream(int length)
//        {
//            A52Algorithm a52 = new A52Algorithm(key, frameNumber);
//            return a52.GenerateKeystream(length);
//        }

//        //public static void Main()
//        //{
//        //    ulong a52Key = 0x0123456789ABCDEF;
//        //    ulong frameNumber = 0x0000000000000000;

//        //    A52WithCTR a52WithCTR = new A52WithCTR(a52Key, frameNumber);

//        //    string plaintext = "Hello, World!";
//        //    byte[] ciphertext = a52WithCTR.Encrypt(plaintext);

//        //    Console.WriteLine("Encrypted: " + BitConverter.ToString(ciphertext).Replace("-", ""));
//        //}
//    }

//    public class A52Algorithm
//    {
//        private const int RegisterSize = 64;
//        private ulong r1, r2, r3; // Tri registra za A5/2

//        public A52Algorithm(ulong key, ulong frameNumber)
//        {
//            InitializeRegisters(key, frameNumber);
//        }

//        private void InitializeRegisters(ulong key, ulong frameNumber)
//        {
//            r1 = key;
//            r2 = frameNumber;
//            r3 = 0x0; // R3 se inicijalizuje na nulu
//        }

//        public byte[] GenerateKeystream(int length)
//        {
//            byte[] keystream = new byte[length];

//            for (int i = 0; i < length; i++)
//            {
//                byte keyBit = GetKeyBit();
//                keystream[i] = keyBit;

//                ClockRegisters();
//            }

//            return keystream;
//        }

//        private void ClockRegisters()
//        {
//            byte majority = (byte)((r1 & r2) | (r1 & r3) | (r2 & r3));
//            majority = (byte)(majority & 0x01);

//            if ((r1 & 0x01) == majority)
//            {
//                r1 = (r1 >> 1) | ((r1 & 0x01) << (RegisterSize - 1));
//            }

//            if ((r2 & 0x01) == majority)
//            {
//                r2 = (r2 >> 1) | ((r2 & 0x01) << (RegisterSize - 1));
//            }

//            if ((r3 & 0x01) == majority)
//            {
//                r3 = (r3 >> 1) | ((r3 & 0x01) << (RegisterSize - 1));
//            }
//        }

//        private byte GetKeyBit()
//        {
//            return (byte)((r1 & 0x01) ^ (r2 & 0x01) ^ (r3 & 0x01));
//        }
//    }

//    public class CTRMode
//    {
//        private SymmetricAlgorithm blockCipher;
//        private byte[] iv;

//        public CTRMode(SymmetricAlgorithm blockCipher)
//        {
//            this.blockCipher = blockCipher ?? throw new ArgumentNullException(nameof(blockCipher));
//            this.iv = new byte[blockCipher.BlockSize / 8];
//        }

//        public byte[] Encrypt(byte[] plaintext)
//        {
//            int blockSize = blockCipher.BlockSize / 8;
//            byte[] ciphertext = new byte[plaintext.Length];

//            for (int i = 0; i < plaintext.Length; i += blockSize)
//            {
//                byte[] counterBlock = GetCounterBlock(i / blockSize);

//                for (int j = 0; j < blockSize && (i + j) < plaintext.Length; j++)
//                {
//                    ciphertext[i + j] = (byte)(plaintext[i + j] ^ counterBlock[j]);
//                }

//                blockCipher.IV = counterBlock;
//                blockCipher.Mode = CipherMode.ECB;

//                using (ICryptoTransform encryptor = blockCipher.CreateEncryptor())
//                {
//                    encryptor.TransformBlock(counterBlock, 0, blockSize, counterBlock, 0);
//                }
//            }

//            return ciphertext;
//        }

//        private byte[] GetCounterBlock(int blockNumber)
//        {
//            byte[] counterBlock = new byte[iv.Length];
//            Array.Copy(iv, 0, counterBlock, 0, iv.Length);

//            byte[] blockNumberBytes = BitConverter.GetBytes(blockNumber);

//            for (int i = 0; i < Math.Min(blockNumberBytes.Length, counterBlock.Length); i++)
//            {
//                counterBlock[i] ^= blockNumberBytes[i];
//            }

//            return counterBlock;
//        }
//    }
//}
