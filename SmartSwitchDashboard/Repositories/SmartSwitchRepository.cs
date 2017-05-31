using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartSwitchDashboard.Models;
using System.Collections.Concurrent;

namespace SmartSwitchDashboard.Repositories
{
    public class SmartSwitchRepository : ISmartSwitchRepository
    {
        private ConcurrentDictionary<string, SmartSwitch> _items = new ConcurrentDictionary<string, SmartSwitch>();
        public void Add(SmartSwitch item)
        {
            item.LastSeen = DateTime.Now;
            _items[item.Id] = item;
        }

        public SmartSwitch Find(string id)
        {
            if (id == null)
            {
                return null;
            }
            SmartSwitch item;
            _items.TryGetValue(id, out item);
            return item;
        }

        public IEnumerable<SmartSwitch> GetAll()
        {
            return _items.Values;
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(SmartSwitch item)
        {
            throw new NotImplementedException();
        }
    }
}
