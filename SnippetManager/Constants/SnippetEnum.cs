using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetManager.SnippetEnum
{
    /// <summary>
    /// 编程语言种类
    /// </summary>
    public enum Languge
    {
        [Description("None")]
        None = 0,
        [Description("C#")]
        CSharp = 1,
        [Description("VB.NET")]
        VB = 2
    }

}
