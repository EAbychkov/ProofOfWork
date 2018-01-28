using System;
using System.Diagnostics;

namespace ProofOfWork
{
    class Program
    {
        public static int CurrentTime => (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

        static void Main()
        {
            // case number one (difficulty = 2)
            int difficulty = 2;
            int numberOfSolutionsFound = 0;
            int finishTime = CurrentTime + 15;
            do
            {
                ChallengeResult result = SolveTheChallenge(RandomStringGenerator.GenerateByLen(10), difficulty);
                numberOfSolutionsFound++;
            } while (CurrentTime < finishTime);
            Console.WriteLine($"Total number of solutions found for (difficulty = 2): {numberOfSolutionsFound}");

            // case number two (difficulty = 3)
            difficulty = 3;
            numberOfSolutionsFound = 0;
            finishTime = CurrentTime + 15;
            do
            {
                ChallengeResult result = SolveTheChallenge(RandomStringGenerator.GenerateByLen(10), difficulty);
                numberOfSolutionsFound++;
            } while (CurrentTime < finishTime);
            Console.WriteLine($"Total number of solutions found for (difficulty = 3): {numberOfSolutionsFound}");

            // case number three (difficulty = 4)
            difficulty = 4;
            numberOfSolutionsFound = 0;
            finishTime = CurrentTime + 15;
            do
            {
                ChallengeResult result = SolveTheChallenge(RandomStringGenerator.GenerateByLen(10), difficulty);
                numberOfSolutionsFound++;
            } while (CurrentTime < finishTime);
            Console.WriteLine($"Total number of solutions found for (difficulty = 4): {numberOfSolutionsFound}");

            // case number four (difficulty = 5)
            difficulty = 5;
            numberOfSolutionsFound = 0;
            finishTime = CurrentTime + 15;
            do
            {
                ChallengeResult result = SolveTheChallenge(RandomStringGenerator.GenerateByLen(10), difficulty);
                numberOfSolutionsFound++;
            } while (CurrentTime < finishTime);
            Console.WriteLine($"Total number of solutions found for (difficulty = 5): {numberOfSolutionsFound}");

            Console.ReadKey();
        }

        private static ChallengeResult SolveTheChallenge(string challengeString, int difficulty)
        {
            var challengeResult  = new ChallengeResult();
            string expectedResult = new string('0', difficulty);  // if the difficulty = 4 the expectedResult will be = '0000'
            var stopwatch = new Stopwatch();
            stopwatch.Start(); // doing time measurement
            do
            {
                challengeResult.NumberOfIterations++; // counting the number of iterations
                challengeResult.SolveString = challengeString + RandomStringGenerator.GenerateByLen(10); // generating random string to test it
                challengeResult.SolveHash = Sha256Generator.GenerateSha256String(challengeResult.SolveString);  // generating sha-256 from the random string
            } while (!challengeResult.SolveHash.StartsWith(expectedResult)); // checking if we found a solution
            challengeResult.SolveSeconds = stopwatch.Elapsed.TotalSeconds;
            return challengeResult;
        }
    }
}
