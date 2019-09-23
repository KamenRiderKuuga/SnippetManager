using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnippetManager
{
    public static class Utility
    {

        #region VS信息相关操作

        /// <summary>
        /// 获取电脑中可用的VS软件的相关信息
        /// </summary>
        /// <returns></returns>
        public static void GetVSInfo(string strFolderPath, List<Library.VSInfo> objListVSInfo)
        {
            try
            {
                if (strFolderPath.Contains(@"C:\Windows"))
                {
                    return;
                }

                foreach (var strFolder in System.IO.Directory.GetDirectories(strFolderPath))
                {
                    if (strFolder.EndsWith(SnippetManager.Constants.Field_FolderKeyCS) ||
                        strFolder.EndsWith(SnippetManager.Constants.Field_FolderKeyVB))
                    {
                        AddVSInfoToList(strFolder, objListVSInfo);
                    }

                    GetVSInfo(strFolder, objListVSInfo);
                }
            }
            catch
            {

            }
        }

        private static void AddVSInfoToList(string strFolder, List<Library.VSInfo> objListVSInfo)
        {
            string strTemp = "";
            System.IO.DirectoryInfo objDirectoryInfo = null;
            if (strFolder.EndsWith(SnippetManager.Constants.Field_FolderKeyCS))
            {
                strTemp = strFolder.Replace(SnippetManager.Constants.Field_FolderKeyCS, "");
                if (System.IO.Directory.Exists(strTemp))
                {
                    objDirectoryInfo = new System.IO.DirectoryInfo(strTemp);
                    objListVSInfo.Add(new Library.VSInfo(objDirectoryInfo.Name, strFolder, SnippetEnum.Languge.CSharp));
                }
            }

            if (strFolder.EndsWith(SnippetManager.Constants.Field_FolderKeyVB))
            {
                strTemp = strFolder.Replace(SnippetManager.Constants.Field_FolderKeyVB, "");
                if (System.IO.Directory.Exists(strTemp))
                {
                    objDirectoryInfo = new System.IO.DirectoryInfo(strTemp);
                    objListVSInfo.Add(new Library.VSInfo(objDirectoryInfo.Name, strFolder, SnippetEnum.Languge.VB));
                }
            }

        }

        public static void SetConfigInfo(string strStartupPath, List<Library.VSInfo> objVSInfo)
        {
            string strConfigFilePath = System.IO.Path.Combine(strStartupPath, Constants.Field_ConfigFileName);
            XDocument objXMLConfig = null;

            if (System.IO.File.Exists(strConfigFilePath))
            {
                objXMLConfig = new XDocument(new XElement(Constants.Field_SnippetManager));
                XElement objXMLElement = objXMLConfig.Root;
                XElement objXMLElementTemp = null;
                foreach (var vsinfo in objVSInfo)
                {
                    objXMLElementTemp = new XElement(Constants.Field_VSInfo,
                                        new XAttribute(Constants.Field_Version, vsinfo.Version),
                                        new XAttribute(Constants.Field_Path, vsinfo.Path),
                                        new XAttribute(Constants.Field_Language, vsinfo.Language));

                    objXMLElement.Add(objXMLElementTemp);
                }

                objXMLConfig.Save(strConfigFilePath);
            }
        }

        public static void GetConfigInfo(string strStartupPath, List<Library.VSInfo> objVSInfo)
        {
            string strConfigFilePath = System.IO.Path.Combine(strStartupPath, Constants.Field_ConfigFileName);
            XDocument objXMLConfig = null;

            if (System.IO.File.Exists(strConfigFilePath))
            {
                objXMLConfig = XDocument.Load(strConfigFilePath);

                try
                {
                    var objVSInfoList = (from obje in objXMLConfig.Root.Elements()
                                         select new
                                         {
                                             version = obje.Attribute(Constants.Field_Version).Value,
                                             path = obje.Attribute(Constants.Field_Path).Value,
                                             language = obje.Attribute(Constants.Field_Language).Value
                                         }).ToList();

                    if (objVSInfoList != null)
                    {
                        foreach (var objVSInfoTemp in objVSInfoList)
                        {
                            objVSInfo.Add(new Library.VSInfo(objVSInfoTemp.version, objVSInfoTemp.path,
                                         (SnippetEnum.Languge)Enum.Parse(typeof(SnippetEnum.Languge), objVSInfoTemp.language)));
                        }

                    }
                }
                catch
                {

                }

            }
            else
            {
                objXMLConfig = new XDocument(new XElement(Constants.Field_SnippetManager));
                objXMLConfig.Save(strConfigFilePath);
            }
        }


        #endregion

        #region Snippet信息相关操作

        public static string GetSnippetDetail(Library.SnippetInfo objNodeTag)
        {
            XDocument objXMLSnippet = null;
            objXMLSnippet = XDocument.Load(objNodeTag.Path);
            //Get Short Cut and Description
            var objRootElements = objXMLSnippet.Descendants();

            //Detail
            string strShortcut = "";
            string strDescription = "";
            string strCode = "";
            bool bolIsExpansion = false;
            bool bolIsSurrounds = false;

            foreach (XElement objXMLElementTemp in objRootElements)
            {
                if (objXMLElementTemp.Name.LocalName == Constants.Field_Shortcut)
                {
                    strShortcut = objXMLElementTemp.Value;
                }
                if (objXMLElementTemp.Name.LocalName == Constants.Field_Description)
                {
                    strDescription = objXMLElementTemp.Value;
                }
                if (objXMLElementTemp.Name.LocalName == Constants.Field_Code)
                {
                    strCode = objXMLElementTemp.Value;
                }
                if (objXMLElementTemp.Name.LocalName == Constants.Field_SnippetType &&
                    objXMLElementTemp.Value == Constants.Field_Expansion)
                {
                    bolIsExpansion = true;
                }
                if (objXMLElementTemp.Name.LocalName == Constants.Field_SnippetType &&
                    objXMLElementTemp.Value == Constants.Field_SurroundsWith)
                {
                    bolIsSurrounds = true;
                }
            }

            objNodeTag.SetDetails(strShortcut, strDescription, strCode);
            objNodeTag.IsExpansion = bolIsExpansion;
            objNodeTag.IsSurrounds = bolIsSurrounds;

            return objNodeTag.Code;
        }

        public static bool SaveSnippetToFile(bool bolExpansion, bool bolSurrounds, string strShortCut, string strCode, string strDescription, string strInput, string strFileName, bool bolIsCSharp)
        {
            try
            {
                XNamespace objXNamespace = @Constants.Field_nscontent;
                var objSnippetXmlDoc = new XDocument(new XElement(objXNamespace + Constants.Field_CodeSnippets));
                //创建最外层
                objSnippetXmlDoc.Root.Add(new XElement(Constants.Field_CodeSnippet,
                                          new XAttribute(Constants.Field_Format, "1.0.0")));

                //添加Header和Snippet
                objSnippetXmlDoc.Root.Element(Constants.Field_CodeSnippet).Add(new XElement(Constants.Field_Header),
                                                                               new XElement(Constants.Field_Snippet));

                //获取Header层
                var objXHeader = objSnippetXmlDoc.Root.Element(Constants.Field_CodeSnippet)
                                                      .Element(Constants.Field_Header);

                objXHeader.Add(new XElement(Constants.Field_Title, strFileName),
                               new XElement(Constants.Field_Shortcut, strShortCut),
                               new XElement(Constants.Field_Description, strDescription),
                               new XElement(Constants.Field_Author, System.Environment.UserName));

                if (bolExpansion == true || bolSurrounds == true)
                {
                    objXHeader.Add(new XElement(Constants.Field_SnippetTypes));
                    var objXSnippetTypes = objXHeader.Element(Constants.Field_SnippetTypes);
                    if (bolExpansion)
                    {
                        objXSnippetTypes.Add(new XElement(Constants.Field_SnippetType, Constants.Field_Expansion));
                    }
                    if (bolSurrounds)
                    {
                        objXSnippetTypes.Add(new XElement(Constants.Field_SnippetType, Constants.Field_SurroundsWith));
                    }
                }

                //获取Snippet层
                var objXSnippet = objSnippetXmlDoc.Root.Element(Constants.Field_CodeSnippet)
                                                       .Element(Constants.Field_Snippet);

                List<string> objListDeclarations = GetDeclarationsByRegex(strCode);

                if (objListDeclarations != null && objListDeclarations.Count > 0)
                {
                    objXSnippet.Add(new XElement(Constants.Field_Declarations));
                    foreach (var strDeclarations in objListDeclarations)
                    {
                        objXSnippet.Element(Constants.Field_Declarations)
                                    .Add(new XElement(Constants.Field_Literal,
                                         new XElement(Constants.Field_ID, strDeclarations),
                                         new XElement(Constants.Field_ToolTip, strDeclarations),
                                         new XElement(Constants.Field_Default, strDeclarations)));
                    }
                }


                objXSnippet.Add(new XElement(Constants.Field_Code,
                                new XAttribute(Constants.Field_Language, bolIsCSharp ? "csharp" : "VB")));

                objXSnippet.Element(Constants.Field_Code).ReplaceNodes(new XCData(strCode));

                foreach (var node in objSnippetXmlDoc.Root.Descendants()
                                                     .Where(n => n.Name.NamespaceName == String.Empty))
                {
                    // Remove the xmlns='' attribute. Note the use of
                    // Attributes rather than Attribute, in case the
                    // attribute doesn't exist (which it might not if we'd
                    // created the document "manually" instead of loading
                    // it from a file.)
                    node.Attributes(Constants.Field_xmlns).Remove();
                    // Inherit the parent namespace instead
                    node.Name = node.Parent.Name.Namespace + node.Name.LocalName;
                }

                objSnippetXmlDoc.Save(strInput);

                return true;
            }
            catch
            {

                return false;
            }

        }

        public static List<Library.SnippetInfo> GetSnippets(string strCBVerValue, string strCBLanguageValue, List<Library.VSInfo> objVSInfo)
        {
            var objVSInfoDetails = (from vsinfo in objVSInfo
                                    where vsinfo.Version == strCBVerValue && vsinfo.LanguageValue == strCBLanguageValue
                                    select vsinfo).FirstOrDefault();

            if (objVSInfoDetails != null && System.IO.Directory.Exists(objVSInfoDetails.Path))
            {
                return (from strFilePath in System.IO.Directory.GetFiles(objVSInfoDetails.Path)
                        let fileinfo = new System.IO.FileInfo(strFilePath)
                        where strFilePath.EndsWith(".snippet")
                        let snippetinfo = new Library.SnippetInfo(fileinfo.Name, strCBVerValue, strFilePath, objVSInfoDetails.Language)
                        select snippetinfo).ToList();
            }
            else
            {
                return null;
            }

        }

        #endregion

        #region 一些日常方法

        private static List<string> GetDeclarationsByRegex(string strCode)
        {
            List<string> objListResult = new List<string>();
            Regex objRegex = new Regex(@"\$([^\s\$]+)\$");
            var objMatches = objRegex.Matches(strCode);
            if (objMatches != null)
            {
                foreach (Match objMatch in objMatches)
                {
                    objListResult.Add(objMatch.Groups[1].Value);
                }
            }
            return objListResult;
        }

        public static string GetEnumDescription(Enum objEnum)
        {
            Type objType = objEnum.GetType();
            FieldInfo objFieldInfo = objType.GetField(objEnum.ToString());
            DescriptionAttribute[] objDescriptions = null;
            if (objFieldInfo != null)
            {
                objDescriptions = (DescriptionAttribute[])objFieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            }

            if (objDescriptions != null)
            {
                return objDescriptions[0].Description;
            }

            return String.Empty;

        }

        #endregion
    }
}
