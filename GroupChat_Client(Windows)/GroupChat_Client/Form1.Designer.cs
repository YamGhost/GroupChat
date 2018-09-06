namespace GroupChat_Client {
    partial class Form1 {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FuncTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ChatContainer = new System.Windows.Forms.SplitContainer();
            this.GroupContainer = new System.Windows.Forms.SplitContainer();
            this.GroupFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FuncFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.NewGroup = new System.Windows.Forms.Button();
            this.DelGroup = new System.Windows.Forms.Button();
            this.LoginoutButton = new System.Windows.Forms.Button();
            this.ChatroomContainer = new System.Windows.Forms.SplitContainer();
            this.OutputLabel = new System.Windows.Forms.RichTextBox();
            this.InputContainer = new System.Windows.Forms.SplitContainer();
            this.InputTextBox = new System.Windows.Forms.RichTextBox();
            this.CheckFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SendButton = new System.Windows.Forms.Button();
            this.EmptyButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LoginIn = new System.Windows.Forms.Panel();
            this.LinkButton = new System.Windows.Forms.Button();
            this.IP_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fileButton = new System.Windows.Forms.Button();
            this.FuncTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChatContainer)).BeginInit();
            this.ChatContainer.Panel1.SuspendLayout();
            this.ChatContainer.Panel2.SuspendLayout();
            this.ChatContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GroupContainer)).BeginInit();
            this.GroupContainer.Panel1.SuspendLayout();
            this.GroupContainer.Panel2.SuspendLayout();
            this.GroupContainer.SuspendLayout();
            this.FuncFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChatroomContainer)).BeginInit();
            this.ChatroomContainer.Panel1.SuspendLayout();
            this.ChatroomContainer.Panel2.SuspendLayout();
            this.ChatroomContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputContainer)).BeginInit();
            this.InputContainer.Panel1.SuspendLayout();
            this.InputContainer.Panel2.SuspendLayout();
            this.InputContainer.SuspendLayout();
            this.CheckFlowPanel.SuspendLayout();
            this.LoginIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(534, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FuncTab
            // 
            this.FuncTab.Controls.Add(this.tabPage1);
            this.FuncTab.Controls.Add(this.tabPage2);
            this.FuncTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FuncTab.Location = new System.Drawing.Point(0, 24);
            this.FuncTab.Name = "FuncTab";
            this.FuncTab.SelectedIndex = 0;
            this.FuncTab.Size = new System.Drawing.Size(534, 487);
            this.FuncTab.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ChatContainer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(526, 461);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "GroupChat";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ChatContainer
            // 
            this.ChatContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChatContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatContainer.Location = new System.Drawing.Point(3, 3);
            this.ChatContainer.Name = "ChatContainer";
            // 
            // ChatContainer.Panel1
            // 
            this.ChatContainer.Panel1.Controls.Add(this.GroupContainer);
            // 
            // ChatContainer.Panel2
            // 
            this.ChatContainer.Panel2.Controls.Add(this.ChatroomContainer);
            this.ChatContainer.Size = new System.Drawing.Size(520, 455);
            this.ChatContainer.SplitterDistance = 100;
            this.ChatContainer.TabIndex = 0;
            // 
            // GroupContainer
            // 
            this.GroupContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GroupContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupContainer.Location = new System.Drawing.Point(0, 0);
            this.GroupContainer.Name = "GroupContainer";
            this.GroupContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // GroupContainer.Panel1
            // 
            this.GroupContainer.Panel1.Controls.Add(this.GroupFlowPanel);
            // 
            // GroupContainer.Panel2
            // 
            this.GroupContainer.Panel2.Controls.Add(this.FuncFlowPanel);
            this.GroupContainer.Size = new System.Drawing.Size(100, 455);
            this.GroupContainer.SplitterDistance = 389;
            this.GroupContainer.TabIndex = 0;
            // 
            // GroupFlowPanel
            // 
            this.GroupFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.GroupFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.GroupFlowPanel.Name = "GroupFlowPanel";
            this.GroupFlowPanel.Size = new System.Drawing.Size(98, 387);
            this.GroupFlowPanel.TabIndex = 0;
            // 
            // FuncFlowPanel
            // 
            this.FuncFlowPanel.Controls.Add(this.NewGroup);
            this.FuncFlowPanel.Controls.Add(this.DelGroup);
            this.FuncFlowPanel.Controls.Add(this.LoginoutButton);
            this.FuncFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FuncFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.FuncFlowPanel.Name = "FuncFlowPanel";
            this.FuncFlowPanel.Size = new System.Drawing.Size(98, 60);
            this.FuncFlowPanel.TabIndex = 0;
            // 
            // NewGroup
            // 
            this.NewGroup.Location = new System.Drawing.Point(3, 3);
            this.NewGroup.Name = "NewGroup";
            this.NewGroup.Size = new System.Drawing.Size(25, 25);
            this.NewGroup.TabIndex = 0;
            this.NewGroup.Text = "+";
            this.NewGroup.UseVisualStyleBackColor = true;
            // 
            // DelGroup
            // 
            this.DelGroup.Location = new System.Drawing.Point(34, 3);
            this.DelGroup.Name = "DelGroup";
            this.DelGroup.Size = new System.Drawing.Size(25, 25);
            this.DelGroup.TabIndex = 1;
            this.DelGroup.Text = "-";
            this.DelGroup.UseVisualStyleBackColor = true;
            // 
            // LoginoutButton
            // 
            this.LoginoutButton.Location = new System.Drawing.Point(3, 34);
            this.LoginoutButton.Name = "LoginoutButton";
            this.LoginoutButton.Size = new System.Drawing.Size(75, 23);
            this.LoginoutButton.TabIndex = 3;
            this.LoginoutButton.Text = "Loginout";
            this.LoginoutButton.UseVisualStyleBackColor = true;
            this.LoginoutButton.Click += new System.EventHandler(this.LoginoutButton_Click);
            // 
            // ChatroomContainer
            // 
            this.ChatroomContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChatroomContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChatroomContainer.Location = new System.Drawing.Point(0, 0);
            this.ChatroomContainer.Name = "ChatroomContainer";
            this.ChatroomContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // ChatroomContainer.Panel1
            // 
            this.ChatroomContainer.Panel1.Controls.Add(this.OutputLabel);
            // 
            // ChatroomContainer.Panel2
            // 
            this.ChatroomContainer.Panel2.Controls.Add(this.InputContainer);
            this.ChatroomContainer.Size = new System.Drawing.Size(416, 455);
            this.ChatroomContainer.SplitterDistance = 334;
            this.ChatroomContainer.TabIndex = 0;
            // 
            // OutputLabel
            // 
            this.OutputLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutputLabel.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.OutputLabel.Location = new System.Drawing.Point(0, 0);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.ReadOnly = true;
            this.OutputLabel.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.OutputLabel.Size = new System.Drawing.Size(414, 332);
            this.OutputLabel.TabIndex = 0;
            this.OutputLabel.Text = "";
            // 
            // InputContainer
            // 
            this.InputContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputContainer.Location = new System.Drawing.Point(0, 0);
            this.InputContainer.Name = "InputContainer";
            // 
            // InputContainer.Panel1
            // 
            this.InputContainer.Panel1.Controls.Add(this.InputTextBox);
            // 
            // InputContainer.Panel2
            // 
            this.InputContainer.Panel2.Controls.Add(this.CheckFlowPanel);
            this.InputContainer.Size = new System.Drawing.Size(414, 115);
            this.InputContainer.SplitterDistance = 320;
            this.InputContainer.TabIndex = 0;
            // 
            // InputTextBox
            // 
            this.InputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputTextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.InputTextBox.Location = new System.Drawing.Point(0, 0);
            this.InputTextBox.MaxLength = 255;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(320, 115);
            this.InputTextBox.TabIndex = 0;
            this.InputTextBox.Text = "";
            // 
            // CheckFlowPanel
            // 
            this.CheckFlowPanel.Controls.Add(this.SendButton);
            this.CheckFlowPanel.Controls.Add(this.EmptyButton);
            this.CheckFlowPanel.Controls.Add(this.fileButton);
            this.CheckFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.CheckFlowPanel.Name = "CheckFlowPanel";
            this.CheckFlowPanel.Size = new System.Drawing.Size(90, 115);
            this.CheckFlowPanel.TabIndex = 0;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(3, 3);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // EmptyButton
            // 
            this.EmptyButton.Location = new System.Drawing.Point(3, 32);
            this.EmptyButton.Name = "EmptyButton";
            this.EmptyButton.Size = new System.Drawing.Size(75, 23);
            this.EmptyButton.TabIndex = 1;
            this.EmptyButton.Text = "Empty";
            this.EmptyButton.UseVisualStyleBackColor = true;
            this.EmptyButton.Click += new System.EventHandler(this.EmptyButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(526, 461);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LoginIn
            // 
            this.LoginIn.Controls.Add(this.LinkButton);
            this.LoginIn.Controls.Add(this.IP_TextBox);
            this.LoginIn.Controls.Add(this.label1);
            this.LoginIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginIn.Location = new System.Drawing.Point(0, 0);
            this.LoginIn.Name = "LoginIn";
            this.LoginIn.Size = new System.Drawing.Size(534, 511);
            this.LoginIn.TabIndex = 1;
            // 
            // LinkButton
            // 
            this.LinkButton.Location = new System.Drawing.Point(394, 115);
            this.LinkButton.Name = "LinkButton";
            this.LinkButton.Size = new System.Drawing.Size(76, 36);
            this.LinkButton.TabIndex = 2;
            this.LinkButton.Text = "連線";
            this.LinkButton.UseVisualStyleBackColor = true;
            this.LinkButton.Click += new System.EventHandler(this.LinkButton_Click);
            // 
            // IP_TextBox
            // 
            this.IP_TextBox.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.IP_TextBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.IP_TextBox.Location = new System.Drawing.Point(209, 113);
            this.IP_TextBox.Name = "IP_TextBox";
            this.IP_TextBox.Size = new System.Drawing.Size(166, 40);
            this.IP_TextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(62, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP:";
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(3, 61);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(75, 23);
            this.fileButton.TabIndex = 1;
            this.fileButton.Text = "File";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 511);
            this.Controls.Add(this.FuncTab);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.LoginIn);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(550, 550);
            this.MinimumSize = new System.Drawing.Size(550, 550);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FuncTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ChatContainer.Panel1.ResumeLayout(false);
            this.ChatContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChatContainer)).EndInit();
            this.ChatContainer.ResumeLayout(false);
            this.GroupContainer.Panel1.ResumeLayout(false);
            this.GroupContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GroupContainer)).EndInit();
            this.GroupContainer.ResumeLayout(false);
            this.FuncFlowPanel.ResumeLayout(false);
            this.ChatroomContainer.Panel1.ResumeLayout(false);
            this.ChatroomContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChatroomContainer)).EndInit();
            this.ChatroomContainer.ResumeLayout(false);
            this.InputContainer.Panel1.ResumeLayout(false);
            this.InputContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InputContainer)).EndInit();
            this.InputContainer.ResumeLayout(false);
            this.CheckFlowPanel.ResumeLayout(false);
            this.LoginIn.ResumeLayout(false);
            this.LoginIn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl FuncTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer ChatContainer;
        private System.Windows.Forms.SplitContainer GroupContainer;
        private System.Windows.Forms.FlowLayoutPanel GroupFlowPanel;
        private System.Windows.Forms.FlowLayoutPanel FuncFlowPanel;
        private System.Windows.Forms.Button NewGroup;
        private System.Windows.Forms.Button DelGroup;
        private System.Windows.Forms.SplitContainer ChatroomContainer;
        private System.Windows.Forms.SplitContainer InputContainer;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel CheckFlowPanel;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button EmptyButton;
        private System.Windows.Forms.Panel LoginIn;
        private System.Windows.Forms.TextBox IP_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LinkButton;
        private System.Windows.Forms.Button LoginoutButton;
        private System.Windows.Forms.RichTextBox OutputLabel;
        private System.Windows.Forms.RichTextBox InputTextBox;
        private System.Windows.Forms.Button fileButton;
    }
}

