using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DomofonServiceApp
{
    // Class to manage domofon service data
    public class ServiceManager
    {
        private readonly List<Domofon> services = new List<Domofon>();

        public void Add(string address, string subscribers, string date, string interval, string condition)
        {
            try
            {
                var dom = new Domofon
                {
                    Address = address,
                    Subscribers = int.Parse(subscribers),
                    LastServiceDate = DateTime.ParseExact(date, "ddMMyyyy", CultureInfo.InvariantCulture),
                    ServiceIntervalDays = int.Parse(interval),
                    Condition = condition.ToLower()
                };
                services.Add(dom);
            }
            catch
            {
                throw new Exception("Invalid input data.");
            }
        }

        public IEnumerable<Domofon> GetAllSortedByAddress()
        {
            return services.OrderBy(s => s.Address);
        }

        public IEnumerable<Domofon> GetBetweenDates(string start, string end)
        {
            DateTime startDate = DateTime.ParseExact(start, "ddMMyyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(end, "ddMMyyyy", CultureInfo.InvariantCulture);
            return services.Where(s => s.LastServiceDate >= startDate && s.LastServiceDate <= endDate);
        }

        public int CountSatisfactoryLastYear()
        {
            int lastYear = DateTime.Now.Year - 1;
            return services.Count(s => s.LastServiceDate.Year == lastYear && s.Condition == "satisfactory");
        }

        public Domofon? GetLastServiceNextMonth()
        {
            int nextMonth = DateTime.Now.AddMonths(1).Month;
            var results = services
                .Where(s => s.NextServiceDate.Month == nextMonth)
                .OrderBy(s => s.NextServiceDate)
                .ToList();

            if (results.Any()) return results.Last();
            return null;
        }

        public IEnumerable<Domofon> GetByExactDate(string date)
        {
            DateTime target = DateTime.ParseExact(date, "ddMMyyyy", CultureInfo.InvariantCulture);
            return services.Where(s => s.LastServiceDate == target);
        }
    }
}
