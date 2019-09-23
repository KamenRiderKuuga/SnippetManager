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
            this.objPanel.Name = "objPanel";
            this.objPanel.Size = new System.Drawing.Size(932, 450);
            this.objPanel.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(176, 118);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // objDescription
            // 
            this.objDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.objDescription.Location = new System.Drawing.Point(173, 297);
            this.objDescription.Multiline = true;
            this.objDescription.Name = "objDescription";
            this.objDescription.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.objDescription.Size = new System.Drawing.Size(107, 121);
            this.objDescription.TabIndex = 16;
            // 
            // LDescription
            // 
            this.LDescription.AutoSize = true;
            this.LDescription.Location = new System.Drawing.Point(173, 279);
            this.LDescription.Name = "LDescription";
            this.LDescription.Size = new System.Drawing.Size(95, 15);
            this.LDescription.TabIndex = 15;
            this.LDescription.Text = "Description";
            // 
            // btnShortCut
            // 
            this.btnShortCut.AutoSize = true;
            this.btnShortCut.Location = new System.Drawing.Point(173, 223);
            this.btnShortCut.Name = "btnShortCut";
            this.btnShortCut.Size = new System.Drawing.Size(71, 15);
            this.btnShortCut.TabIndex = 14;
            this.btnShortCut.Text = "ShortCut";
            // 
            // objShortCut
            // 
            this.objShortCut.Location = new System.Drawing.Point(176, 241);
            this.objShortCut.Name = "objShortCut";
            this.objShortCut.Size = new System.Drawing.Size(104, 25);
            this.objShortCut.TabIndex = 13;
            // 
            // ChkSurrounds
            // 
            this.ChkSurrounds.AutoSize = true;
            this.ChkSurrounds.Location = new System.Drawing.Point(176, 191);
            this.ChkSurrounds.Name = "ChkSurrounds";
            this.ChkSurrounds.Size = new System.Drawing.Size(101, 19);
            this.ChkSurrounds.TabIndex = 12;
            this.ChkSurrounds.Text = "Surrounds";
            this.ChkSurrounds.UseVisualStyleBackColor = true;
            // 
            // ChkExpansion
            // 
            this.ChkExpansion.AutoSize = true;
            this.ChkExpansion.Location = new System.Drawing.Point(176, 166);
            this.ChkExpansion.Name = "ChkExpansion";
            this.ChkExpansion.Size = new System.Drawing.Size(101, 19);
            this.ChkExpansion.TabIndex = 11;
            this.ChkExpansion.Text = "Expansion";
            this.ChkExpansion.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(176, 60);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDelete.Size = new System.Drawing.Size(104, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(176, 89);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAdd.Size = new System.Drawing.Size(104, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "新建Snippet";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // objProgressBar
            // 
            this.objProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.objProgressBar.Location = new System.Drawing.Point(0, 424);
            this.objProgressBar.Name = "objProgressBar";
            this.objProgressBar.Size = new System.Drawing.Size(932, 23);
            this.objProgressBar.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "编程语言";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "VS版本";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(608, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 23);
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
            this.objRichBox.Location = new System.Drawing.Point(302, 60);
            this.objRichBox.Name = "objRichBox";
            this.objRichBox.Size = new System.Drawing.Size(595, 358);
            this.objRichBox.TabIndex = 3;
            this.objRichBox.Text = "";
            // 
            // objTreeView
            // 
            this.objTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.objTreeView.Location = new System.Drawing.Point(19, 60);
            this.objTreeView.Name = "objTreeView";
            this.objTreeView.Size = new System.Drawing.Size(135, 358);
            this.objTreeView.TabIndex = 2;
            // 
            // objCBVer
            // 
            this.objCBVer.FormattingEnabled = true;
            this.objCBVer.Location = new System.Drawing.Point(82, 12);
            this.objCBVer.Name = "objCBVer";
            this.objCBVer.Size = new System.Drawing.Size(243, 23);
            this.objCBVer.TabIndex = 1;
            // 
            // objCBLanguage
            // 
            this.objCBLanguage.FormattingEnabled = true;
            this.objCBLanguage.Items.AddRange(new object[] {
            "C#",
            "VB.NET"});
            this.objCBLanguage.Location = new System.Drawing.Point(460, 12);
            this.objCBLanguage.Name = "objCBLanguage";
            this.objCBLanguage.Size = new System.Drawing.Size(121, 23);
            this.objCBLanguage.TabIndex = 0;
            // 
            // FrmSnippetManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 450);
            this.Controls.Add(this.objPanel);
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

