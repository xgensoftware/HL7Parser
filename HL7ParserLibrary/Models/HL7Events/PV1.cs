﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HL7Parser.Base;

namespace HL7Parser.Models
{
    /// <summary>
    /// Created By: Anthony Sanfilippo
    /// Create Date: 2017-02-08
    /// Description: PV1 HL7 Model
    /// </summary>

    public class PV1 : BaseEvent, IEvent
    {
        #region Member Variables 

        #endregion

        #region Properties

        #endregion

        #region Constructor 
        public PV1(string eventType, string name, string version, int seq, bool isOptional, bool isRepeated) : base()
        {
            _eventType = eventType;
            _name = name;
            _version = version;
            _sequence = seq;
            _isOptional = isOptional;
            _isRepeated = isRepeated;
        }
        #endregion
    }
}
