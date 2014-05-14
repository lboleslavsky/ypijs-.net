using System.Collections.Generic;

namespace Ypi.Core
{
    /// <summary>
    /// Avatar object
    /// ---
    /// @author:     lboleslavsky [http://boleslavsky.net] 2014
    /// @license:    MIT [link to ypijs.org required]
    /// @project:
    ///              Your Presentation Interface for JavaScript
    ///              [http://ypijs.org]
    /// </summary>
    class Avatar:IAvatar
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters"></param>
        public Avatar(IDictionary<string, object> parameters)
        {
            this.parameters = parameters;
        }

        /// <summary>
        /// Parameters
        /// </summary>
        public IDictionary<string, object> Parameters
        {
            get
            {
                return parameters;
            }
        }

        // initial parameters
        private IDictionary<string, object> parameters;
    }
}
