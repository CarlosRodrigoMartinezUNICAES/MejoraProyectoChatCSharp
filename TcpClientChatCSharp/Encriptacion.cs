using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

public class AESUtil
{
    private static readonly int KeySize = 256; // Tamaño de la clave en bits
    private static readonly int BlockSize = 128; // Tamaño del bloque en bits


    // Método para cifrar datos utilizando AES
    public static byte[] Encrypt(string plainText, byte[] keyBytes)
    {
        byte[] ivBytes = GenerateIV();

        IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CTR/NoPadding");
        cipher.Init(true, new ParametersWithIV(new KeyParameter(keyBytes), ivBytes));

        byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] outputBytes = cipher.DoFinal(inputBytes);

        return CombineArrays(ivBytes, outputBytes);
    }

    // Método para descifrar datos utilizando AES
    public static string Decrypt(byte[] cipherText, byte[] keyBytes)
    {
        byte[] ivBytes = new byte[16]; // El IV está incluido al inicio del texto cifrado

        Array.Copy(cipherText, 0, ivBytes, 0, ivBytes.Length);

        IBufferedCipher cipher = CipherUtilities.GetCipher("AES/CTR/NoPadding");
        cipher.Init(false, new ParametersWithIV(new KeyParameter(keyBytes), ivBytes));

        byte[] inputBytes = new byte[cipherText.Length - ivBytes.Length];
        Array.Copy(cipherText, ivBytes.Length, inputBytes, 0, inputBytes.Length);

        byte[] outputBytes = cipher.DoFinal(inputBytes);

        return Encoding.UTF8.GetString(outputBytes);
    }

    // Método para generar un IV aleatorio
    private static byte[] GenerateIV()
    {
        byte[] iv = new byte[BlockSize / 8];
        SecureRandom random = new SecureRandom();
        random.NextBytes(iv);
        return iv;
    }

    // Método para combinar dos arreglos de bytes
    private static byte[] CombineArrays(byte[] first, byte[] second)
    {
        byte[] result = new byte[first.Length + second.Length];
        Buffer.BlockCopy(first, 0, result, 0, first.Length);
        Buffer.BlockCopy(second, 0, result, first.Length, second.Length);
        return result;
    }
    public static byte[] ConvertTo128Bits(string key)
    {
        // Convierte la clave a bytes utilizando UTF-8
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        // Tomar los primeros 16 bytes de la clave de 256 bits como la nueva clave de 128 bits
        byte[] result = new byte[32];
        Array.Copy(keyBytes, 0, result, 0, 16);
        return result;
    }

}
