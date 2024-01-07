using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalProject {
    internal class Program {
        static void Main (string[] args) {

            //Check for alphabet characters also allow spaces
             bool IsAlphabetic (string input) {

                return input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || c == '.' || c == ',');

            }

            // the ourAnimals array will store the following: 
            string animalSpecies = "";
            string animalID = "";
            string animalAge = "";
            string animalPhysicalDescription = "";
            string animalPersonalityDescription = "";
            string animalNickname = "";
            string suggestedDonation = "";

            // variables that support data entry
            int maxPets = 8;
            string readResult;
            string menuSelection = "";
            decimal decimalDonation = 0.00m;

            // array used to store runtime data, there is no persisted data
            string[,] ourAnimals = new string[maxPets, 7];

            // TODO: Convert the if-elseif-else construct to a switch statement

            for (int i = 0; i < maxPets; i++) {
                switch (i) {
                    case 0:
                        animalSpecies = "dog";
                        animalID = "d1";
                        animalAge = "2";
                        animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
                        animalNickname = "lola";
                        suggestedDonation = "85.00";
                        break;

                    case 1:
                        animalSpecies = "dog";
                        animalID = "d2";
                        animalAge = "9";
                        animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
                        animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
                        animalNickname = "loki";
                        suggestedDonation = "49.99";
                        break;

                    case 2:
                        animalSpecies = "cat";
                        animalID = "c3";
                        animalAge = "1";
                        animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
                        animalPersonalityDescription = "friendly";
                        animalNickname = "Puss";
                        suggestedDonation = "40.00";
                        break;

                    case 3:
                        animalSpecies = "cat";
                        animalID = "c4";
                        animalAge = "?";
                        animalPhysicalDescription = "tbd";
                        animalPersonalityDescription = "tbd";
                        animalNickname = "tbd";
                        suggestedDonation = "";
                        break;

                    default:
                        animalSpecies = "";
                        animalID = "";
                        animalAge = "";
                        animalPhysicalDescription = "";
                        animalPersonalityDescription = "";
                        animalNickname = "";
                        suggestedDonation = "";
                        break;

                }

                ourAnimals[i, 0] = "ID #: " + animalID;
                ourAnimals[i, 1] = "Species: " + animalSpecies;
                ourAnimals[i, 2] = "Age: " + animalAge;
                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                ourAnimals[i, 6] = "SuggestedDonation: " + suggestedDonation;

                if (!decimal.TryParse(suggestedDonation, out decimalDonation)) {
                    decimalDonation = 45.00m; // if suggestedDonation NOT a number, default to 45.00
                }
                ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
            }

            // display the top-level menu options

            do {

                Console.Clear();

                Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are: \n");
                Console.WriteLine(" 1. List all of our current pet information");
                Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
                Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
                Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
                Console.WriteLine(" 5. Edit an animal’s age");
                Console.WriteLine(" 6. Edit an animal’s personality description");
                Console.WriteLine(" 7. Display all cats with a specified characteristic");
                Console.WriteLine(" 8. Display all dogs with a specified characteristic");
                Console.WriteLine();
                Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

                readResult = Console.ReadLine();
                Console.WriteLine();
                if (readResult != null) {
                    menuSelection = readResult.ToLower();
                }

                /*
                Console.WriteLine($"You selected menu option {menuSelection}.");
                Console.WriteLine("Press the Enter key to continue");

                // pause code execution
                readResult = Console.ReadLine();
                */

                switch (menuSelection) {
                    case "1":

                        for (int i = 0; i < maxPets; i++) {
                            if (ourAnimals[i, 0] != "ID #: ") {

                                for (int j = 0; j < 7; j++) {
                                    {
                                        Console.WriteLine(ourAnimals[i, j]);
                                    }
                                }
                            }
                            Console.WriteLine();
                        }

                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    case "2":

                        string anotherPet = "y";
                        int petCount = 0;

                        for(int i = 0; i < maxPets; i++) {
                            if (ourAnimals[i, 0] != "ID #: ") {
                                petCount++;
                            }
                        }
                        
                        if (petCount < maxPets) {
                            Console.WriteLine($"We curreny have {petCount} pets that need homes. We can manage {maxPets - petCount} more");
                        }

                        bool validEntry = false;

                        // get species (cat or dog) - string animalSpecies is a required field 
                        do {
                            Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin new entry");
                            readResult = Console.ReadLine();

                            if(readResult != null) {
                                animalSpecies = readResult.ToLower();
                            }

                            if (animalSpecies != "dog" && animalSpecies != "cat")
                                validEntry = false;
                            else
                                validEntry = true;

                        }while(validEntry == false);

                        animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                        //get the pet's age. can be ? for initial entry
                        do {
                            int petAge;
                            Console.WriteLine("Enter the pet's age or enter ? if unknown");
                            readResult = Console.ReadLine();

                            if (readResult != null) {

                                animalAge = readResult;
                                if (animalAge != "?")
                                    validEntry = int.TryParse(animalAge, out petAge);
                                else
                                    validEntry = true;
                            }
                        } while(validEntry == false);

                        //Add pet's description
                        do {
                            Console.WriteLine("Enter the pet's description (size, colour, gender, weight). Press the Enter key to assign 'tbd' if unknown");
                            readResult = Console.ReadLine();

                            if(readResult != null) {
                                animalPhysicalDescription = readResult.ToLower();

                                if (animalPhysicalDescription == "")
                                    animalPhysicalDescription = "tbd";
                            }

                        } while (animalPhysicalDescription == "");

                        //Add pet's personality
                        do {
                            Console.WriteLine("Enter the pet's personality descirption. Press the Enter key to assign 'tbd' if unknown");
                            readResult = Console.ReadLine();

                            if(readResult != null) {
                                animalPersonalityDescription = readResult.ToLower();

                                if (animalPersonalityDescription == "")
                                    animalPersonalityDescription = "tbd";
                            }

                        } while (animalPersonalityDescription == "");

                        //Add per's nickname
                        do {
                            Console.WriteLine("Enter pet's nickname. Press the Enter key to assign 'tbd' if unknown");
                            readResult  = Console.ReadLine();

                            if(readResult != null) {
                                animalNickname = readResult.ToLower();

                                if (animalNickname == "")
                                    animalNickname = "tbd";
                            }

                        } while (animalNickname == "");

                        //Store the pets information in array
                        ourAnimals[petCount, 0] = "ID #: " + animalID;
                        ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                        ourAnimals[petCount, 2] = "Age: " + animalAge;
                        ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                        ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                        ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                        while (anotherPet == "y" && petCount < maxPets) {

                            petCount++;
                            if (petCount < maxPets) {
                                Console.WriteLine("Would you like to add a new pet? Enter (y/n)");

                                do {
                                    readResult = Console.ReadLine();
                                    if (readResult != null) {
                                        anotherPet = readResult.ToLower();
                                    }

                                } while (anotherPet != "y" && anotherPet != "n");

                            }
                        }

                        if(petCount >= maxPets) {
                            Console.WriteLine("We have reached the limit, cannot add more pets");
                            Console.WriteLine("Press the Enter key to continue");
                            readResult = Console.ReadLine();  
                        }


                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    ////Ensure pet's Age and Physical descriptions are updated

                    case "3":

                        bool validAgeEntry = false;
                        int age;

                        for (int i = 0; i < maxPets; i++) {
                            if(ourAnimals[i, 2].Contains("?")) {

                                Console.WriteLine($"Enter age for {ourAnimals[i, 3].Substring(10)} {ourAnimals[i, 0]}");
                                validAgeEntry = false;
                                
                                do {
                                    readResult = Console.ReadLine();
                                    if (readResult != null && int.TryParse(readResult, out age)) {

                                        ourAnimals[i, 2] = "Age: " + readResult;
                                        validAgeEntry = true;  
                                    }
                                    else 
                                        Console.WriteLine($"Please enter a valid age for {ourAnimals[i, 3].Substring(10)}");

                                } while (validAgeEntry == false);
                            }

                            if (ourAnimals[i, 4].Contains("tbd")) {

                                Console.WriteLine($"Enter Physical Description for {ourAnimals[i, 3].Substring(10)} {ourAnimals[i, 0]}");
                                validAgeEntry = false;

                                do {
                                    readResult = Console.ReadLine();
                                    if(readResult != null && readResult.Length >= 10 && IsAlphabetic(readResult)) {
                                        ourAnimals[i, 4] = "Physical description: " + readResult;
                                        validAgeEntry = true;
                                    }
                                    else
                                        Console.WriteLine($"Please enter a valid physical description for {ourAnimals[i, 3].Substring(10)} (min 10 characters)");

                                } while(validAgeEntry == false);
                            }

                        }

                        Console.WriteLine("All pets have a valid age and physical description entered! ^_^ \n");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    //Ensure pet's Nicknames and personality descriptions are updated

                    case "4":

                        for (int i = 0; i < maxPets; i++) {
                            if (ourAnimals[i, 3].Contains("tbd")) {

                                Console.WriteLine($"Enter Nickname for {ourAnimals[i, 0]}");
                                validAgeEntry = false;

                                do {
                                    readResult = Console.ReadLine();
                                    if (readResult != null && readResult.Length >= 3 && IsAlphabetic(readResult)) {
                                        ourAnimals[i, 3] = "Nickname: " + readResult;
                                        validAgeEntry = true;
                                    }
                                    else
                                        Console.WriteLine($"Please enter a valid Nickname for {ourAnimals[i, 0]} (min 3 characters)");

                                } while (validAgeEntry == false);
                            }

                            if (ourAnimals[i, 5].Contains("tbd")) {

                                Console.WriteLine($"Enter Personality Description for {ourAnimals[i, 3].Substring(10)} {ourAnimals[i, 0]}");
                                validAgeEntry = false;

                                do {
                                    readResult = Console.ReadLine();
                                    if (readResult != null && readResult.Length >= 10 && IsAlphabetic(readResult)) {
                                        ourAnimals[i, 5] = "Personality: " + readResult;
                                        validAgeEntry = true;
                                    }
                                    else
                                        Console.WriteLine($"Please enter valid Personality description for {ourAnimals[i, 3].Substring(10)} {ourAnimals[i, 0]} (min 10 characters)");

                                } while (validAgeEntry == false);
                            }
                        }

                        Console.WriteLine("All pets have a valid Nickname and personality description entered! :) \n");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    case "5":
                        Console.WriteLine("Challenge Project - please check back soon to see progress.");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;
                    case "6":
                        Console.WriteLine("Challenge Project - please check back soon to see progress.");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;
                    case "7":
                        Console.WriteLine("Challenge Project - please check back soon to see progress.");
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;
                    case "8":

                        string dogCharacteristic = "";
                        string dogChar = "";

                        while(dogCharacteristic == "") {
                            Console.WriteLine($"\nEnter one desired dog characteristic to search for: ");
                            readResult = Console.ReadLine();
                            if(readResult != null) {
                                dogCharacteristic = readResult.ToLower().Trim();
                            }
                        }

                        Console.WriteLine($"Details Matched for: {dogCharacteristic} \n");

                        int indexFound = 0;

                        for (int i = 0; i < maxPets; i++) {
                            if (ourAnimals[i, 1].Contains("dog")) {
                                dogChar = ourAnimals[i, 4].ToLower().Trim();
                                
                                if (dogChar.Contains(dogCharacteristic)) {
                                    indexFound++;
                                    Console.WriteLine(ourAnimals[i, 0]);
                                    Console.WriteLine(ourAnimals[i, 1]);
                                    Console.WriteLine(ourAnimals[i, 3]);
                                    Console.WriteLine(ourAnimals[i, 2]);
                                    Console.WriteLine(ourAnimals[i, 5]);
                                    Console.WriteLine(ourAnimals[i, 4]);
                                    Console.WriteLine(ourAnimals[i, 6]);
                                    Console.WriteLine();
                                }
                            }
                            if (!dogChar.Contains(dogCharacteristic) && indexFound == 0) {
                                Console.WriteLine($"Sorry couldn't find any details matching the keyword: {dogCharacteristic} \n");
                                break;
                            }
                        }
                        
                        Console.WriteLine("Press the Enter key to continue.");
                        readResult = Console.ReadLine();
                        break;

                    default:
                        break;

                }

            } while (menuSelection != "exit");
        }
    }
}
