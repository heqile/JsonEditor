
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.HotKeyBindingLabel = new System.Windows.Forms.Label();
            this.ModifierKeyBindingTextBox = new System.Windows.Forms.TextBox();
            this.MainKeyBindingTextBox = new System.Windows.Forms.TextBox();
            this.HotKeyBindingPlusLabel = new System.Windows.Forms.Label();
            this.TimeWaitingMs = new System.Windows.Forms.TextBox();
            this.TimeWaitingLabel = new System.Windows.Forms.Label();
            this.EnableCompactConversionLabel = new System.Windows.Forms.Label();
            this.CompactConversionEnabled = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.DisplaySuccessNotificationEnabled = new System.Windows.Forms.CheckBox();
            this.DisplaySuccessNotificationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveButton.Location = new System.Drawing.Point(248, 199);
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
            this.CancelButton.Location = new System.Drawing.Point(360, 199);
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
            // HotKeyBindingPlusLabel
            // 
            this.HotKeyBindingPlusLabel.AutoSize = true;
            this.HotKeyBindingPlusLabel.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HotKeyBindingPlusLabel.Location = new System.Drawing.Point(344, 30);
            this.HotKeyBindingPlusLabel.Name = "HotKeyBindingPlusLabel";
            this.HotKeyBindingPlusLabel.Size = new System.Drawing.Size(21, 21);
            this.HotKeyBindingPlusLabel.TabIndex = 4;
            this.HotKeyBindingPlusLabel.Text = "+";
            // 
            // TimeWaitingMs
            // 
            this.TimeWaitingMs.Font = new System.Drawing.Font("Leelawadee UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimeWaitingMs.Location = new System.Drawing.Point(360, 71);
            this.TimeWaitingMs.Name = "TimeWaitingMs";
            this.TimeWaitingMs.Size = new System.Drawing.Size(94, 25);
            this.TimeWaitingMs.TabIndex = 6;
            this.TimeWaitingMs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TimeWaitingMs.TextChanged += new System.EventHandler(this.TimeWaitingMs_TextChanged);
            // 
            // TimeWaitingLabel
            // 
            this.TimeWaitingLabel.AutoSize = true;
            this.TimeWaitingLabel.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimeWaitingLabel.Location = new System.Drawing.Point(25, 71);
            this.TimeWaitingLabel.Name = "TimeWaitingLabel";
            this.TimeWaitingLabel.Size = new System.Drawing.Size(325, 21);
            this.TimeWaitingLabel.TabIndex = 5;
            this.TimeWaitingLabel.Text = "Time to wait window ready before copy (ms) :";
            this.TimeWaitingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnableCompactConversionLabel
            // 
            this.EnableCompactConversionLabel.AutoSize = true;
            this.EnableCompactConversionLabel.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EnableCompactConversionLabel.Location = new System.Drawing.Point(25, 112);
            this.EnableCompactConversionLabel.Name = "EnableCompactConversionLabel";
            this.EnableCompactConversionLabel.Size = new System.Drawing.Size(192, 21);
            this.EnableCompactConversionLabel.TabIndex = 7;
            this.EnableCompactConversionLabel.Text = "Compact json conversion :";
            this.EnableCompactConversionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CompactConversionEnabled
            // 
            this.CompactConversionEnabled.AutoSize = true;
            this.CompactConversionEnabled.Font = new System.Drawing.Font("Leelawadee UI", 12F);
            this.CompactConversionEnabled.Location = new System.Drawing.Point(281, 111);
            this.CompactConversionEnabled.Name = "CompactConversionEnabled";
            this.CompactConversionEnabled.Size = new System.Drawing.Size(84, 25);
            this.CompactConversionEnabled.TabIndex = 8;
            this.CompactConversionEnabled.Text = "Enabled";
            this.CompactConversionEnabled.UseVisualStyleBackColor = true;
            this.CompactConversionEnabled.CheckedChanged += new System.EventHandler(this.CompactConversionEnabled_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DisplaySuccessNotificationEnabled
            // 
            this.DisplaySuccessNotificationEnabled.AutoSize = true;
            this.DisplaySuccessNotificationEnabled.Font = new System.Drawing.Font("Leelawadee UI", 12F);
            this.DisplaySuccessNotificationEnabled.Location = new System.Drawing.Point(281, 150);
            this.DisplaySuccessNotificationEnabled.Name = "DisplaySuccessNotificationEnabled";
            this.DisplaySuccessNotificationEnabled.Size = new System.Drawing.Size(84, 25);
            this.DisplaySuccessNotificationEnabled.TabIndex = 10;
            this.DisplaySuccessNotificationEnabled.Text = "Enabled";
            this.DisplaySuccessNotificationEnabled.UseVisualStyleBackColor = true;
            this.DisplaySuccessNotificationEnabled.CheckedChanged += new System.EventHandler(this.DisplayMessageIfJsonIsValidEnabled_CheckedChanged);
            // 
            // DisplaySuccessNotificationLabel
            // 
            this.DisplaySuccessNotificationLabel.AutoSize = true;
            this.DisplaySuccessNotificationLabel.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DisplaySuccessNotificationLabel.Location = new System.Drawing.Point(25, 151);
            this.DisplaySuccessNotificationLabel.Name = "DisplaySuccessNotificationLabel";
            this.DisplaySuccessNotificationLabel.Size = new System.Drawing.Size(126, 17);
            this.DisplaySuccessNotificationLabel.TabIndex = 9;
            this.DisplaySuccessNotificationLabel.Text = "Notify if json is valid :";
            this.DisplaySuccessNotificationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 238);
            this.Controls.Add(this.DisplaySuccessNotificationEnabled);
            this.Controls.Add(this.DisplaySuccessNotificationLabel);
            this.Controls.Add(this.CompactConversionEnabled);
            this.Controls.Add(this.EnableCompactConversionLabel);
            this.Controls.Add(this.TimeWaitingMs);
            this.Controls.Add(this.TimeWaitingLabel);
            this.Controls.Add(this.HotKeyBindingPlusLabel);
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label HotKeyBindingLabel;
        private System.Windows.Forms.TextBox ModifierKeyBindingTextBox;
        private System.Windows.Forms.TextBox MainKeyBindingTextBox;
        private System.Windows.Forms.Label HotKeyBindingPlusLabel;
        private System.Windows.Forms.TextBox TimeWaitingMs;
        private System.Windows.Forms.Label TimeWaitingLabel;
        private System.Windows.Forms.Label EnableCompactConversionLabel;
        private System.Windows.Forms.CheckBox CompactConversionEnabled;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox DisplaySuccessNotificationEnabled;
        private System.Windows.Forms.Label DisplaySuccessNotificationLabel;
    }
}