using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ypi.Controls
{
    /// <summary>
    /// Avatar control interface
    /// ---
    /// @author:     lboleslavsky [http://boleslavsky.net] 2014
    /// @license:    MIT [link to ypijs.org required]
    /// @project:
    ///              Your Presentation Interface for JavaScript
    ///              [http://ypijs.org]
    /// </summary>
    interface IAvatar
    {
        /// <summary>
        /// Avatar span ID
        /// </summary>
        string Name
        {
            set;
        }

        /// <summary>
        /// Avatar alias
        /// </summary>
        string Alias
        {
            set;
        }

        /// <summary>
        /// Avatar's bubble span ID
        /// </summary>
        string BubbleId
        {
            set;
        }

        /// <summary>
        /// Interval to repeat last speech if no reaction occurse. 
        /// </summary>
        string IdleInterval
        {
            set;
        }

        /// <summary>
        /// Speech speed.
        /// </summary>
        string Speed
        {
            set;
        }
       
        /// <summary>
        /// Target YpiControl to register this as avatar
        /// </summary>
        string YpiBaseName
        {
            set;
            get;
        }
    }
}
