using System;

namespace Ypi.Controls
{
    /// <summary>
    /// Base control interface
    /// ---
    /// @author:     lboleslavsky [http://boleslavsky.net] 2014
    /// @license:    MIT [link to ypijs.org required]
    /// @project:
    ///              Your Presentation Interface for JavaScript
    ///              [http://ypijs.org]
    /// </summary>
    interface IBaseControl
    {
        /// <summary>
        /// Occurs when property is changed
        /// </summary>
        event EventHandler OnPropertyChanged;
        /// <summary>
        /// Occurs when property is set;
        /// </summary>
        event EventHandler OnPropertySet;
    }
}
