namespace Lab4_MIP
{
    partial class KeywordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_keyword = new System.Windows.Forms.Label();
            this.keyword_textbox = new System.Windows.Forms.TextBox();
            this.ok_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_keyword
            // 
            this.label_keyword.AutoSize = true;
            this.label_keyword.Location = new System.Drawing.Point(327, 157);
            this.label_keyword.Name = "label_keyword";
            this.label_keyword.Size = new System.Drawing.Size(59, 16);
            this.label_keyword.TabIndex = 0;
            this.label_keyword.Text = "Keyword";
            this.label_keyword.Click += new System.EventHandler(this.label_keyword_Click);
            // 
            // keyword_textbox
            // 
            this.keyword_textbox.Location = new System.Drawing.Point(169, 176);
            this.keyword_textbox.Name = "keyword_textbox";
            this.keyword_textbox.Size = new System.Drawing.Size(364, 22);
            this.keyword_textbox.TabIndex = 1;
            // 
            // ok_btn
            // 
            this.ok_btn.Location = new System.Drawing.Point(479, 224);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(118, 62);
            this.ok_btn.TabIndex = 2;
            this.ok_btn.Text = "Ok";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(87, 234);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(118, 68);
            this.cancel_btn.TabIndex = 3;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            // 
            // KeywordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 356);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.keyword_textbox);
            this.Controls.Add(this.label_keyword);
            this.Name = "KeywordForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.KeywordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_keyword;
        private System.Windows.Forms.TextBox keyword_textbox;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.Button cancel_btn;
    }
}