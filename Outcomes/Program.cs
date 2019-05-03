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

            // 'goalswing' of 3 means each non-draw result has a +3 or -3 effect on GD
            Simulation.TestScenario(currentTable, 3);
        }
    }
}
