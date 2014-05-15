using System;
using Ypi.Events;

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
        /// Occurs when property is set or changed
        /// </summary>
        event EventHandler OnPropertyChanged;        
        /// <summary>
        /// When including embedded file
        /// </summary>
        event EventHandler<ScriptEventArgs> OnScriptRequired;
    }
}
