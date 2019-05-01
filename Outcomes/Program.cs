using System.Collections.Generic;

namespace Outcomes
{
    internal enum Team
    {
        Spurs,
        Arsenal,
        Chelsea,
        ManUtd
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var currentTable = new Dictionary<Team, PointsAndGoalDifference>
            {
                {Team.Spurs, new PointsAndGoalDifference(2, 70, 29)},
                {Team.Chelsea, new PointsAndGoalDifference(2,68, 21)},
                {Team.Arsenal, new PointsAndGoalDifference(2,66, 20)},
                {Team.ManUtd, new PointsAndGoalDifference(2,65, 13)}
            };

            Simulation.TestScenario(currentTable, 3);
        }
    }
}
