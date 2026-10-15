namespace wt_lab3_3mvc_lyashuk.Models;

public class Player
{
    public int Id { get; set; }
    public string Nickname { get; set; } = "";
    public string Role { get; set; } = "";
    public int Rating { get; set; }
    public bool IsActive { get; set; }
}