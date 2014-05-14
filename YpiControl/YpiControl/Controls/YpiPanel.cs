using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using YpiControl;

namespace Ypi.Controls
{
    /// <summary>
    /// Panel with reactions
    /// ---
    /// @author:     lboleslavsky [http://boleslavsky.net] 2014
    /// @license:    MIT [link to ypijs.org required]
    /// @project:
    ///              Your Presentation Interface for JavaScript
    ///              [http://ypijs.org]
    /// </summary>
    [DefaultProperty("ID")]
    [ToolboxData("<{0}:YpiPanel runat=server></{0}:YpiPanel>")]
    public class YpiPanel : WebControl
    {          
        /// <summary>
        /// Render panel with reactions
        /// </summary>
        /// <param name="output"></param>
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Resource.RENDER_PANEL_CONTENT);   
        }
    }
}
