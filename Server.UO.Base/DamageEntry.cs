using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class DamageEntry
    {
        private IMobile m_Damager;
        private int m_DamageGiven;
        private DateTime m_LastDamage;
        private List<DamageEntry> m_Responsible;

        public IMobile Damager { get { return m_Damager; } }
        public int DamageGiven { get { return m_DamageGiven; } set { m_DamageGiven = value; } }
        public DateTime LastDamage { get { return m_LastDamage; } set { m_LastDamage = value; } }
        public bool HasExpired { get { return (DateTime.Now > (m_LastDamage + m_ExpireDelay)); } }
        public List<DamageEntry> Responsible { get { return m_Responsible; } set { m_Responsible = value; } }

        private static TimeSpan m_ExpireDelay = TimeSpan.FromMinutes(2.0);

        public static TimeSpan ExpireDelay
        {
            get { return m_ExpireDelay; }
            set { m_ExpireDelay = value; }
        }

        public DamageEntry(IMobile damager)
        {
            m_Damager = damager;
        }
    }

}
