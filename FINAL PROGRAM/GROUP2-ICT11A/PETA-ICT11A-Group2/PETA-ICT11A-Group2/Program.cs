using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace PETA_ICT11A_Group2
{
    class Program
    {
        static void Main(string[] args)
        {

            string header = @"
+-----------------------------------------------------+  
           _                                      
          | |                                     
       ___| |     __ _  ___ _ __  _ __   ___  ___ 
      / __| |    / _` |/ _ \ '_ \| '_ \ / _ \/ __|
     | (__| |___| (_| |  __/ | | | | | |  __/ (__ 
      \___|______\__,_|\___|_| |_|_| |_|\___|\___|                                                                                          
+-----------------------------------------------------+                                                   
";
            string seperator = "+-----------------------------------------------------+";
            int ageConverter;
            string name, gender;
            string age;


            string[] nameInput = new string[]{
                "             Please Enter your full name ", "             What is your full name ?", "             Put your full name here", "             May i have your full name please?"
            };


            string[] ageInput = new string[]{
                "               How old are you?", "             How old are you now ?" , "               May i have your age please?"
            };

            string[] genderInput = new string[]{
                "              What is your gender?", "             Are you male or female?","I'm sorry, but our policy dictates that we ask this \nquestion: What is your gender?",
            };

            string[] select3 = new string[]{
                "             Please select 3 more symptoms", "               Kindly pick 3 more", "             Try to choose 3 more symptoms", "             Choose another symptoms"
            };

            string[] select2 = new string[]{
                "             Please select 2 more symptoms", "               Kindly pick 2 more", "             Try to choose 2 more symptoms", "             Choose another symptoms"
            };

            string[] select1 = new string[]{
                "               Select the last symptom", "                       Last one", "                   Please choose the last symptom"
            };

            /*Combinations of all the symptoms in the array */

            string[] foodPoisoning = new string[] { "1", "2", "3", "4" };/*FEVER,DIARRHEA,FATIGUE,MUSCLEACHES*/
            string[] crohnsDisease = new string[] { "1", "2", "3", "5" };/*FEVER,DIARRHEA,FATIGUE,COUGHING */
            string[] dyspepsia = new string[] { "1", "2", "3", "6", "9" };/*FEVER,DIARRHEA,FATIGUE,INDIGESTIONS */
            string[] whippleDisease = new string[] { "1", "2", "3", "7" };/*FEVER,DIARRHEA,FATIGUE,JAWPAIN */
            string[] dumpingSyndrome = new string[] { "1", "2", "3", "8" };/*FEVER,DIARRHEA,FATIGUE,LIGHTHEADEDNESS */
            string[] gad = new string[] { "1", "2", "3", "9" };/*FEVER,DIARRHEA,FATIGUE,ANXIETY */
            string[] influenza = new string[] { "1", "2", "4", "5", "8" };/*FEVER,DIARRHEA,MUSCLEACHES,COUGHING */
            string[] gastroenteritis = new string[] { "1", "2", "4", "6" };/*FEVER,DIARRHEA,MUSCLEACHES,INDIGESTIONS */
            string[] dengueFever = new string[] { "1", "2", "4", "7" };/*FEVER,DIARRHEA,MUSCLEACHES,JAWPAIN */
            string[] flu = new string[] { "1", "3", "4", "5", "8" };/*FEVER,DIARRHEA,MUSCLEACHES,LIGHTHEADEDNESS */
            string[] irritableBowelSyndrome = new string[] { "1", "2", "4", "9" };/*FEVER,DIARRHEA,MUSCLEACHES,ANXIETY */
            string[] meningitis = new string[] { "1", "2", "5", "7" };/*FEVER,DIARRHEA,COUGHING,JAWPAIN */
            string[] gastrointestinal = new string[] { "1", "2", "5", "9" };/*FEVER,DIARRHEA,COUGHING,ANXIETY */
            string[] abdominalPain = new string[] { "1", "2", "6", "7", "8" };/*FEVER,DIARRHEA,INDIGESTIONS,LIGHTHEADEDNESS*/
            string[] stress = new string[] { "1", "2", "3", "7", "9" };/*FEVER,DIARRHEA,JAWPAIN,ANXIETY*/
            string[] lupus = new string[] { "1", "3", "4", "7" };/*FEVER,FATIGUE,MUSCLEACHES,JAWPAIN*/
            string[] pneumonia = new string[] { "1", "3", "5", "6", "8" };/*FEVER,FATIGUE,COUGHING,INDIGESTIONS*/
            string[] sinusInfection = new string[] { "1", "3", "5", "7" };/*FEVER,FATIGUE,COUGHING,JAWPAIN*/
            string[] chronicCough = new string[] { "1", "3", "5", "9" };/*FEVER,FATIGUE,COUGHING,ANXIETY*/
            string[] heartBurn = new string[] { "1", "3", "5", "6", "7" };/*FEVER,FATIGUE,INDIGESTIONS,JAWPAIN*/
            string[] tuberculousMeningitis = new string[] { "1", "3", "4", "6", "7", "8" };/*FEVER,FATIGUE,INDIGESTIONS,LIGHTHEADEDNESS*/
            string[] viralPharyngitis = new string[] { "1", "3", "7", "8" };/*FEVER,FATIGUE,JAWPAIN,LIGHTHEADEDNESS*/
            string[] vertigo = new string[] { "1", "3", "8", "9" };/*FEVER,FATIGUE,LIGHTHEADEDNESS,ANXIETY*/
            string[] laryngitis = new string[] { "1", "4", "5", "6" };/*FEVER,MUSCLEACHES,COUGHING,INDIGESTIONS*/
            string[] colds = new string[] { "1", "4", "5", "7" };/*FEVER,MUSCLEACHES,COUGHING,JAWPAIN*/
            string[] anxietyCough = new string[] { "1", "4", "5", "9" };/*FEVER,MUSCLEACHES,COUGHING,ANXIETY*/
            string[] heartAttack = new string[] { "1", "4", "6", "7", "9" };/*FEVER,MUSCLEACHES,INDIGESTIONS,JAWPAIN*/
            string[] acidReflux = new string[] { "1", "4", "5", "6", "8" };/*FEVER,MUSCLEACHES,INDIGESTIONS,LIGHTHEADEDNESS*/
            string[] GERD = new string[] { "1", "4", "6", "9", "5" };/*FEVER,MUSCLEACHES,INDIGESTIONS,ANXIETY*/
            string[] depression = new string[] { "1", "4", "8", "9" };/*FEVER,MUSCLEACHES,LIGHTHEADEDNESS,ANXIETY*/
            string[] pericarditis = new string[] { "1", "5", "7", "8" };/*FEVER,COUGHING,JAWPAIN,LIGHTHEADEDNESS*/
            string[] aorticAneurysm = new string[] { "1", "5", "7", "9" };/*FEVER,COUGHING,JAWPAIN,ANXIETY*/
            string[] brucellosis = new string[] { "1", "5", "8", "9" };/*FEVER,COUGHING,LIGHTHEADEDNESS,ANXIETY*/
            string[] flukeInfection = new string[] { "1", "5", "7", "8" };/*FEVER,INDIGESTIONS,JAWPAIN,LIGHTHEADEDNESS*/
            string[] irritablebowelsyndrome = new string[] { "1", "6", "7", "9" };/*FEVER,INDIGESTIONS,JAWPAIN,ANXIETY*/
            string[] panicAttack = new string[] { "1", "6", "8", "9" };/*FEVER,INDIGESTIONS,LIGHTHEADEDNESS,ANXIETY*/
            string[] chronicFatigueSyndrome = new string[] { "1", "7", "8", "9" };/*FEVER,JAWPAIN,LIGHTHEADEDNESS,ANXIETY*/
            string[] viralHepatitis = new string[] { "2", "3", "4", "5" };/*f*/
            string[] cholera = new string[] { "2", "3", "8", "9" };/*DIARRHEA,FATIGUE,LIGHTHEADEDNESS,ANXIETY*/
            string[] strongyloidiasis = new string[] { "2", "4", "5", "6" };/*DIARRHEA,MUSCLE ACHES,COUGHING,INDIGESTION*/
            string[] malaria = new string[] { "2", "4", "5", "7" };/*DIARRHEA,MUSCLE ACHES,COUGHING,JAW PAIN*/
            string[] sepsisAndShock = new string[] { "2", "4", "5", "8" };/*DIARRHEA,MUSCLE ACHES,COUGHING,LIGHTHEADEDNESS*/
            string[] pseudomonas = new string[] { "2", "4", "5", "9" };/*DIARRHEA,MUSCLE ACHES,COUGHING,ANXIETY*/
            string[] drugOverdose = new string[] { "2", "4", "6", "7" };/*DIARRHEA,MUSCLE ACHES,INDIGESTION,JAW PAIN*/
            string[] toxicShockSyndrome = new string[] { "2", "4", "6", "8" };/*DIARRHEA,MUSCLE ACHES,INDIGESTION,LIGHTHEADEDNESS*/
            string[] eosinophiliaMyalgiaSyndrome = new string[] { "2", "4", "6", "9" };/*DIARRHEA,MUSCLE ACHES,INDIGESTION,ANXIETY*/
            string[] sickleCellAnemia = new string[] { "2", "4", "7", "8" };/*DIARRHEA,MUSCLE ACHES,JAW PAIN,LIGHTHEADEDNESS*/
            string[] stressHeadache = new string[] { "2", "4", "7", "9" };/*DIARRHEA,MUSCLE ACHES,JAW PAIN,ANXIETY*/
            string[] bacterialMeningitis = new string[] { "2", "4", "8", "9" };/*DIARRHEA,MUSCLE ACHES,LIGHTHEADEDNESS,ANXIETY*/
            string[] atypicalPneumonia = new string[] { "2", "5", "6", "7" };/*DIARRHEA,COUGHING,INDIGESTIONS,JAW PAIN*/
            string[] pancreaticCancer = new string[] { "2", "5", "6", "8" };/*DIARRHEA,COUGHING,INDIGESTIONS,LIGHTHEADEDNESS*/
            string[] pepticUlcer = new string[] { "2", "5", "6", "9" };/*DIARRHEA,COUGHING,INDIGESTIONS,ANXIETY*/
            string[] thoracicAorticAneurysm = new string[] { "2", "5", "7", "8" };// DIARRHEA,COUGHING,JAW PAIN,LIGHTHEADEDNESS
            string[] endometriosis = new string[] { "2", "5", "7", "9" };// DIARRHEA,COUGHING,JAW PAIN,ANXIETY
            string[] panicDisorder = new string[] { "2", "5", "8", "9" };// DIARRHEA,COUGHING,LIGHTHEADEDNESS,ANXIETY
            string[] visceroptosis = new string[] { "2", "6", "7", "8" };// DIARRHEA,INDIGESTION,JAW PAIN,LIGHTHEADEDNESS
            string[] systemicSclerosis = new string[] { "2", "6", "7", "9" };// DIARRHEA,INDIGESTION,JAW PAIN,ANXIETY
            string[] perniciousAnemia = new string[] { "2", "6", "8", "9" };// DIARRHEA,INDIGESTION,LIGHTHEADEDNESS,ANXIETY
            string[] posturalOrthostaticTachycardiaSyndrome = new string[] { "2", "7", "8", "9" };// DIARRHEA,JAW PAIN,LIGHTHEADEDNESS,ANXIETY
            string[] infectiousMononucleosis = new string[] { "3", "4", "5", "6" };// FATIGUE,MUSCLE ACHES,COUGHING,INDIGESTIONS
            string[] influenza2 = new string[] { "3", "4", "5", "7" };// FATIGUE,MUSCLE ACHES,COUGHING,JAW PAIN
            string[] relapsingFever = new string[] { "3", "4", "5", "8" };// FATIGUE,MUSCLE ACHES,COUGHING,LIGHTHEADEDNESS
            string[] influenza3 = new string[] { "3", "4", "5", "9" };// FATIGUE,MUSCLE ACHES,COUGHING,ANXIETY
            string[] HumanGranulocyticAnaplasmosis = new string[] { "3", "4", "6", "7" };// FATIGUE,MUSCLE ACHES,INDIGESTION,JAW PAIN
            string[] CommonCold = new string[] { "3", "4", "6", "8" };// FATIGUE,MUSCLE ACHES,INDIGESTION,LIGHTHEADEDNESS
            string[] ChronicFatigueSyndrome = new string[] { "3", "4", "6", "9" };// FATIGUE,MUSCLE ACHES,INDIGESTION,ANXIETY
            string[] ToothAbscess = new string[] { "3", "4", "7", "8" };// FATIGUE,MUSCLE ACHES,JAW PAIN,LIGHTHEADEDNESS
            string[] Fibromyalgia = new string[] { "3", "4", "7", "9" };// FATIGUE,MUSCLE ACHES,JAW PAIN,ANXIETY
            string[] AlcoholHangover = new string[] { "3", "4", "8", "9" };// FATIGUE,MUSCLE ACHES,LIGHTHEADEDNESS,ANXIETY
            string[] SJogrensSyndrome = new string[] { "3", "5", "6", "7" };// FATIGUE,COUGHING,INDIGESTION,JAW PAIN
            string[] HeartFailure = new string[] { "3", "5", "6", "8" };// FATIGUE,COUGHING,INDIGESTION,LIGHTHEADEDNESS
            string[] pericarditis2 = new string[] { "3", "5", "6", "9" };// FATIGUE,COUGHING,INDIGESTION,ANXIETY
            string[] cryptococcusNeoformans = new string[] { "3", "5", "7", "8" };// FATIGUE,COUGHING,JAW PAIN,LIGHTHEADEDNESS
            string[] aorticAneurysm2 = new string[] { "3", "5", "7", "9" };// FATIGUE,COUGHING,JAW PAIN,ANXIETY
            string[] brucellosis2 = new string[] { "3", "5", "8", "9" };// FATIGUE,COUGHING,LIGHTHEADEDNESS,ANXIETY
            string[] HeavyMetalIntoxication = new string[] { "3", "6", "7", "8" };// FATIGUE,INDIGESTION,JAW PAIN,LIGHTHEADEDNESS
            string[] cirrhosis = new string[] { "3", "6", "7", "9" };// FATIGUE,INDIGESTION,JAW PAIN,ANXIETY
            string[] GravesDisease = new string[] { "3", "6", "8", "9" };// FATIGUE,INDIGESTION,LIGHTHEADEDNESS,ANXIETY
            string[] concussion = new string[] { "3", "7", "8", "9" };// FATIGUE,JAW PAIN,LIGHTHEADEDNESS,ANXIETY
            string[] TrigeminalNeuralgia = new string[] { "4", "5", "6", "7" };// MUSCLE ACHES,COUGHING,INDIGESTION,JAW PAIN
            string[] CommonCold2 = new string[] { "4", "5", "6", "8" };// MUSCLE ACHES,COUGHING,INDIGESTION,LIGHTHEADEDNESS -
            string[] FlukeInfection2 = new string[] { "4", "5", "6", "9" };// MUSCLE ACHES,COUGHING,INDIGESTION,ANXIETY - 
            string[] PulmonaryEmbolism = new string[] { "4", "5", "7", "8" };// MUSCLE ACHES,COUGHING,JAW PAIN,LIGHTHEADEDNESS - 
            string[] sinusitis = new string[] { "4", "5", "7", "9" };// MUSCLE ACHES,COUGHING,JAW PAIN,ANXIETY - 
            string[] influenza4 = new string[] { "4", "5", "8", "9" };// MUSCLE ACHES,COUGHING,LIGHTHEADEDNESS,ANXIETY 
            string[] lymeDisease = new string[] { "4", "6", "7", "8" };// MUSCLE ACHES,INDIGESTION,JAW PAIN,LIGHTHEADEDNESS
            string[] toothAbscess2 = new string[] { "4", "6", "7", "9" };// MUSCLE ACHES,INDIGESTION,JAW PAIN,ANXIETY
            string[] diabeticNeuropathy = new string[] { "4", "6", "8", "9" };// MUSCLE ACHES,INDIGESTION,LIGHTHEADEDNESS,ANXIETY
            string[] generalAnxietyDisorder = new string[] { "4", "6", "7", "8" };// MUSCLE ACHES,JAW PAIN,LIGHTHEADEDNESS,ANXIETY
            string[] bronchitis = new string[] { "5", "6", "7", "8" };// COUGHING,INDIGESTION,JAW PAIN,LIGHTHEADEDNESS
            string[] esophagitis = new string[] { "5", "6", "7", "9" };// COUGHING,INDIGESTION,JAW PAIN,ANXIETY
            string[] gastroesophagealReflux = new string[] { "5", "6", "8", "9" };// COUGHING,INDIGESTION,LIGHTHEADEDNESS,ANXIETY
            string[] asthma = new string[] { "5", "7", "8", "9" };// COUGHING,JAW PAIN,LIGHTHEADEDNESS,ANXIETY
            string[] unstableAngina = new string[] { "6", "7", "8", "9" };// INDIGESTION,JAW PAIN,LIGHTHEADEDNESS,ANXIETY

            string[] SalmonellaInfections = new string[] { "2", "5", "8", "9" };/*ANXIETY,DIARRHEA,LIGHTHEADEDNESS,COUGHING */
            string[] ParkinsonsDisease = new string[] { "4", "7", "8", "9", };/*MUSCLE ACHES,JAW PAIN,LIGHTHEADEDNESS,ANXIETY */
            string[] tularemia = new string[] { "7", "2", "3", "4" };/*MUSCLE ACHES,DIARRHEA,FATIGUE,JAWPAIN */
            string[] stomachflu = new string[] { "8", "2", "3", "4" };/*MUSCLE ACHES,DIARRHEA,FATIGUE,LIGHTHEADEDNESS */
            string[] stomachchurning= new string[] { "9", "2", "3", "4" };/*MUSCLE ACHES,DIARRHEA,FATIGUE,ANXIETY */
            string[] Pneuomococcal = new string[] { "3", "5", "2", "7", };/*FATIGUE,DIARRHEA,JAW PAIN,COUGHING */
            string[] mastocytosis = new string[] { "3", "2", "7", "8", };/*FATIGUE,DIARRHEA,JAW PAIN,LIGHTHEADEDNESS */

            int symptomCollector, symptomCollector2, symptomCollector3, symptomCollector4;
            Console.Clear();
            //display header
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);

            //display date and time
            Console.ForegroundColor = ConsoleColor.White;
            
            Console.WriteLine("\nToday is " + DateTime.Now);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
            Console.Clear();

            login:
            Console.Clear();
            //log-in

            string[] defaultUserName = new string[4] {
                "kurtjacob",
                "amielchristian",
                "natalia",
                "kylejustin",

            };

            string[] defaultPassWord = new string[4] {
                "urquico",
                "paguia",
                "patricio",
                "suarez",
            };

            string userName;
            string passWord = "";

            userName:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.Write("Username: ");
            
            userName = Console.ReadLine().ToLower();

            while (true)
            {
                if (userName == "")
                {
                    goto userName;
                }
                else if (defaultUserName.Contains(userName))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(seperator);
                    Console.WriteLine("Correct UserName");
                    Console.WriteLine(seperator);
                    Console.ReadKey();
                    break;

                }
                else if (!defaultUserName.Contains(userName))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(seperator);
                    Console.WriteLine("Incorrect UserName");
                    Console.WriteLine(seperator);
                    Console.Write("Username: ");
                    userName = Console.ReadLine().ToLower();
                }

            }


            enterPassword:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.Write("Password: ");
            while (true)
            {

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Enter)
                {
                    passWord += key.KeyChar;
                    Console.Write("*");

                }
                else if (key.Key == ConsoleKey.Enter)
                {

                    break;

                }
            }

            passWord = passWord.ToLower();
            while (true)
            {
                if (passWord == "")
                {

                    goto enterPassword;
                }
                else if (defaultPassWord.Contains(passWord))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(seperator);
                    Console.WriteLine("Correct Password");
                    Console.WriteLine(seperator);

                    Console.ReadKey();
                    break;

                }
                else if (!defaultPassWord.Contains(passWord))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(seperator);
                    Console.WriteLine("Incorrect Password");
                    Console.Write("Password: ");
                    passWord = Console.ReadLine();
                    Console.ReadKey();
                    
                }

            }

            menu:
            //name input
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.WriteLine(nameInput[new Random().Next(0, nameInput.Length)]);
            Console.WriteLine(seperator);
            name = Console.ReadLine();
            Console.Clear();


            while (true)
            {
                if (name != null && name.Length < 5)
                {//this statement checks if there's a name and it should be greater than 5 characters
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(seperator);
                    Console.WriteLine(nameInput[new Random().Next(0, nameInput.Length)]);
                    Console.WriteLine(seperator);
                    name = Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    break;

                }
            }
            Console.Clear();


        //age input
        ageInput:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.WriteLine(ageInput[new Random().Next(0, ageInput.Length)]);
            Console.WriteLine(seperator);
            age = Console.ReadLine();

            while (true)
            {

                if (age == "")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(seperator);
                    Console.WriteLine(ageInput[new Random().Next(0, ageInput.Length - 1)]);
                    Console.WriteLine(seperator);
                    age = Console.ReadLine();
                    Console.Clear();
                }
                else if (age != "")
                {

                    goto ageConverter;
                }
            }

        ageConverter:
            ageConverter = Int32.Parse(age);
            if (ageConverter > 99)
            {
                goto ageInput;

            } else if (ageConverter < 5) {
                goto ageInput;
            }
            else { }


            Console.Clear();






            //Gender Input
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.WriteLine(genderInput[new Random().Next(0, genderInput.Length)]);
            Console.WriteLine(seperator);
            Console.WriteLine("[1.] Male");
            Console.WriteLine("[2.] Female\n");
            gender = Console.ReadLine();

            while (true)
            {
                if (gender == "1")
                {
                    gender = "Male";
                    break;
                }
                else if (gender == "2")
                {
                    gender = "Female";
                    break;
                }
                else if (gender != "1" || gender != "2")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(seperator);
                    Console.WriteLine(genderInput[2]);
                    Console.WriteLine(seperator);
                    Console.WriteLine("1. Male");
                    Console.WriteLine("2. Female");
                    gender = Console.ReadLine();


                }
            }
            //Locationnnnnn
            locationsInput:
            string[] locationNum = new string[10] {
                "1","2","3","4","5","6","7","8","9","10",
            };

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.WriteLine("Please Enter your Location");
            Console.WriteLine(seperator);
            Console.WriteLine("\n1. Manila \n2. Quezon City \n3. Makati \n4. Pasay \n5. Taguig \n6. Pasig \n7. Mandaluyong \n8 Marikina \n9. Las Piñas \n10. Parañaque");
            Console.WriteLine(seperator);
            Console.Write("Enter number: ");
            string location = Console.ReadLine();

            while (true) {
                if (locationNum.Contains(location))
                {
                    break;
                }
                else {
                    goto locationsInput;
                }
            }
            //location


            Console.Clear();
        
            ArrayList sympt = new ArrayList(9);

            sympt.Add("\n\t[1.] Fever");
            sympt.Add("\t[2.] Diarrhea");
            sympt.Add("\t[3.] Fatigue");
            sympt.Add("\t[4.] Muscle aches");
            sympt.Add("\t[5.] Coughing");
            sympt.Add("\t[6.] indigestion");
            sympt.Add("\t[7.] jaw pain");
            sympt.Add("\t[8.] lightheadedness");
            sympt.Add("\t[9.] anxiety");


        
            // Console.WriteLine("Please select 4 symptoms but 1 at a time\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.WriteLine("List of symptoms");
            Console.WriteLine(seperator);
            foreach (string str in sympt)
                Console.WriteLine(str);
            Console.WriteLine("\n");

            //first input
            Console.WriteLine("Please select 4 symptoms but 1 at a time");
            symptomCollector = int.Parse(Console.ReadLine());
            while (true)
            {
                if (symptomCollector > 9)
                {

                    Console.WriteLine("Please select 4 symptoms but 1 at a time");
                    symptomCollector = int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.Clear();
            // sympt.RemoveAt(symptomCollector-1);
            sympt[symptomCollector - 1] = null;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.WriteLine("List of symptoms");
            Console.WriteLine(seperator);
            foreach (string str in sympt)
                Console.WriteLine(str);
            Console.WriteLine("\n");

            //second input
            Console.WriteLine(select3[new Random().Next(0, select3.Length)]);
            symptomCollector2 = int.Parse(Console.ReadLine());
            while (true)
            {
                if (symptomCollector2 > 9 || symptomCollector2 == symptomCollector)
                {
                    Console.WriteLine(select3[new Random().Next(0, select3.Length)]);
                    symptomCollector2 = int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.Clear();
            // sympt.RemoveAt(symptomCollector2-1); 
            sympt[symptomCollector2 - 1] = null;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.WriteLine("List of symptoms");
            Console.WriteLine(seperator);
            foreach (string str in sympt)
                Console.WriteLine(str);
            Console.WriteLine("\n");

            //third input
            Console.WriteLine(select2[new Random().Next(0, select2.Length)]);
            symptomCollector3 = int.Parse(Console.ReadLine());
            while (true)
            {
                if (symptomCollector3 > 9 || symptomCollector3 == symptomCollector || symptomCollector3 == symptomCollector2)
                {
                    Console.WriteLine(select2[new Random().Next(0, select2.Length)]);
                    symptomCollector3 = int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }

            Console.Clear();
            // sympt.RemoveAt(symptomCollector3-1); 
            sympt[symptomCollector3 - 1] = null;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.WriteLine("List of symptoms");
            Console.WriteLine(seperator);
            foreach (string str in sympt)
                Console.WriteLine(str);
            Console.WriteLine("\n");
            //fourth input
            Console.WriteLine(select1[new Random().Next(0, select1.Length)]);
            symptomCollector4 = int.Parse(Console.ReadLine());
            while (true)
            {
                if (symptomCollector4 > 9 || symptomCollector4 == symptomCollector3 || symptomCollector4 == symptomCollector2 || symptomCollector4 == symptomCollector)
                {
                    Console.WriteLine(select1[new Random().Next(0, select1.Length)]);
                    symptomCollector4 = int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }

            Console.Clear();
            // sympt.RemoveAt(symptomCollector4-1); 
            sympt[symptomCollector4 - 1] = null;
            Console.WriteLine(seperator);
            Console.WriteLine("List of symptoms");
            Console.WriteLine(seperator);
            foreach (string str in sympt)
                Console.WriteLine(str);
            Console.WriteLine("\n");

            string a = Convert.ToString(symptomCollector);
            string b = Convert.ToString(symptomCollector2);
            string c = Convert.ToString(symptomCollector3);
            string d = Convert.ToString(symptomCollector4);
            Console.Clear();

            string results;




            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);

            Console.ForegroundColor = ConsoleColor.White;
            if (foodPoisoning.Contains(a) && foodPoisoning.Contains(b)
            && foodPoisoning.Contains(c) && foodPoisoning.Contains(d))
            {
                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |   
|                    (Food Poison)                    |
+-----------------------------------------------------+
| So your main job is to drink plenty of fluids. Start| 
|with ice chips or small sips if you need to.It’s also|
|helpful to:                                          |
|                                                     |
|   - Avoid food for the first few hours as your      |
|    stomach settles down                             |
| - Drink water, broth, or an electrolyte solution,   |
|    which will replace the minerals that you lose    |
|    with vomiting and diarrhea                       |
|  - Eat when you feel ready, but start with small    |
|    amounts of bland, non fatty foods such as toast, |
|    rice, and crackers                               |
|  - Get plenty of rest                               |
|  - Stay away from dairy,caffeine, alcohol, bubbly   |
|    or fizzy drinks, or spicy and fatty foods --     |
|    they can just make everything worse              |
+-----------------------------------------------------+
            ";

                Console.WriteLine(results);

            }
            else if (crohnsDisease.Contains(a) && crohnsDisease.Contains(b)
            && crohnsDisease.Contains(c) && crohnsDisease.Contains(d))
            {
                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                  (Crohn's Disease)                  |
+-----------------------------------------------------+
| Along with the medicine your doctor prescribes, you |
|may want to add “complementary” treatments to help   |
|with Crohn’s symptoms, boost your immune system, or  |
|just feel better every day. There are many options   |
|out there, from herbal remedies to mindfulness       |
|practices.  But remember: Let your doctor know about |
|any new therapies you want to try. She can give you  |
|an idea of what’s safe and most likely to help you.  |
|                                                     |
|       - Probiotics                                  |
|       - Prebiotics                                  |
|       - Fish Oils                                   |
|       - Bowel Rest                                  |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (dyspepsia.Contains(a) && dyspepsia.Contains(b)
            && dyspepsia.Contains(c) && dyspepsia.Contains(d))
            {
                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                     (Dyspepsia)                     |
+-----------------------------------------------------+
| Along with the medicine your doctor prescribes, you |
|may want to add “complementary” treatments to help   |
|with Crohn’s symptoms, boost your immune system, or  |
|just feel better every day. There are many options   |
|out there, from herbal remedies to mindfulness       |
|practices.  But remember: Let your doctor know about |
|any new therapies you want to try. She can give you  |
|an idea of what’s safe and most likely to help you.  |
|                                                     |
|       - Probiotics                                  |
|       - Prebiotics                                  |
|       - Fish Oils                                   |
|       - Bowel Rest                                  |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (whippleDisease.Contains(a) && whippleDisease.Contains(b)
            && whippleDisease.Contains(c) && whippleDisease.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                  (Whipple Disease)                  |
+-----------------------------------------------------+
|   Treatment of Whipple disease is with antibiotics, |
|either alone or in combination, which can destroy the|
|bacteria causing the infection.                      |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (dumpingSyndrome.Contains(a) && dumpingSyndrome.Contains(b)
            && dumpingSyndrome.Contains(c) && dumpingSyndrome.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                  (dumping Syndrome)                 |
+-----------------------------------------------------+
|   Early dumping syndrome is likely to resolve on    |
|its own within three months. In the meantime, there's|
|a good chance that diet changes will ease your       |
|symptoms. If not, your doctor may recommend          |
|medications or surgery.                              |
|                                                     |
|   Medications:                                      |
|                                                     |
|   For people with severe signs and symptoms         |
|unrelieved by dietary changes, doctors sometimes     |
|prescribe octreotide (Sandostatin). This anti-       |
|diarrheal drug, administered by injection under your |
|skin (subcutaneously), can slow the emptying of food |
|into the intestine. Possible side effects include    |
|nausea, vomiting and stomach upset.                  |
|                                                     |
|    Talk with your doctor about the proper way to    |
|self-administer the drug.                            |
|                                                     |
|                                                     |
|                                                     |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (gad.Contains(a) && gad.Contains(b)
            && gad.Contains(c) && gad.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|           (Generalized Anxiety  disorder)           |
+-----------------------------------------------------+
|   Medications:                                      |
|                                                     |
|   Several types of medications are used to treat    |
|generalized anxiety disorder, including those below. |
|Talk with your doctor about benefits, risks and      |
|possible side effects.                               |
|                                                     |
|    - Buspirone. An anti-anxiety medication called   |
|buspirone may be used on an ongoing basis. As with   |
|most antidepressants,it typically takes up to several|
|weeks to become fully effective.                     |
|                                                     |
|    - Benzodiazepines. In limited circumstances, your|
|doctor may prescribe a benzodiazepine for relief of  |
|anxiety symptoms. These sedatives are generally used |
|only for relieving acuteanxiety on a short-term basis|
|Because they can be habit-forming, these medications |
|aren't a good choice if you have or had problems with|
|alcohol or drug abuse.                               |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (influenza.Contains(a) && influenza.Contains(b)
            && influenza.Contains(c) && influenza.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                     (Influenza)                     |
+-----------------------------------------------------+
|   Medications:                                      |
|                                                     |
|   Usually, you'll need nothing more than bed rest   |
|and plenty of fluids to treat the flu. But in some   |
|cases, your doctor may prescribe an antiviral        |
|medication, such as oseltamivir (Tamiflu) or         |
|zanamivir (Relenza). If taken soon after you notice  |
|symptoms, these drugs may shorten your illness by a  |
|day or so and help prevent serious complications.    | 
|                                                     |
|   Oseltamivir is an oral medication. Zanamivir is   |
|inhaled through a device similar to an asthma inhaler|
|and shouldn't be used by anyone with respiratory     |
|problems, such as asthma and lung disease.           |
|                                                     |
|    Antiviral medication side effects may include    |
|nausea and vomiting. These side effects may be       |
|lessened if the drug is taken with food. Oseltamivir |
|has also been associated with delirium and self-harm |
|behaviors in teenagers.                              |
|                                                     |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (gastroenteritis.Contains(a) && gastroenteritis.Contains(b)
            && gastroenteritis.Contains(c) && gastroenteritis.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                  (Gastroenteritis)                  |
+-----------------------------------------------------+
|                                                     |
|    Stop eating for a few hours to let your stomach  |
|settle.                                              |
|                                                     |
|    - Sip liquids, such as a sports drink or water,  |
|to prevent dehydration. Drinking fluids too quickly  |
|can worsen the nausea and vomiting, so try to take   |
|small frequent sips over a couple of hours, instead  |
|of drinking a large amount at once.                  |
|                                                     |
|    - Take note of urination. You should be urinating|
|at regular intervals, and your urine should be light |
|and clear. Infrequent passage of dark urine is a sign|
|of dehydration. Dizziness and lightheadedness also   |
|are signs of dehydration. If any of these signs and  |
|symptoms occur and you can't drink enough fluids,    |
|seek medical attention.                              |
|                                                     |
|    - Ease back into eating. Try to eat small amounts|
|of food frequently if you experience nausea.         |
|Otherwise, gradually begin to eat bland, easy to     |
|digest foods, such as soda crackers, toast, gelatin, |
|bananas, rice and chicken. Stop eating if your nausea|
|returns. Avoid milk and dairy products, caffeine,    |
|alcohol, nicotine, and fatty or highly seasoned foods|
|for a few days.                                      |
|                                                     |
|    - Get plenty of rest. The illness and dehydration|
|can make you weak and tired.                         |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (dengueFever.Contains(a) && dengueFever.Contains(b)
            && dengueFever.Contains(c) && dengueFever.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                   (Dengue Fever)                    |
+-----------------------------------------------------+
|                                                     |
|    No specific treatment for dengue fever exists.   |
|Your doctor may recommend that you drink plenty of   |
|fluids to avoid dehydration from vomiting and a      |
|high fever.                                          |
|                                                     |
|    While recovering from dengue fever, watch for    |
|signs and symptoms of dehydration. Call your doctor  |
|right away if you develop any of the following:      |
|                                                     |
|    - Decreased urination                            |
|    - Few or no tears                                |
|    - Dry mouth or lips                              |
|    - Lethargy or confusion                          |
|    - Cold or clammy extremities                     |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (flu.Contains(a) && flu.Contains(b)
            && flu.Contains(c) && flu.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                        (Flu)                        |
+-----------------------------------------------------+
|                                                     |
|   Usually, you'll need nothing more than bed rest   |
|and plenty of fluids to treat the flu. But in some   |
|cases, your doctor may prescribe an antiviral        |
|medication, such as oseltamivir (Tamiflu) or zanami- |
|vir (Relenza). If taken soon after you notice        |
|symptoms, these drugs may shorten your illness by a  |
|day or so and help prevent serious complications.    |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (irritableBowelSyndrome.Contains(a) && irritableBowelSyndrome.Contains(b)
            && irritableBowelSyndrome.Contains(c) && irritableBowelSyndrome.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|              (Irritable Bowel Syndrome)             |
+-----------------------------------------------------+
|                                                     |
|   Medications approved for certain people with      |
|IBS include:                                         |
|                                                     |
|   - Rifaximin (Xifaxan). This antibiotic can        |
|decrease bacterial overgrowth and diarrhea.          |
|                                                     |
|    - Lubiprostone (Amitiza). Lubiprostone can       |
|increase fluid secretion in your small intestine to  |
|help with the passage of stool. It's approved for    |
|women who have IBS with constipation, and is         |
|generally prescribed only for women with severe      |
|symptoms that haven't responded to other treatments. |
|                                                     |
|    - Linaclotide (Linzess). Linaclotide also can    |
|increase fluid secretion in your small intestine to  |
|help you pass stool. Linaclotide can cause diarrhea, |
|but taking the medication 30 to 60 minutes before    |
|eating might help.                                   |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (meningitis.Contains(a) && meningitis.Contains(b)
            && meningitis.Contains(c) && meningitis.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|              Treatment and Medication               |
|                   (Meningitis)              	      | 
+-----------------------------------------------------+
|                                                     |
| The treatment depends on the type of meningitis you |
|or your child has.                                   |	
|                                                     |
|   Bacterial meningitis:                             |  
|                                                     |
|   *Acute bacterial meningitis must be treated       |
|immediately with intravenous antibiotics and         |
|sometimes corticosteroids. This helps to ensure      |
|recovery and reduce the risk of complications, such  |
|as brain swelling and seizures.                      |
|                                                     |
|The antibiotic or combination of antibiotics depends |
|on the type of bacteria causing the infection. Your  |
|doctor may recommend a broad-spectrum antibiotic     |
|until he or she can determine the exact cause of the |
|meningitis. Your doctor may drain any infected       |
|sinuses or mastoids                                  |
|                                                     |
|   — the bones behind the outer ear that connects to |
|middle ear.                                          |
|                                                     |
|   *Viral meningitis                                 |
|                                                     | 
|    - Antibiotics cant cure viral meningitis,and most|
|cases improve on their own in several weeks.         |				
|Treatment of mild cases of viral meningitis usually  |
|includes:                                            |
|   - Bed rest                                        |
|   - Plenty of fluids                                |
|   - Over-the-counter pain medications to help reduce|
|fever and relieve body aches                         |
|   - Your doctor may prescribe corticosteroids to    |
|reduce swelling in the brain, and an anticonvulsant  |
|medication to control seizures. If a herpes virus    |
|caused your meningitis, an antiviral medication is   |
|available.                                           |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (gastrointestinal.Contains(a) && gastrointestinal.Contains(b)
            && gastrointestinal.Contains(c) && gastrointestinal.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|              Treatment and Medication               |
|                  (Gastro Internal)                  | 
+-----------------------------------------------------+
|-Often, GI bleeding stops on its own. If it doesn't, |
|treatment depends on where the bleed is from. In many|
|cases, medication or a procedure to control the      |
|bleeding can be given during some tests. For example,|
|it's sometimes possible to treat a bleeding peptic   |
|ulcer during an upper endoscopy or to remove polyps  |
|during a colonoscopy.                                |
|-If you have an upper GI bleed, you might be given an|
|IV drug known as a proton pump inhibitor (PPI) to    |
|suppress stomach acid production. Once the source of |
|the bleeding is identified, your doctor will         |
|determine whether you need to continue taking a PPI. |
|Depending on the amount of blood loss and whether you|
|continue to bleed, you might require fluids through a|
|needle (IV) and, possibly, blood transfusions. If you|
|take blood-thinning medications, including aspirin or|
|nonsteroidal anti-inflammatory medications, you might|
|need to stop.                                        |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (abdominalPain.Contains(a) && abdominalPain.Contains(b)
            && abdominalPain.Contains(c) && abdominalPain.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|              Treatment and Medication               |
|                  (Abdominal Pain)                   | 
+-----------------------------------------------------+
|Home Remedies:                                       |
|-You might try a heating pad to ease belly pain.     |
|Chamomile or peppermint tea may help with gas.Be sure|
|to drink plenty of clear fluids so your body has     |
|enough water.                                        |
|                                                     |
|You also can do things to make stomach pain less     |
|likely. It can help to:                              |
|-Eat several smaller meals instead of three big ones |
|-Chew your food slowly and well                      |
|-Stay away from foods that bother you (spicy or fried|
|foods, for example)                                  |
|-Ease stress with exercise, meditation, or yoga      |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (stress.Contains(a) && stress.Contains(b)
            && stress.Contains(c) && stress.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|              Treatment and Medication               |
|                     (Stress)                        | 
+-----------------------------------------------------+
|Some examples of good ways to deal with stress:      |
|                                                     |
|-Take some deep breaths.                             |
|-Talk to someone you trust.                          |
|-Create a stress diary, note down when you feel      |
|stressed and why.                                    |
|-Have a health check with your doctor.               |
|-Exercise.                                           |
|-Eat a healthy, balanced diet.                       |
|-Try to avoid smoking, alcohol and caffeine.         |
|-Make time for things you enjoy.                     |
|                                                     |
|These are ways to help you bounce back and be more   |
|resilient to stress.                                 |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (lupus.Contains(a) && lupus.Contains(b)
            && lupus.Contains(c) && lupus.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|              Treatment and Medication               |
|                      (Lupus)                        | 
+-----------------------------------------------------+
|   Treatment for lupus depends on your signs and     |
|symptoms. Determining whether your signs and symptoms|
|should be treated and what medications to use        |
|requires a careful discussion of the benefits and    |
|risks with your doctor.                              |
|                                                     |
|    As your signs and symptoms flare and subside,    |
|you and your doctor may find that you'll need to     |
|change medications or dosages. The medications most  |
|commonly used to control lupus include:              |
|                                                     |
|    - Nonsteroidal anti-inflammatory drugs (NSAIDs). |
|    - Antimalarial drugs                             |
|    - Corticosteroids                                |
|    - Immunosuppressants.                            |
|    - Biologics                                      |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (pneumonia.Contains(a) && pneumonia.Contains(b)
            && pneumonia.Contains(c) && pneumonia.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|              Treatment and Medication               |
|                     (Pneumonia)                     | 
+-----------------------------------------------------+
|Treatment for pneumonia involves curing the infection|
|and preventing complications. People who have        |
|community-acquired pneumonia usually can be treated  |
|at home with medication. Although most symptoms ease |
|in a few days or weeks, the feeling of tiredness can |
|persist for a month or more.                         |
|Specific treatment depend on the type and severity of|
|your pneumonia, your age and your overall health. The|
|options include:                                     |
|                                                     |
|-Antibiotics. These medicines are used to treat      |
|bacterial pneumonia. It may take time to identify the|
|type of bacteria causing your pneumonia and to choose|
|the best antibiotic to treat it. If your symptoms    |
|don't improve, your doctor may recommend a different |
|antibiotic.                                          |
|-Cough medicine. This medicine may be used to calm   |
|your cough so that you can rest. Because coughing    |
|helps loosen and move fluid from your lungs, it's a  |
|good idea not to eliminate your cough completely. In |
|addition, you should know that very few studies have |
|looked at whether over-the-counter cough medicines   |
|lessen coughing caused by pneumonia. If you want to  |
|try a cough suppressant, use the lowest dose that    |
|helps you rest.                                      |
|-Fever reducers/pain relievers. You may take these as|
|needed for fever and discomfort. These include drugs |
|such as aspirin, ibuprofen (Advil, Motrin IB, others)|
|and acetaminophen (Tylenol, others).                 |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (sinusInfection.Contains(a) && sinusInfection.Contains(b)
            && sinusInfection.Contains(c) && sinusInfection.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                  (Sinus Infection)                  | 
+-----------------------------------------------------+
|                                                     |
|Treatments:                                          |
|   Antibiotics are standard treatments for bacterial |
|sinus infections.Antibiotics are usually taken from 3| 
|to 28 days, depending on the type of antibiotic.     |
|Because the sinuses are deep-seated in the bones, and|
|blood supply is limited, longer treatments may be    |
|prescribed for people with longer lasting or severe  |
|cases.                                               |
|                                                     |
|    Nasal decongestant sprays Topical nasal          |
|decongestants can be helpful if used for no more than|
|three to four days.These medications shrink swollen  |
|nasal passages, facilitating the flow of drainage    |
|from the sinuses.Overuse of topical nasal            |
|decongestants can result in a dependent condition in |
|which the nasal passages swell shut, called rebound  |
|phenomenon.                                          |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (chronicCough.Contains(a) && chronicCough.Contains(b)
            && chronicCough.Contains(c) && chronicCough.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                  (Chronic Cough)                    | 
+-----------------------------------------------------+
|Medications used to treat chronic cough may include: | 
|-Antihistamines, glucocorticoids and decongestants.  |
|These drugs are standard treatment for allergies and |
|postnasal drip.				                      |
|-Inhaled asthma drugs. The most effective treatments |
|for asthma-related cough are glucocorticoids and     |
|bronchodilators, which reduce inflammation and open  |
|up your airways.				                      |
|-Antibiotics.If a bacterial infection is causing your|
|chronic cough, your doctor may prescribe antibiotics.|
|-Acid blockers.When lifestyle changes don't take care|
|of acid reflux, you may be treated with medications  |
|that block acid production. Some people need surgery |
|to resolve the problem.			                  |
|-Cough suppressants. If the reason for your cough    |
|can't be determined and it's causing serious problems|
|for you, such as keeping you from sleeping, your     |
|doctor may prescribe a cough suppressant. However,   |
|there's no evidence that over-the-counter cough      |
|medicines are effective.			                  |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (heartBurn.Contains(a) && heartBurn.Contains(b)
            && heartBurn.Contains(c) && heartBurn.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                    (Heartburn)                      | 
+-----------------------------------------------------+
|  Many over-the-counter medications can help relieve |
|heartburn. The options include:                      |
|                                                     |
|-Antacids,which help neutralize stomach acid.Antacids|
|may provide quick relief. But they can't heal an     |
|esophagus damaged by stomach acid.                   |
|                                                     |
|-H-2-receptor antagonists (H2RAs), which can reduce  |
|stomach acid. H2RAs don't act as quickly as antacids,|
|but may provide longer relief.                       |
|                                                     |
|-Proton pump inhibitors, such as lansoprazole        |
|(Prevacid 24HR) and omeprazole (Nexium 24HR, Prilosec|
|OTC), which also can reduce stomach acid.            |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (tuberculousMeningitis.Contains(a) && tuberculousMeningitis.Contains(b)
            && tuberculousMeningitis.Contains(c) && tuberculousMeningitis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|              (Tuberculous Meningitis)               | 
+-----------------------------------------------------+
|  Treatment:                                         |
|The treatment depends on the type of meningitis you  |
|or your child has.                                   |
|                                                     |
|*Bacterial meningitis                                |
| -Acute bacterial meningitis must be treated         |
|immediately with intravenous antibiotics and         |
|sometimes corticosteroids. This helps to ensure      |
|recovery and reduce the risk of complications, such  |
|as brain swelling and seizures.                      |
|                                                     |
|The antibiotic or combination of antibiotics depends |
|on the type of bacteria causing the infection. Your  |
|doctor may recommend a broad-spectrum antibiotic     |
|until he or she can determine the exact cause of the |
|meningitis.                                          |
|                                                     |
|Your doctor may drain any infected sinuses or        |
| mastoids — the bones behind the outer ear that      |
|connect to the middle ear.                           |
|                                                     |
|*Viral meningitis                                    |
| -Antibiotics can't cure viral meningitis, and most  |
|cases improve on their own in several weeks.Treatment|
|of mild cases of viral meningitis usually includes:  |
|                                                     |
|-Bed rest                                            |
|-Plenty of fluids                                    |
|-Over-the-counter pain medications to help reduce    |
|fever and relieve body aches                         |
|-Your doctor may prescribe corticosteroids to reduce |
|swelling in the brain, and an anticonvulsant         |
|medication to control seizures. If a herpes virus    |
|caused your meningitis, an antiviral medication is   |
|available.                                           |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (viralPharyngitis.Contains(a) && viralPharyngitis.Contains(b)
            && viralPharyngitis.Contains(c) && viralPharyngitis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                (Viral Pharyngitis)                  | 
+-----------------------------------------------------+
| Treatment:					                      |
|-There is no specific treatment for viral pharyngitis|
|You can relieve symptoms by gargling with warm salt  |
|water several times a day (use one half teaspoon or 3|
|grams of salt in a glass of warm water). Taking      |
|anti-inflammatory medicine, such as acetaminophen,can| 
|control fever. Excessive use of anti-inflammatory    |
|lozenges or sprays may make a sore throat worse.     |
|						                              |
|-It is important NOT to take antibiotics when a sore |
|throat is due to a viral infection. The antibiotics  |
|will not help. Using them to treat viral infections  |
|helps bacteria become resistant to antibiotics.      |
|						                              |
|-With some sore throats (such as those caused by     |
|infectious mononucleosis),the lymph nodes in the neck|
|may become very swollen. Your provider may prescribe |
|anti-inflammatory drugs, such as prednisone, to treat|
|them.						                          |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (vertigo.Contains(a) && vertigo.Contains(b)
            && vertigo.Contains(c) && vertigo.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                    (Vertigo)                        | 
+-----------------------------------------------------+
| Medications:					                      |
|*Water pills. If you have Meniere's disease, your    |
|doctor may prescribe a water pill (diuretic). This   |
|along with a low-salt diet may help reduce how often |
|you have dizziness episodes.			              |
|*Medications that relieve dizziness and nausea. Your |  
|doctor may prescribe drugs to provide immediate      |
|relief from vertigo, dizziness and nausea, including |
|prescription antihistamines and anticholergenics.Many|
|of these drugs cause drowsiness.		              |
|*Anti-anxiety medications. Diazepam (Valium) and     |
|alprazolam (Xanax) are in a class of drugs called    |
|benzodiazepines, which may cause addiction. They may |
|also cause drowsiness.				                  |
|*Preventive medicine for migraine. Certain medicines |
|may help prevent migraine attacks.		              |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (laryngitis.Contains(a) && laryngitis.Contains(b)
            && laryngitis.Contains(c) && laryngitis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                   (Laryngitis)                      | 
+-----------------------------------------------------+
| Treatment:                                          |
|-Acute laryngitis often gets better on its own within|
|a week or so. Self-care measures also can help       |
|improve symptoms.                                    |
|                                                     |
|-Chronic laryngitis treatments are aimed at treating |
|the underlying causes, such as heartburn, smoking or |
|excessive use of alcohol.                            |
|                                                     |
|Medications used in some cases include:              |
|                                                     |
|*Antibiotics. In almost all cases of laryngitis, an  |
|antibiotic won't do any good because the cause is    |
|usually viral. But if you have a bacterial infection,|
|your doctor may recommend an antibiotic.             |
|*Corticosteroids. Sometimes, corticosteroids can help|
|reduce vocal cord inflammation.However,this treatment|
|is used only when there's an urgent need to treat    |
|laryngitis — for example, when you need to use your  |
|voice to sing or give a speech or oral presentation, |
|or in some cases when a toddler has laryngitis       |
|associated with croup.                               |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (colds.Contains(a) && colds.Contains(b)
            && colds.Contains(c) && colds.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                     (Colds)                         | 
+-----------------------------------------------------+
|                                                     |
|If you catch a cold,you can expect to be sick for one|
|to two weeks. That doesn't mean you have to be       |
|miserable. Besides getting enough rest, these        |
|remedies might help you feel better:                 |
|                                                     |
|*Stay hydrated. Water, juice, clear broth or warm    |
|lemon water with honey helps loosen congestion and   |
|prevents dehydration. Avoid alcohol, coffee and      |
|caffeinated sodas, which can make dehydration worse. |
|*Rest.Your body needs to heal.                       |
|*Soothe a sore throat. A saltwater gargle — 1/4 to   |
|1/2 teaspoon salt dissolved in an 8-ounce glass of   |
|warm water — can temporarily relieve a sore or       |
|scratchy throat. Children younger than 6 years are   |
|unlikely to be able to gargle properly.              |
|                                                     |
|*Relieve pain. For children 6 months or younger, give|
|only acetaminophen. For children older than 6 months,|
|give either acetaminophen or ibuprofen. Ask your     |
|child's doctor for the correct dose for your child's |
|age and weight. Adults can take acetaminophen        |
|(Tylenol, others), ibuprofen                         |
|(Advil, Motrin IB, others) or aspirin.               |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (anxietyCough.Contains(a) && anxietyCough.Contains(b)
            && anxietyCough.Contains(c) && anxietyCough.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                  (Anxiety Cough)                    | 
+-----------------------------------------------------+
| Treatment:					                      |
|*Learn to deep breathe. This is essentially a        |
|relaxation exercise. Breathe in slowly through your  |
|nose for about five seconds. Hold your breath for two|
|seconds. Breathe out through your mouth for at least |
|seven seconds. Do this multiple times every day.     |
|*Learn to think differently.Rather than allowing your|
|thoughts to stay on anxious things, list several     |
|positive things you can think about. When you feel   |
|anxious, pull out the list and think about one of the|
|positive things.				                      |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (heartAttack.Contains(a) && heartAttack.Contains(b)
            && heartAttack.Contains(c) && heartAttack.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                  (Heart Attack)                     | 
+-----------------------------------------------------+
| **What to do if you or someone else may be having a |
|     heart attack?                                   |
|- Call 911 or your local medical emergency number.   |
|Don't ignore or attempt to tough out the symptoms of |
|a heart attack for more than five minutes. If you    |
|don't have access to emergency medical services, have|
|a neighbor or a friend drive you to the nearest      |
|hospital. Drive yourself only as a last resort, and  |
|realize that it places you and others at risk when   |
|you drive under these circumstances.                 |
|- Chew and swallow an aspirin,unless you are allergic|
|to aspirin or have been told by your doctor never to |
|take aspirin. But seek emergency help first, such as |
|calling 911.                                         |
|- Take nitroglycerin, if prescribed. If you think    |
|you're having a heart attack and your doctor has     |
|previously prescribed nitroglycerin for you, take it |
|as directed. Do not take anyone else's nitroglycerin,|
|because that could put you in more danger.           |
|- Begin CPR if the person is unconscious. If you're  |
|with a person who might be having a heart attack and |
|he or she is unconscious, tell the 911 dispatcher or |
|another emergency medical specialist. You may be     |
|advised to begin cardiopulmonary resuscitation (CPR).|  
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (acidReflux.Contains(a) && acidReflux.Contains(b)
            && acidReflux.Contains(c) && acidReflux.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                  (Acid Reflux)                      | 
+-----------------------------------------------------+
| -- One of the most effective ways to treat acid     |
|reflux disease is to avoid the foods and beverages   |
|that trigger symptoms. Here are other steps you can  |
|take:						                          |
|						                              |
|*Eat smaller meals more frequently throughout the day|
|and modify the types of foods you are eating..       |
|*Quit smoking.					                      |
|*Put blocks under the head of your bed to raise it at|
|least 4 inches to 6 inches.			              |
|*Eat at least 2 to 3 hours before lying down.        |
|*Try sleeping in a chair for daytime naps.           |
|*Don't wear tight clothes or tight belts.            |
|*If you're overweight or obese, take steps to lose   |
|weight with exercise and diet changes.               |
|*Also, ask your doctor whether any medication could  |
|be triggering your heartburn or other symptoms of    |
|acid reflux disease.				                  |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (GERD.Contains(a) && GERD.Contains(b)
            && GERD.Contains(c) && GERD.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|          (Gastroesophageal reflux disease)          | 
+-----------------------------------------------------+
| Treatment:                                          |
|- GERD will often be treated with medications before |
|attempting other lines of treatment.                 |
|                                                     |
|- Proton pump inhibitors are one of the main         |
|pharmaceutical treatment options for people with GERD|
|.They decrease the amount of acid produced by the    |
|stomach.                                             |
|                                                     |
|Other options include:                               |
|                                                     |
|*H2 blockers: These are another option to help       |
|decrease acid production.                            |
|*Antacids: These counteract the acid in the stomach  |
|with alkaline chemicals. Side effects can include    |
|diarrhea and constipation. Antacids are available to |
|purchase online.                                     |
|*Prokinetics: These help the stomach empty faster.   |
|Side effects include diarrhea, nausea, and anxiety.  |
|*Erythromycin: Ths is a type of antibiotic that also |
|helps empty the stomach.                             |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (depression.Contains(a) && depression.Contains(b)
            && depression.Contains(c) && depression.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                   (Depression)                      | 
+-----------------------------------------------------+
|         -- Depression treatment tips --             |
|*Learn as much as you can about your depression.     |
|It’s important to determine whether your depression  |
|symptoms are due to an underlying medical condition. | 
|If so, that condition will need to be treated first. |
|						                              |
|*It takes time to find the right treatment. It might |
|take some trial and error to find the treatment and  |
|support that works best for you.                     |
|						                              |
|*Don’t rely on medications alone. Although medication| 
|can relieve the symptoms of depression, it is not    |
|usually suitable for long-term use. Other treatments,|
|including exercise and therapy, can be just as       |
|effective as medication, often even more so,but don’t|
|come with unwanted side effects. If you do decide to |
|try medication, remember that medication works best  |
|when you make healthy lifestyle changes as well.     |
|						                              |
|*Get social support. The more you cultivate your     |
|social connections, the more protected you are from  |
|depression. If you are feeling stuck, don’t hesitate |
|to talk to trusted family members or friends, or seek|
|out new connections at a depression support group.   |
|						                              |
|*Treatment takes time and commitment. All of these   |
|depression treatments take time, and sometimes it    |
|might feel overwhelming or frustratingly slow.That is| 
|normal. Recovery usually has its ups and downs.      |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (pericarditis.Contains(a) && pericarditis.Contains(b)
            && pericarditis.Contains(c) && pericarditis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                   (Pericarditis)                    | 
+-----------------------------------------------------+
|        -- Specific Types of Treatment --            |
|*First, your doctor may advise you to rest until you |
|feel better and have no fever. He or she may tell you|
|to take over-the-counter, anti-inflammatory medicines|
|to reduce pain and inflammation. Examples of these   |
|medicines are aspirin and ibuprofen.                 |
|                                                     |
|*Stronger medicine may be needed if the pain is      |
|severe. Your doctor may prescribe a medicine called  |
|colchicine and a steroid called prednisone.          |
|                                                     |
|*If an infection is causing your pericarditis, your  |
|doctor will prescribe an antibiotic or other medicine|
|.You may need to stay in the hospital during         |
|treatment so your doctor can check you for           |
|complications.Symptoms of acute pericarditis can last| 
|from a few days to three weeks. Chronic pericarditis |
|may last several months.                             |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (aorticAneurysm.Contains(a) && aorticAneurysm.Contains(b)
            && aorticAneurysm.Contains(c) && aorticAneurysm.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                 (Aortic Aneurysm)                   | 
+-----------------------------------------------------+
|                  -- Treatment --		              |
|- The goal of treatment — either medical monitoring  |
|or surgery is to prevent your aneurysm from rupturing| 
|						                              |
|*Medical monitoring                                  |
| - Your doctor might recommend this option if your   |
|abdominal aortic aneurysm is small and you don't have|
|symptoms.You'll have regular appointments to check if|
|your aneurysm is growing, treatment to manage other  |
|medical conditions, such as high blood pressure, that|
|could worsen your aneurysm.			              |
|						                              |
|*Surgery					                          |
|- Repair is generally recommended if your aneurysm is|
|1.9 to 2.2 inches (4.8 to 5.6 centimeters) or larger |
|or if it's growing quickly. Also, your doctor might  |
|recommend surgery if you have symptom such as stomach|
|pain or you have a leaking,tender or painful aneurysm|
|						                              |
| -- Depending on several factors, including location |
|and size of the aneurysm, your age, and other        |
|conditions you have, repair options might include:   |
|						                              |
|*Open abdominal surgery. This involves removing the  |
|damaged section of the aorta and replacing it with a |
|synthetic tube (graft), which is sewn into place.Full|
|recovery is likely to take a month or more.	      |
|*Endovascular repair. This less invasive procedure is|
|used more often. Doctors attach a synthetic graft to |
|the end of a thin tube (catheter) that's inserted    |
|through an artery in your leg and threaded into your |
|aorta.						                          |
|						                              |
|(Long-term survival rates are similar for both       |
|endovascular surgery and open surgery).              |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (brucellosis.Contains(a) && brucellosis.Contains(b)
            && brucellosis.Contains(c) && brucellosis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                   (Brucellosis)                     | 
+-----------------------------------------------------+
|       -- How Is Brucellosis Treated? --             |
|- Brucellosis can be difficult to treat. If you have |
|brucellosis, your doctor will prescribe antibiotics. |
|Antibiotics commonly used to treat brucellosis       |
|include:                                             |
|                                                     |
|*doxycycline (Acticlate, Monodox, Vibra-Tabs,        |
|Vibramycin)                                          |
|*streptomycin                                        |
|*ciprofloxacin (Cipro) or ofloxacin (Floxin)         |
|*rifampin (Rifadin, Rimactane)                       |
|*sulfamethoxazole/trimethoprim (Bactrim)             |  
|*tetracycline (Sumycin)                              |
|                                                     |
|- You will generally be given doxycycline and        |
|rifampin a in combination for 6-8 weeks.             |
|                                                     |
|- You must take the antibiotics for many weeks to    | 
|prevent the disease from returning.  The rate of     |
|relapse following treatment is about 5-15% and       |
|usually occurs within the first six months after     |
|treatment.                                           |
|                                                     |
|- Recovery can take weeks, even months. Patients who |
|receive treatment within one month of the start of   |
|symptomscan be cured of the disease.                  |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (flukeInfection.Contains(a) && flukeInfection.Contains(b)
            && flukeInfection.Contains(c) && flukeInfection.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                 (Fluke Infection)                   | 
+-----------------------------------------------------+
|                  -- Treatments --		              |
|*A medication called triclabendazole is commonly used|
|to treat a liver fluke infection, as this effectively|
|kills the liver flukes and their eggs.		          |
|						                              |
|*Other drugs, such as pain relievers, may be used to |
|treat some of the symptoms such as pain and diarrhea.|
|						                              |
|*Surgery may be necessary in rare cases where        |
|cholangitis, an infection of the bile ducts in the   |
|liver, has developed.				                  |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (irritablebowelsyndrome.Contains(a) && irritablebowelsyndrome.Contains(b)
            && irritablebowelsyndrome.Contains(c) && irritablebowelsyndrome.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|             (Irritable Bowel Syndrome)              |
+-----------------------------------------------------+
|                                                     |
|   Avoid foods that trigger your symptoms            |
|   Eat high-fiber foods                              |
|   Drink plenty of fluids                            |
|   Exercise regularly                                |
|   Get enough sleep                                  |
|   Your doctor might suggest that you eliminate      |
| from your diet                                      |
|   A dietitian can help you with these diet changes  |
|                                                     |
|   Fiber supplements                                 |
|   Laxatives                                         |
|   Anti-diarrheal medications                        |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (panicAttack.Contains(a) && panicAttack.Contains(b)
            && panicAttack.Contains(c) && panicAttack.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                   (Panic Attack)                    |
+-----------------------------------------------------+
|    If one medication doesn't work well for you, your| 
|doctor may recommend switching to another or         |
|combining certain medications to boost effectiveness.|
|Keep in mind that it can take several weeks after    |
|first starting a medication to notice an improvement |
|in symptoms.                                         |
|                                                     |
|    All medications have a risk of side effects, and |
|some may not be recommended in certain situations,   |
|such as pregnancy. Talk with your doctor about       |
|possible side effects and risks.                     |
|                                                     |
|    Benzodiazepines                                  |
|    Serotonin and norepinephrine reuptake inhibitors |
|    Selective serotonin reuptake inhibitors          |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (chronicFatigueSyndrome.Contains(a) && chronicFatigueSyndrome.Contains(b)
            && chronicFatigueSyndrome.Contains(c) && chronicFatigueSyndrome.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|              (Chronic Fatigue Syndrome)             |
+-----------------------------------------------------+
|    Cognitive training. Talking with a counselor can |
|help you figure out options to work around some of   |
|the limitations that chronic fatigue syndrome imposes|
|on you. Feeling more in control of your life can     |
|improve your outlook dramatically.                   |
|                                                     |
|    Graded exercise. A physical therapist can help   |
|determine what exercises are best for you. Inactive  |
|people often begin with range-of-motion and          |
|stretching exercises for just a few minutes a day.   |
|Gradually increasing the intensity of your exercise  |
|over time may help reduce your hypersensitivity to   |
|exercise, just like allergy shots gradually reduce   |
|a person's hypersensitivity to a particular allergen.|
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (viralHepatitis.Contains(a) && viralHepatitis.Contains(b)
            && viralHepatitis.Contains(c) && viralHepatitis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                   (Viral Hepatitis)                 |
+-----------------------------------------------------+
|    No specific treatment exists for hepatitis A.    |
|Your body will clear the hepatitis A virus on its    |
|own. In most cases of hepatitis A, the liver heals   |
|within six months with no lasting damage.            |
|                                                     |
|    Hepatitis A treatment usually focuses on keeping |
|comfortable and controlling signs and symptoms.      |
|You may need to:                                     |
|                                                     |
|    - Rest.                                          |
|                                                     |
|    Many people with hepatitis A infection feel tired|
|and sick and have less energy.                       |
|                                                     |
|                                                     |
|    - Manage nausea                                  |
|    - Avoid alcohol and use medications with care    |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (cholera.Contains(a) && cholera.Contains(b)
            && cholera.Contains(c) && cholera.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                      (Cholera)                      |
+-----------------------------------------------------+
|    Cholera requires immediate treatment because the |
|disease can cause death within hours.                |
|                                                     |
|    - Rehydration. The goal is to replace lost fluids|
|and electrolytes using a simple rehydration solution,|
|oral rehydration salts (ORS). The ORS solution is    |
|available as a powder that can be reconstituted in   |
|boiled or bottled water. Without rehydration,        |
|approximately half the people with cholera die. With |
|treatment, the number of fatalities drops to less    |
|than 1 percent.                                      |
|                                                     |
|   - Intravenous fluids. During a cholera epidemic,  |
|most people can be helped by oral rehydration alone, |
|but severely dehydrated people may also need         |
|intravenous fluids.                                  |
|                                                     |
|    - Antibiotics. While antibiotics are not a       |
|necessary part of cholera treatment, some of these   |
|drugs may reduce both the amount and duration of     |
|cholera-related diarrhea for people who are severely |
|ill.                                                 |
|                                                     |
|    - Zinc supplements. Research has shown that zinc |
|may decrease and shorten the duration of diarrhea in |
|children with cholera.                               |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (strongyloidiasis.Contains(a) && strongyloidiasis.Contains(b)
            && strongyloidiasis.Contains(c) && strongyloidiasis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                  (strongyloidiasis)                 |
+-----------------------------------------------------+
|    The initial sign of acute strongyloidiasis, if   |
|noticed at all, is a localized pruritic, erythematous|
|rash at the site of skin penetration. Patients may   |
|then develop tracheal irritation and a dry cough as  |
|the larvae migrate from the lungs up through the     |
|trachea. After the larvae are swallowed into the     |
|gastrointestinal tract, patients may experience      |
|diarrhea, constipation, abdominal pain, and anorexia.|
|                                                     |
|NO CURE!                                             |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (malaria.Contains(a) && malaria.Contains(b)
            && malaria.Contains(c) && malaria.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                      (Malaria)                      |
+-----------------------------------------------------+
|                                                     |
|    The most common antimalarial drugs include:      |
|                                                     |
|    - Artemisinin-based combination therapies (ACTs).|
|ACTs are, in many cases, the first line treatment for|
|malaria. There are several different types of ACTs.  |
|Examples include artemether-lumefantrine (Coartem)   |
|and artesunate-amodiaquine. Each ACT is a combination|
|of two or more drugs that work against the malaria   |
|parasite in different ways.                          |
|                                                     |
|    - Chloroquine phosphate. Chloroquine is the      |
|preferred treatment for any parasite thats sensitive |
|to the drug. But in many parts of the world, the     |
|parasites that cause malaria are resistant to        |
|chloroquine, and the drug is no longer an effective  |
|treatment.                                           |
|                                                     |
|                                                     |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (sepsisAndShock.Contains(a) && sepsisAndShock.Contains(b)
            && sepsisAndShock.Contains(c) && sepsisAndShock.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                   (sepsisAndShock)                  |
+-----------------------------------------------------+
|                                                     |
|    A number of medications are used in treating     |
|sepsis and septic shock. They include:               |
|                                                     |
|   - Antibiotics. Treatment with antibiotics should  |
|begin immediately. Initially you'll receive broad-   |
|spectrum antibiotics, which are effective against    |
|a variety of bacteria. The antibiotics are           |
|administered intravenously (IV).                     |
|                                                     |
|    - After learning the results of blood tests, your|
|doctor may switch to a different antibiotic that's   |
|targeted to fight the particular bacteria causing    |
|the infection.                                       |
|                                                     |
|   - Intravenous fluids. People who have sepsis often|
|receive intravenous fluids right away, usually within|
|three hours.                                         |
|                                                     |
|    - Vasopressors. If your blood pressure remains   |
|too low even after receiving intravenous fluids, you |
|may be given a vasopressor medication which constrict|
|blood vessels and helps to increase blood pressure.  |
|                                                     |
|    Other medications you may receive include low    |
|doses of corticosteroids, insulin to help maintain   |
|stable blood sugar levels, drugs that modify the     |
|immune system responses, and painkillers or          |
|sedatives.                                           |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (pseudomonas.Contains(a) && pseudomonas.Contains(b)
            && pseudomonas.Contains(c) && pseudomonas.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|               (Pseudomonas Infection)               |
+-----------------------------------------------------+
|                                                     |
|    Antibiotics are the best option to treat         |
|Pseudomonas or other bacterial infections.           |                                 
|                                                     |
|    Some Pseudomonas infections require an aggressive|
|approach with powerful drugs. The earlier the        |
|treatment begins, the more effective it is in        |
|stopping the infection.                              |
|                                                     |
|    This is particularly true in the hospital        |
|environment. The bacteria in hospitals get regular   |
|exposure to antibiotics, and, over time, develop     |
|resistance to these drugs. This makes them more      |
|difficult to treat.                                  |
|                                                     |
|    Once doctors know which type of Pseudomonas      |
|bacteria is responsible for the infection and whether|
|or not this strain is resistant to any drugs,they can|
|combine medications to make treatment more effective.|
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (drugOverdose.Contains(a) && drugOverdose.Contains(b)
            && drugOverdose.Contains(c) && drugOverdose.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                   (Drug Overdose)                   |
+-----------------------------------------------------+
|                                                     |
|    If you think someone has taken an overdose:      |
|                                                     |
|    - Stay calm.                                     |
|    - Call an ambulance on triple zero (000).        |
|    - If the person is unconscious but breathing,    |
|place them on their side in the recovery position.   |
|Make sure that the airway remains open by tilting the| 
|head back and lifting the chin. Check breathing and  |
|monitor their condition until help arrives.          |
|    - Do not try to make the person vomit.           |
    - Do not give them anything to eat or drink.      |
    - Bring the pill containers to hospital.          |
    - Even if the person seems okay, call the Poisons |
Information Centre on 13 11 26 for advice on what     |
to do to help. The centre is open 24 hours, 7 days    |
a week.                                               |
                                                      |
    Some knowledge of basic first aid could mean the  |
difference between life and death in an emergency.    |    
Consider doing a first aid course, so that you will be| 
able to manage if someone is injured or becomes ill.  |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (toxicShockSyndrome.Contains(a) && toxicShockSyndrome.Contains(b)
            && toxicShockSyndrome.Contains(c) && toxicShockSyndrome.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                (Toxic Shock Syndrome)               |
+-----------------------------------------------------+
|                                                     |
|    If you develop toxic shock syndrome, you'll      |
|likely be hospitalized. In the hospital, you'll:     |
|                                                     |
|    - Be treated with antibiotics while doctors seek |
|the infection source                                 |
|                                                     |
|    - Receive medication to stabilize your blood     |
|pressure if it's low (hypotension) and fluids to     |
|treat dehydration                                    |
|                                                     |
|    - Receive supportive care to treat other signs   |
|and symptoms                                         |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (eosinophiliaMyalgiaSyndrome.Contains(a) && eosinophiliaMyalgiaSyndrome.Contains(b)
            && eosinophiliaMyalgiaSyndrome.Contains(c) && eosinophiliaMyalgiaSyndrome.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|            (Eosinophilia-Myalgia Syndrome)          |
+-----------------------------------------------------+
|                                                     |
|    There is no cure for EMS, so treatment focuses   |
|on relieving symptoms. Those with EMS may be         |
|prescribed muscle relaxants and pain relievers.      |
|Prednisone helps some people, but not all. EMS is a  |
|chronic (long-term) illness. In a study of 333 people|
|with EMS, only 10 percent reported a full recovery   |
|after four years with the disease.                   |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (sickleCellAnemia.Contains(a) && sickleCellAnemia.Contains(b)
            && sickleCellAnemia.Contains(c) && sickleCellAnemia.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                (Sickle Cell Anemia)                 |
+-----------------------------------------------------+
|                                                     |
|    Medications used to treat sickle cell anemia     |
|include:                                             |
|                                                     |
|    - Antibiotics. Children with sickle cell anemia  |      
|may begin taking the antibiotic penicillin when      | 
|they're about 2 months old and continue taking it    | 
|until they're at least 5 years old. Doing so helps   |
|prevent infections, such as pneumonia, which can be  |
|life-threatening to an infant or child with sickle   |
|cell anemia.                                         |
|                                                     |
|    - As an adult, if you've had your spleen removed |
|or had pneumonia, you might need to take penicillin  |
|throughout your life.                                |
|                                                     |
|    - Hydroxyurea (Droxia, Hydrea). When taken daily,|
|hydroxyurea reduces the frequency of painful crises  |
|and might reduce the need for blood transfusions and |
|hospitalizations. Hydroxyurea seems to work by       |
|stimulatingproduction of fetal hemoglobin — a type of|
|hemoglobin found in newborns that helps prevent the  |
|formation of sickle cells.                           |
|                                                     |
|    - Pain-relieving medications. To relieve pain    |
|during a sickle cell crisis, your doctor might       |
|prescribe pain medications.                          |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (stressHeadache.Contains(a) && stressHeadache.Contains(b)
            && stressHeadache.Contains(c) && stressHeadache.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                  (Stress Headache)                  |
+-----------------------------------------------------+
|                                                     |
|   You can take over-the-counter (OTC) pain          |
|medications, such as ibuprofen or aspirin, to get    |
|rid of a tension headache. However, these should only|
|be used occasionally.                                |
|                                                     |
|    According to the Mayo Clinic, using OTC          |
|medications too much may lead to “overuse” or        |
|“rebound” headaches. These types of headaches occur  |
|when you become so accustomed to a medication that   |
|you experience pain when the drugs wear off.         |
|                                                     |
|    If painkillers aren’t working, your doctor may   |
|prescribe a muscle relaxant. This is a medication    |
|that helps stop muscle contractions. Your doctor may |
|also prescribe an antidepressant, such as a selective|
|serotonin reuptake inhibitor (SSRI). SSRIs can       |
|stabilize your brain’s levels of serotonin and can   |
|help you cope with stress.                           |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (bacterialMeningitis.Contains(a) && bacterialMeningitis.Contains(b)
            && bacterialMeningitis.Contains(c) && bacterialMeningitis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                (Bacterial meningitis)               |
+-----------------------------------------------------+
|                                                     |
|   Acute bacterial meningitis must be treated        |
|immediately with intravenous antibiotics and         |
|sometimes corticosteroids. This helps to ensure      |
|recovery and reduce the risk of complications, such  |
|as brain swelling and seizures.                      |
|                                                     |
|    The antibiotic or combination of antibiotics     |
|depends on the type of bacteria causing the infection|
|Your doctor may recommend a broad-spectrum antibiotic|
|until he or she can determine the exact cause of the |
|meningitis.                                          |
|                                                     |
|    Your doctor may drain any infected sinuses or    |
|mastoids — the bones behind the outer ear that       |
|connect to the middle ear.                           |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (atypicalPneumonia.Contains(a) && atypicalPneumonia.Contains(b)
            && atypicalPneumonia.Contains(c) && atypicalPneumonia.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                 (Atypical Pneumonia)                |
+-----------------------------------------------------+
|                                                     |
|   Pneumonia usually goes away on its own after a    |
|few weeks or months. If the symptoms are severe      |
|enough to require treatment, there are several types |
|of antibiotics available that are effective. Use of  |
|antibiotics may shorten the recovery period.         |
|                                                     |
|    Antibiotics that are used to treat mycoplasma    |
|pneumonia, chlamydia pneumonia, and Legionnaires’    |
|disease include:                                     |
|                                                     |
|    - Macrolide antibiotics: Macrolide drugs are the |
|preferred treatment for children and adults.         |
||Macrolides include azithromycin (Zithromax®) and    |
|clarithromycin (Biaxin®).                            |
|    - Fluoroquinolones: These drugs include          |
|ciprofloxacin (Cipro®) and levofloxacin (Levaquin®). |
|Fluoroquinolones are not recommended for young       |
|children.                                            |
|    - Tetracyclines: This group includes doxycycline |
|and tetracycline. They are suitable for adults and   |
|older children.                                      |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (pancreaticCancer.Contains(a) && pancreaticCancer.Contains(b)
            && pancreaticCancer.Contains(c) && pancreaticCancer.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                  (Pancreatic Cancer)                |
+-----------------------------------------------------+
|                                                     |
|   There are different types of treatment for        |
|patients with pancreatic cancer.Five types of        |
|standard treatment are used:                         |
|                                                     |
|    - Surgery                                        |
|    - Radiation therapy                              |
|    - Chemotherapy                                   |
|    - Chemoradiation therapy                         |
|    - Targeted therapy                               |
|                                                     |
|There are treatments for pain caused by pancreatic   |
|cancer.Patients with pancreatic cancer have special  |
|nutritional needs.New types of treatment are being   |
|tested in clinical trials.                           |
|                                                     |
|------------------Biologic therapy-------------------|
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (pepticUlcer.Contains(a) && pepticUlcer.Contains(b)
            && pepticUlcer.Contains(c) && pepticUlcer.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                    (Peptic Ulcer)                   |
+-----------------------------------------------------+
|                                                     |
|   Treatment for peptic ulcers depends on the cause. |
|Usually treatment will involve killing the H. pylori |
|bacterium, if present, eliminating or reducing use   |
|of NSAIDs, if possible, and helping your ulcer to    |
|heal with medication.                                |
|                                                     |
|    Medications can include:                         |
|                                                     |
|    - Antibiotic medications to kill H. pylori.      |
|    - Medications that block acid production and     |
|promote healing.                                     |
|    - Medications to reduce acid production.         |
|    - Antacids that neutralize stomach acid.         |
|    - Medications that protect the lining of your    |
|stomach and small intestine.                         |
|                                                     |  
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (thoracicAorticAneurysm.Contains(a) && thoracicAorticAneurysm.Contains(b)
            && thoracicAorticAneurysm.Contains(c) && thoracicAorticAneurysm.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|              (Thoracic Aortic Aneurysm)             |
+-----------------------------------------------------+
|                                                     |
|   If you have high blood pressure or blockages in   |
|your arteries, it's likely that your doctor will     | 
|prescribe medications to lower your blood pressure   |
|and reduce your cholesterol levels to reduce the risk|
|of complications from your aneurysm.                 |
|    These medications could include:                 |
|                                                     |
|    - Beta blockers. Beta blockers lower your blood  |
|pressure by slowing your heart rate. For people with |
|Marfan syndrome, beta blockers may reduce how fast   |
|the aorta is dilating. Examples of beta blockers     |
|include metoprolol (Lopressor, Toprol-XL), atenolol  |
|(Tenormin) and bisoprolol (Zebeta).                  |
|                                                     |
|    - Angiotensin II receptor blockers. Your doctor  |
|may also prescribe these medications if beta blockers|
|aren't enough to control your blood pressure or if   |
|you can't take beta blockers. These medications are  |
|often recommended for people who have Marfan         |
|syndrome, even if they don't have high blood         |
|pressure. Examples of angiotensin II receptor        | 
|blockers include losartan (Cozaar), valsartan        |
|(Diovan) and olmesartan (Benicar).                   |
|                                                     |
|    - Statins. These medications can help lower your |
|cholesterol, which can help reduce blockages in your |
|arteries and reduce your risk of aneurysm            |
|complications. Examples of statins include           |
|atorvastatin (Lipitor), lovastatin (Altoprev),       |
|simvastatin (Zocor) and others.                      |
|                                                     |
|If you smoke or chew tobacco, it's important that you|
|quit. Using tobacco can worsen your aneurysm.        |
|                                                     |  
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (endometriosis.Contains(a) && endometriosis.Contains(b)
            && endometriosis.Contains(c) && endometriosis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                  (Endometriosis)                    |
+-----------------------------------------------------+
|                                                     |
|   Your doctor may recommend that you take an over-  |
|the-counter pain reliever, such as the nonsteroidal  |
|anti-inflammatory drugs (NSAIDs) ibuprofen (Advil,   |
|Motrin IB, others) or naproxen sodium (Aleve, others)|
|to help ease painful menstrual cramps.               |
|                                                     |  
|    If you find that taking the maximum dose of these|
|medications doesn't provide full relief, you may need|
|to try another approach to manage your signs and     |
|symptoms.                                            |
|                                                     |  
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (TrigeminalNeuralgia.Contains(a) && TrigeminalNeuralgia.Contains(b)
            && TrigeminalNeuralgia.Contains(c) && TrigeminalNeuralgia.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                (Trigeminal Neuralgia)               |
+-----------------------------------------------------+
|                                                     |
|   Trigeminal neuralgia treatment usually starts     |
|with medications, and some people don't need any     |
|additional treatment. However, over time, some people|
|with the condition may stop responding to medications|
|or they may experience unpleasant side effects. For  |
|those people, injections or surgery provide other    |
|trigeminal neuralgia treatment options.              |
|                                                     |
|    To treat trigeminal neuralgia,your doctor usually|
|will prescribe medications to lessen the pain        |
|signals sent to your brain.                          |
|                                                     |
|    - Anticonvulsants.                               |
|    - Antispasmodic agents.                          |
|    - Botox injections.                              |
|                                                     |  
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (panicDisorder.Contains(a) && panicDisorder.Contains(b)
            && panicDisorder.Contains(c) && panicDisorder.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                  (Panic Disorder)                   |
+-----------------------------------------------------+
|                                                     |
|   Treatment can help reduce the intensity and       |
|frequency of your panic attacks and improve your     |
|function in daily life. The main treatment options   |
|are psychotherapy and medications. One or both types |
|of treatment may be recommended, depending on your   |
|preference, your history, the severity of your panic |
|disorder and whether you have access to therapists   |
|who have special training in treating panic disorders|
|                                                     |
|    Psychotherapy, also called talk therapy, is      |
|considered an effective first choice treatment for   |
|panic attacks and panic disorder. Psychotherapy can  |
|help you understand panic attacks and panic disorder |
|and learn how to cope with them.                     |
|                                                     |  
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (visceroptosis.Contains(a) && visceroptosis.Contains(b)
            && visceroptosis.Contains(c) && visceroptosis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                   (Visceroptosis)                   |
+-----------------------------------------------------+
|                                                     |
|   Rest in bed, attention to diet, hygiene,          |
|exercise, and general muscular upbuilding will cure  |
|the majority of cases. In others operation may       |
|become necessary. Visceroptosis is a known risk      |
|factor for the development of Superior mesenteric    |
|artery syndrome.                                     |
|                                                     |  
+-----------------------------------------------------+
";
                Console.WriteLine(results);

                 }
            else if (visceroptosis.Contains(a) && visceroptosis.Contains(b)
            && visceroptosis.Contains(c) && visceroptosis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                   (Visceroptosis)                   |
+-----------------------------------------------------+
|                                                     |
|   Rest in bed, attention to diet, hygiene,          |
|exercise, and general muscular upbuilding will cure  |
|the majority of cases. In others operation may       |
|become necessary. Visceroptosis is a known risk      |
|factor for the development of Superior mesenteric    |
|artery syndrome.                                     |
|                                                     |  
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (systemicSclerosis.Contains(a) && systemicSclerosis.Contains(b)
            && systemicSclerosis.Contains(c) && systemicSclerosis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                 (Systemic Sclerosis)                |
+-----------------------------------------------------+
|                                                     |
|   At present, there is no cure for systemic         |
|sclerosis, limited or diffuse. However, much can be  |
|done to help. The aims of treatment are:             |
|                                                     |
|     - For the skin, moisturisers and stretching     |
|exercises help with dry or tight skin.               |
|                                                     |
|    - If swallowing lumpy foods is difficult then it |
|may help to have lots to drink with meals. Surgery   |
|may be required in difficult cases, particularly if  |
|partial blockage or bowel incontinence develops.     |
|                                                     |  
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (perniciousAnemia.Contains(a) && perniciousAnemia.Contains(b)
            && perniciousAnemia.Contains(c) && perniciousAnemia.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|                  (Pernicious Anemia)                |
+-----------------------------------------------------+
|                                                     |
|   For milder cases of vitamin B-12 deficiency,      |
|treatment may involve changes to your diet and       |
|vitamin B-12 supplements in pill form or as a nasal  |
|spray. Your doctor may suggest vitamin B-12          |
|injections, particularly if your vitamin B-12        |
|deficiency is severe. At first, you may receive the  |
|shots as often as every other day. Eventually, you'll|
|need injections just once a month, which may continue|
|for life, depending on your situation.               |
|                                                     |  
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (posturalOrthostaticTachycardiaSyndrome.Contains(a) && posturalOrthostaticTachycardiaSyndrome.Contains(b)
            && posturalOrthostaticTachycardiaSyndrome.Contains(c) && posturalOrthostaticTachycardiaSyndrome.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|     (Postural Orthostatic Tachycardia Syndrome)     |
+-----------------------------------------------------+
|                                                     |
|   There's no cure for POTS, but various things      |
|can help with your symptoms.                         |
|                                                     |
|    Your doctor may prescribe drugs such as          |
|fludrocortisone (along with more salt and water),    |
|midodrine, phenylephrine, or a type of medicine      |
|called a beta-blocker to help with blood flow.       |
|                                                     |
|    Compression stockings. These help push the blood |
|up from your legs to your heart. You’ll want ones    |
|that provide at least 30-40 minutes of compression   |
|and go all the way up to your waist, or at least up  |
|to your thighs. Your doctor can prescribe a pair.    |
|                                                     |
|    Exercise. POTS can make it hard to be active,    |
|but even light exercise such as walking or simple    |
|yoga can help with blood flow and keep your heart    |
|healthy.                                             |
|                                                     |
|    Communication. POTS can make simple activities a |
|bit harder,and that can be frustrating and stressful.|
|A support group or therapist may help you manage the |
|emotional issues the condition can cause.            |
|                                                     |  
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (infectiousMononucleosis.Contains(a) && infectiousMononucleosis.Contains(b)
            && infectiousMononucleosis.Contains(c) && infectiousMononucleosis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|               Treatment and Medication              |
|              (Infectious Mononucleosis)             |
+-----------------------------------------------------+
|                                                     |
|   There's no specific therapy available to treat    |
|infectious mononucleosis. Antibiotics don't work     |
|against viral infections such as mono. Treatment     |
|mainly involves taking care of yourself, such as     |
|getting enough rest, eating a healthy diet and       |
|drinking plenty of fluids. You may take over-the-    |
|counter pain relievers to treat a fever or sore      |
|throat.                                              |
|                                                     |
|    Medications                                      |
|                                                     |
|    Treating secondary infections. Occasionally,     |
|a streptococcal (strep) infection accompanies the    |
|sore throat of mononucleosis. You may also develop   |
|a sinus infection or an infection of your tonsils    |
|(tonsillitis). If so, you may need treatment with    |
|antibiotics for these accompanying bacterial         |
|infections.                                          |
|                                                     |
|    Risk of rash with some medications. Amoxicillin  |
|and other penicillin derivatives aren't recommended  |
|for people with mononucleosis. In fact, some people  |
|with mononucleosis who take one of these drugs may   |
|develop a rash. The rash doesn't necessarily mean    |
|that they're allergic to the antibiotic, however.    |
|If needed, other antibiotics that are less likely    |
|to cause a rash are available to treat infections    |
|that may accompany mononucleosis.                    |
|                                                     |  
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (influenza2.Contains(a) && influenza2.Contains(b)
            && influenza2.Contains(c) && influenza2.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                     (Influenza)                     |
+-----------------------------------------------------+
|   Medications:                                      |
|                                                     |
|   Usually, you'll need nothing more than bed rest   |
|and plenty of fluids to treat the flu. But in some   |
|cases, your doctor may prescribe an antiviral        |
|medication, such as oseltamivir (Tamiflu) or         |
|zanamivir (Relenza). If taken soon after you notice  |
|symptoms, these drugs may shorten your illness by a  |
|day or so and help prevent serious complications.    | 
|                                                     |
|   Oseltamivir is an oral medication. Zanamivir is   |
|inhaled through a device similar to an asthma inhaler|
|and shouldn't be used by anyone with respiratory     |
|problems, such as asthma and lung disease.           |
|                                                     |
|    Antiviral medication side effects may include    |
|nausea and vomiting. These side effects may be       |
|lessened if the drug is taken with food. Oseltamivir |
|has also been associated with delirium and self-harm |
|behaviors in teenagers.                              |
|                                                     |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (influenza3.Contains(a) && influenza3.Contains(b)
            && influenza3.Contains(c) && influenza3.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                     (Influenza)                     |
+-----------------------------------------------------+
|   Medications:                                      |
|                                                     |
|   Usually, you'll need nothing more than bed rest   |
|and plenty of fluids to treat the flu. But in some   |
|cases, your doctor may prescribe an antiviral        |
|medication, such as oseltamivir (Tamiflu) or         |
|zanamivir (Relenza). If taken soon after you notice  |
|symptoms, these drugs may shorten your illness by a  |
|day or so and help prevent serious complications.    | 
|                                                     |
|   Oseltamivir is an oral medication. Zanamivir is   |
|inhaled through a device similar to an asthma inhaler|
|and shouldn't be used by anyone with respiratory     |
|problems, such as asthma and lung disease.           |
|                                                     |
|    Antiviral medication side effects may include    |
|nausea and vomiting. These side effects may be       |
|lessened if the drug is taken with food. Oseltamivir |
|has also been associated with delirium and self-harm |
|behaviors in teenagers.                              |
|                                                     |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (influenza4.Contains(a) && influenza4.Contains(b)
            && influenza4.Contains(c) && influenza4.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                     (Influenza)                     |
+-----------------------------------------------------+
|   Medications:                                      |
|                                                     |
|   Usually, you'll need nothing more than bed rest   |
|and plenty of fluids to treat the flu. But in some   |
|cases, your doctor may prescribe an antiviral        |
|medication, such as oseltamivir (Tamiflu) or         |
|zanamivir (Relenza). If taken soon after you notice  |
|symptoms, these drugs may shorten your illness by a  |
|day or so and help prevent serious complications.    | 
|                                                     |
|   Oseltamivir is an oral medication. Zanamivir is   |
|inhaled through a device similar to an asthma inhaler|
|and shouldn't be used by anyone with respiratory     |
|problems, such as asthma and lung disease.           |
|                                                     |
|    Antiviral medication side effects may include    |
|nausea and vomiting. These side effects may be       |
|lessened if the drug is taken with food. Oseltamivir |
|has also been associated with delirium and self-harm |
|behaviors in teenagers.                              |
|                                                     |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (relapsingFever.Contains(a) && relapsingFever.Contains(b)
            && relapsingFever.Contains(c) && relapsingFever.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                  (Relapsing Fever)                  |
+-----------------------------------------------------+
|                                                     |
|    For decades, penicillins and tetracyclines have  |
|been the treatment of choice in relapsing fever. In  |
|vitro, Borrelia species are also susceptible to      |
|cephalosporins, macrolides, and chloramphenicol,     |
|although less data are available on these            |
|antibiotics. Borrelia species are relatively         |
|resistant to fluoroquinolones, sulfa drugs, rifampin,|
|aminoglycosides, and metronidazole.                  |
|                                                     |
|    The efficacy of treatment can be demonstrated by |
|noting clearance of spirochetes in the blood,        |
|usually occurring within 8 hours of administration   |
|of an effective antibiotic.                          |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (HumanGranulocyticAnaplasmosis.Contains(a) && HumanGranulocyticAnaplasmosis.Contains(b)
            && HumanGranulocyticAnaplasmosis.Contains(c) && HumanGranulocyticAnaplasmosis.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|          (Human Granulocytic Anaplasmosis)          |
+-----------------------------------------------------+
|                                                     |
|    Doxycycline is the treatment of choice. If       |
|anaplasmosis is suspected, treatment should not be   |
|delayed while waiting for a definitive laboratory    |
|confirmation, as prompt doxycycline therapy has been |
|shown to improve outcomes. Presentation during early |
|pregnancy can complicate treatment. Doxycycline      |
|compromises dental enamel during development.        |
|Although rifampin is indicated for post-delivery     |
|pediatric and some doxycycline-allergic patients, it |
|is teratogenic. Rifampin is contraindicated during   |
|conception and pregnancy.                            |
|                                                     |
|    If the disease is not treated quickly, sometimes |
|before the diagnosis, the person has a high chance of|
|mortality. Most people make a complete recovery,     |
|though some people are intensively cared for after   |
|treatment. A reason for a person needing intensive   |
|care is if the person goes too long without seeing a |
|doctor or being diagnosed. The majority of people,   |
|though, make a complete recovery with no residual    |
|damage.                                              |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (CommonCold.Contains(a) && CommonCold.Contains(b)
            && CommonCold.Contains(c) && CommonCold.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                    (Common Cold)                    |
+-----------------------------------------------------+
|                                                     |
|    Doxycycline is the treatment of choice. If       |
|anaplasmosis is suspected, treatment should not be   |
|delayed while waiting for a definitive laboratory    |
|confirmation, as prompt doxycycline therapy has been |
|shown to improve outcomes. Presentation during early |
|pregnancy can complicate treatment. Doxycycline      |
|compromises dental enamel during development.        |
|Although rifampin is indicated for post-delivery     |
|pediatric and some doxycycline-allergic patients, it |
|is teratogenic. Rifampin is contraindicated during   |
|conception and pregnancy.                            |
|                                                     |
|    If the disease is not treated quickly, sometimes |
|before the diagnosis, the person has a high chance of|
|mortality. Most people make a complete recovery,     |
|though some people are intensively cared for after   |
|treatment. A reason for a person needing intensive   |
|care is if the person goes too long without seeing a |
|doctor or being diagnosed. The majority of people,   |
|though, make a complete recovery with no residual    |
|damage.                                              |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (ChronicFatigueSyndrome.Contains(a) && ChronicFatigueSyndrome.Contains(b)
            && ChronicFatigueSyndrome.Contains(c) && ChronicFatigueSyndrome.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|              (Chronic Fatigue Syndrome)             |
+-----------------------------------------------------+
|                                                     |
|   There is no cure for chronic fatigue syndrome.    |
|Treatment focuses on symptom relief.                 |
|                                                     |
|    Many people who have chronic fatigue syndrome are|
|also depressed. Treating your depression can make it |
|easier for you to cope with the problems associated  |
|with chronic fatigue syndrome. Low doses of some     |
|antidepressants also can help improve sleep and      |
|relieve pain.                                        |
|                                                     |
|    The most effective treatment for chronic fatigue |
|syndrome appears to be a two-pronged approach that   |
|combines cognitive training with a gentle exercise   |
|program.                                             |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (ToothAbscess.Contains(a) && ToothAbscess.Contains(b)
            && ToothAbscess.Contains(c) && ToothAbscess.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                   (Tooth Abscess)                   |
+-----------------------------------------------------+
|                                                     |
|   The goal of treatment is to get rid of the        |
|infection. To accomplish this, your dentist may:     |
|                                                     |
|    Open up (incise) and drain the abscess. The      |
|dentist will make a small cut into the abscess,      |
|allowing the pus to drain out, and then wash the     |
|area with salt water (saline). Occasionally, a       |
|small rubber drain is placed to keep the area open   |
|for drainage while the swelling decreases.           |
|                                                     |
|    Perform a root canal. This can help eliminate    |
|the infection and save your tooth. To do this, your  |
|dentist drills down into your tooth, removes the     |
|diseased central tissue (pulp) and drains the        |
|abscess. He or she then fills and seals the tooth's  |
|pulp chamber and root canals. The tooth may be capped|
|with a crown to make it stronger, especially if this |
|is a back tooth. If you care for your restored tooth |
|properly, it can last a lifetime.                    |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (Fibromyalgia.Contains(a) && Fibromyalgia.Contains(b)
            && Fibromyalgia.Contains(c) && Fibromyalgia.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                   (Fibromyalgia)                    |
+-----------------------------------------------------+
|                                                     |
|   In general, treatments for fibromyalgia include   |
|both medication and self-care. The emphasis is on    |
|minimizing symptoms and improving general health.    |
|No one treatment works for all symptoms.             |
|                                                     |
|Medications can help reduce the pain of fibromyalgia |
|and improve sleep. Common choices include:           |
|                                                     |
|    - Pain relievers.                                |
|    - Antidepressants.                               |
|    - Anti-seizure drugs.                            |
|    - Physical therapy.                              |
|    - Occupational therapy.                          |
|    - Counseling.                                    |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (AlcoholHangover.Contains(a) && AlcoholHangover.Contains(b)
            && AlcoholHangover.Contains(c) && AlcoholHangover.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                 (Alcohol Hangover)                  |
+-----------------------------------------------------+
|                                                     |
|   Time is the only sure cure for a hangover. In     |
|the meantime, here are a few things you can do to    |
|help yourself feel better:                           |
|                                                     |
|    Fill your water bottle. Sip water or fruit juice |
|to prevent dehydration. Resist any temptation to     |
|treat your hangover with more alcohol. It'll only    |
|make you feel worse.                                 |
|                                                     |
|    Have a snack. Bland foods, such as toast and     |
|crackers, may boost your blood sugar and settle your |
|stomach. Bouillon soup can help replace lost salt    |
|and potassium.                                       |
|                                                     |
|    Take a pain reliever. A standard dose of an over-|
|the-counter pain reliever may ease your headache. But|
|aspirin can irritate your stomach. And if you        |
|regularly drink alcohol to excess, acetaminophen     |
|(Tylenol, others) can cause severe liver damage even |
|in doses previously thought to be safe.              |
|                                                     |
|    Go back to bed. If you sleep long enough, your   |
|hangover may be gone when you awaken.                |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (SJogrensSyndrome.Contains(a) && SJogrensSyndrome.Contains(b)
            && SJogrensSyndrome.Contains(c) && SJogrensSyndrome.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                (Sjogren's Syndrome)                 |
+-----------------------------------------------------+
|                                                     |
|   Treatment for Sjogren's syndrome depends on the   |
|parts of the body affected. Many people manage the   |
|dry eye and dry mouth of Sjogren's syndrome by using |
|over-the-counter eyedrops and sipping water more     |
|frequently. But some people need prescription        |
|medications, or even surgical procedures.            |
|                                                     |
|    Depending on your symptoms, your doctor might    |
|suggest medications that:                            |
|                                                     |
|    Decrease eye inflammation. Prescription eyedrops |
|such as cyclosporine (Restasis) or lifitegrast       |
|(Xiidra) may be recommended by your eye doctor if you|
|have moderate to severe dry eyes.                    |
|                                                     |
|    Increase production of saliva. Drugs such as     |
|pilocarpine (Salagen) and cevimeline (Evoxac) can    |
|increase the production of saliva, and sometimes     |
|tears. Side effects can include sweating, abdominal  |
|pain, flushing and increased urination.              |
|                                                     |
|    Treat systemwide symptoms. Hydroxychloroquine    |
|(Plaquenil), a drug designed to treat malaria, is    |
|often helpful in treating Sjogren's syndrome. Drugs  |
|that suppress the immune system, such as methotrexate|
|(Trexall), also might be prescribed.                 |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (HeartFailure.Contains(a) && HeartFailure.Contains(b)
            && HeartFailure.Contains(c) && HeartFailure.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                   (Heart Failure)                   |
+-----------------------------------------------------+
|                                                     |
|   Heart failure is a chronic disease needing        |
|lifelong management. However, with treatment, signs  |
|and symptoms of heart failure can improve, and the   |
|heart sometimes becomes stronger. Treatment may help |
|you live longer and reduce your chance of dying      |
|suddenly.                                            |
|                                                     |
|    Doctors sometimes can correct heart failure by   |
|treating the underlying cause. For example, repairing|
|a heart valve or controlling a fast heart rhythm may |
|reverse heart failure. But for most people, the      |
|treatment of heart failure involves a balance of the |
|right medications and, in some cases, use of devices |
|that help the heart beat and contract properly.      |
|                                                     |
|    Doctors usually treat heart failure with a       |
|combination of medications. Depending on your        |
|symptoms, you might take one or more medications,    |
|including:                                           |
|                                                     |
|    - Angiotensin-converting enzyme (ACE) inhibitors.|
|    - Angiotensin II receptor blockers.              |
|    - Beta blockers.                                 |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (pericarditis2.Contains(a) && pericarditis2.Contains(b)
            && pericarditis2.Contains(c) && pericarditis2.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                   (Pericarditis)                    | 
+-----------------------------------------------------+
|        -- Specific Types of Treatment --	          |
|*First, your doctor may advise you to rest until you |
|feel better and have no fever. He or she may tell you|
|to take over-the-counter, anti-inflammatory medicines|
|to reduce pain and inflammation. Examples of these   |
|medicines are aspirin and ibuprofen.		          |
|                                                     |
|*Stronger medicine may be needed if the pain is      |
|severe. Your doctor may prescribe a medicine called  |
|colchicine and a steroid called prednisone.	      |
| 						                              |
|*If an infection is causing your pericarditis, your  |
|doctor will prescribe an antibiotic or other medicine|
|.You may need to stay in the hospital during 	      |
|treatment so your doctor can check you for 	      |
|complications.Symptoms of acute pericarditis can last| 
|from a few days to three weeks. Chronic pericarditis |
|may last several months.			                  |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (cryptococcusNeoformans.Contains(a) && cryptococcusNeoformans.Contains(b)
            && cryptococcusNeoformans.Contains(c) && cryptococcusNeoformans.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|              (Cryptococcus Neoformans)              | 
+-----------------------------------------------------+
|                                                     |
|    Treatment of extraneural nonpulmonary disease    |
|                                                     |
|    For patients without AIDS, treat cryptococcal    |
|lesions of the skin, bones, or other organs with     |
|amphotericin B plus flucytosine or with amphotericin |
|B alone. All patients with evidence of cryptococcal  |
|infection should undergo lumbar puncture to ensure   |
|the absence of CNS infection.                        |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (aorticAneurysm2.Contains(a) && aorticAneurysm2.Contains(b)
            && aorticAneurysm2.Contains(c) && aorticAneurysm2.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                 (Aortic Aneurysm)                   | 
+-----------------------------------------------------+
|                  -- Treatment --		              |
|- The goal of treatment — either medical monitoring  |
|or surgery is to prevent your aneurysm from rupturing| 
|						                              |
|*Medical monitoring                                  |
| - Your doctor might recommend this option if your   |
|abdominal aortic aneurysm is small and you don't have|
|symptoms.You'll have regular appointments to check if|
|your aneurysm is growing, treatment to manage other  |
|medical conditions, such as high blood pressure, that|
|could worsen your aneurysm.			              |
|						                              |
|*Surgery					                          |
|- Repair is generally recommended if your aneurysm is|
|1.9 to 2.2 inches (4.8 to 5.6 centimeters) or larger |
|or if it's growing quickly. Also, your doctor might  |
|recommend surgery if you have symptom such as stomach|
|pain or you have a leaking,tender or painful aneurysm|
|						                              |
| -- Depending on several factors, including location |
|and size of the aneurysm, your age, and other        |
|conditions you have, repair options might include:   |
|						                              |
|*Open abdominal surgery. This involves removing the  |
|damaged section of the aorta and replacing it with a |
|synthetic tube (graft), which is sewn into place.Full|
|recovery is likely to take a month or more.	      |
|*Endovascular repair. This less invasive procedure is|
|used more often. Doctors attach a synthetic graft to |
|the end of a thin tube (catheter) that's inserted    |
|through an artery in your leg and threaded into your |
|aorta.						                          |
|						                              |
|(Long-term survival rates are similar for both       |
|endovascular surgery and open surgery).              |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (brucellosis2.Contains(a) && brucellosis2.Contains(b)
            && brucellosis2.Contains(c) && brucellosis2.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                   (Brucellosis)                     | 
+-----------------------------------------------------+
|       -- How Is Brucellosis Treated? --	          |
|- Brucellosis can be difficult to treat. If you have |
|brucellosis, your doctor will prescribe antibiotics. |
|Antibiotics commonly used to treat brucellosis       |
|include:					                          |
|					                                  |
|*doxycycline (Acticlate, Monodox, Vibra-Tabs, 	      |
|Vibramycin)					                      |
|*streptomycin					                      |
|*ciprofloxacin (Cipro) or ofloxacin (Floxin)	      |
|*rifampin (Rifadin, Rimactane)			              |
|*sulfamethoxazole/trimethoprim (Bactrim)	          |  
|*tetracycline (Sumycin)			                  |
|						                              |
|- You will generally be given doxycycline and	      |
|rifampin a in combination for 6-8 weeks.	          |
|						                              |
|- You must take the antibiotics for many weeks to    | 
|prevent the disease from returning.  The rate of     |
|relapse following treatment is about 5-15% and       |
|usually occurs within the first six months after     |
|treatment. 					                      |
|						                              |
|- Recovery can take weeks, even months. Patients who |
|receive treatment within one month of the start of   |
|symptomscan be cured of the disease.                 |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (HeavyMetalIntoxication.Contains(a) && HeavyMetalIntoxication.Contains(b)
            && HeavyMetalIntoxication.Contains(c) && HeavyMetalIntoxication.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|             (Heavy Metal Intoxication)              | 
+-----------------------------------------------------+
|                                                     |
|    The main step is to stay away from whatever made |
|you sick so you don’t make the problem worse. Your   |
|doctor can help you figure out how to protect        |
|yourself.                                            |
|                                                     |
|    Sometimes you might need to have your stomach    |
|pumped to get the metals out.                        |
|                                                     |
|    If your poisoning is serious, one treatment      |
|option is chelation. You get drugs, usually through  |
|an IV needle, that go into your blood and “stick” to |
|the heavy metals in your body. They then get flushed |
vout with your pee. Chelation can be an important part|
|of treatment. But the therapy can be dangerous, and  |
|it doesn’t work with all heavy metals. So doctors    |
|only use it only if you have high levels of the metal|
|and clear symptoms of poisoning.                     |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (cirrhosis.Contains(a) && cirrhosis.Contains(b)
            && cirrhosis.Contains(c) && cirrhosis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                    (Cirrhosis)                      | 
+-----------------------------------------------------+
|                                                     |
|    Treatment for cirrhosis depends on the cause and |
|extent of your liver damage. The goals of treatment  |
|are to slow the progression of scar tissue in the    |
|liver and to prevent or treat symptoms and           |
|complications of cirrhosis. You may need to be       |
|hospitalized if you have severe liver damage.        |
|                                                     |
|    - Treatment for alcohol dependency. People with  |
|cirrhosis caused by excessive alcohol use should     |
|try to stop drinking. If stopping alcohol use is     |
|difficult, your doctor may recommend a treatment     |
|program for alcohol addiction. If you have cirrhosis,|
|it is critical to stop drinking since any amount of  |
|alcohol is toxic to the liver.                       |
|                                                     |
|    - Weight loss. People with cirrhosis caused by   |
|nonalcoholic fatty liver disease may become healthier|
|if they lose weight and control their blood sugar    |
|levels.                                              |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (GravesDisease.Contains(a) && GravesDisease.Contains(b)
            && GravesDisease.Contains(c) && GravesDisease.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                  (Graves Disease)                   | 
+-----------------------------------------------------+
|                                                     |
|    People with Graves' disease may be sensitive to  |
|harmful side effects from iodine. Eating foods that  |
|have large amounts of iodine - such as kelp, dulse,  |
|or other kinds of seaweed - may cause or worsen      |
|hyperthyroidism. Taking iodine supplements can have  |
|the same effect.                                     |
|                                                     |
|    Talk with your health care professional about    |
|what foods you should limit or avoid, and let him or |
|her know if you take iodine supplements. Also, share |
|information about any cough syrups or multivitamins  |
|that you take because they may contain iodine.       |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (concussion.Contains(a) && concussion.Contains(b)
            && concussion.Contains(c) && concussion.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                   (Concussion)                      | 
+-----------------------------------------------------+
|                                                     |
|    Rest is the most appropriate way to allow your   |
|brain to recover from a concussion. Your doctor will |
|recommend that you physically and mentally rest to   |
|recover from a concussion.                           |
|                                                     |
|    This means avoiding activities that increase any |
|of your symptoms, such as general physical exertion, |
|sports or any vigorous movements, until these        |
|activities no longer provoke your symptoms.          |
|                                                     |
|    This rest also includes limiting activities that |
|require thinking and mental concentration, such as   |
|playing video games, watching TV, schoolwork, reading|
|texting or using a computer, if these activities     |
|trigger your symptoms or worsen them.                | 
|                                                     |
|    Your doctor may recommend that you have shortened|
|school days or workdays, take breaks during the day, |
|or have reduced school workloads or work assignments |
|as you recover from a concussion.                    |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (CommonCold2.Contains(a) && CommonCold2.Contains(b)
            && CommonCold2.Contains(c) && CommonCold2.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                    (Common Cold)                    |
+-----------------------------------------------------+
|                                                     |
|    Doxycycline is the treatment of choice. If       |
|anaplasmosis is suspected, treatment should not be   |
|delayed while waiting for a definitive laboratory    |
|confirmation, as prompt doxycycline therapy has been |
|shown to improve outcomes. Presentation during early |
|pregnancy can complicate treatment. Doxycycline      |
|compromises dental enamel during development.        |
|Although rifampin is indicated for post-delivery     |
|pediatric and some doxycycline-allergic patients, it |
|is teratogenic. Rifampin is contraindicated during   |
|conception and pregnancy.                            |
|                                                     |
|    If the disease is not treated quickly, sometimes |
|before the diagnosis, the person has a high chance of|
|mortality. Most people make a complete recovery,     |
|though some people are intensively cared for after   |
|treatment. A reason for a person needing intensive   |
|care is if the person goes too long without seeing a |
|doctor or being diagnosed. The majority of people,   |
|though, make a complete recovery with no residual    |
|damage.                                              |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (FlukeInfection2.Contains(a) && FlukeInfection2.Contains(b)
            && FlukeInfection2.Contains(c) && FlukeInfection2.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                 (Fluke Infection)                   | 
+-----------------------------------------------------+
|                  -- Treatments --		              |
|*A medication called triclabendazole is commonly used|
|to treat a liver fluke infection, as this effectively|
|kills the liver flukes and their eggs.		          |
|						                              |
|*Other drugs, such as pain relievers, may be used to |
|treat some of the symptoms such as pain and diarrhea.|
|						                              |
|*Surgery may be necessary in rare cases where        |
|cholangitis, an infection of the bile ducts in the   |
|liver, has developed.				                  |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (PulmonaryEmbolism.Contains(a) && PulmonaryEmbolism.Contains(b)
            && PulmonaryEmbolism.Contains(c) && PulmonaryEmbolism.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                (Pulmonary Embolism)                 | 
+-----------------------------------------------------+
|    Treatment for pulmonary embolism is typically    |
|provided in a hospital, where your condition can be  |
|closely monitored. The length of your treatment and  |
|hospital stay will vary, depending on the severity   |
|of the clot. Depending on your medical condition,    |
|treatment options may include anticoagulant          |
|(blood-thinner) medications, thrombolytic therapy,   |
|compression stockings, and sometimes surgery or      |
|interventional procedures to improve blood flow and  |
|reduce the risk of future blood clots.               |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (sinusitis.Contains(a) && sinusitis.Contains(b)
            && sinusitis.Contains(c) && sinusitis.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                    (Sinusitis)                      | 
+-----------------------------------------------------+
|    Most people who assume they have sinusitis       |
|actually have migraines or tension-type headaches.   |
|                                                     |
|    Migraines and chronic or recurrent headaches may |
|be treated with prescription medication thats either |
|taken every day to reduce or prevent headaches or    |
|taken at the onset of a headache to prevent it from  |
|getting worse.                                       |
|                                                     |
|    To treat these types of headaches, your doctor   |
|may recommend:                                       |
|                                                     |
|    - Over-the-counter pain relievers.               |
|    - Triptans.                                      |
|    - Glucocorticoids (dexamethasone).               |
|    - Anti-nausea medications.                       |
|    - Ergots.                                        |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (lymeDisease.Contains(a) && lymeDisease.Contains(b)
            && lymeDisease.Contains(c) && lymeDisease.Contains(d))
            {

                results = @"

+-----------------------------------------------------+
|              Treatment and Medication               |
|                  (Lyme Disease)                     | 
+-----------------------------------------------------+
|    If your Lyme disease is found soon after you’ve  |
|been infected, your doctor will start you on         |
|antibiotics:                                         |
|                                                     |
|    - Doxycycline                                    |
|    - Amoxicillin                                    |
|    - Cefuroxime                                     |
|                                                     |
|    Which drug you’re prescribed will depend on your |
|age. Your doctor will also take into account if      |
|you’re pregnant or nursing. You’ll need to take this |
|medicine for 10 to 21 days.                          |
|                                                     |
|    The earlier Lyme disease is found, the better.   |
|Most people who start treatment in this stage improve|
|quickly. If not, your doctor may need to prescribe   |
|another course of antibiotics.                       |
|                                                     |
|                                                     |
+-----------------------------------------------------+
";
                Console.WriteLine(results);

            }
            else if (toothAbscess2.Contains(a) && toothAbscess2.Contains(b)
            && toothAbscess2.Contains(c) && toothAbscess2.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                   (Tooth Abscess)                   |
+-----------------------------------------------------+
|                                                     |
|   The goal of treatment is to get rid of the        |
|infection. To accomplish this, your dentist may:     |
|                                                     |
|    Open up (incise) and drain the abscess. The      |
|dentist will make a small cut into the abscess,      |
|allowing the pus to drain out, and then wash the     |
|area with salt water (saline). Occasionally, a       |
|small rubber drain is placed to keep the area open   |
|for drainage while the swelling decreases.           |
|                                                     |
|    Perform a root canal. This can help eliminate    |
|the infection and save your tooth. To do this, your  |
|dentist drills down into your tooth, removes the     |
|diseased central tissue (pulp) and drains the        |
|abscess. He or she then fills and seals the tooth's  |
|pulp chamber and root canals. The tooth may be capped|
|with a crown to make it stronger, especially if this |
|is a back tooth. If you care for your restored tooth |
|properly, it can last a lifetime.                    |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (diabeticNeuropathy.Contains(a) && diabeticNeuropathy.Contains(b)
            && diabeticNeuropathy.Contains(c) && diabeticNeuropathy.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                (Diabetic Neuropathy)                |
+-----------------------------------------------------+
|                                                     |
|   Diabetic neuropathy has no known cure. The goals  |
|of treatment are to:                                 |
|                                                     |
|    - Slow progression of the disease                |
|        > Consistently keeping your blood sugar      |
|within your target range is the key to preventing or |
|delaying nerve damage. Doing so may even improve some|
|of your current symptoms. Your doctor will determine |
|the best target range for you based on several       |
|factors, such as your age, how long you've had       |
|diabetes and your overall health.                    |
|                                                     |
|    - Relieve pain                                   |
|        > Many prescription medications are available|
|for diabetes-related nerve pain, but they don't work |
|for everyone. Side effects are always possible. When |
|considering any medication, talk to your doctor about|
|the benefits and drawbacks to determine what might   |
|work best for you.                                   |
|                                                     |
|    - Manage complications and restore function      |
|        > Your diabetes health care team will likely |
|include different specialists, such as doctor that   |
|treats urinary tract problems (urologist) and a heart|
|doctor (cardiologist), who can help prevent or treat |
|complications.                                       |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (generalAnxietyDisorder.Contains(a) && generalAnxietyDisorder.Contains(b)
            && generalAnxietyDisorder.Contains(c) && generalAnxietyDisorder.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|           (Generalized Anxiety  disorder)           |
+-----------------------------------------------------+
|   Medications:                                      |
|                                                     |
|   Several types of medications are used to treat    |
|generalized anxiety disorder, including those below. |
|Talk with your doctor about benefits, risks and      |
|possible side effects.                               |
|                                                     |
|    - Buspirone. An anti-anxiety medication called   |
|buspirone may be used on an ongoing basis. As with   |
|most antidepressants,it typically takes up to several|
|weeks to become fully effective.                     |
|                                                     |
|    - Benzodiazepines. In limited circumstances, your|
|doctor may prescribe a benzodiazepine for relief of  |
|anxiety symptoms. These sedatives are generally used |
|only for relieving acuteanxiety on a short-term basis|
|Because they can be habit-forming, these medications |
|aren't a good choice if you have or had problems with|
|alcohol or drug abuse.                               |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (bronchitis.Contains(a) && bronchitis.Contains(b)
            && bronchitis.Contains(c) && bronchitis.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                    (Bronchitis)                     |
+-----------------------------------------------------+
|                                                     |
|    Most cases of acute bronchitis get better without|
|treatment, usually within a couple of weeks.         |
|                                                     |
|    Because most cases of bronchitis are caused by   |
|viral infections, antibiotics aren't effective.      |
|However, if your doctor suspects that you have a     |
|bacterial infection, he or she may prescribe an      |
|antibiotic.                                          |
|                                                     |
|    In some circumstances, your doctor may recommend |
|other medications, including:                        |
|                                                     |
|    - Cough medicine.                                |
|    - Other medications. If you have allergies,      |
|asthma or chronic obstructive pulmonary disease      |
|(COPD), your doctor may recommend an inhaler and     |
|other medications to reduce inflammation and open    |
|narrowed passages in your lungs.                     |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (esophagitis.Contains(a) && esophagitis.Contains(b)
            && esophagitis.Contains(c) && esophagitis.Contains(d))
            {

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                    (Esophagitis)                    |
+-----------------------------------------------------+
|                                                     |
|   Eosinophilic esophagitis is considered a chronic  |
|relapsing disease, meaning that most people will     |
|require ongoing treatment to control their symptoms. |
|Treatment will involve one or more of the following: |
|                                                     |
|   Dietary therapy                                   |
|                                                     |
|  Depending on your response to tests for food       |
|allergies, your doctor may recommend that you stop   |
|eating certain foods, such as dairy or wheat         |
|products, to relieve your symptoms and reduce        |
|inflammation. A more limited diet is sometimes       |
|required.                                            |
|                                                     |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (gastroesophagealReflux.Contains(a) && gastroesophagealReflux.Contains(b)
            && gastroesophagealReflux.Contains(c) && gastroesophagealReflux.Contains(d)) { 
            

                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|              (Gastro Esophageal Reflux)             |
+-----------------------------------------------------+
|                                                     |
|   Your doctor is likely to recommend that you first |
|try lifestyle modifications and over-the-counter     |
|medications. If you don't experience relief within a |
|few weeks, your doctor might recommend prescription  |
|medication or surgery.                               |
|                                                     |
|    Over-the-counter medications                     |
|                                                     |
|   The options include:                              |
|                                                     |
|    - Antacids that neutralize stomach acid.         |
|Antacids, such as Mylanta, Rolaids and Tums, may     |
|provide quick relief. But antacids alone won't heal  |
|an inflamed esophagus damaged by stomach acid.       |
|Overuse of some antacids can cause side effects,     |
|such as diarrhea or sometimes kidney problems.       |
|                                                     |
|   - Medications to reduce acid production. These    |
|medications — known as H-2-receptor blockers —       |
|include cimetidine (Tagamet HB), famotidine          |
|(Pepcid AC), nizatidine (Axid AR) and ranitidine     |
|(Zantac). H-2-receptor blockers don't act as quickly |
|as antacids, but they provide longer relief and may  |
|decrease acid production from the stomach for up to  |
|12 hours. Stronger versions are available by         |
|prescription.                                        |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (asthma.Contains(a) && asthma.Contains(b)
            && asthma.Contains(c) && asthma.Contains(d))
            {


                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                       (Asthma)                      |
+-----------------------------------------------------+
|                                                     |
|   Treatment                                         |
|Prevention and long-term control are key in stopping |
|asthma attacks before they start. Treatment usually  |
|involves learning to recognize your triggers, taking |
|steps to avoid them and tracking your breathing to   |
|make sure your daily asthma medications are keeping  |
|symptoms under control. In case of an asthma         |
|flare-up, you may need to use a quick-relief         |
|inhaler, such as albuterol.                          |
|                                                     |
|    Medications                                      |
|The right medications for you depend on a number     |
|of things — your age, symptoms, asthma triggers      |
|and what works best to keep your asthma under        |
|control.                                             |
|                                                     |
|Preventive, long-term control medications reduce     |
|the inflammation in your airways that leads to       |
|symptoms. Quick-relief inhalers (bronchodilators)    |
|quickly open swollen airways that are limiting       |
|breathing. In some cases, allergy medications are    |
|necessary.                                           |
|                                                     |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (unstableAngina.Contains(a) && unstableAngina.Contains(b)
            && unstableAngina.Contains(c) && unstableAngina.Contains(d))
            {


                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                (Unstable Angina)                    |
+-----------------------------------------------------+
|                                                     |
|   There are many options for angina treatment,      |
|including lifestyle changes, medications, angioplasty|
|and stenting, or coronary bypass surgery. The goals  |
|of treatment are to reduce the frequency and severity|
|of your symptoms and to lower your risk of a heart   |
|attack and death.                                    |
|                                                     |
|   However, if you have unstable angina or angina    |
|pain that's different from what you usually have,    |
|such as occurring when you're at rest, you need      |
|immediate treatment in a hospital.                   |
|                                                     |
|    Lifestyle changes                                |
|    -If your angina is mild, lifestyle changes may   |
|be all you need. Even if your angina is severe,      |
|making lifestyle changes can still help.             |
|Changes include:                                     |
|                                                     |
|    -If you smoke, stop smoking. Avoid exposure to   |
|secondhand smoke.                                    |
|                                                     |
|   -If you're overweight, talk to your doctor        |
|about weight-loss options.                           |
|                                                     |
|    -Eat a healthy diet with limited amounts of      |
|saturated fat, lots of whole grains, and many        |
|fruits and vegetables.                               |          
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (SalmonellaInfections.Contains(a) && SalmonellaInfections.Contains(b)
           && SalmonellaInfections.Contains(c) && SalmonellaInfections.Contains(d))
            {


                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|               (Salmonella Infections)               |
+-----------------------------------------------------+
|   Because salmonella infection can be dehydrating,  |
|treatment focuses on replacing fluids and            |
|electrolytes. Severe cases may require               |
|hospitalization and fluids delivered directly into   |
|a vein (intravenous). In addition, your doctor may   |
|recommend:                                           |
|                                                     |
|   Anti-diarrheals. Medications such as loperamide   |
|(Imodium A-D) can help relieve cramping, but they    |
|may also prolong the diarrhea associated with        |
|salmonella infection.                                |
|                                                     |
|Antibiotics. If your doctor suspects that salmonella |
|bacteria have entered your bloodstream,or if you have|
|a severe case or a compromised immune system, he or  |
|she may prescribe antibiotics to kill the bacteria.  |
|Antibiotics are not of benefit in |uncomplicated     |
|cases. In fact, antibiotics may prolong the period   |
|in which you carry the |bacteria and can infect      |
|others, and they can increase your risk of relapse.  |
|                                                     |
| - Anti-diarrheals                                   |
| - Antibiotics                                       |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (ParkinsonsDisease.Contains(a) && ParkinsonsDisease.Contains(b)
          && ParkinsonsDisease.Contains(c) && ParkinsonsDisease.Contains(d))
            {


                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                 (Parkinson's Disease)               |
+-----------------------------------------------------+
|                                                     |
|   Parkinson's disease can't be cured, but           |
|medications can help control your symptoms, often    |
|dramatically. In some later cases, surgery may be    |
|advised.                                             |
|                                                     |
|   Your doctor may also recommend lifestyle changes, |
|especially ongoing aerobic |exercise. In some cases, |
|physical therapy that focuses on balance and         |
|stretching also |is important. A speech-language     |
|pathologist may help improve your speech problems.   |
|                                                     |
|   Medications may help you manage problems with     |
|walking, movement and tremor. These medications      |
|increase or substitute for dopamine.                 |
|                                                     |
|   People with Parkinson's disease have low brain    |
|dopamine concentrations. However, dopamine can't     |
|be given directly, as it can't enter your brain.     |
|                                                     |
|   You may have significant improvement of your      |
|symptoms after beginning Parkinsons disease treatment|
|Over time, however, the benefits of drugs frequently |
|diminish or become less consistent. You can usually  |
|still control your symptoms fairly well.             |
|                                                     |
| - Massage                                           |
| - Tai chi                                           |
| - Yoga                                              |
| - Meditation                                        |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (tularemia.Contains(a) && tularemia.Contains(b)
         && tularemia.Contains(c) && tularemia.Contains(d))
            {


                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                     (tularemia)                     |
+-----------------------------------------------------+
|                                                     |
|    Tularemia can be effectively treated with        |
|antibiotics such as streptomycin or gentamicin,      |
|which are given by injection directly into a muscle  |
|or vein. Depending on |the type of tularemia being   |
|treated, doctors may prescribe oral antibiotics such |
|as doxycycline (Oracea, Vibramycin, others) instead. |
|                                                     |
|   You'll also receive therapy for any complications |
|such as meningitis or pneumonia. In general, you     |
|should be immune to tularemia after recovering from  |
|the disease, but |some people may experience a       |
|recurrence or reinfection.                           |
|                                                     |
|   - Probiotics                                      |
|   - Prebiotics                                      |
|   - Fish Oils                                       |
|   - Bowel Rest                                      |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (mastocytosis.Contains(a) && mastocytosis.Contains(b)
        && mastocytosis.Contains(c) && mastocytosis.Contains(d))
            {


                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                    (MASTOCYTOSIS)                   |
+-----------------------------------------------------+
|   Mastocytosis is a condition that occurs when mast |
|cells accumulate in skin and/or internal organs such |
|as the liver, spleen, bone marrow, and small         |
|intestines. The signs and symptoms vary based on     |
|which part(s) of the body are affected.              |
|                                                     |
|    FDA-approved treatments                          |
|                                                     |
|    The medication(s) listed below have been approved|
|by the Food and Drug Administration (FDA) as orphan  |
|products for treatment of this condition.            |
|                                                     |
|    Cromolyn sodium (Brand name: Gastrocrom® (oral)) |
|- Manufactured by Azur Pharma FDA-approved indication|
|Treatment of mastocytosis.                           |
|                                                     |
|    Midostaurin (Brand name: Rydapt®) - Manufactured |
|by Novartis Oncology FDA-approved indication:        |
|Treatment of adult patients with aggressive systemic |
|mastocytosis (ASM), systemic mastocytosis with       |
|associated hematological neoplasm (SM-AHN), or mast  |
|cell leukemia (MCL).                                 |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (stomachflu.Contains(a) && stomachflu.Contains(b)
       && stomachflu.Contains(c) && stomachflu.Contains(d))
            {


                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                     (stomach flu)                   |
+-----------------------------------------------------+
|                                                     |
|   Prevention                                        |
|                                                     |
|   The best way to prevent the spread of intestinal  |
|infections is to follow these precautions:           |
|                                                     |
|   Stomach flu treatments                            |
|                                                     |
|   There are no drugs that can cure stomach flu;     |
|antibiotics cannot help because  the condition is    |
|usually caused by a virus.                           |
|                                                     |
|   *Ibuprofen - can help with fever and aches, but   |
|it should be used cautiously as it |can upset the    |
|stomach and give the kidneys extra work to do when   |
|they are already dehydrated.                         |
|                                                     |
|   *Acetaminophen - this is often recommended and    |
|has less side effects than |ibuprofen. If you want to|
|buy Acetaminophen, it is available on amazon.        |
|                                                     |
|   *Antiemetics - these can relieve the feelings of  |
|nausea. Doctors may prescribe promethazine,          |
|ondansetron, metoclopramide, or prochlorperazine.    |
|                                                     |
|   *OTC antidiarrheals - including subsalicylate     |
|(Pepto-Bismol) and loperamide |hydrochloride         |
|(Imodium). Pepto-Bismol should not be used in        |
|children.                                            |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }
            else if (Pneuomococcal.Contains(a) && Pneuomococcal.Contains(b)
      && Pneuomococcal.Contains(c) && Pneuomococcal.Contains(d))
            {


                results = @"
+-----------------------------------------------------+
|               Treatment and Medication              |
|                    (PNEUMOCOCCAL)                   |
+-----------------------------------------------------+
|                                                     |
|    Treatment                                        |
|                                                     |
|    Antibiotics can treat pneumococcal disease.      |
|However, many types of pneumococcal bacteria have    |
|become resistant to some of the antibiotics used to  |
|treat these infections. Available data Cdc-pdf[5.24  |
|MB, 114 pages] show that pneumococcal bacteria are   |
|resistant to one or more antibiotic in 3 out of every|
|10 cases.                                            |
|                                                     |
|    Antibiotic treatment for invasive pneumococcal   |
|infections typically includes ‘broad-spectrum’       |
|antibiotics until results of antibiotic sensitivity  |
|testing are available.Broad-spectrum antibiotics work|
|against a wide range of bacteria.Once the sensitivity|
|of the bacteria is known, a more targeted (or ‘narrow|
|spectrum’) antibiotic may be selected.               |
|                                                     |
|    With success of the pneumococcal conjugate       |
|vaccine, we see much less antibiotic-resistant       |
|pneumococcal infections. In addition to the vaccine, |
|appropriate use of antibiotics may also slow or      |
|reverse drug-resistant pneumococcal infections.      |
|                                                     |
+-----------------------------------------------------+
            ";
                Console.WriteLine(results);

            }




            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.WriteLine("Press M to go back to menu, V to view nearby Hospitals \nand Q to quit");
            Console.WriteLine(seperator);
            string optMenu = Console.ReadLine();
            Console.Clear();

            while (true)
            {
                if (optMenu == "M" || optMenu == "m")
                {
                    goto menu;
                }
                else if (optMenu == "Q" || optMenu == "q")
                {
                    goto quit;
                }
                else if ( optMenu == "V" || optMenu == "v")
                {
                    goto locations;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(seperator);
                    Console.WriteLine("Press M to go back to menu and Q to quit");
                    Console.WriteLine(seperator);
                    optMenu = Console.ReadLine();
                }
            }

            locations:
            while (true)
            {
                if (location == "1")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(" \t\n Manila Hospitals \n ");

                    Console.Write(" \n Manila Doctors \n Address: 667 United Nations Ave, Ermita, Manila, 1000 Metro Manila \n Phone: (02) 558 0888 \n");
                    Console.Write("\n Ospital ng Maynila Medical Center \n Address: 719, President Quirino Avenue, Roxas, Boulevard, Malate, Manila, Metro Manila, 1004 Metro Manila \n Phone: (02) 524 6061 \n");
                    Console.Write("\n ManilaMed Medical Center Manila \n Address: 850 United Nations Ave, Ermita, Manila, Metro Manila \n Phone: (02) 523 8131 \n");
                    Console.Write("\n Philippine General Hospital \n Address: Taft Ave, Ermita, Manila, 1000 Metro Manila \n Phone: (02) 554 8400 \n");
                    Console.Write("\n Dr. Jose Fabella Memorial Hospital \n Address: 1003 Lope de Vega St, Santa Cruz, Manila, 1003 Metro Manila \n Phone: (02) 733 8537 \n");
                    Console.Write("\n Adventist Medical Center Manila \n Address: 1975 Corner Donada and San Juan Street, Pasay, 1300 Metro Manila \n Phone: (02) 525 9191 \n");
                    Console.Write("\n Metropolitan Medical center \n Address: 1357 Masangkay St, Santa Cruz, Manila, 1012 Metro Manila \n Phone: (02) 863 2500 \n");
                    Console.Write("\n Mary chiles General Hospital \n Address: 667 Dalupan St, Sampaloc, Manila, 1008 Metro Manila \n Phone: (02) 735 5352 \n");
                    Console.Write("\n Capitol Medical center \n Address: Cor.Scout, Quezon Avenue, Sct.Magbanua, Diliman, Quezon City, 1103 Metro Manila \n Phone: (02) 372 3825 \n");
                    Console.Write("\n Justice Jose Abad Santos Mother and Child Maternity Hospital \n Address: Numancia St, San Nicolas, Manila, 1006 Metro Manila \n Phone: 0947 437 7705 \n");
                    Console.Write("\n San lazaro Hospital \n Address: Quiricada St, Santa Cruz, Manila, Metro Manila \n Phone: (02) 732 3777 \n");
                    Console.Write("\n Mary Johnston Hospital \n Address: 1221 J Nolasco, Tondo, Maynila, 1012 Kalakhang Maynila \n Phone: (02) 245 4021 \n");
                    Console.Write("\n Gat Andres Bonifacio Memorial Medical center \n Address: Manila, 924 Delpan St, Tondo, Maynila, 1012 Kalakhang Maynila \n Phone: (02) 243 8845 \n");
                    Console.Write("\n Hospital of the Infant Jesus \n Address: 1556 Laong Laan Rd, Sampaloc, Manila, 1008 Metro Manila \n Phone: (02) 731 2771 \n");
                    break;
                }

                else if (location == "2")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(" \t\n Quezon City Hospitals \n ");

                    Console.Write("\n Quezon City General Hospital \n Address: Seminary Rd, Project 8, Quezon City, Metro Manila \n Phone: (02) 863 0800 \n");
                    Console.Write("\n Providence Hospital \n Address: 1515 Quezon Ave, Diliman, Quezon City, Metro Manila \n Phone: (02) 558 6999 \n");
                    Console.Write("\n East Avenue Medical Center \n Address: East Ave, Diliman, Quezon City, 1100 Metro Manila \n Phone: (02) 928 0611 \n");
                    Console.Write("\n Capitol Medical center \n Address: Cor.Scout, Quezon Avenue, Sct.Magbanua, Diliman, Quezon City, 1103 Metro Manila \n Phone: (02) 372 3825 \n");
                    Console.Write("\n UERM Memorial Hospital \n Address: 64 Aurora Blvd, Doña Imelda, Quezon City, Metro Manila \n Phone: (02) 715 0861 \n");
                    Console.Write("\n Dr.Jesus C. Delgado Memorial Hospital \n Address: 7 Kamuning Rd, Diliman, Quezon City, 1103 Metro Manila \n Phone: (02) 924 4051 \n");
                    Console.Write("\n Philippine Children's Medical Center \n Address: Quezon Avenue, corner Agham Rd, Diliman, Quezon City, 1101 Metro Manila \n Phone: (02) 588 9900 \n");
                    Console.Write("\n National Children's Hospital \n Address: 264 E Rodriguez Sr.Ave, New Manila, Quezon City, 1113 Metro Manila \n Phone: (02) 724 0656 \n");
                    Console.Write("\n Sta. Teresita General Hospital and Eye Center \n Address: Santa Mesa Heights, Quezon City, 1114 Metro Manila \n Phone: N / A \n");
                    Console.Write("\n World Citi Medical Center \n Address: 960 Aurora Blvd, Project 4, Quezon City, 1109 Metro Manila \n Phone: (02) 913 8380 \n");
                    Console.Write("\n Fe Del Mundo Medical center \n Address: 11 Banawe St, Quezon City, 1113 Metro Manila \n Phone: (02) 712 0845 \n");
                    Console.Write("\n Philippine Heart Center Hospital \n Address: East Ave, Diliman, Quezon City, Metro Manila \n Phone: (02) 925 2401 \n");
                    Console.Write("\n Pascual General Hospital \n Address: 130 Quirino Hwy, Quezon City, 1106 Metro Manila \n Phone: 0905 312 7144 \n");
                    Console.Write("\n New Era General Hospital \n Address: Commonwealth Ave, New Era, Quezon City, Metro Manila \n Phone: (02) 932 7387 \n");
                    Console.Write("\n National Kidney and Transplant Institute \n Address: East Ave, Diliman, Quezon City, 1101 Metro Manila \n Phone: (02) 981 0300 \n");
                    Console.Write("\n Quirino Memorial Medical Center \n Address: JP Rizal Street, Project 4, Quezon City, 1109 Metro Manila \n Phone: (02) 421 2250 \n");
                    Console.Write("\n Veterans Memorial Medical Center \n Address: North Ave, Diliman, Quezon City, Metro Manila \n Phone: (02) 927 6426 \n");
                    Console.Write("\n Novaliches General Hospital \n Address: 793 Quirino Hwy, Novaliches, Quezon City, Metro Manila \n Phone: (02) 938 7890 \n");
                    break;
                }

                else if (location == "3")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(" \t\n Makati Hospitals \n ");

                    Console.Write("\n St. Clare’s Medical Center \n Address: 1838 Dian St, Makati, 1235 Metro Manila \n Phone: (02) 831 6511 \n");
                    Console.Write("\n Ospital ng Makati \n Address: Sampaguita St, Makati, 1218 Metro Manila \n Phone: (02) 882 6316 \n");
                    Console.Write("\n Healthkard Hospital \n Address: 104, Ormanza Street, Legaspi Village, Makati, 1200 Metro Manila \n Phone: (02) 810 5221 \n");
                    Console.Write("\n Centuria Medical Makati \n Address: Century City Gen.Luna St, cor Salamanca, St.Brgy, Makati, Metro Manila \n Phone: (02) 793 8606 \n");
                    Console.Write("\n Makati Medical Center \n Address: 2 Amorsolo Street, Legazpi Village, Makati, 1229 Kalakhang Maynila \n Phone: (02) 888 8999 \n");
                    Console.Write("\n PhilhealthCare Incorporated \n Address: 6764 4th and 5th floor, STI Holdings Center Ayala Avenue, Legazpi Village, Makati, 1226 Metro Manila \n Phone: (02) 802 7333 \n");
                    Console.Write("\n Accredited OFW Medical Clinics & Hospital \n Address: Atlas Compound, Naga Rd, Las Pinas, 1742 Metro Manila \n Phone: (02) 872 4827 \n");
                    Console.Write("\n Saint Claire's Hospital and Nursery \nAddress: 1838, Dian Corner Rockefeller Streets, Makati, 1200 Metro Manila \n Phone: (02) 831 6511 \n");
                    break;
                }

                else if (location == "4")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(" \t\n Pasay Hospitals \n ");

                    Console.Write("\n Pasay City General Hospital \n Address: P.Burgos St., Pasay, Metro Manila \n Phone: (02) 833 6022 \n");
                    Console.Write("\n San Juan de Dios Educational Foundation Inc. - Hospital \n Address: 2772 Roxas Blvd, Pasay, 1300 Metro Manila \n Phone: (02) 831 9731 \n");
                    Console.Write("\n Adventist Medical Center Manila \n Address: 1975 Corner Donada and San Juan Street, Pasay, 1300 Metro Manila \n Phone: (02) 525 9191 \n");
                    Console.Write("\n Air Force General Hospital \n Address: Pasay, Metro Manila \n Phone: N/A \n");
                    break;
                }

                else if (location == "5")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(" \t\n Taguig Hospitals \n ");

                    Console.Write("\n Taguig Doctors Hospital \n Address: 39 Dir.A.Bunye, Taguig, Kalakhang Maynila \n Phone: (02) 837 0178 \n");
                    Console.Write("\n Medical Center Taguig, Inc. \n Address: Levi B.Mariano Ave, Taguig, 1630 Metro Manila \n Phone: (02) 888 6284 \n");
                    Console.Write("\n Taguig District Hospital \n Address: E Service Rd, Taguig - Pateros, Taguig, 1630 Metro Manila \n Phone: (02) 837 8132 \n ");
                    Console.Write("\n Dr. Sabili General Hospital \n Address: Number 313, General Santos Avenue, Lower Bicutan, Taguig, Metro Manila \n Phone: 0905 404 8348 \n");
                    Console.Write("\n Army General Hospital \n Address: MGEN M Castaneda St, Taguig, 1630 Metro Manila \n Phone: (02) 845 9555 \n");
                    Console.Write("\n Cruz-Rabe Maternity & General Hospital \n Address: 57 Gen.A Luna St, Taguig, 1634 Metro Manila \nPhone: (02) 642 3433 \n");
                    Console.Write("\n Philippine Navy, Manila Naval Hospital \n Address: Taguig, Metro Manila \n Phone: N /A \n");
                    Console.Write("\n Recuenco General Hospital \n Address: 68 Sampaloc Ext, Taguig, 1630 Metro Manila \n Phone: (02) 808 5950 \n");
                    Console.Write("\n Holy Mary Family Hospital \n Address: 34, Manuel L.Quezon Street, Bagumbayan, Metro Manila, Taguig, 1630 \n Phone: (02) 837 0246 \n");
                    Console.Write("\n Saint Luke's Medical Center \n Address: Rizal Drive cor. 32nd St and, 5th Ave, Taguig, 1634 Kalakhang Maynila \n Phone: (02) 789 7700 \n");
                    break;
                }

                else if (location == "6")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(" \t\n Pasig Hospitals \n ");

                    Console.Write("\n Rizal Medical Center \n Address: Pasig Blvd, Pasig, 1600 Metro Manila \n Phone: (02) 865 8400 \n");
                    Console.Write("\n Sabater Hospital \n Address: Caruncho Ave, Pasig, Metro Manila \n Phone: (02) 641 8194 \n");
                    Console.Write("\n Tricity Medical Center \n Address: 269 C.Raymundo Ave, Pasig, 1607 Metro Manila \n Phone: (02) 275 9752 \n");
                    Console.Write("\n MCPC St. Therese of Lisieux Doctors Hospital \n Address: C.Raymundo Ave, Pasig, 1600 Metro Manila \n Phone: (02) 546 2833 \n");
                    Console.Write("\n Pasig City General Hospital \n Address: M Eusebio, Pasig, Metro Manila \n Phone: (02) 643 3333 \n");
                    Console.Write("\n Alfonso Specialist Hospital \n Address: 185 Dr.Sixto Antonio Avenue, Pasig, 1609 Metro Manila \n Phone: 571 - 1285 \n");
                    Console.Write("\n Pasig City Children's Hospital \n Address: 15 A Industria, Pasig, 1600 Metro Manila \n Phone: 0916 869 2901 \n");
                    Console.Write("\n Mission Hospital \n Address: 17 km Ortigas Ave, Pasig, 1800 Metro Manila \n Phone: (02) 655 0162 \n");
                    Console.Write("\n Pasig Doctors Medical Center \n Address: 254 Eulogio Amang Rodriguez Ave, Pasig, Metro Manila \n Phone: (02) 878 7362 \n");
                    Console.Write("\n The Medical City Hospital \n Address: Ortigas Ave, Pasig, Metro Manila \n Phone: (02) 988 1000 \n");
                    Console.Write("\n Florence Nightingale Medical Hospital \n Address: Old Capitol Compound, Shaw Blvd, Kapitolyo, Pasig, 1610 Metro Manila \n Phone: 0923 516 8769 \n");
                    Console.Write("\n Salve Regina General Hospital, Inc. \n Address: Marikina - Infanta Hwy, Pasig, 1800 Metro Manila \n Phone: (02) 477 4832 \n");
                    break;
                }

                else if (location == "7")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(" \t\n Mandaluyong Hospitals \n ");

                    Console.Write("\n Mandaluyong City Medical Center \n Address: 605 Boni Ave, Mandaluyong, 1550 Metro Manila \n Phone: 0919 781 7760 \n");
                    Console.Write("\n Unciano General Hospital \n Address: Boni Avenue Corner Dansalan Street, Mandaluyong, 1550 Metro Manila \n Phone: (02) 533 6565 \n");
                    Console.Write("\n St.Michaels Medical center \n Address: 497 F Mariano Avenue Manggahan, Pasig, 1611 Metro Manila \n Phone: (02) 681 7158 \n");
                    Console.Write("\n St. Patrick's Healthcare System \n Address: 566 Shaw Blvd, Mandaluyong, 1550 Metro Manila \n Phone: (02) 533 9329 \n");
                    Console.Write("\n VRP Medical Center \n Address: Edsa, 163 Sierra Madre, Mandaluyong, 1501 Metro Manila \n Phone: (02) 464 9999 \n");
                    Console.Write("\n Our Lady of Lourdes Hospital \n Address: 46 P.Sanchez St, Santa Mesa, Manila, Metro Manila \n Phone: (02) 716 8001 \n");
                    break;
                }

                else if (location == "8")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(" \t\n Marikina Hospitals \n ");

                    Console.Write("\n Marikina Valley Medical Center \n Address: Sumulong Hwy, Marikina, 1800 Metro Manila \n Phone: (02) 682 2222 \n");
                    Console.Write("\n Amang Rodriguez Memorial Medical Center \n Address: Sumulong Highway Sto.Nino, Marikina, 1800 Metro Manila \n Phone: (02) 941 5854 \n");
                    Console.Write("\n Marikina Doctors Hospital and Medical Center, Inc. \n Address: 10 Evangelista Ave, Pasig, 1800 Metro Manila \n Phone: 0949 801 4867 \n");
                    Console.Write("\n St. Victoria Hospital \n Address: 444 JP Rizal, Sto Nino, Marikina, 1800 Metro Manila \n Phone: (02) 942 2022 \n");
                    Console.Write("\n Sta. Monica Hospital \n Address: 138 A A.Bonifacio Ave, Marikina, 1800 Metro Manila \n Phone: N/A \n");
                    Console.Write("\n Garcia General Hospital \n Address: 49 Bayan - Bayanan Ave, Marikina, 1810 Metro Manila \n Phone: (02) 941 5511 \n");
                    Console.Write("\n St. Anthony Medical Center \n Address: 32 Santa Ana Ext., Marikina, 1801 Metro Manila \n Phone: (02) 682 2000 \n");
                    Console.Write("\n SDS Medical Center \n Address: 61 Katipunan St, Marikina, 1800 Metro Manila \n Phone: (02) 933 1405 \n");
                    Console.Write("\n San Ramon Hospital \n Address: 108 Gen.Ordoñez Ave, Marikina, 1811 Metro Manila \n Phone: (02) 941 8632  \n");
                    Console.Write("\n Immaculate Conception Hospital \n Address: 195 Katipunan St, Marikina, 1800 Metro Manila \n Phone: (02) 941 9362 \n");
                    break;
                }

                else if (location == "9")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write(" \t\n Las Piñas Hospitals \n ");

                    Console.Write("\n Las Piñas Doctors Hospital \n Address: 1742 CAA Rd, Las Pinas, 1742 Metro Manila \n Phone: (02) 825 5236 \n");
                    Console.Write("\n Las Piñas General Hospital and Satellite Trauma Center \n Address: Diego Cera Ave, Bernabe Compound, Pulanglupa I, Las Piñas City Metro, Manila, Las Pinas, Metro Manila \n Phone: (02) 873 0557 \n");
                    Console.Write("\n Las Piñas City Medical Center \n Address: 1314 Marcos Alvarez Ave, Las Pinas, 1747 Metro Manila \n Phone: (02) 806 2288 \n");
                    Console.Write("\n Perpetual Help Medical Center \n Address: Alabang–Zapote Road, Las Pinas, 1740 Metro Manila \n Phone: (02) 874 8515 \n");
                    Console.Write("\n A. Zarate General Hospital \n Address: 13 - 765 Atlas compond, Naga Rd, Las Pinas, 2011 Metro Manila \n Telephone Number: 874 - 6903 \n");
                    Console.Write("\n Christ The King General Hospital \n Address: 130 Real Street, Las Pinas, 1740 Metro Manila \n Phone: (02) 873 1119 \n");
                    Console.Write("\n Pamplona Hospital and Medical Center \n Address: 46 Alabang - Zapote Rd, Pamplona 1, Las Pinas, 1740 Metro Manila \n Phone: (02) 873 0054 \n");
                    Console.Write("\n Dr. E. Zarate General Hospital \n Address: Las Pinas, Metro Manila \n Telephone Number: 871 - 1440 \n");
                    break;
                }

                else if (location == "10")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(header);

                    Console.ForegroundColor = ConsoleColor.White;


                    Console.Write(" \t\n Parañaque Hospitals \n ");

                    Console.Write("\n Paranaque Doctor's Hospital \n Address: 175 Doña Soledad Ave Better Living Subdivision, Parañaque, 1711 Metro Manila \n Phone: (02) 776 0644 \n");
                    Console.Write("\n Unihealth-Paranaque Hospital & Medical Center \n Address: Dr Arcadio Santos Ave, Parañaque, 1700 Metro Manila \n Phone: (02) 832 0636 \n");
                    Console.Write("\n Medical Center Parañaque \n Address: Dr Arcadio Santos Ave, San Antonio, Parañaque, 1700 Metro Manila \n Phone: (02) 820 0290 \n");
                    Console.Write("\n Protacio Hospital \n Address: 484 Quirino Ave, Baclaran, Parañaque, 1700 Metro Manila \n Phone: (02) 852 2953 \n");
                    Console.Write("\n The Premier Medical Center \n Address: Business, Parañaque, 1715 Metro Manila \n Telephone Number: 552 - 1138 \n");
                    Console.Write("\n Ospital ng Parañaque \n Address: Quirino Ave, Parañaque, 1700 Metro Manila \n Phone: (02) 825 4902 \n");
                    Console.Write("\n Our Lady of Peace Hospital \n Address: Parañaque, Metro Manila \n Phone: (02) 829 5775 \n");
                    Console.Write("\n Olivarez General Hospital \n Address: Dr Arcadio Santos Ave, Parañaque, 1700 Metro Manila \n Phone: (02) 826 7966 \n ");
                    break;
                } else if (location == "" || location != "") {
                    goto locations;
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.WriteLine("Press M to go back to menu, L to log-out and Q to quit");
            Console.WriteLine(seperator);
            optMenu = Console.ReadLine();

            while (true)
            {
                if (optMenu == "M" || optMenu == "m")
                {
                    goto menu;
                }
                else if (optMenu == "Q" || optMenu == "q")
                {
                    goto quit;
                }
                else if (optMenu == "L" || optMenu == "l")
                {
                    goto logOutSection;
                }
                else if (optMenu == "") {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(seperator);
                    Console.WriteLine("Press M to go back to menu and Q to quit");
                    Console.WriteLine(seperator);
                    optMenu = Console.ReadLine();
                }
            }


        logOutSection:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(header);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(seperator);
            Console.WriteLine("Press L to log-in again and E to exit");
            Console.WriteLine(seperator);

            string logOutmenu = Console.ReadLine();
            if (logOutmenu == "L" || logOutmenu == "l") {
                goto login;
            }else if (logOutmenu == "E" || logOutmenu == "e")
            {
                goto quit;
            }

            Console.ReadKey();


            quit:
            Console.Clear(); 
            Console.WriteLine("Hi " + name + ", Thankyou for using cLaennec, Get well soon");
            Console.ReadKey();

            

        }
    }
}
