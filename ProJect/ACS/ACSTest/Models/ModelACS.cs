using ACS.SPiiPlusNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSTest.Models
{
    internal class ModelACS
    {
        private static Api _apiInstance = null;
        private static readonly object Padlock = new object();

        public static Api apiInstance
        { 
            get 
            {
                lock (Padlock) 
                {
                    if (_apiInstance == null)
                        _apiInstance = new Api();
                    return _apiInstance;
                }                
            } 
        }
    }
}