



using System;
using System.Reflection;

namespace SoftUniCoursePlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> courses = Console.ReadLine().Split(",").Select(item => item.TrimStart()).ToList();
            string input = string.Empty;
            while ((input=Console.ReadLine())!= "course start")
            {
                List<string> commands = input.Split(":").ToList();
                string lessonTitle;
                int index;
                switch (commands[0])
                {
                    case "Add":
                        lessonTitle = commands[1];
                        AddMethod(courses, lessonTitle);
                        break;
                    case "Insert":
                        lessonTitle = commands[1];
                        index = int.Parse(commands[2]);
                        if (index >= 0 && index < courses.Count)
                        {
                            InsertMethod(courses, lessonTitle, index);
                        }
                        break;
                    case "Remove":
                        lessonTitle = commands[1];
                        RemoveMethod(courses, lessonTitle);
                        break;
                    case "Swap":
                        lessonTitle = commands[1];
                        string lessonTitle2= commands[2];
                        SwapMethod(courses, lessonTitle, lessonTitle2);
                        break;
                    case "Exercise":
                        lessonTitle = commands[1];
                        ExerciseMethod(courses, lessonTitle);
                        break;

                }
            }
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Contains("Exercise"))
                {
                    string excerciseString = courses[i];
                    string lesson = courses[i].Substring(0, courses[i].Length-9);
                    courses.Remove(excerciseString);
                    if (courses.IndexOf(lesson) < courses.Count - 1) courses.Insert(courses.IndexOf(lesson) + 1, excerciseString);
                    else courses.Add(excerciseString);

                    
                }
            }

                for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{courses[i]}");
            }

        }

        static void ExerciseMethod(List<string> courses, string lessonTitle)
        {
            string excerciseString = lessonTitle + "-Exercise";
            if (CheckIfDoesNotExist(courses, lessonTitle))
            {
                AddMethod(courses, lessonTitle);
                AddMethod(courses, excerciseString);
            }
            else if (!CheckIfDoesNotExist(courses, lessonTitle))
            {
                if (CheckIfDoesNotExist(courses, excerciseString))
                {
                    int helpValue = courses.IndexOf(lessonTitle);
                    InsertMethod(courses, excerciseString, helpValue+1);
                }
            }
        }

        static void SwapMethod(List<string> courses, string lessonTitle, string lessonTitle2)
        {
            if (!CheckIfDoesNotExist(courses, lessonTitle)&& !CheckIfDoesNotExist(courses, lessonTitle2))
            {
                int helpValueToSwap = courses.IndexOf(lessonTitle2);
                courses[courses.IndexOf(lessonTitle)] = lessonTitle2;
                courses[helpValueToSwap] = lessonTitle;
            }
        }

        static void RemoveMethod(List<string> courses, string lessonTitle)
        {
            if (!CheckIfDoesNotExist(courses, lessonTitle))
            {
                courses.RemoveAll(cour=>cour==lessonTitle);
                //maybestarts with
            }
        }

        static void InsertMethod(List<string> courses, string lessonTitle, int index)
        {
            if (CheckIfDoesNotExist(courses, lessonTitle))
            {
                courses.Insert(index,lessonTitle);
            }
        }

        static void AddMethod(List<string> courses, string lessonTitle)
        {
            if(CheckIfDoesNotExist(courses, lessonTitle))
            {
                courses.Add(lessonTitle);
            }
        }

        static bool CheckIfDoesNotExist(List<string> courses, string lessonTitle)
        {
            bool DoesNotExist=true;
            if (courses.Contains(lessonTitle))
            {
                DoesNotExist=false;
            }
            return DoesNotExist;

        }
    }
}
