using System.Collections.Generic;
using FastColoredTextBoxNS;

namespace CodeEditorWinForms
{
	class Languages
	{
		public static Dictionary<string, Language> languages =
				new Dictionary<string, Language>
				{
					{"C#", Language.CSharp},
					{"VB", Language.VB},
					{"HTML", Language.HTML},
					{"XML", Language.XML},
					{"JS", Language.JS},
					{"PHP", Language.PHP},
					{"LUA", Language.Lua},
					{"SQL", Language.SQL},
				};
	}
}
