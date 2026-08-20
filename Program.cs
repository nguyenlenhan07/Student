using System;

public class Student
{
    private string name;
    private double score;
    private static int totalStudents = 0;

    public Student(string name, double score)
    {
        this.name = name;
        this.score = score;
        totalStudents++;
    }

    public string GetName()
    {
        return this.name;
    }

    public double GetScore()
    {
        return this.score;
    }

    public bool IsPassed()
    {
        return this.score >= 5.0;
    }

    public string GetClassification()
    {
        if (this.score >= 8.0)
        {
            return "Excellent";
        }
        else if (this.score >= 6.5)
        {
            return "Good";
        }
        else if (this.score >= 5.0)
        {
            return "Average";
        }
        else
        {
            return "Weak";
        }
    }


    public static int GetTotalStudents()
    {
        return totalStudents;
    }


    public static Student FindTopStudent(Student[] students)
    {
        if (students == null || students.Length == 0)
        {
            return null;
        }

        Student topStudent = students[0];

        for (int i = 1; i < students.Length; i++)
        {
            if (students[i].GetScore() > topStudent.GetScore())
            {
                topStudent = students[i];
            }
        }

        return topStudent;
    }


    public static double CalculateAverageScore(Student[] students)
    {
        if (students == null || students.Length == 0)
        {
            return 0;
        }

        double totalScore = 0;

        foreach (Student student in students)
        {
            totalScore += student.GetScore();
        }

        return totalScore / students.Length;
    }


    class Program
    {
        static void Main(string[] args)
        {

            Student[] students = new Student[]
            {
                new Student("Nhan", 9.0),
                new Student("Tien", 7.5),
                new Student("Anh", 4.0),
                new Student("Ngoc", 6.0),
                new Student("Minh", 8.5)
            };

            Console.WriteLine("===== STUDENT MANAGEMENT =====");

            Console.WriteLine(
                "\nTotal students created: " +
                Student.GetTotalStudents()
            );


            Console.WriteLine("\n===== STUDENT LIST =====");

            foreach (Student student in students)
            {
                string status;

                if (student.IsPassed())
                {
                    status = "Passed";
                }
                else
                {
                    status = "Failed";
                }

                Console.WriteLine(
                    "Name: " + student.GetName() +
                    " | Score: " + student.GetScore() +
                    " | Classification: " + student.GetClassification() +
                    " | Status: " + status
                );
            }


            Student topStudent = Student.FindTopStudent(students);

            Console.WriteLine("\n===== TOP STUDENT =====");

            Console.WriteLine(
                "Name: " + topStudent.GetName() +
                " | Score: " + topStudent.GetScore()
            );

            double averageScore =
                Student.CalculateAverageScore(students);

            Console.WriteLine("\n===== CLASS AVERAGE =====");

            Console.WriteLine(
                "Average score: " +
                averageScore.ToString("F2")
            );
        }
    }
}