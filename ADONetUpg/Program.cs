using Microsoft.Data.SqlClient;
namespace ADONetUpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var programStart = new UserQuestion();

            programStart.RunProgram();
        }
    }
}
