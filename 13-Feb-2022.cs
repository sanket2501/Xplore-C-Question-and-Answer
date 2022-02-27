/*
Input
4
252
Ashwa
Triplex
26000
6
21
Susila
triplex
17000
9
28
Lakshami
single storey
5000
5
215
Ashwa
Triplex
29000
15
Triplex

Output
21:Susila:triplex:17850:9
215:Ashwa:Triplex:30450:15
*/

using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n=Convert.ToInt32(Console.ReadLine());
        colonymanagement manager=new colonymanagement();
        for(int i=0;i<n;i++)
        {
            int flatno=Convert.ToInt32(Console.ReadLine());
            string name=Console.ReadLine();
            string type=Console.ReadLine();
            double rent=Convert.ToDouble(Console.ReadLine());
            int count=Convert.ToInt32(Console.ReadLine());
            manager.colonylist.Add(new colony(flatno,name,type,rent,count));
        }
        string flattype=Console.ReadLine();
        List<colony>res= manager.method1(flattype);
        if(res.Count==0)
        {
            Console.WriteLine("No found");
        }
        else
        {
            foreach(colony co in res)
            {
                Console.WriteLine("{0}:{1}:{2}:{3}:{4}",co.Flatno, co.Name, co.Type, co.Rent, co.Count);
            }
        }
    }
    class colony
    {
        public int Flatno{get; set;}
        public string Name{get; set;}
        public string Type{get; set;}
        public double Rent{get; set;}
        public int Count{get; set;}
        
        public colony(int flat,string name,string type,double rent, int count)
        {
            Flatno=flat;
            Name=name;
            Type=type;
            Rent=rent;
            Count=count;
        }
    }
    
    class colonymanagement
    {
        public List<colony>colonylist=new List<colony>();
        public List<colony>method1(string type)
        {
            List<colony>res=new List<colony>();
            foreach(colony co in colonylist)
            {
                if(co.Type.ToLower().Contains(type.ToLower()) && co.Count>8)
                {
                    double g=0.0;
                    g=co.Rent*5/100;
                    g=g+co.Rent;
                    colony ans=new colony(co.Flatno, co.Name,co.Type,g,co.Count);
                    res.Add(ans);
                }
            }
            return res;
        }
    }
}
