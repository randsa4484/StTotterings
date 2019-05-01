namespace Outcomes
{
    internal class PointsAndGoalDifference
    {
        public PointsAndGoalDifference(int gamesOutstanding, int points, int goalDifference)
        {
            GamesOutstanding = gamesOutstanding;
            Points = points;
            GoalDifference = goalDifference;
        }

        public int GamesOutstanding { get; }
        public int Points { get; set; }
        public int GoalDifference { get; set; }
    }
}