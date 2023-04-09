using System.Collections.Specialized;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Sources;

namespace Exam_Program
{
    internal class Program
    {
        static public void Print(int index, int i,string[,]arr,ref int score, bool enter = false)
        {
            Console.Clear();
            Console.SetCursorPosition(42, 8);
            Console.WriteLine(arr[i,0]);
            Console.WriteLine($"\n\t\t\t\t\t\t\t\t\tScore: {score}");
            for (int j = 1; j <4 ; j++)
            {
                if (j == index) {
                    
                    if (enter && (arr[i, index] == arr[i,4])) { Console.ForegroundColor = ConsoleColor.Green;
                        score += 10; }    
                    else if (enter && (arr[i, index] != arr[i,4])) { Console.ForegroundColor = ConsoleColor.Red; 
                        if(score!=0)score -= 10; }    
                    else Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                Console.SetCursorPosition(50, j + 10);
                Console.WriteLine(arr[i,j]);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Shuffle(ref string[,] array)
        {
            Random random= new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    int swapindex = random.Next(1, 4);
                    string temp = array[i, j];
                    array[i, j] = array[i, swapindex];
                    array[i, swapindex] = temp;
                }
            }
        }
        static void Main(string[] args)
        {
            // All Questions

            string[,] Questions = new string[,] {
                {"Azerbaycanin paytaxti haradir?","Baki", "Gence", "Naxcivan", "Baki" },
                {"Azerbaycanda en hundur dag hansidir?", "Bazarduzu", "Sahdag", "Kepez", "Bazarduzu"},
                {"İtaliyanin paytaxti hansidir?", "Venesiya", "Neapol", "Roma", "Roma" },
                {"Eyfel qullesi harada yerlesir?", "Roma", "Madrid", "Paris", "Paris"},
                {"Bakinin en cox ehaliye sahib rayonu hansidir?", "Xetai", "Yasamal", "Nizami", "Xetai" },
                {"Microfost-un qurucusu kimdir?", "Elon Musk", "Jeff Bezos", "Bill Gates", "Bill Gates" },
                {"Dunyanin en derin golu hansidir?", "Xezer", "Baykal", "Viktoriya", "Baykal" },
                {"Futbol uzre ilk Dunya Cempionati hansi olkede kecirilmisdir?", "Argentina", "Braziliya", "Uruqvay", "Uruqvay"},
                {"Hansi Frans Kafka-nin bir eseridir?", "Kimyager", "Mehkeme", "Sefiller", "Mehkeme" },
                {"Dunyanin en cox satilan smartfonu markasi hansidir?", "Nokia", "Samsung", "Realme","Nokia"},
            };
            int index = 1,i=0,score=0;
            while(true)
            {
                if(i==10)
                {
                    Console.WriteLine($"Your Total Score: {score}");
                    Console.WriteLine("Click 'N' to play again");
                    var info = Console.ReadKey(true);
                    if (info.Key == ConsoleKey.N)
                    {
                        i = 0; score = 0;
                        index = 1;
                        Shuffle(ref Questions);
                        continue;
                    }
                    else break;   
                }
                Print(index,i,Questions,ref score);
                var key = Console.ReadKey(true);
                if(key.Key==ConsoleKey.UpArrow)
                {
                    if (index == 1) index=3;
                    else index--;
                }
                else if (key.Key==ConsoleKey.DownArrow)
                {
                    if (index == 3) index=1;
                    else index++;
                }
                else if(key.Key == ConsoleKey.Enter)
                {
                    Print(index, i, Questions,ref score, true);
                    Thread.Sleep(500);
                    i++;
                    index = 1;                    
                }    
            }
        }
    }
}