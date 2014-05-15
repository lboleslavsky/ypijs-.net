using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using YpiControl;
using Ypi.Events;

namespace Ypi.Controls
{
    /// <summary>
    /// Base control
    /// ---
    /// @author:     lboleslavsky [http://boleslavsky.net] 2014
    /// @license:    MIT [link to ypijs.org required]
    /// @project:
    ///              Your Presentation Interface for JavaScript
    ///              [http://ypijs.org]
    /// </summary>
    public class BaseControl : WebControl, INamingContainer, IBaseControl
    { 
        // parameters
        protected IDictionary<string, object> parameters;
        /// <summary>
        /// Occurs when property is changed
        /// </summary>
        public event EventHandler OnPropertyChanged;
        /// <summary>
        /// When including embedded file
        /// </summary>
        public event EventHandler<ScriptEventArgs> OnScriptRequired;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseControl()
        {
            parameters = new Dictionary<string, object>();           
        }       

        /// <summary>
        /// Set property
        /// </summary>
        /// <param name="name">property name</param>
        /// <param name="value">property value</param>
        public void SetProperty(string name, object value)
        {
            if (!parameters.ContainsKey(name))
            {
                if (OnPropertyChanged != null)
                {
                    OnPropertyChanged.Invoke(this, new PropertyEventArgs(name,value,null));
                }
                parameters.Add(name, value);              
            }
            else
            {
                if (OnPropertyChanged != null)
                {
                    OnPropertyChanged.Invoke(this, new PropertyEventArgs(name,value,parameters[name]));
                }
                parameters[name] = value;                
            }
        }

        /// <summary>
        /// Set number property 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected void SetNumber(string name, string value)
        {
            int result;
            if (!int.TryParse(value, out result))
            {
                throw new ArgumentException(Resource.ERROR_INVALID_NUMBER_FORMAT);
            }
            SetProperty(name, value);
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

        /// <summary>
        /// Try to find control by ID
        /// </summary>
        /// <param name="rootControl">root</param>
        /// <param name="controlID">target ID</param>
        /// <returns>Contol with ID match</returns>
        protected Control FindControlRecursive(Control rootControl, string controlID)
        {
            if (rootControl.ID == controlID) return rootControl;
            foreach (Control controlToSearch in rootControl.Controls)
            {
                Control controlToReturn = FindControlRecursive(controlToSearch, controlID);
                if (controlToReturn != null)
                {
                    return controlToReturn;
                }
            }
            return null;
        }

        /// <summary>
        /// Place script near to </body> attribute
        /// </summary>
        /// <param name="key">script key</param>
        /// <param name="content">content</param>
        protected void PlaceScript(string key, string content)
        {
            if (OnScriptRequired != null)
            {
                OnScriptRequired.Invoke(this, new ScriptEventArgs(key, content));
                return;  
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), key, content);
        }

        protected void PlaceStyleshet(string url)
        {
            Page.Header.Controls.Add(new Literal() { Text = string.Format(Resource.INCLUDE_STYLESHEET_URL, url) });
        }

        /// <summary>
        /// Return url of embedded file
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string GetEmbeddedFileUrl(string key)
        {
            return Page.ClientScript.GetWebResourceUrl(this.GetType(), key);
        }
    }
}
