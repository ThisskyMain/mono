/**
 * Namespace: System.Web.UI.WebControls
 * Class:     FontInfo
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
using System.Text;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.ComponentModel;

namespace System.Web.UI.WebControls
{
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public sealed class FontInfo
	{
		private Style infoOwner;				
		
		internal FontInfo(Style owner)
		{
			infoOwner = owner;
		}
		
		/// <summary>
		/// Default constructor
		/// <remarks>
		/// The default constructor is made private to prevent any instances being made.
		/// </remarks>
		/// </summary>
		private FontInfo()
		{
		}
		
		public bool Bold
		{
			get
			{
				if(infoOwner.IsSet(Style.FONT_BOLD))
					return (bool)(infoOwner.ViewState["FontInfoBold"]);
				return false;
			}
			set
			{
				infoOwner.ViewState["FontInfoBold"] = value;
				infoOwner.Set(Style.FONT_BOLD);
			}
		}
		
		public bool Italic
		{
			get
			{
				if(infoOwner.IsSet(Style.FONT_ITALIC))
					return (bool)(infoOwner.ViewState["FontInfoItalic"]);
				return false;
			}
			set
			{
				infoOwner.ViewState["FontInfoItalic"] = value;
				infoOwner.Set(Style.FONT_ITALIC);
			}
		}
		
		public bool Overline
		{
			get
			{
				if(infoOwner.IsSet(Style.FONT_OLINE))
					return (bool)(infoOwner.ViewState["FontInfoOverline"]);
				return false;
			}
			set
			{
				infoOwner.ViewState["FontInfoOverline"] = value;
				infoOwner.Set(Style.FONT_OLINE);
			}
		}
		
		public bool Strikeout
		{
			get
			{
				if(infoOwner.IsSet(Style.FONT_STRIKE))
					return (bool)(infoOwner.ViewState["FontInfoStrikeout"]);
				return false;
			}
			set
			{
				infoOwner.ViewState["FontInfoStrikeout"] = value;
				infoOwner.Set(Style.FONT_STRIKE);
			}
		}
		
		public bool Underline
		{
			get
			{
				if(infoOwner.IsSet(Style.FONT_ULINE))
					return (bool)(infoOwner.ViewState["FontInfoUnderline"]);
				return false;
			}
			set
			{
				infoOwner.ViewState["FontInfoUnderline"] = value;
				infoOwner.Set(Style.FONT_ULINE);
			}
		}
		
		//TODO: How do I check if the value is negative. FontUnit is struct not enum
		public FontUnit Size
		{
			get
			{
				if(infoOwner.IsSet(Style.FONT_SIZE))
					return (FontUnit)(infoOwner.ViewState["FontInfoSize"]);
				return FontUnit.Empty;
			}
			set
			{
				infoOwner.ViewState["FontInfoSize"] = value;
				infoOwner.Set(Style.FONT_SIZE);
			}
		}
		
		public string Name
		{
			get
			{
				if(Names!=null)
					return Names[0];
				return String.Empty;
			}
			set
			{
				if(value == null)
					throw new ArgumentException();
				string[] strArray = null;
				if(value.Length > 0)
				{
					strArray = new string[1];
					strArray[0] = value;
				}
				Names = strArray;
			}
		}
		
		public string[] Names
		{
			get
			{
				if(infoOwner.IsSet(Style.FONT_NAMES))
					return (string[])(infoOwner.ViewState["FontInfoNames"]);
				return (new string[0]);
			}
			set
			{
				if(value!=null)
				{
					infoOwner.ViewState["FontInfoNames"] = value;
					infoOwner.Set(Style.FONT_NAMES);
				}
			}
		}
		
		internal void Reset()
		{
			if(infoOwner.IsSet(Style.FONT_NAMES))
				infoOwner.ViewState.Remove("FontInfoNames");
			if(infoOwner.IsSet(Style.FONT_BOLD))
				infoOwner.ViewState.Remove("FontInfoBold");
			if(infoOwner.IsSet(Style.FONT_ITALIC))
				infoOwner.ViewState.Remove("FontInfoItalic");
			if(infoOwner.IsSet(Style.FONT_STRIKE))
				infoOwner.ViewState.Remove("FontInfoStrikeout");
			if(infoOwner.IsSet(Style.FONT_OLINE))
				infoOwner.ViewState.Remove("FontInfoOverline");
			if(infoOwner.IsSet(Style.FONT_ULINE))
				infoOwner.ViewState.Remove("FontInfoUnderline");
			if(infoOwner.IsSet(Style.FONT_SIZE) && infoOwner.Font.Size != FontUnit.Empty)
				infoOwner.ViewState.Remove("FontInfoSize");
		}
		
		internal Style Owner
		{
			get
			{
				return infoOwner;
			}
		}
		
		public void CopyFrom(FontInfo source)
		{
			if(source!=null)
			{
				if(source.Owner.IsSet(Style.FONT_NAMES))
					Names = source.Names;
				if(source.Owner.IsSet(Style.FONT_BOLD))
					Bold = source.Bold;
				if(source.Owner.IsSet(Style.FONT_ITALIC))
					Italic = source.Italic;
				if(source.Owner.IsSet(Style.FONT_STRIKE))
					Strikeout = source.Strikeout;
				if(source.Owner.IsSet(Style.FONT_OLINE))
					Overline = source.Overline;
				if(source.Owner.IsSet(Style.FONT_ULINE))
					Underline = source.Underline;
				if(source.Owner.IsSet(Style.FONT_SIZE) && source.Size != FontUnit.Empty)
					Size = source.Size;
			}
		}
		
		public void MergeWith(FontInfo with)
		{
			if(with!=null)
			{
				if(with.Owner.IsSet(Style.FONT_NAMES) && !infoOwner.IsSet(Style.FONT_NAMES))
					Names = with.Names;
				if(with.Owner.IsSet(Style.FONT_BOLD) && !infoOwner.IsSet(Style.FONT_BOLD))
					Bold = with.Bold;
				if(with.Owner.IsSet(Style.FONT_ITALIC) && !infoOwner.IsSet(Style.FONT_ITALIC))
					Italic = with.Italic;
				if(with.Owner.IsSet(Style.FONT_STRIKE) && !infoOwner.IsSet(Style.FONT_STRIKE))
					Strikeout = with.Strikeout;
				if(with.Owner.IsSet(Style.FONT_OLINE) && !infoOwner.IsSet(Style.FONT_OLINE))
					Overline = with.Overline;
				if(with.Owner.IsSet(Style.FONT_ULINE) && !infoOwner.IsSet(Style.FONT_ULINE))
					Underline = with.Underline;
				if(with.Owner.IsSet(Style.FONT_SIZE) && with.Size != FontUnit.Empty && !infoOwner.IsSet(Style.FONT_SIZE))
					Size = with.Size;
			}
		}
		
		public bool ShouldSerializeNames()
		{
			return (Names.Length > 0);
		}
		
		public override string ToString()
		{
			return ( (Name.Length > 0) ? (Name.ToString() + ", " + Size.ToString()) : Size.ToString() );
		}
	}
}
