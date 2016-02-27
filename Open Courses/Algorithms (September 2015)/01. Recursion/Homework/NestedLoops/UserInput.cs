namespace CombinationsWithRepetition
{
    public class UserInput
    {
        public UserInput(int totalElements, int combinationElements)
        {
            this.TotalElements = totalElements;
            this.CombinationElements = combinationElements;
        }

        public int TotalElements { get; set; }

        public int CombinationElements { get; set; }
    }
}