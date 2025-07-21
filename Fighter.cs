namespace MonsterkampfSimulator
{
    abstract public class Fighter
    {
        public EType Race { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public string WinningText { get; protected set; } = "";

        public float Hlt { get; protected set; }
        public float Atk { get; protected set; }
        public float Def { get; protected set; }
        public float Spd { get; protected set; }

        public float InitHLT { get; protected set; }
        public bool IsDead { get; protected set; }

        protected static Random rnd = new Random();

        protected string[] attackTexts = new string[4];
        protected string[] defendTexts = new string[3];

        public bool isFirstToAttack;

        public Fighter(float _Hlt, float _Atk, float _Def, float _Spd)
        {
            Hlt = _Hlt;
            Atk = _Atk;
            Def = _Def;
            Spd = _Spd;

            InitHLT = _Hlt;
        }

        virtual public void Attack(Fighter other)
        {
            ColoredWrite($"{Race}", Color);

            if (isFirstToAttack)
            {
                Console.WriteLine(" launch their offensive:");
            }
            else
            {
                Console.WriteLine(" responds with a counter-offensive:");
            }

            int luck = rnd.Next(0,4);

            Console.Write(attackTexts[luck]);

            float actualDamage = -1;//default

            switch(luck)
            {
                case 0:
                    actualDamage = 0;
                    break;
                case 1:
                case 2:
                    actualDamage = Atk;
                    break;
                case 3:
                    actualDamage = Atk + 1;
                    break;
                case 4:
                    actualDamage = Atk + 2;
                    break;
                default:
                    actualDamage = Atk;
                    break;
            }

            other.TakeDamage(actualDamage);
        }

        virtual public void TakeDamage(float damage)
        {
            float damageAfterDefense = Math.Max(0,damage - Def);
            DamageAnalysisInfo(damageAfterDefense);
        }

        virtual public void PrintWinningText()
        {
            ColoredWrite(WinningText, Color);
        }

        virtual public void ColoredWrite(string content, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(content);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DamageAnalysisInfo(float damageAfterDefense)
        {
            if (damageAfterDefense >= Hlt)
            {
                Console.Write($". The attack was a fatal strike to the ");
                ColoredWrite($"{Race}", Color);
                Console.Write($".\n");
            }
            else
            {
                Console.WriteLine(defendTexts[Math.Clamp((int)damageAfterDefense, 0, defendTexts.Length - 1)]);
            }

            ColoredWrite($"{Race}", Color);
            Console.Write(" took ");
            ColoredWrite($"<{damageAfterDefense}>", Color);
            Console.Write(" damage, ");

            if (Hlt - damageAfterDefense > 0)
            {
                if (damageAfterDefense == 0)
                {
                    Console.Write("health remained ");
                    ColoredWrite($"<{Hlt}/{InitHLT}>\n", Color);
                }
                else
                {
                    Hlt -= damageAfterDefense;

                    Console.Write("health fell down to ");
                    ColoredWrite($"<{Hlt}/{InitHLT}>\n", Color);
                }
            }
            else
            {
                IsDead = true;
                ColoredWrite($"{Race} was defeated!\n", Color);
            }
        }
    }
    
}

