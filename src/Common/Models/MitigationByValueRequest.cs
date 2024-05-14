namespace stfc.MitigationCalculator.Common.Models;

public class MitigationByValueRequest
{
    public AttackerValues Attacker { get; set; } = null!;
    public DefenderValues Defender{ get; set; } = null!;
}