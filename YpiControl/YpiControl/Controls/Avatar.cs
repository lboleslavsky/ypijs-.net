using System;
using System.ComponentModel;
using System.Web.UI;
using YpiControl;

namespace Ypi.Controls
{
    /// <summary>
    /// Avatar control
    /// ---
    /// @author:     lboleslavsky [http://boleslavsky.net] 2014
    /// @license:    MIT [link to ypijs.org required]
    /// @project:
    ///              Your Presentation Interface for JavaScript
    ///              [http://ypijs.org]
    /// </summary>
    [DefaultProperty("Alias")]
    [ToolboxData("<{0}:Avatar runat=server></{0}:Avatar>")]
    public class Avatar : BaseControl
    {      
        /// <summary>
        /// Constructor
        /// </summary>
        public Avatar():base()
        {            
        }

        /// <summary>
        /// Avatar span ID
        /// </summary>
        public string Name
        {
            set
            {
                SetProperty(Resource.ATTR_NAME, value);
            }
        }

        /// <summary>
        /// Avatar alias
        /// </summary>
        public string Alias
        {
            set
            {
                SetProperty(Resource.ATTR_ALIAS, value);
            }
        }

        /// <summary>
        /// Avatar's bubble span ID
        /// </summary>
        public string BubbleId
        {
            set
            {
                SetProperty(Resource.ATTR_BUBBLE_ID, value);
            }
        }

        /// <summary>
        /// Interval to repeat last speech if no reaction occurse. 
        /// </summary>
        public string IdleInterval
        {
            set
            {
                SetNumber(Resource.ATTR_IDLE_INTERVAL, value);
            }
        }

        /// <summary>
        /// Speech speed.
        /// </summary>
        public string Speed
        {
            set
            {
                SetNumber(Resource.ATTR_SPEED, value);
            }
        }

        /// <summary>
        /// Target YpiControl to register this
        /// </summary>
        public string YpiBaseName
        {
            set;
            get;
        }       

        /// <summary>
        /// Register to YpiControl here
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            if (!parameters.ContainsKey(Resource.ATTR_BUBBLE_ID))
            {
                SetProperty(Resource.ATTR_BUBBLE_ID,string.Format(Resource.ATTR_BUBBLE_ID_DEFAULT,this.ID));
            }
            if (!parameters.ContainsKey(Resource.ATTR_NAME))
            {
                SetProperty(Resource.ATTR_NAME, this.ID);
            }
            
            YpiControl ypiControl = FindControlRecursive(Page, YpiBaseName) as YpiControl;
            if (ypiControl != null)
            {
                ypiControl.RegisterAvatar(this);
            }
            base.OnInit(e);
        }

        /// <summary>
        /// Render Avatar content
        /// </summary>
        /// <param name="output">output writer</param>
        protected override void RenderContents(HtmlTextWriter output)
        {  
            output.Write(string.Format(Resource.RENDER_AVATAR_CONTENT, parameters[Resource.ATTR_BUBBLE_ID],parameters[Resource.ATTR_NAME]));         
        }
    }
}
