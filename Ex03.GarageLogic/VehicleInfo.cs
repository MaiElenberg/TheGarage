using System;
using System.Collections.Generic;

namespace GarageLogicVehicle
{
    public class VehicleInfo
    {

        private string m_OwnerName;
        private string m_OwnerNumber;

        internal VehicleInfo(string i_OwnerName, string i_OwnerNumber)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerNumber = i_OwnerNumber;
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
        }

        public string OwnerNumber
        {
            get
            {
                return m_OwnerNumber;
            }
        }

        public override string ToString()
        {
            string clientInfo = string.Format(
                @"Client's name = {0}
Client's number = {1}"
, m_OwnerName, m_OwnerNumber);

            return clientInfo;
        }
    }
}
