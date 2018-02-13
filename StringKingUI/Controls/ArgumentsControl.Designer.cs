namespace StringKingUI
{
    partial class ArgumentsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelArgument = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelArgument
            // 
            this.flowLayoutPanelArgument.AutoScroll = true;
            this.flowLayoutPanelArgument.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanelArgument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelArgument.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelArgument.Name = "flowLayoutPanelArgument";
            this.flowLayoutPanelArgument.Size = new System.Drawing.Size(353, 188);
            this.flowLayoutPanelArgument.TabIndex = 5;
            // 
            // ArgumentsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.flowLayoutPanelArgument);
            this.Name = "ArgumentsControl";
            this.Size = new System.Drawing.Size(353, 188);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelArgument;
    }
}
