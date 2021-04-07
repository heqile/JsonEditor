
namespace JsonEditor
{
    partial class Editor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.TextComponent = new System.Windows.Forms.RichTextBox();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.JsonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CompactJsonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IndentedJsonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Notifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextComponent
            // 
            this.TextComponent.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextComponent.Location = new System.Drawing.Point(1, 33);
            this.TextComponent.Margin = new System.Windows.Forms.Padding(4);
            this.TextComponent.Name = "TextComponent";
            this.TextComponent.Size = new System.Drawing.Size(1024, 491);
            this.TextComponent.TabIndex = 0;
            this.TextComponent.Text = "";
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuItem,
            this.JsonMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.Menu.Size = new System.Drawing.Size(1029, 28);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "menuStrip1";
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit});
            this.FileMenuItem.Name = "FileMenuItem";
            this.FileMenuItem.Size = new System.Drawing.Size(48, 24);
            this.FileMenuItem.Text = "File";
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(118, 26);
            this.Exit.Text = "Exit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // JsonMenuItem
            // 
            this.JsonMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CompactJsonMenuItem,
            this.IndentedJsonMenuItem});
            this.JsonMenuItem.Name = "JsonMenuItem";
            this.JsonMenuItem.Size = new System.Drawing.Size(55, 24);
            this.JsonMenuItem.Text = "Json";
            // 
            // CompactJsonMenuItem
            // 
            this.CompactJsonMenuItem.Name = "CompactJsonMenuItem";
            this.CompactJsonMenuItem.Size = new System.Drawing.Size(190, 26);
            this.CompactJsonMenuItem.Text = "CompactJson";
            this.CompactJsonMenuItem.Click += new System.EventHandler(this.CompactJsonMenuItem_Click);
            // 
            // IndentedJsonMenuItem
            // 
            this.IndentedJsonMenuItem.Name = "IndentedJsonMenuItem";
            this.IndentedJsonMenuItem.Size = new System.Drawing.Size(190, 26);
            this.IndentedJsonMenuItem.Text = "IndentedJson";
            this.IndentedJsonMenuItem.Click += new System.EventHandler(this.IndentedJsonMenuItem_Click);
            // 
            // Notifier
            // 
            this.Notifier.Icon = ((System.Drawing.Icon)(resources.GetObject("Notifier.Icon")));
            this.Notifier.Text = "JsonEditor";
            this.Notifier.Visible = true;
            this.Notifier.DoubleClick += new System.EventHandler(this.Notifier_DoubleClick);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 529);
            this.Controls.Add(this.TextComponent);
            this.Controls.Add(this.Menu);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Editor";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Editor_Load);
            this.Resize += new System.EventHandler(this.Editor_Resize);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextComponent;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem JsonMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CompactJsonMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IndentedJsonMenuItem;
        private System.Windows.Forms.NotifyIcon Notifier;
    }
}

