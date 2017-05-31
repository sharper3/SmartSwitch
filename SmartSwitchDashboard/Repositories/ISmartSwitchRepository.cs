using SmartSwitchDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSwitchDashboard.Repositories
{
    public interface ISmartSwitchRepository
    {
        void Add(SmartSwitch item);
        IEnumerable<SmartSwitch> GetAll();
        SmartSwitch Find(string id);
        void Remove(string id);
        void Update(SmartSwitch item);


    }
}
