namespace ResturangOmdome.Models;

public class Omdome
{
    public int Id { get; set; }
    public int RestaurangId { get; set; }
    public int Betyg { get; set; }
    public string Kommentar { get; set; } = string.Empty;
}

