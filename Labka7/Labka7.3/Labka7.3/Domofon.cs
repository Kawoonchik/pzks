using System;

namespace DomofonServiceApp
{
    public struct Domofon
    {
        public string Address { get; set; }
        public int Subscribers { get; set; }
        public DateTime LastServiceDate { get; set; }
        public int ServiceIntervalDays { get; set; }
        public string Condition { get; set; }

        public DateTime NextServiceDate => LastServiceDate.AddDays(ServiceIntervalDays);

        public override string ToString()
        {
            return $"{Address} | Last: {LastServiceDate:dd.MM.yyyy} | Next: {NextServiceDate:dd.MM.yyyy} | Condition: {Condition}";
        }
    }
}
