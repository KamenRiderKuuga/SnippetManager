namespace SnippetManager
{
    partial class FrmSnippetManager
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.objPanel = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.objDescription = new System.Windows.Forms.TextBox();
            this.LDescription = new System.Windows.Forms.Label();
            this.btnShortCut = new System.Windows.Forms.Label();
            this.objShortCut = new System.Windows.Forms.TextBox();
            this.ChkSurrounds = new System.Windows.Forms.CheckBox();
            this.ChkExpansion = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.objProgressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.objRichBox = new System.Windows.Forms.RichTextBox();
            this.objTreeView = new System.Windows.Forms.TreeView();
            this.objCBVer = new System.Windows.Forms.ComboBox();
            this.objCBLanguage = new System.Windows.Forms.ComboBox();
            this._objBGWorker = new System.ComponentModel.BackgroundWorker();
            this.objPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // objPanel
            // 
            this.objPanel.Controls.Add(this.btnSave);
            this.objPanel.Controls.Add(this.objDescription);
            this.objPanel.Controls.Add(this.LDescription);
            this.objPanel.Controls.Add(this.btnShortCut);
            this.objPanel.Controls.Add(this.objShortCut);
            this.objPanel.Controls.Add(this.ChkSurrounds);
            this.objPanel.Controls.Add(this.ChkExpansion);
            this.objPanel.Controls.Add(this.btnDelete);
            this.objPanel.Controls.Add(this.btnAdd);
            this.objPanel.Controls.Add(this.objProgressBar);
            this.objPanel.Controls.Add(this.label2);
            this.objPanel.Controls.Add(this.label1);
            this.objPanel.Controls.Add(this.btnSearch);
            this.objPanel.Controls.Add(this.objRichBox);
            this.objPanel.Controls.Add(this.objTreeView);
            this.objPanel.Controls.Add(this.objCBVer);
            this.objPanel.Controls.Add(this.objCBLanguage);
            this.objPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objPanel.Location = new System.Drawing.Point(0, 0);
            this.objPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.objPanel.Name = "objPanel";
            this.objPanel.Size = new System.Drawing.Size(699, 360);
            this.objPanel.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(133, 97);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(78, 20);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // objDescription
            // 
            this.objDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.objDescription.Location = new System.Drawing.Point(130, 238);
            this.objDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.objDescription.Multiline = true;
            this.objDescription.Name = "objDescription";
            this.objDescription.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.objDescription.Size = new System.Drawing.Size(81, 98);
            this.objDescription.TabIndex = 16;
            // 
            // LDescription
            // 
            this.LDescription.AutoSize = true;
            this.LDescription.Location = new System.Drawing.Point(130, 223);
            this.LDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LDescription.Name = "LDescription";
            this.LDescription.Size = new System.Drawing.Size(71, 12);
            this.LDescription.TabIndex = 15;
            this.LDescription.Text = "Description";
            // 
            // btnShortCut
            // 
            this.btnShortCut.AutoSize = true;
            this.btnShortCut.Location = new System.Drawing.Point(130, 178);
            this.btnShortCut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnShortCut.Name = "btnShortCut";
            this.btnShortCut.Size = new System.Drawing.Size(53, 12);
            this.btnShortCut.TabIndex = 14;
            this.btnShortCut.Text = "ShortCut";
            // 
            // objShortCut
            // 
            this.objShortCut.Location = new System.Drawing.Point(132, 193);
            this.objShortCut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.objShortCut.Name = "objShortCut";
            this.objShortCut.Size = new System.Drawing.Size(79, 21);
            this.objShortCut.TabIndex = 13;
            // 
            // ChkSurrounds
            // 
            this.ChkSurrounds.AutoSize = true;
            this.ChkSurrounds.Location = new System.Drawing.Point(132, 153);
            this.ChkSurrounds.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChkSurrounds.Name = "ChkSurrounds";
            this.ChkSurrounds.Size = new System.Drawing.Size(78, 16);
            this.ChkSurrounds.TabIndex = 12;
            this.ChkSurrounds.Text = "Surrounds";
            this.ChkSurrounds.UseVisualStyleBackColor = true;
            // 
            // ChkExpansion
            // 
            this.ChkExpansion.AutoSize = true;
            this.ChkExpansion.Location = new System.Drawing.Point(132, 133);
            this.ChkExpansion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChkExpansion.Name = "ChkExpansion";
            this.ChkExpansion.Size = new System.Drawing.Size(78, 16);
            this.ChkExpansion.TabIndex = 11;
            this.ChkExpansion.Text = "Expansion";
            this.ChkExpansion.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(132, 48);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(78, 20);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(132, 73);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(78, 20);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "新建Snippet";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // objProgressBar
            // 
            this.objProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objProgressBar.Location = new System.Drawing.Point(0, 339);
            this.objProgressBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.objProgressBar.Name = "objProgressBar";
            this.objProgressBar.Size = new System.Drawing.Size(699, 18);
            this.objProgressBar.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "编程语言";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "VS版本";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(456, 10);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 20);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "一键搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // objRichBox
            // 
            this.objRichBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objRichBox.Font = new System.Drawing.Font("Courier New", 10F);
            this.objRichBox.Location = new System.Drawing.Point(226, 48);
            this.objRichBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.objRichBox.Name = "objRichBox";
            this.objRichBox.Size = new System.Drawing.Size(447, 287);
            this.objRichBox.TabIndex = 3;
            this.objRichBox.Text = "";
            // 
            // objTreeView
            // 
            this.objTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.objTreeView.Location = new System.Drawing.Point(14, 48);
            this.objTreeView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.objTreeView.Name = "objTreeView";
            this.objTreeView.Size = new System.Drawing.Size(102, 287);
            this.objTreeView.TabIndex = 2;
            // 
            // objCBVer
            // 
            this.objCBVer.FormattingEnabled = true;
            this.objCBVer.Location = new System.Drawing.Point(62, 10);
            this.objCBVer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.objCBVer.Name = "objCBVer";
            this.objCBVer.Size = new System.Drawing.Size(183, 20);
            this.objCBVer.TabIndex = 1;
            // 
            // objCBLanguage
            // 
            this.objCBLanguage.FormattingEnabled = true;
            this.objCBLanguage.Items.AddRange(new object[] {
            "C#",
            "VB.NET"});
            this.objCBLanguage.Location = new System.Drawing.Point(345, 10);
            this.objCBLanguage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.objCBLanguage.Name = "objCBLanguage";
            this.objCBLanguage.Size = new System.Drawing.Size(92, 20);
            this.objCBLanguage.TabIndex = 0;
            // 
            // FrmSnippetManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 360);
            this.Controls.Add(this.objPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmSnippetManager";
            this.Text = "Snippet Manager";
            this.objPanel.ResumeLayout(false);
            this.objPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel objPanel;
        private System.Windows.Forms.TreeView objTreeView;
        private System.Windows.Forms.ComboBox objCBVer;
        private System.Windows.Forms.ComboBox objCBLanguage;
        private System.Windows.Forms.RichTextBox objRichBox;
        private System.Windows.Forms.ProgressBar objProgressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox ChkExpansion;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox objDescription;
        private System.Windows.Forms.Label LDescription;
        private System.Windows.Forms.Label btnShortCut;
        private System.Windows.Forms.TextBox objShortCut;
        private System.Windows.Forms.CheckBox ChkSurrounds;
        private System.Windows.Forms.Button btnSave;
    }
}

