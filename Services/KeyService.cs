namespace softhsm_csharp.Services;

using System.Security.Cryptography;
using softhsm_csharp.Models;

public class KeyService
{
    // TODO: Flesh out business logic for key operations (generation, validation, usage)
    public Key GenerateKey(Key key)
    {
        // TODO: Given the object passed in, generate the approprate key and then return the object.
        switch (key.KeyType)
        {
            case "AES":
                using (Aes aesKey = Aes.Create())
                {
                    aesKey.KeySize = key.KeySize;
                    aesKey.GenerateKey();
                    key.KeyMaterial = Convert.ToBase64String(aesKey.Key);
                }
                break;
            case "RSA":
            case "ECDSA":
            case "ED25519":
            default:
                key.Id = -1;
                break;
        }
        return key;
    }
}