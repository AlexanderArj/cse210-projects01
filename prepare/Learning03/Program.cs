
class Program
{
    static void Main(string[] args)
    {
        string texto = @"1 There was a man of the Pharisees, named Nicodemus, a ruler of the Jews:
                        2 The same came to Jesus by night, and said unto him, Rabbi, we know that thou art a teacher come from God: 
                        for no man can do these miracles that thou doest, except God be with him.
                        3 Jesus answered and said unto him, Verily, verily, I say unto thee, Except a man be born again, he cannot see 
                        the kingdom of God.
                        4 Nicodemus saith unto him, How can a man be born when he is old? can he enter the second time into his mother’s womb, 
                        and be born?
                        5 Jesus answered, Verily, verily, I say unto thee, Except a man be born of water and of the Spirit, 
                        he cannot enter into the kingdom of God.";


        Reference nuevaReferencia = new Reference("John", 3, 1, 5);

        Scripture nuevaEscritura = new Scripture(nuevaReferencia, texto);

        Random random = new Random();

        Console.WriteLine(nuevaReferencia.GetDisplayText());

        Console.WriteLine($"{texto}");

        Console.WriteLine("Press Enter to hide some words or press Esc to exit...");

        while (!nuevaEscritura.isCompletelyHidden())
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

        
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                int randomWordsToHide = random.Next(1, texto.Split(' ').Length + 1);
                
                nuevaEscritura.HideRandomWords(randomWordsToHide);

                Console.Clear();

                Console.WriteLine(nuevaReferencia.GetDisplayText());

                Console.WriteLine(nuevaEscritura.GetStringText());

                if (nuevaEscritura.isCompletelyHidden())
                {
                    break;
                }

                Console.WriteLine("Press Enter to hide more words or press Esc to exit...");
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                break;
            }
        }

        Console.Clear();
        Console.WriteLine(nuevaReferencia.GetDisplayText());

        Console.WriteLine(nuevaEscritura.GetStringText());

        Console.WriteLine("\nPress any key to exit...");

        Console.ReadKey();
    }
}
