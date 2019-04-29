using System;
using System.Collections.Generic;
using System.Linq;

namespace Outcomes
{
    internal enum Result
    {
        Lose = 0,
        Draw = 1,
        Win = 3
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var scenarios = new List<Scenario>
            {
                new Scenario(71, 66)
            };

            int spursGames = 2;
            int arsenalGames = 2;

            for (int s = 0; s < spursGames; s++)
            {
                scenarios = ProcessScenarios(scenarios, true);
            }

            for (int a = 0; a < arsenalGames; a++)
            {
                scenarios = ProcessScenarios(scenarios, false);
            }

            var stTottsScore = scenarios.Count(s => s.IsStTotteringhamsDay);

            Console.ReadKey();
        }

        private static List<Scenario> ProcessScenarios(List<Scenario> scenarios, bool SpursGame)
        {
            var newScenarios = new List<Scenario>();

            var resultOutcomes = Enum.GetValues(typeof(Result)).Cast<Result>();

            foreach (var previousScenario in scenarios)
            {
                foreach (var result in resultOutcomes)
                {
                    newScenarios.Add(new Scenario(previousScenario, SpursGame, result));
                }
            }

            return newScenarios;
        }
    }

    internal class Scenario
    {
        public Scenario(int spursPoints, int arsenalPoints)
        {
            SpursPoints = spursPoints;
            ArsenalPoints = arsenalPoints;
        }

        public Scenario(Scenario previousScenario, bool IsSpursResult, Result result)
        {
            SpursPoints = previousScenario.SpursPoints;
            ArsenalPoints = previousScenario.ArsenalPoints;

            if (IsSpursResult)
                SpursPoints += (int) result;
            else
                ArsenalPoints += (int) result;
        }

        internal int SpursPoints { get; }
        internal int ArsenalPoints { get; }
        public bool IsStTotteringhamsDay => ArsenalPoints > SpursPoints;
    }


}
