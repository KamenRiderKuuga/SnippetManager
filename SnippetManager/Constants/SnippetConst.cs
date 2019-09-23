using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManager
{
    static class Constants
    {
        public const string Field_Ver2010 = "Visual Studio 2010";
        public const string Field_Ver2012 = "Visual Studio 2012";
        public const string Field_Ver2017 = "Visual Studio 2017";
        public const string Field_Ver2019 = "Visual Studio 2019";

        public const string Field_FolderKeyCS = @"Code Snippets\Visual C#\My Code Snippets";
        public const string Field_FolderKeyVB = @"Code Snippets\Visual Basic\My Code Snippets";

        //XML
        public const string Field_ConfigFileName = "Config.xml";
        public const string Field_SnippetManager = "SnippetManager";
        public const string Field_VSInfo = "VSInfo";
        public const string Field_Version = "Version";
        public const string Field_Path = "Path";
        public const string Field_Language = "Language";
        public const string Field_Value = "Value";

        //Snippet Detail
        public const string Field_CodeSnippets = "CodeSnippets";
        public const string Field_xmlns = "xmlns";
        public const string Field_nscontent = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet";
        public const string Field_Format = "Format";
        public const string Field_CodeSnippet = "CodeSnippet";
        public const string Field_Header = "Header";
        public const string Field_Snippet = "Snippet";
        public const string Field_Title = "Title";
        public const string Field_Shortcut = "Shortcut";
        public const string Field_Description = "Description";
        public const string Field_Code = "Code";
        public const string Field_Author = "Author";
        public const string Field_SnippetTypes = "SnippetTypes";
        public const string Field_Declarations = "Declarations";
        public const string Field_Literal = "Literal";
        public const string Field_ID = "ID";
        public const string Field_ToolTip = "ToolTip";
        public const string Field_Default = "Default";
        public const string Field_SnippetType = "SnippetType";
        public const string Field_Expansion = "Expansion";
        public const string Field_SurroundsWith = "SurroundsWith";
    }
}
