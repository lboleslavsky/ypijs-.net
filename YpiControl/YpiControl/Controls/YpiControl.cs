using System.ComponentModel;
using System.Web.UI;
using Ypi.Core;
using YpiControl;

namespace Ypi.Controls
{
    /// <summary>
    /// Ypi base script control
    /// ---
    /// @author:     lboleslavsky [http://boleslavsky.net] 2014
    /// @license:    MIT [link to ypijs.org required]
    /// @project:
    ///              Your Presentation Interface for JavaScript
    ///              [http://ypijs.org]
    /// </summary>
    [DefaultProperty("ID")]
    [ToolboxData("<{0}:YpiControl runat=server></{0}:YpiControl>")]
    public class YpiControl : BaseControl, IYpiControl
    {         
        /// <summary>
        /// Constructor
        /// </summary>
        public YpiControl():base()
        {
            ypiBaseGenerator = new YpiBaseGenerator(parameters);            
        }
        
        /// <summary>
        /// Register avatar to YpiControl script base
        /// </summary>
        /// <param name="avatar">avatar control</param>
        public void RegisterAvatar(Avatar avatar)
        {           
            ypiBaseGenerator.CreateAvatar(avatar.Parameters);       
        }
        
        /// <summary>
        /// Url with chapter XML file
        /// </summary>
        public string ChapterUrl
        {
            set
            {
                SetProperty(Resource.ATTR_CHAPTER_URL, value);
            }
        }

        /// <summary>
        /// Init case in current chapter
        /// </summary>
        public string InitState
        {
            set
            {
                SetProperty(Resource.ATTR_INIT_STATE, value);
            }
        }

        /// <summary>
        /// Start dialog automatically
        /// </summary>
        public string IsAutostart
        {
            set
            {
               SetProperty(Resource.ATTR_IS_AUTOSTART,value);
            }
        }

        /// <summary>
        /// Enable/disable sound 
        /// </summary>
        public string IsSoundEnabled
        {
            set
            {
                SetProperty(Resource.ATTR_IS_SOUND_ENABLED, value);
            }
        }

        /// <summary>
        /// Link custom javascript file
        /// </summary>
        public string CustomJs
        {
            set
            {
                ypiCustomFileUrl = value;    
            }            
        }

        /// <summary>
        /// Link custom stylesheet file
        /// </summary>
        public string CustomStylesheet
        {
            set
            {
                ypiCssFileUrl = value;
            }
        }

        /// <summary>
        /// Register stylesheet
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(System.EventArgs e)
        {
            if (ypiCssFileUrl != null)
            {
                PlaceStyleshet(ypiCssFileUrl);   
            }               
            base.OnInit(e);
        }

        /// <summary>
        /// Render ypi script base
        /// </summary>
        /// <param name="output"></param>
        protected override void RenderContents(HtmlTextWriter output)
        {
            string jqueryFileUrl = GetEmbeddedFileUrl(Resource.JQUERY_FILE_URL);
            string ypiMinFileUrl = GetEmbeddedFileUrl(Resource.YPI_MIN_FILE_URL);
            if (ypiCustomFileUrl == null)
            {
                ypiCustomFileUrl = GetEmbeddedFileUrl(Resource.YPI_MIN_CUSTOM_URL);
            }
            PlaceScript(Resource.JQUERY_KEY, string.Format(Resource.SCRIPT_INCLUDE,jqueryFileUrl));
            PlaceScript(Resource.YPI_MIN_KEY,string.Format(Resource.SCRIPT_INCLUDE,ypiMinFileUrl));            
            PlaceScript(Resource.YPI_MIN_CUSTOM_KEY, string.Format(Resource.SCRIPT_INCLUDE, ypiCustomFileUrl));
            PlaceScript(Resource.YPI_BASE_KEY, string.Format(Resource.SCRIPT_YPI_BASE, ypiBaseGenerator.GetBaseScript()));
            PlaceScript(Resource.YPI_START_KEY, Resource.SCRIPT_YPI_START);
        }

        // script generator
        private YpiBaseGenerator ypiBaseGenerator;
        // url to css file
        private string ypiCssFileUrl;
        // url to custom javascript file
        private string ypiCustomFileUrl;

    }
}
