using CiscoNetworkGame.Game.Enemies;

namespace CiscoNetworkGame.Game.Locations;

public class ProfessorsOffice : Location
{
    public ProfessorsOffice()
    {
        Name = "Kancelář profesora Prokeše";
        Description = "Temná kancelář plná certifikátů CCNA, CCNP a CCIE. Na stole leží sada zkouškových testů.";
    }

    public override Enemy CreateEnemy()
    {
        return new ProfessorProkes();
    }

    public override string GetEntryMessage()
    {
        return $"⚠️⚠️⚠️ {base.GetEntryMessage()} ⚠️⚠️⚠️";
    }
}
