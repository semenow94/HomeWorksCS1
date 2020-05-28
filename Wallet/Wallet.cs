using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Wallet
{
    
    public class Operation
    {
        public double Sum { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public Operation()
        {

        }
        public Operation(double _sum, DateTime _date, string _description, string _type)
        {
            Sum = _sum;
            Date = _date;
            Description = _description;
            Type = _type;
        }
        public override string ToString()
        {
            string str=$"{Sum} {Date} {Description}";
            return str;
        }
    }
    public delegate void Action();
    public class Wallet
    {
        [XmlIgnore]
        public Action action;
        public double Money
        {
            get
            {
                double money=0;
                foreach(Operation a in opers)
                {
                    if(a.Type=="Расход")
                    {
                        money += a.Sum*-1;
                    }
                    else
                    {
                        money += a.Sum;
                    }
                }
                return money;
            }
            set
            {

            }
        }
        public List<Operation> opers = new List<Operation>();
        
        public Wallet()
        {

        }
        public void DelOperation(int a)
        {
            opers.RemoveAt(a);
            action();
        }
        public void AddOperation(double _sum, DateTime _date, string _description, string _type)
        {
            opers.Add(new Operation(Math.Round(_sum,2), _date, _description, _type));
            action();
        }
        public void EditOperation(int index, double _sum, DateTime _date, string _description, string _type)
        {
            opers[index].Sum = Math.Round(_sum, 2);
            opers[index].Date = _date;
            opers[index].Description = _description;
            opers[index].Type = _type;
            action();
        }
    }
}
