using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Benefis";
        job1._jobTitle = "Certified Nursing Assistant";
        job1._startYear = 2020;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._company = "Great Falls Clinic";
        job2._jobTitle = "CNA/Medical Scheduler";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myresume = new Resume();
        myresume._name = "Sariah Wandler";

        myresume._jobs.Add(job1);
        myresume._jobs.Add(job2);

        myresume.Display();
    }
}