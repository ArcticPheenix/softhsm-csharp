using System.ComponentModel.DataAnnotations;

namespace softhsm_csharp.Models;

public class Key
{
    public long Id { get; set; }
    public string? KeyMaterial { get; set; }
    [AllowedKeyTypeValue("AES", "RSA", "ECDSA", "ED25519")]
    public string? KeyType { get; set; }
    [AllowedKeySizeValue(128, 256, 2048, 4096)]
    public int KeySize { get; set; }
    public string? Algorithm { get; set; }
    public DateTime CreationDate { get; set; }
    public string? State { get; set; }
    public int Version { get; set; }
}

public class AllowedKeyTypeValueAttribute : ValidationAttribute
{
    private readonly string[] _allowedValues;

    public AllowedKeyTypeValueAttribute(params string[] allowedValues)
    {
        _allowedValues = allowedValues;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || !_allowedValues.Contains(value.ToString()))
        {
            return new ValidationResult($"KeyType must be one of: {string.Join(", ", _allowedValues)}");
        }
        return ValidationResult.Success;
    }
}

public class AllowedKeySizeValueAttribute : ValidationAttribute
{
    private readonly int[] _allowedValues;

    public AllowedKeySizeValueAttribute(params int[] allowedValues)
    {
        _allowedValues = allowedValues;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        int index = Array.IndexOf(_allowedValues, value);
        if (value == null || index == -1)
        {
            return new ValidationResult($"KeySize must be one of: {string.Join(", ", _allowedValues)}");
        }
        return ValidationResult.Success;
    }
}