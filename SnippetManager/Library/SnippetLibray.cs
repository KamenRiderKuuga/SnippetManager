using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManager
{
    public static class Library
    {
        /// <summary>
        /// VS信息
        /// </summary>
        public class VSInfo
        {
            private string _strName;
            private string _strPath;
            private SnippetEnum.Languge _objLanguge;

            public VSInfo(string strVer, string strPath, SnippetEnum.Languge objLanguge)
            {
                this.Version = strVer;
                this.Path = strPath;
                this.Language = objLanguge;
            }

            //VS名称
            public string Version
            {
                get { return _strName; }
                set { _strName = value; }
            }

            //VS安装路径
            public string Path
            {
                get { return _strPath; }
                set { _strPath = value; }
            }

            //语言种类
            public SnippetEnum.Languge Language
            {
                get { return _objLanguge; }
                set { _objLanguge = value; }
            }

            //语言种类
            public string LanguageValue
            {
                get { return Utility.GetEnumDescription(this.Language); }
            }
        }

        /// <summary>
        /// Snippet信息
        /// </summary>
        public class SnippetInfo
        {
            private string _strSnippetName;
            private string _strVersion;
            private SnippetEnum.Languge _objLanguge;
            private string _strPath;
            private string _strShortcut;
            private string _strDescription;
            private string _strCode;
            private bool _bolExpansion;
            private bool _bolSurround;

            public SnippetInfo(string strFileName, string strVer, string strPath, SnippetEnum.Languge objLanguge)
            {
                this.FileName = strFileName;
                this.Version = strVer;
                this.Path = strPath;
                this.Language = objLanguge;
            }

            public void SetDetails(string strShortcut,string strDescription,string strCode)
            {
                this._strShortcut = strShortcut;
                this._strDescription = strDescription;
                this._strCode = strCode;
            }

            public string FileName
            {
                get { return _strSnippetName; }
                set { _strSnippetName = value; }
            }

            public string Version
            {
                get { return _strVersion; }
                set { _strVersion = value; }
            }

            //语言种类
            public SnippetEnum.Languge Language
            {
                get { return _objLanguge; }
                set { _objLanguge = value; }
            }

            //Snippet路径
            public string Path
            {
                get { return _strPath; }
                set { _strPath = value; }
            }

            public string Shortcut
            {
                get { return _strShortcut; }
            }

            public string Description
            {
                get { return _strDescription; }
            }

            public string Code
            {
                get { return _strCode; }
            }

            public bool IsExpansion
            {
                get { return _bolExpansion; }
                set { _bolExpansion = value; }
            }

            public bool IsSurrounds
            {
                get { return _bolSurround; }
                set { _bolSurround = value; }
            }

        }
    }
}
