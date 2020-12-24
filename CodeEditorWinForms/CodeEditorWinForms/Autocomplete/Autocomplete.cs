using FastColoredTextBoxNS;
using System.Collections.Generic;

namespace CodeEditorWinForms
{
	class Autocomplete
	{
		string[] keywords = { "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while", "add", "alias", "ascending", "descending", "dynamic", "from", "get", "global", "group", "into", "join", "let", "orderby", "partial", "remove", "select", "set", "value", "var", "where", "yield" };

		string[] methods = { "Equals()", "GetHashCode()", "GetType()", "ToString()" };

		string[] snippets = { "if(^)\n{\n;\n}", "if(^)\n{\n;\n}\nelse\n{\n;\n}", "for(^;;)\n{\n;\n}", "while(^)\n{\n;\n}", "do${\n^;\n}while();", "switch(^)\n{\ncase : break;\n}" };

		string[] declarationSnippets = {
			   "public class ^\n{\n}", "private class ^\n{\n}", "internal class ^\n{\n}",
			   "public struct ^\n{\n;\n}", "private struct ^\n{\n;\n}", "internal struct ^\n{\n;\n}",
			   "public void ^()\n{\n;\n}", "private void ^()\n{\n;\n}", "internal void ^()\n{\n;\n}", "protected void ^()\n{\n;\n}",
			   "public ^{ get; set; }", "private ^{ get; set; }", "internal ^{ get; set; }", "protected ^{ get; set; }"
			   };

		public void BuildAutocompleteMenu(AutocompleteMenu popupMenu)
		{
			List<AutocompleteItem> items = new List<AutocompleteItem>();

			foreach (var item in snippets)
				items.Add(new SnippetAutocompleteItem(item) { ImageIndex = 1 });
			foreach (var item in declarationSnippets)
				items.Add(new DeclarationSnippet(item) { ImageIndex = 0 });
			foreach (var item in methods)
				items.Add(new MethodAutocompleteItem(item) { ImageIndex = 2 });
			foreach (var item in keywords)
				items.Add(new AutocompleteItem(item));

			items.Add(new InsertSpaceSnippet());
			items.Add(new InsertSpaceSnippet(@"^(\w+)([=<>!:]+)(\w+)$"));
			items.Add(new InsertEnterSnippet());

			//set as autocomplete source
			popupMenu.Items.SetAutocompleteItems(items);
		}
	}
}
