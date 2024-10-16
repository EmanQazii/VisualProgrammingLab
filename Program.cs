using System;
namespace lab4
{
    public class Program
    {
        public static void Main()
        {
            WorkItem item = new WorkItem("Fix Bugs", "Fix all bugs in my code branch", new TimeSpan(3, 4, 0, 0));
            ChangeRequest change = new ChangeRequest("Change Base Class Design", "Add members to the class", new TimeSpan(4, 0, 0), 1);
            Console.WriteLine(item.ToString());
            change.Update("Change the Design of the Base Class", new TimeSpan(4,0,0));
            Console.WriteLine(change.ToString());
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

    }

    public class WorkItem
    {
        private static int currentID;

        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string Description { get; set; }
        protected TimeSpan jobLength { get; set; }

        public WorkItem()
        {
            ID = 0;
            Title = "Default Title";
            Description = "Default Description";
            jobLength = new TimeSpan();
        }
        public WorkItem(string title, string desc, TimeSpan joblen)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.jobLength = joblen;
        }
        protected int GetNextID()
        {
            return ++currentID;
        }

        public void Update(string title, TimeSpan joblen)
        {
            this.Title = title;
            this.jobLength = joblen;
        }
        public override
        string ToString()
        {
            return String.Format("{0} - {1}", this.ID, this.Title);
        }
    }


    public class ChangeRequest : WorkItem
    {
        protected int originalItemID { get; set; }

        public ChangeRequest() { }

        public ChangeRequest(string title, string desc, TimeSpan joblen, int originalID)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.jobLength = joblen;
            this.originalItemID = originalID;

        }

        public ChangeRequest(int originalItemID)
        {
            this.originalItemID = originalItemID;
        }
    }

}

/*static void TestCatch()
        {
            System.IO.StreamWriter av = null;
            try
            {
                av=new StreamWriter("C:\\Users\\233531\\Desktop\\lab4.txt");
                av.WriteLine("Hello");
            }    
            catch(System.IO.FileNotFoundException es)
            {
                System.Console.WriteLine(es.ToString());
            }
            finally
            {
                av.Close();
            }
            Console.WriteLine("The data is written in file");
        }

        static double SafeDivision(double a ,double b)
        {
            if(b==0)
                //throw new System.DivideByZeroException();
            return a/b;
        }
                {
            /*TestCatch();
            double a = 98, b = 0;
            double result = 0;
            //with try catch
            try
            {
                result = SafeDivision(a, b);
                Console.WriteLine($"{a} divided by {b} = {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Attempted divided by zero");
            }

            //without try catch
            result = SafeDivision(a, b);
            Console.WriteLine($"{a} divided by {b} = {result}");*/

