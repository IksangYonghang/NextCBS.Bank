namespace Bank.Data;

public class DbOption
{
    public required string Host { get; set; }
    public int Port { get; set; }
    public required string Database { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}