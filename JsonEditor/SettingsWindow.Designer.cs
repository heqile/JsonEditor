
namespace JsonEditor
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.HotKeyBindingLabel = new System.Windows.Forms.Label();
            this.ModifierKeyBindingTextBox = new System.Windows.Forms.TextBox();
            this.MainKeyBindingTextBox = new System.Windows.Forms.TextBox();
            this.ShortcutBindingPlusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveButton.Location = new System.Drawing.Point(248, 86);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(91, 27);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CancelButton.Location = new System.Drawing.Point(360, 86);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(91, 27);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // HotKeyBindingLabel
            // 
            this.HotKeyBindingLabel.AutoSize = true;
            this.HotKeyBindingLabel.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HotKeyBindingLabel.Location = new System.Drawing.Point(25, 29);
            this.HotKeyBindingLabel.Name = "HotKeyBindingLabel";
            this.HotKeyBindingLabel.Size = new System.Drawing.Size(124, 21);
            this.HotKeyBindingLabel.TabIndex = 1;
            this.HotKeyBindingLabel.Text = "HotKey binding :";
            this.HotKeyBindingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModifierKeyBindingTextBox
            // 
            this.ModifierKeyBindingTextBox.Font = new System.Drawing.Font("Leelawadee UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ModifierKeyBindingTextBox.Location = new System.Drawing.Point(204, 29);
            this.ModifierKeyBindingTextBox.Name = "ModifierKeyBindingTextBox";
            this.ModifierKeyBindingTextBox.ReadOnly = true;
            this.ModifierKeyBindingTextBox.Size = new System.Drawing.Size(126, 25);
            this.ModifierKeyBindingTextBox.TabIndex = 2;
            this.ModifierKeyBindingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ModifierKeyBindingTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ModifierKeyBindingTextBox_KeyDown);
            // 
            // MainKeyBindingTextBox
            // 
            this.MainKeyBindingTextBox.Font = new System.Drawing.Font("Leelawadee UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainKeyBindingTextBox.Location = new System.Drawing.Point(381, 29);
            this.MainKeyBindingTextBox.Name = "MainKeyBindingTextBox";
            this.MainKeyBindingTextBox.ReadOnly = true;
            this.MainKeyBindingTextBox.Size = new System.Drawing.Size(79, 25);
            this.MainKeyBindingTextBox.TabIndex = 3;
            this.MainKeyBindingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MainKeyBindingTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainKeyBindingTextBox_KeyDown);
            // 
            // ShortcutBindingPlusLabel
            // 
            this.ShortcutBindingPlusLabel.AutoSize = true;
            this.ShortcutBindingPlusLabel.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShortcutBindingPlusLabel.Location = new System.Drawing.Point(344, 30);
            this.ShortcutBindingPlusLabel.Name = "ShortcutBindingPlusLabel";
            this.ShortcutBindingPlusLabel.Size = new System.Drawing.Size(21, 21);
            this.ShortcutBindingPlusLabel.TabIndex = 4;
            this.ShortcutBindingPlusLabel.Text = "+";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 131);
            this.Controls.Add(this.ShortcutBindingPlusLabel);
            this.Controls.Add(this.MainKeyBindingTextBox);
            this.Controls.Add(this.ModifierKeyBindingTextBox);
            this.Controls.Add(this.HotKeyBindingLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsWindow";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label HotKeyBindingLabel;
        private System.Windows.Forms.TextBox ModifierKeyBindingTextBox;
        private System.Windows.Forms.TextBox MainKeyBindingTextBox;
        private System.Windows.Forms.Label ShortcutBindingPlusLabel;
    }
}