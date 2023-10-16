namespace softhsm_csharp.Models;

public class Key
{
    public long Id { get; set; }
    public string? KeyMaterial { get; set; }
    public string? KeyType { get; set; }
    public string? KeyUsage {get; set; }
    public int KeySize { get; set; }
    public string? Algorithm { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string? State { get; set; }
    public int Version { get; set; }
}