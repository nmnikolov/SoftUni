namespace _04.SULS
{
    public class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string Lastname, int age, string studentNumber, double averageGrade, string currentCourse)
            : base(firstName, Lastname, age, studentNumber, averageGrade, currentCourse)
        {           
        }
    }
}
