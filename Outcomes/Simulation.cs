using System;
using System.Collections.Generic;
using System.Linq;

namespace Outcomes
{
    internal class Simulation
    {
        public static void TestScenario(Dictionary<Team, PointsAndGoalDifference> currentTable, int goalSwing)
        {
            var scenarios = new List<Scenario>
            {
                new Scenario(currentTable)
            };

            var teams = Enum.GetValues(typeof(Team)).Cast<Team>();

            foreach (var team in teams)
            {
                for (int s = 0; s < currentTable[team].GamesOutstanding; s++)
                {
                    scenarios = ProcessScenarios(scenarios, team, goalSwing);
                }
            }

            var stTottsCount = scenarios.Count(s => s.IsStTotteringhamsDay);
            var jammyStTottsCount = scenarios.Count(s => s.JammyStTotteringhamsDay);
            var superJammyStTottsCount = scenarios.Count(s => s.SuperJammyStTotteringhamsDay);

            var noCLForSpurs = scenarios.Count(s => s.Place(Team.Spurs) > 1);

            var mixedBag1 = scenarios.Count(s => !s.IsStTotteringhamsDay && s.Place(Team.Spurs) > 1);
            var mixedBag2 = scenarios.Count(s => s.IsStTotteringhamsDay && s.Place(Team.Spurs) < 2);

            var sorrowForMike = scenarios.Count(s => s.Place(Team.Arsenal) > 1);
            var toughTitsUtd = scenarios.Count(s => s.Place(Team.ManUtd) > 1);
            var toughTitsChavs = scenarios.Count(s => s.Place(Team.Chelsea) > 1);

            Console.ReadKey();
        }

        private static List<Scenario> ProcessScenarios(IEnumerable<Scenario> previousScenarios, Team team, int goalSwing)
        {
            var newScenarios = new List<Scenario>();

            var resultOutcomes = Enum.GetValues(typeof(Result)).Cast<Result>();

            foreach (var previousScenario in previousScenarios)
            {
                foreach (var result in resultOutcomes)
                {
                    newScenarios.Add(new Scenario(previousScenario, team, result, goalSwing));
                }
            }

            return newScenarios;
        }
    }
}