
namespace Ypi.Controls
{
    /// <summary>
    /// Ypi base script control interface
    /// ---
    /// @author:     lboleslavsky [http://boleslavsky.net] 2014
    /// @license:    MIT [link to ypijs.org required]
    /// @project:
    ///              Your Presentation Interface for JavaScript
    ///              [http://ypijs.org]
    /// </summary>
    public interface IYpiControl
    {
         /// <summary>
        /// Register avatar to YpiControl script base
        /// </summary>
        /// <param name="avatar">avatar control</param>
        void RegisterAvatar(Avatar avatar);
        
        /// <summary>
        /// Url with chapter XML file
        /// </summary>
        string ChapterUrl
        {
            set;
        }

        /// <summary>
        /// Init case in current chapter
        /// </summary>
        string InitState
        {
            set;
        }

        /// <summary>
        /// Start dialog automatically
        /// </summary>
        string IsAutostart
        {
            set;
        }

        /// <summary>
        /// Enable/disable sound 
        /// </summary>
        string IsSoundEnabled
        {
            set;
        }

        /// <summary>
        /// Link custom javascript file
        /// </summary>
        string CustomJs
        {
            set;
        }

        /// <summary>
        /// Link custom stylesheet file
        /// </summary>
        string CustomStylesheet
        {
            set;
        }
    }
}
