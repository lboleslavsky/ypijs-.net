Your Presentation Interface control for ASP.NET appplications (Microsoft Sharepoint too).
==========

Package
-------------------
**Ypi.Controls.YpiControl**
- Script base

**Ypi.Controls.Avatar**
- Avatar control

**Ypi.Controls.YpiPanel**
- Panel with reactions

Installation 
-------------------
- Add reference to YpiControl.dll to your asp .net application. You can obtain bin file (all you need) or compile your own from source. JavaScript and CSS is embedded. 
- Register component to your aspx page. For example.  

**Default.aspx:**

```aspx-cs
<%@ Register TagPrefix="ypi" Assembly="YpiControl" Namespace="Ypi.Controls" %>
```

Usage
-------------------
Add following controls anywhere to page content. At first add script base.
 
**Default.aspx:**
 
```aspx-cs
<ypi:YpiControl ID="ypiScriptBase" runat="server" ChapterUrl="welcome.xml" InitState="n1" IsAutostart="true" />   
``` 
 
Then add corresponding avatar or more of them. There is tag called YpiBaseName to join with YpiControl by ID. This control can be anywhere in page body content too.

```aspx-cs
<ypi:Avatar ID="avatar1" YpiBaseName="ypiScriptBase" BubbleId="npc_avatar_1" IdleTimeout="30000" Speed="150" Alias="Joe Doe" runat="server" />
``` 
 
Finally add panel with answers. 
 
```aspx-cs
<ypi:YpiPanel runat="server"/>
```

Customize
-------------------
Package contains some predefined tags. However, it is possible to set custom property with SetProperty method (YpiControl, Avatar). 

```csharp
	protected void Page_Load(object sender, EventArgs e)
	{
		//ypiScriptBase.OnScriptRequired+=new EventHandler<Ypi.Events.ScriptEventArgs>(ypiScriptBase_OnScriptRequired);
		ypiScriptBase.SetProperty("attrCase","['trackId','custom']"); 			
		avatar1.SetProperty("Speed", "150");
	}
```

There is custom event called OnScriptRequired to require embedded script into your page container. Registered method overrides main script including strategy (default is RegisterStartupScript method).

```csharp
	protected void ypiScriptBase_OnScriptRequired(object sender,Ypi.Events.ScriptEventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), e.Key, e.Url); 
    }
```

Custom stylesheet
-------------------
Link stylesheet file with CustomStylesheet property of YpiControl. 