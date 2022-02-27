/*
Input
4
Varun
111
1122
5000
Chennai
Raju
112
3212
6500
Bangalore
Laksha
113
2334
3400
Chennai
Akshay
115
3115
4500
Chennai
Chennai

Output
Varun:111:1122:5000:Chennai
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
            Bank manager=new Bank();
            for(int i=0;i<n;i++)
            {
                string name=Console.ReadLine();
                int accid=Convert.ToInt32(Console.ReadLine());
                int clid=Convert.ToInt32(Console.ReadLine());
                double balance=Convert.ToDouble(Console.ReadLine());
                string branch=Console.ReadLine();
                manager.accountlist.Add(new Account(name,accid,clid,balance,branch));
            }
            string branch1=Console.ReadLine();
            Account res=manager.method1(branch1);
            if(res==null)
            {
                Console.WriteLine("No found");
            }
            else
            {
                Console.WriteLine("{0}:{1}:{2}:{3}:{4}",res.Name,res.Accid,res.Clid,res.Balance,res.Branch);
            }
        }
    }
    
    class Account
    {
        public string Name {get; set;}
        public int Accid {get; set;}
        public int Clid {get; set;}
        public double Balance{get; set;}
        public string Branch{get; set;}
        
        public Account(string name, int accid, int clid, double balance, string branch)
        {
            Name=name;
            Accid=accid;
            Clid=clid;
            Balance=balance;
            Branch=branch;
        }
    }
    
    class Bank
    {
        public List<Account>accountlist=new List<Account>();
        public Account method1(string branch)
        {
            double max=double.MinValue;
            Account res=null;
            foreach(Account ac in accountlist)
            {
                if(ac.Branch.ToLower().Contains(branch.ToLower()) && max<ac.Balance)
                {
                    res=ac;
                    max=ac.Balance;
                }
            }
            return res;
        }
    }
}
