using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ypi.Events
{
    /// <summary>
    /// Event args for included script
    /// ---
    /// @author:     lboleslavsky [http://boleslavsky.net] 2014
    /// @license:    MIT [link to ypijs.org required]
    /// @project:
    ///              Your Presentation Interface for JavaScript
    ///              [http://ypijs.org]
    /// </summary>
    public class ScriptEventArgs: EventArgs
    {      
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">script key</param>
        /// <param name="url">required file Url</param>
        public ScriptEventArgs(string key, string url)
            : base()
        {
            this.key = key;
            this.url = url ;
        }

        /// <summary>
        /// Required file Url
        /// </summary>
        public string Url
        {
            get
            {
                return url;
            }
        }

        /// <summary>
        /// Script key
        /// </summary>
        public string Key
        {
            get
            {
                return key;
            }
        }

        private string key;
        private string url;
    }
}
