using System.Collections.Generic;

namespace Ypi.Core
{
    /// <summary>
    /// Avatar interface
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
        /// Parameters
        /// </summary>
        IDictionary<string, object> Parameters
        {
            get;
        }
    }
}
