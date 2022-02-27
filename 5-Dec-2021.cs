/*
Input
5
Deccan Express
Hydrabad
300.50
True
Rajdhani Express
Delhi
1200.45
True
Hirkani
Mumbai
300.23
False
Ratrani
Kolhapur
200
False
Shivshahi
Mumbai
600
True
2
Mumbai
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution
{
    class Solution
    {
        public static void Main()
        {
            int n=Convert.ToInt32(Console.ReadLine());
            msrtc manager=new msrtc();
            for(int i=0;i<n;i++)
            {
                string name=Console.ReadLine();
                string destination=Console.ReadLine();
                double fare=Convert.ToDouble(Console.ReadLine());
                bool isexpress=Convert.ToBoolean(Console.ReadLine());
                manager.buslist.Add(new bus(name, destination, fare, isexpress));
            }
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                string destination=Console.ReadLine();
                List<bus>res=manager.method1(destination);
                if(res.Count==0)
                {
                    Console.WriteLine("No Found");
                    break;
                }
                foreach(bus by in res)
                {
                    Console.WriteLine("{0}:{1}:{2}:{3}",by.Name,by.Destination,by.Fare,by.IsExpress);   
                }
                break;
                case 2:
                string destination2=Console.ReadLine();
                
                bus res1=manager.method2(destination2);
                if(res1 == null)
                {
                    Console.WriteLine("No found");
                    break;
                }
                Console.WriteLine("{0}:{1}:{2}:{3}",res1.Name,res1.Destination,res1.Fare,res1.IsExpress);
                break;
            }
        }
    }
    
    class bus
    {
        public string Name{get; set;}
        public string Destination{get; set;}
        public double Fare{get; set;}
        public bool IsExpress{get; set;}
        
        public bus(){}
        
        public bus(string name, string destination, double fare, bool isexpress)
        {
            Name= name;
            Destination= destination;
            Fare= fare;
            IsExpress= isexpress;
        }
    }
    
    class msrtc
    {
        public List<bus> buslist= new List<bus>();
        public List<bus> method1(string destination)
        {
            List<bus>newbus = new List<bus>();
            foreach(bus by in buslist)
            {
                if(by.Destination.ToLower().Contains(destination.ToLower()))
                {
                    newbus.Add(by);
                }
            }
            return newbus;
        }
        
        public bus method2(string destination)
        {
            bus obj=null;
            double min= double.MaxValue;
            foreach(bus by in buslist)
            {
                if(by.Destination.ToLower().Contains(destination.ToLower()) && by.Fare<min)
                {
                    obj=by;
                    min=by.Fare;
                }
            }
            return obj;
        }
    }
}
