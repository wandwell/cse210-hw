using System;

class Program
{
    static void Main(string[] args)
    {   
        bool willQuit = false;
        Log log = new Log();

        try 
        {
            log.LoadActivityLog();
        }
        catch(FileNotFoundException)
        {
            log.SaveActivityLog();
        }

        do
        {
            Menu menu = new Menu();

            menu.DisplayMenu();
            string title = menu.SelectOption();
            
            if (title == "Quit")
            {
                willQuit = true;
            }

            else if (title == "View Activity Log")
            {
                log.DisplayLog();
            }
            
            else if (title == "Breathing Activity")
            {
                BreathingActivity activity = new BreathingActivity(title);
                activity.DisplayStartMsg();

                int time = activity.GetTime();
                DateTime startTime = DateTime.Now;
                DateTime goal = startTime.AddSeconds(time);
                DateTime currentTime = DateTime.Now;
                
                while(currentTime < goal)
                {
                    int respiration = 0;

                    string prompt = activity.GetPrompt(respiration);
                    activity.DisplayCountdown(prompt);
                    respiration += 1;

                    prompt = activity.GetPrompt(respiration);
                    activity.DisplayCountdown(prompt);
                    respiration += 1;

                    currentTime = DateTime.Now;
                    Console.WriteLine("");
                    Console.WriteLine("");
                }

                TimeSpan timespan = currentTime - startTime;
                time = (int) timespan.TotalSeconds;
                activity.SetTime(time);

                activity.DisplayEndMsg();

                log.AddActivity(activity);
            }

            else if (title == "Reflecting Activity")
            {
                ReflectingActivity activity = new ReflectingActivity(title);
                activity.DisplayStartMsg();
                activity.DisplayReflectionPrompt();

                int time = activity.GetTime();
                DateTime startTime = DateTime.Now;
                DateTime goal = startTime.AddSeconds(time);
                DateTime currentTime = DateTime.Now;
                
                while(currentTime < goal)
                {
                    activity.DisplayQuestion();
                    currentTime = DateTime.Now;   
                }
                
                TimeSpan timespan = currentTime - startTime;
                time = (int) timespan.TotalSeconds;
                activity.SetTime(time);

                activity.DisplayEndMsg();

                log.AddActivity(activity);
            }

            else if (title == "Listing Activity")
            {
                ListingActivity activity = new ListingActivity(title);
                activity.DisplayStartMsg();            

                string prompt = activity.getPrompt();
                activity.DisplayCountdown(prompt);
                Console.WriteLine("");

                int time = activity.GetTime();
                DateTime startTime = DateTime.Now;
                DateTime goal = startTime.AddSeconds(time);
                DateTime currentTime = DateTime.Now;
                
                while(currentTime < goal)
                {
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    activity.StoreResponse(response);
                    currentTime = DateTime.Now;   
                }

                activity.GetResponseCount();

                TimeSpan timespan = currentTime - startTime;
                time = (int) timespan.TotalSeconds;
                activity.SetTime(time);
                activity.DisplayEndMsg();

                log.AddActivity(activity);
            }
        }while(willQuit == false);

        log.SaveActivityLog();
    }
}