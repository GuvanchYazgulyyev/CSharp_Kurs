namespace CSharp_Kurs.Kurslar.Ders2;


public class Calculator
{
    // Program.cs faýlyndan çagyrylýan esasy funksiýa
    public static void RunCalculator(string[] args)
    {
        Console.WriteLine("--------------------");
        Console.WriteLine("Yonekey Kalkulyator!");
        Console.WriteLine("Çykmak üçin: exit ýa-da cyk basyn");
        Console.WriteLine("--------------------");

        while (true)
        {
            double num1 = 0;
            double num2 = 0;
            char op = ' ';
            double result = 0;

            // 1. Birinji sany soramak
            Console.Write("Birinji sany girez ýa-da (exit/cyk): ");
            var girdi1 = Console.ReadLine();
            var cleanedInput = girdi1?.Trim().ToLower();

            // Çykmak barlagy (exit/cyk ýa-da boş girizme)
            if (string.IsNullOrWhiteSpace(girdi1) || cleanedInput == "exit" || cleanedInput == "cyk")
            {
                Console.WriteLine("Program gutardy. Sag boluň!");
                break;
            }

            // Birinji sanyň dogrulygyny barlamak   dkksl
            if (!double.TryParse(girdi1, out num1))
            {
                Console.WriteLine("Yalnysh san formaty. Dogry san giriziň.");
                Console.WriteLine("--------------------");
                continue;
            }

            // 2. Operatory soramak
            Console.Write("Amallary giriziň (+, -, *, /, %): ");
            var opInput = Console.ReadLine()?.Trim();

            // Operatoryň dogrulygyny barlamak
            if (opInput?.Length != 1 || !"+-*/%".Contains(opInput))
            {
                Console.WriteLine("Yalnysh operator. Diňe +, -, *, /, % simwollaryny ulanyň.");
                Console.WriteLine("--------------------");
                continue;
            }
            op = opInput[0];

            // 3. Ikinji sany soramak
            Console.Write("Ikinji sany giriziň: ");
            var girdi2 = Console.ReadLine();

            // Ikinji sanyň dogrulygyny barlamak
            if (!double.TryParse(girdi2, out num2))
            {
                Console.WriteLine("Yalnysh san formaty. Dogry san giriziň.");
                Console.WriteLine("--------------------");
                continue;
            }

            // 4. Hasaplama we Ýalňyşlyk Dolandyryşy (try-catch)
            try
            {
                switch (op)
                {
                    case '+': result = num1 + num2; break;
                    case '-': result = num1 - num2; break;
                    case '*': result = num1 * num2; break;
                    case '/':
                        // Nol-a bölünme barlagy
                        if (num2 == 0)
                        {
                            // Ýörite ýalňyşlyk döretmek
                            throw new DivideByZeroException("0-a bölünmeýär."); 
                        }
                        result = num1 / num2; 
                        break;
                    case '%':
                        result = num1 % num2; break;
                    default:
                        // Bu şert, dogry operator barlagy sebäpli ýetmez
                        Console.WriteLine("Nämälim operator."); 
                        continue;
                }

                // 5. Netijäni görkezmek
                Console.WriteLine($"Netije: {num1} {op} {num2} = {result:F2}");
            }
            // Ýörite ýalňyşlyk dolandyryşy (Nol-a Bölünme)
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
            // Beýleki ähli ýalňyşlyklar (umumy ýalňyşlyk)
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: Bir ýalňyşlyk ýüze çykdy: {ex.Message}");
            }
            finally
            {
                // Her hasaplamadan soň aýyryjy goýmak
                Console.WriteLine("--------------------");
            }
        }
    }
}
