namespace MonsterkampfSimulator
{
	public class Hooligan : Fighter
	{
        private const string hooliganWinningText = "Violent hooligans rioted in many parts of the city, smashing windows and vandalizing stores.";

        private static string[] hooliganAttackTexts = {
            "'The hooligans threw garbage, including bottles and leftover food",
            "'The hooligans attacked with baseball bats, steel pipes and chains",
            "'One of the hooligans pulled out a switchblade and injured several people",
            "'One of the hooligans fired a sawed-off shotgun and injured several people"
        };
        private static string[] hooliganDefendTexts = {
            ", but the hooligans were able to maintain their position.'",
            ". After this, some of the hooligans entrenched themselves in backyards.'",
            ". Several members of the hooligans were taken to hospital, others were arrested.'"
        };

        public Hooligan(float newHLT, float newATK, float newDEF, float newSPD, ConsoleColor newColor)
            : base(newHLT, newATK, newDEF, newSPD)
        {
            Color = newColor;

            attackTexts = hooliganAttackTexts;
            defendTexts = hooliganDefendTexts;

            Race = EType.HOOLIGAN;
            WinningText = hooliganWinningText;
        }
    }
}

