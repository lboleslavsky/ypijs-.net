using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ypi.Events
{
    /// <summary>
    /// Event args for property changed or set event
    /// ---
    /// @author:     lboleslavsky [http://boleslavsky.net] 2014
    /// @license:    MIT [link to ypijs.org required]
    /// @project:
    ///              Your Presentation Interface for JavaScript
    ///              [http://ypijs.org]
    /// </summary>
    public class PropertyEventArgs:EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="oldValue"></param>
        public PropertyEventArgs(string name, object value, object oldValue)
        {
            this.name = name;
            this.value = value;
            this.oldValue = oldValue;   
        }

        /// <summary>
        /// Property name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Property new value
        /// </summary>
        public object Value
        {
            get
            {
                return value;
            }
        }

        /// <summary>
        /// Property old value
        /// </summary>
        public object OldValue
        {
            get
            {
                return oldValue;
            }
        }

        private string name;
        private object value;
        private object oldValue;
    }
}
