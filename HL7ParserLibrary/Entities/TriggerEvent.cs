﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL7Parser
{
    /// <summary>
    /// Partial class for DB entity
    /// </summary>
    public partial class TriggerEvent
    {
        #region Member Variables 
        
        #endregion

        #region Properties
        public List<Segment> SegmentCollection
        {
            get; set;
        }
        #endregion

        #region Constructor 

        #endregion

        #region Overrides
        public override string ToString()
        {
            return string.Format("{0}_{1}", this.MessageType, this.EventType);
        }
        #endregion
    }
}
