/**
 * Namespace: System.Web.UI.WebControls
 * Class:     Label
 *
 * Author:  Gaurav Vaish
 * Maintainer: gvaish@iitk.ac.in
 * Contact: <my_scripts2001@yahoo.com>, <gvaish@iitk.ac.in>
 * Implementation: yes
 * Status:  100%
 *
 * (C) Gaurav Vaish (2001)
 */

using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;

namespace System.Web.UI.WebControls
{
	[DefaultProperty("Text")]
	//[Designer("??")]
	[ControlBuilder(typeof(LabelControlBuilder))]
	//[DataBindingHandler("??")]
	[ParseChildren(false)]
	[ToolboxData("<{0}:Label runat=\"server\">Label</{0}:Label>")]
	public class Label : WebControl
	{
		public Label(): base()
		{
		}

		internal Label(HtmlTextWriterTag tagKey): base(tagKey)
		{
		}

		public virtual string Text
		{
			get
			{
				object o = ViewState["Text"];
				if(o!=null)
					return (string)o;
				return String.Empty;
			}
			set
			{
				ViewState["Text"] = value;
			}
		}

		protected override void AddParsedSubObject(object obj)
		{
			if(HasControls())
			{
				AddParsedSubObject(obj);
				return;
			}
			if(obj is LiteralControl)
			{
				Text = ((LiteralControl)obj).Text;
				return;
			}
			if(Text.Length > 0)
			{
				AddParsedSubObject(Text);
				Text = String.Empty;
			}
			AddParsedSubObject(obj);
		}

		protected override void LoadViewState(object savedState)
		{
			if(savedState != null)
			{
				base.LoadViewState(savedState);
				string savedText = (string)ViewState["Text"];
				if(savedText != null)
					Text = savedText;
			}
		}

		protected override void RenderContents(HtmlTextWriter writer)
		{
			if(HasControls())
			{
				RenderContents(writer);
			} else
			{
				writer.Write(Text);
			}
		}
	}
}
