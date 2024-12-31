
                string username = Console.ReadLine();
                string password = new string(username.Reverse().ToArray());
                string input = "";
                int counter = 0;    
                while ((input = Console.ReadLine()) != password)
                {
                    counter++;
                    if (counter >= 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        return;
                    }
                    else Console.WriteLine("Incorrect password. Try again.");

                }

                Console.WriteLine($"User {username} logged in.");
            