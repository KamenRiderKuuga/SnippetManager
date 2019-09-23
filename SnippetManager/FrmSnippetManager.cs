using Microsoft.VisualBasic;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnippetManager
{
    public partial class FrmSnippetManager : Form
    {
        public FrmSnippetManager()
        {
            InitializeComponent();
            this.EventContorler();
        }

        private List<SnippetManager.Library.VSInfo> _objListVSInfo;
        private System.ComponentModel.BackgroundWorker _objBGWorker = new BackgroundWorker();
        private bool _bolEditing;

        #region Properties

        public bool IsEditing
        {
            get { return _bolEditing; }
            set { _bolEditing = value; }
        }

        public List<SnippetManager.Library.VSInfo> VSInfo
        {
            get { return _objListVSInfo; }
            set { _objListVSInfo = value; }
        }

        public string CBVerValue
        {
            get { return this.objCBVer.SelectedValue == null ? String.Empty : this.objCBVer.SelectedValue.ToString(); }
        }

        public string CBLangugeValue
        {
            get { return this.objCBLanguage.SelectedValue == null ? String.Empty : this.objCBLanguage.SelectedValue.ToString(); }
        }

        #endregion

        #region 初始化

        /// <summary>
        /// 为窗体添加事件
        /// </summary>
        private void EventContorler()
        {
            this.Load += this.Form_Load;
            this.btnSearch.Click += this.Button_Click;
            this.btnDelete.Click += this.Button_Click;
            this.btnAdd.Click += this.Button_Click;
            this.btnSave.Click += this.Button_Click;
            this._objBGWorker.DoWork += this.BGWorker_Start;
            this._objBGWorker.ProgressChanged += this.BGWorker_Notify;
            this._objBGWorker.RunWorkerCompleted += this.BGWorker_Completed;
            this.objCBVer.SelectedIndexChanged += this.ComboBox_SelectedIndexChanged;
            this.objCBLanguage.SelectedIndexChanged += this.ComboBox_SelectedIndexChanged;
            this.objTreeView.AfterSelect += this.TreeView_AfterSelect;
            this.ChkExpansion.CheckedChanged += this.CheckBox_CheckedChanged;
            this.ChkSurrounds.CheckedChanged += this.CheckBox_CheckedChanged;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            //初始化控件相关属性
            this.InitControls();
        }

        private void InitControls()
        {
            //隐藏进度条
            this.objProgressBar.Visible = false;
            //设置进度条
            this.objProgressBar.Minimum = 0;
            this.objProgressBar.Maximum = 100;

            //设置ComboBox样式为只能选取
            this.objCBVer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.objCBLanguage.DropDownStyle = ComboBoxStyle.DropDownList;

            //初始化语言信息
            this.VSInfo = new List<Library.VSInfo>();
            SnippetManager.Utility.GetConfigInfo(Application.StartupPath, this.VSInfo);
            //填充界面上的两个Combox
            this.FillComboBox();
            this.IsEditing = false;
            this._objBGWorker.WorkerReportsProgress = true;
        }

        #endregion

        #region Event

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox objChkTemp = (CheckBox)sender;

            if (objChkTemp.Checked)
            {
                objChkTemp.BackColor = Color.LightBlue;
            }
            else
            {
                objChkTemp.BackColor = Color.Red;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case nameof(this.btnSearch):
                    if (_objBGWorker.IsBusy == true)
                    {
                        return;
                    }
                    if (MessageBox.Show("即将开始搜索Snippet目录，是否继续？", "提示语", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }

                    this.objProgressBar.Visible = true;
                    this.VSInfo.Clear();
                    this._objBGWorker.RunWorkerAsync();

                    break;

                case nameof(this.btnDelete):

                    if (this.objTreeView.SelectedNode != null)
                    {
                        var objSnippetInfo = (Library.SnippetInfo)this.objTreeView.SelectedNode.Tag;
                        if (System.IO.File.Exists(objSnippetInfo.Path))
                        {
                            if (MessageBox.Show("确认删除所选文件吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                System.IO.File.Delete(objSnippetInfo.Path);
                                this.objTreeView.Nodes.Remove(this.objTreeView.SelectedNode);
                                if (this.objTreeView.Nodes.Count == 0)
                                {
                                    this.ResetControls(true);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("请先选中一个文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                case nameof(this.btnAdd):
                    if (this.IsEditing == false)
                    {
                        this.IsEditing = true;
                        this.ResetControls(false);
                    }
                    break;

                case nameof(this.btnSave):
                    if (this.IsEditing == true)
                    {
                        DialogResult objDialogResult;

                        objDialogResult = MessageBox.Show("是否保存为新文件?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        switch (objDialogResult)
                        {
                            case DialogResult.Yes:
                                this.SaveSnippet();
                                break;

                            case DialogResult.No:
                                this.IsEditing = false;
                                this.ComboBox_SelectedIndexChanged(null, null);
                                break;

                            default:
                                break;
                        }
                    }
                    break;

                default:
                    break;
            }

        }

        private void SaveSnippet()
        {
            if (this.ValidateControls() == false)
            {
                return;
            }
            string strFileName;
            String strInput = this.GetValidedFileName(out strFileName);

            if (strInput != String.Empty)
            {
                bool bolReulst = Utility.SaveSnippetToFile(this.ChkExpansion.Checked, this.ChkSurrounds.Checked,
                                          this.objShortCut.Text.Trim(), this.objRichBox.Text.Trim(),
                                          this.objDescription.Text.Trim(), strInput, strFileName,
                                          this.CBLangugeValue == Utility.GetEnumDescription(SnippetEnum.Languge.CSharp));

                if (bolReulst)
                {
                    this.IsEditing = false;
                    List<Library.SnippetInfo> objListSnippetInfo = Utility.GetSnippets(this.CBVerValue, this.CBLangugeValue, this.VSInfo);

                    if (objListSnippetInfo != null)
                    {
                        this.SetTreeSource(this.objTreeView, objListSnippetInfo, strFileName);
                    }
                }

            }
        }

        private bool ValidateControls()
        {
            bool bolResult = true;

            if (this.objShortCut.Text.Trim() == String.Empty)
            {
                MessageBox.Show("ShortCut为空,无法保存!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bolResult = false;
            }

            if (this.objRichBox.Text.Trim() == String.Empty)
            {
                MessageBox.Show("代码内容为空,无法保存!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bolResult = false;
            }

            return bolResult;
        }

        private string GetValidedFileName(out string strInput)
        {
            strInput = Interaction.InputBox("请输入新文件名称", "文件名设置", "");

            string strTarget = "";

            if (strInput.Trim() != String.Empty && strInput.Trim() != ".snippet")
            {
                if (strInput.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
                {
                    //含有非法字符 \ / : * ? " < > | 等
                    MessageBox.Show("文件名称含有非法字符，请重新输入", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return GetValidedFileName(out strInput);
                }

                string strVSPath = (from vsinfo in this.VSInfo
                                    where vsinfo.Version == this.CBVerValue && vsinfo.LanguageValue == CBLangugeValue
                                    select vsinfo.Path).FirstOrDefault();

                if (strVSPath != String.Empty)
                {
                    strTarget = System.IO.Path.Combine(strVSPath, strInput.Replace(".snippet", String.Empty)) + ".snippet";
                    if (System.IO.File.Exists(strTarget))
                    {
                        MessageBox.Show("文件名已存在,请重新输入!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return GetValidedFileName(out strInput);
                    }
                    else
                    {
                        return strTarget;
                    }

                }

            }

            return strTarget.Trim().Replace(".snippet", String.Empty);
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.IsEditing)
            {
                return;
            }

            this.ResetControls(true);

            if (this.CBVerValue != String.Empty &&
                this.CBLangugeValue != String.Empty)
            {
                List<Library.SnippetInfo> objListSnippetInfo = Utility.GetSnippets(this.CBVerValue, this.CBLangugeValue, this.VSInfo);
                if (objListSnippetInfo != null)
                {
                    this.SetTreeSource(this.objTreeView, objListSnippetInfo);
                }
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.IsEditing)
            {
                return;
            }
            this.ResetControls(true);
            var objSnippetInfo = (Library.SnippetInfo)e.Node.Tag;
            this.objRichBox.Text = Utility.GetSnippetDetail(objSnippetInfo);
            this.objShortCut.Text = objSnippetInfo.Shortcut;
            this.objDescription.Text = objSnippetInfo.Description;
            this.ChkExpansion.Checked = objSnippetInfo.IsExpansion;
            this.ChkSurrounds.Checked = objSnippetInfo.IsSurrounds;
        }

        #region  BGWorkerEvent

        private void BGWorker_Notify(object sender, ProgressChangedEventArgs e)
        {
            this.objProgressBar.Value = e.ProgressPercentage;
        }

        private void BGWorker_Start(object sender, DoWorkEventArgs e)
        {
            this.StartSearch();
        }

        private void BGWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            this.objProgressBar.Visible = false;
            if (this.VSInfo != null && this.VSInfo.Count > 0)
            {
                if (MessageBox.Show("已搜索到目录，是否保存设置？", "搜索成功", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //填充界面上的两个Combox
                    this.FillComboBox();
                    //保存设置
                    SnippetManager.Utility.SetConfigInfo(Application.StartupPath, this.VSInfo);
                }
            }
        }

        #endregion

        #endregion

        #region Private Method

        private void FillComboBox()
        {
            if (this.VSInfo != null && this.VSInfo.Count != 0)
            {
                this.objCBLanguage.DataSource = (from obj in this.VSInfo
                                                 let languge = Utility.GetEnumDescription(obj.Language)
                                                 orderby languge
                                                 select languge).Distinct().ToList();

                this.objCBVer.DataSource = (from obj in this.VSInfo
                                            orderby obj.Version descending
                                            select obj.Version).Distinct().ToList();
            }
        }

        private void StartSearch()
        {
            int intCount = 0;
            //获得C盘中的所有文件夹数量，作为进度条
            string[] strDirectories = System.IO.Directory.GetDirectories(@"C:\");
            intCount = strDirectories.Length;

            for (int intTemp = 0; intTemp < intCount; intTemp++)
            {
                SnippetManager.Utility.GetVSInfo(strDirectories[intTemp], this.VSInfo);
                this._objBGWorker.ReportProgress((int)((decimal)intTemp / (decimal)intCount * 100) + 1);
            }
        }

        private void SetTreeSource(TreeView objTreeView, List<Library.SnippetInfo> objListSnippetInfo, string strNodeName = "")
        {
            objTreeView.Nodes.Clear();
            TreeNode objTreeNodTemp = null;

            foreach (var objSnippetInfo in objListSnippetInfo)
            {
                var objTreeNod = new TreeNode();
                objTreeNod.Name = objSnippetInfo.FileName;
                objTreeNod.Tag = objSnippetInfo;
                objTreeNod.Text = objSnippetInfo.FileName.Replace(".snippet", String.Empty);
                objTreeNodTemp = objTreeNod.Text == strNodeName ? objTreeNod : null;
                objTreeView.Nodes.Add(objTreeNod);
            }

            if (objTreeView.Nodes.Count == 0)
            {
                this.objRichBox.Text = String.Empty;
            }
            else
            {
                objTreeView.SelectedNode = objTreeNodTemp == null ?
                                           objTreeView.Nodes[0] :
                                           objTreeNodTemp;
            }
        }

        private void ResetControls(bool bolReadOnly)
        {
            if (bolReadOnly)
            {
                this.ChkExpansion.Enabled = false;
                this.ChkExpansion.Checked = false;
                this.ChkSurrounds.Enabled = false;
                this.ChkSurrounds.Checked = false;
                this.objShortCut.ReadOnly = true;
                this.objShortCut.Text = String.Empty;
                this.objDescription.ReadOnly = bolReadOnly;
                this.objDescription.Text = String.Empty;
                this.objRichBox.ReadOnly = bolReadOnly;
                this.objRichBox.Text = String.Empty;
                this.objCBLanguage.Enabled = true;
                this.objCBVer.Enabled = true;
            }
            else
            {
                this.ChkExpansion.Enabled = true;
                this.ChkExpansion.Checked = false;
                this.ChkSurrounds.Enabled = true;
                this.ChkSurrounds.Checked = false;
                this.objShortCut.ReadOnly = false;
                this.objShortCut.Text = String.Empty;
                this.objDescription.ReadOnly = bolReadOnly;
                this.objDescription.Text = String.Empty;
                this.objRichBox.ReadOnly = bolReadOnly;
                this.objRichBox.Text = String.Empty;
                this.objCBLanguage.Enabled = false;
                this.objCBVer.Enabled = false;
            }
        }

        #endregion

    }
}
