namespace MonsterkampfSimulator
{
	public class Cop : Fighter
	{
		private const string copWinningText = "The police were able to restore general safety.";

        private static string[] copAttackTexts = {
            "'The police made targeted advances",
            "'The Forces used batons",
            "'The forces used water cannons",
            "'The police used tear gas. The deployment is not without controversy"
        };
        private static string[] copDefendTexts = {
            ", but the police were able to fend off the attacks with protective shields.'",
            ". The police had to withdraw temporarily and left the area to the rioters.'",
            ". Several police officers were injured and had to be taken to hospital.'"
        };

        public Cop(float newHLT, float newATK, float newDEF, float newSPD, ConsoleColor newColor)
            :base(newHLT, newATK, newDEF, newSPD)
        {
            Color = newColor;

            attackTexts = copAttackTexts;
            defendTexts = copDefendTexts;

            Race = EType.COP;
            WinningText = copWinningText;
        }
    }
}

