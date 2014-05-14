using System.Collections.Generic;
using System.Text;
using YpiControl;

namespace Ypi.Core
{
    /// <summary>
    /// Basic Ypi javascript generator
    /// ---
    /// @author:     lboleslavsky [http://boleslavsky.net] 2014
    /// @license:    MIT [link to ypijs.org required]
    /// @project:
    ///              Your Presentation Interface for JavaScript
    ///              [http://ypijs.org]
    /// </summary>
    class YpiBaseGenerator
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parameters"></param>
        public YpiBaseGenerator(IDictionary<string,object> parameters)
        {
            this.avatars = new List<IAvatar>();
            this.parameters = parameters;
        }
        
        /// <summary>
        /// Create Avatar
        /// </summary>
        /// <param name="parameters">initial parameters</param>
        /// <returns>avatar</returns>
        public IAvatar CreateAvatar(IDictionary<string, object> parameters)
        {
            Avatar avatar = new Avatar(parameters);            
            avatars.Add(avatar);
            return avatar;
        }

        /// <summary>
        /// Returns Ypi base javascript syntax
        /// </summary>
        /// <returns>Ypi base javascript syntax</returns>
        public string GetBaseScript()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Resource.SCRIPT_GENERATOR_INIT);            
            sb.Append(GetObjectStr(parameters));
            sb.Append(Resource.DELIM_COMMA);
            sb.Append(Resource.SCRIPT_GENERATOR_LOAD); 
            foreach (var avatar in avatars)
            {
                sb.Append(Resource.SCRIPT_GENERATOR_CREATE_AVATAR);
                sb.Append(GetObjectStr(avatar.Parameters));
                sb.Append(Resource.SCRIPT_GENERATOR_CREATE_AVATAR_END);
            }
            sb.Append(Resource.SCRIPT_GENERATOR_LOAD_END);
            return sb.ToString();
        }

        /// <summary>
        /// Returns javascript syntax of parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>javascript syntax for parameters</returns>
        private string GetObjectStr(IDictionary<string, object> parameters)
        {
            if (parameters.Count <= 0)
            {
                return string.Empty;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in parameters)
            {
                if(item.Value as string!=null)
                {
                    sb.Append(string.Format(Resource.JS_ARGUMENT_STRING_FORMAT,item.Key,item.Value));
                }
            }
            return sb.ToString(0,sb.Length-1);
        }

        // registered avatars
        private IList<IAvatar> avatars;
        // init parameters
        private IDictionary<string, object> parameters;    
    }
}
