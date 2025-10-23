namespace CSharp_Kurs.Kurslar.Ders2
{
    // CLASS NAME must be 'Collections' (based on the namespace and structure)
    public class Collections
    {
        //Collections samples 
       public static void RunListDemo()
       {
           //lets create students list with their grades 
           Console.WriteLine("--- 1. List<T> Demo (Ordered Collection) ---");
           var studentGrades = new List<int>{75, 95, 80}; // Missing semicolon (;) and redundant spaces removed

           // Missing comma (,) in string.Join in the original code
           Console.WriteLine($"Initial Grades:{string.Join(",", studentGrades)}"); 

           //Lets add some elemets to list
           studentGrades.Add(90);
           // Missing comma (,) and closing parenthesis in the original code
           Console.WriteLine($"After add(90):{string.Join(",", studentGrades)}"); 

           //Lets now remove 75
           studentGrades.Remove(75);
           Console.WriteLine($"After Remove (75): {string.Join(", ", studentGrades)}");

           // Lets check if it contains element  in it 
           bool hasPerfectScore = studentGrades.Contains(100);
           Console.WriteLine($"Does the list contain 100? {hasPerfectScore}");

           //sorting the list 
           studentGrades.Sort();

           Console.WriteLine($"After Sort: {string.Join(", ", studentGrades)}");
       }

       public static void RunDictionary()
       {
           Console.WriteLine("\n--- 3. Creative Dictionary Demo: User Profiles (Ulanyjy Profilleri) ---");
           var userProfiles = new Dictionary<string, string>
           {
               ["gurban"] = "Online(Ishjen)",
               ["merjen"] = "Offline(Ocirilen)",
               ["dostum"] = "Busy(Aladaly)"
           };

           string userNameToFind = "gurban";
           // Extra semicolon (;) after the if statement removed, and status variable was used outside of its scope 
           // In C#, 'if' condition requires parentheses
           if(userProfiles.TryGetValue(userNameToFind, out var status)) 
           {
               Console.WriteLine($"-{userNameToFind} profili:Statusy -> {status}");
               if(status.Contains("Online")){
                   Console.WriteLine("Habarlashmaga rugsat edilyar");
               }
           }
           // The else branch (if TryGetValue fails) is missing here, but the code is syntactically correct now.
        
           //update and add new entry 
           userProfiles["merjen"] = "Online(isjen)";//we swictched status from offline to online
           // '=' operator was used instead of ']' to close the key in the original code
           userProfiles["almaz"] = "Offline (ocurlen)";//add new user 
           Console.WriteLine($"Merjenin tazelenen statusy :{userProfiles["merjen"]}");

           //conditional remove 
           string userToRemove = "dostum";
           if(userProfiles.ContainsKey(userToRemove)){
               userProfiles.Remove(userToRemove); 
               Console.WriteLine($"-'{userToRemove}' ulanyjysy ayryldy.");
           }
           
           //Looping through the Dictionary
           Console.WriteLine("\n--- Ähli Aktiw Ulanyjy Profilleri: ---");

           foreach(var profile in userProfiles){
               // lets print only online users 
               if(profile.Value.Contains("Online")){
                   //profile.Key =Key
                   //profile.Value=Baha
                   Console.WriteLine($"*Ulanyjy Ady:{profile.Key} | Status:{profile.Value}");
               }
           }
           
           //3 sany
           // Misspelled method name (Console.Writeline) and missing semicolon (;)
           Console.WriteLine($"Jemi Profillering sany: {userProfiles.Count}"); 
       }
    }
}