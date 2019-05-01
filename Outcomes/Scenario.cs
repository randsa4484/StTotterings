using System;
using System.Collections.Generic;
using System.Linq;

namespace Outcomes
{
    internal class Scenario
    {
        public Dictionary<Team, PointsAndGoalDifference> Teams { get; }

        public Scenario(Dictionary<Team, PointsAndGoalDifference> teams)
        {
            Teams = teams;
        }

        public Scenario(Scenario previousScenario, Team team, Result result, int goalSwing)
        {
            Teams = new Dictionary<Team, PointsAndGoalDifference>();

            foreach (var teamAndPoints in previousScenario.Teams)
            {
                var points = teamAndPoints.Value.Points;
                var goalDiff = teamAndPoints.Value.GoalDifference;
                var gamesOutstanding = teamAndPoints.Value.GamesOutstanding - 1;

                if (teamAndPoints.Key == team)
                {
                    points += (int) result;
                    switch (result)
                    {
                        case Result.Win:
                            goalDiff += goalSwing;
                            break;
                        case Result.Lose:
                            goalDiff -= goalSwing;
                            break;
                    }
                }

                Teams.Add(teamAndPoints.Key, new PointsAndGoalDifference(gamesOutstanding, points, goalDiff));
            }
        }

        public int Points(Team team)
        {
            return Teams[team].Points;
        }

        public int GoalDiff(Team team)
        {
            return Teams[team].GoalDifference;
        }

        public int Place(Team team)
        {
            var ordered = Teams.OrderByDescending(t => t.Value.Points).ThenBy(t => t.Value.GoalDifference);

            int place = 0;

            foreach (var keyValuePair in ordered)
            {
                if (keyValuePair.Key == team)
                    return place;
                place++;
            }

            throw new ArgumentOutOfRangeException();
        }

        public bool IsStTotteringhamsDay => Points(Team.Arsenal) > Points(Team.Spurs) || 
                                            (Points(Team.Arsenal) == Points(Team.Spurs) && GoalDiff(Team.Arsenal) >= GoalDiff(Team.Spurs));
        public bool JammyStTotteringhamsDay => Points(Team.Arsenal) == Points(Team.Spurs) && GoalDiff(Team.Arsenal) >= GoalDiff(Team.Spurs);
        public bool SuperJammyStTotteringhamsDay => Points(Team.Arsenal) == Points(Team.Spurs) && GoalDiff(Team.Arsenal) == GoalDiff(Team.Spurs);
    }
}