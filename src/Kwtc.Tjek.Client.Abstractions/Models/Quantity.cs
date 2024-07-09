namespace Kwtc.Tjek.Client.Abstractions.Models;

public class Quantity
{
    public Pieces Pieces { get; set; } = default!;

    public Size Size { get; set; } = default!;

    public Unit? Unit { get; set; }
}
