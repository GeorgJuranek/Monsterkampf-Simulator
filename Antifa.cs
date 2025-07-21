namespace MonsterkampfSimulator
{
	public class Antifa : Fighter
	{
        private const string antifaWinningText = "Autonomists set several cars on fire and kept control until the early morning.";

        private static string[] antifaAttackTexts = {
            "'The autonomists were able to gain space with fireworks",
            "'Some of the autonomists threw bottles",
            "'Some of the autonomists threw stones from a nearby building site",
            "'Occasionally, Molotov cocktails prepared by the autonomists were thrown"
        };
        private static string[] antifaDefendTexts = {
            ", but the attack was stopped by self-erected barricades by the autonomists.'",
            ". Individual autonomists ran into backyards and hid in doorways.'",
            ". Several members of Antifa were hospitalized, others were arrested.'"
        };

        public Antifa(float newHLT, float newATK, float newDEF, float newSPD, ConsoleColor newColor)
            : base(newHLT, newATK, newDEF, newSPD)
        {
            Color = newColor;

            attackTexts = antifaAttackTexts;
            defendTexts = antifaDefendTexts;

            Race = EType.ANTIFA;
            WinningText = antifaWinningText;
        }
    }
}

