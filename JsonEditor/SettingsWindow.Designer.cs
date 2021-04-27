
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
            this.IndentedFomattingKeyBindingLabel = new System.Windows.Forms.Label();
            this.IndentedFormattingModifierKeyBindingTextBox = new System.Windows.Forms.TextBox();
            this.IndentedFormattingMainKeyBindingTextBox = new System.Windows.Forms.TextBox();
            this.IndentedFormattingKeyBindingPlusLabel = new System.Windows.Forms.Label();
            this.TimeWaitingMs = new System.Windows.Forms.TextBox();
            this.TimeWaitingLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.DisplaySuccessNotificationEnabled = new System.Windows.Forms.CheckBox();
            this.DisplaySuccessNotificationLabel = new System.Windows.Forms.Label();
            this.CompactFormattingKeyBindingPlusLabel = new System.Windows.Forms.Label();
            this.CompactFormattingMainKeyBindingTextBox = new System.Windows.Forms.TextBox();
            this.CompactFormattingModifierKeyBindingTextBox = new System.Windows.Forms.TextBox();
            this.CompactFomattingKeyBindingLabel = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveButton.Location = new System.Drawing.Point(244, 194);
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
            this.CancelButton.Location = new System.Drawing.Point(438, 194);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(91, 27);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // IndentedFomattingKeyBindingLabel
            // 
            this.IndentedFomattingKeyBindingLabel.AutoSize = true;
            this.IndentedFomattingKeyBindingLabel.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IndentedFomattingKeyBindingLabel.Location = new System.Drawing.Point(25, 29);
            this.IndentedFomattingKeyBindingLabel.Name = "IndentedFomattingKeyBindingLabel";
            this.IndentedFomattingKeyBindingLabel.Size = new System.Drawing.Size(241, 21);
            this.IndentedFomattingKeyBindingLabel.TabIndex = 1;
            this.IndentedFomattingKeyBindingLabel.Text = "Indented formatting key binding :";
            this.IndentedFomattingKeyBindingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IndentedFormattingModifierKeyBindingTextBox
            // 
            this.IndentedFormattingModifierKeyBindingTextBox.Font = new System.Drawing.Font("Leelawadee UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IndentedFormattingModifierKeyBindingTextBox.Location = new System.Drawing.Point(271, 29);
            this.IndentedFormattingModifierKeyBindingTextBox.Name = "IndentedFormattingModifierKeyBindingTextBox";
            this.IndentedFormattingModifierKeyBindingTextBox.ReadOnly = true;
            this.IndentedFormattingModifierKeyBindingTextBox.Size = new System.Drawing.Size(126, 25);
            this.IndentedFormattingModifierKeyBindingTextBox.TabIndex = 2;
            this.IndentedFormattingModifierKeyBindingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IndentedFormattingModifierKeyBindingTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IndentedFormattingModifierKeyBindingTextBox_KeyDown);
            // 
            // IndentedFormattingMainKeyBindingTextBox
            // 
            this.IndentedFormattingMainKeyBindingTextBox.Font = new System.Drawing.Font("Leelawadee UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IndentedFormattingMainKeyBindingTextBox.Location = new System.Drawing.Point(424, 29);
            this.IndentedFormattingMainKeyBindingTextBox.Name = "IndentedFormattingMainKeyBindingTextBox";
            this.IndentedFormattingMainKeyBindingTextBox.ReadOnly = true;
            this.IndentedFormattingMainKeyBindingTextBox.Size = new System.Drawing.Size(79, 25);
            this.IndentedFormattingMainKeyBindingTextBox.TabIndex = 3;
            this.IndentedFormattingMainKeyBindingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IndentedFormattingMainKeyBindingTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IndentedFormattingMainKeyBindingTextBox_KeyDown);
            // 
            // IndentedFormattingKeyBindingPlusLabel
            // 
            this.IndentedFormattingKeyBindingPlusLabel.AutoSize = true;
            this.IndentedFormattingKeyBindingPlusLabel.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IndentedFormattingKeyBindingPlusLabel.Location = new System.Drawing.Point(400, 30);
            this.IndentedFormattingKeyBindingPlusLabel.Name = "IndentedFormattingKeyBindingPlusLabel";
            this.IndentedFormattingKeyBindingPlusLabel.Size = new System.Drawing.Size(21, 21);
            this.IndentedFormattingKeyBindingPlusLabel.TabIndex = 4;
            this.IndentedFormattingKeyBindingPlusLabel.Text = "+";
            // 
            // TimeWaitingMs
            // 
            this.TimeWaitingMs.Font = new System.Drawing.Font("Leelawadee UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TimeWaitingMs.Location = new System.Drawing.Point(404, 110);
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
            this.TimeWaitingLabel.Location = new System.Drawing.Point(25, 110);
            this.TimeWaitingLabel.Name = "TimeWaitingLabel";
            this.TimeWaitingLabel.Size = new System.Drawing.Size(325, 21);
            this.TimeWaitingLabel.TabIndex = 5;
            this.TimeWaitingLabel.Text = "Time to wait window ready before copy (ms) :";
            this.TimeWaitingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DisplaySuccessNotificationEnabled
            // 
            this.DisplaySuccessNotificationEnabled.AutoSize = true;
            this.DisplaySuccessNotificationEnabled.Font = new System.Drawing.Font("Leelawadee UI", 12F);
            this.DisplaySuccessNotificationEnabled.Location = new System.Drawing.Point(367, 151);
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
            this.DisplaySuccessNotificationLabel.Location = new System.Drawing.Point(25, 152);
            this.DisplaySuccessNotificationLabel.Name = "DisplaySuccessNotificationLabel";
            this.DisplaySuccessNotificationLabel.Size = new System.Drawing.Size(158, 21);
            this.DisplaySuccessNotificationLabel.TabIndex = 9;
            this.DisplaySuccessNotificationLabel.Text = "Notify if json is valid :";
            this.DisplaySuccessNotificationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CompactFormattingKeyBindingPlusLabel
            // 
            this.CompactFormattingKeyBindingPlusLabel.AutoSize = true;
            this.CompactFormattingKeyBindingPlusLabel.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CompactFormattingKeyBindingPlusLabel.Location = new System.Drawing.Point(400, 69);
            this.CompactFormattingKeyBindingPlusLabel.Name = "CompactFormattingKeyBindingPlusLabel";
            this.CompactFormattingKeyBindingPlusLabel.Size = new System.Drawing.Size(21, 21);
            this.CompactFormattingKeyBindingPlusLabel.TabIndex = 14;
            this.CompactFormattingKeyBindingPlusLabel.Text = "+";
            // 
            // CompactFormattingMainKeyBindingTextBox
            // 
            this.CompactFormattingMainKeyBindingTextBox.Font = new System.Drawing.Font("Leelawadee UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CompactFormattingMainKeyBindingTextBox.Location = new System.Drawing.Point(424, 69);
            this.CompactFormattingMainKeyBindingTextBox.Name = "CompactFormattingMainKeyBindingTextBox";
            this.CompactFormattingMainKeyBindingTextBox.ReadOnly = true;
            this.CompactFormattingMainKeyBindingTextBox.Size = new System.Drawing.Size(79, 25);
            this.CompactFormattingMainKeyBindingTextBox.TabIndex = 13;
            this.CompactFormattingMainKeyBindingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CompactFormattingMainKeyBindingTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompactFormattingMainKeyBindingTextBox_KeyDown);
            // 
            // CompactFormattingModifierKeyBindingTextBox
            // 
            this.CompactFormattingModifierKeyBindingTextBox.Font = new System.Drawing.Font("Leelawadee UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CompactFormattingModifierKeyBindingTextBox.Location = new System.Drawing.Point(271, 69);
            this.CompactFormattingModifierKeyBindingTextBox.Name = "CompactFormattingModifierKeyBindingTextBox";
            this.CompactFormattingModifierKeyBindingTextBox.ReadOnly = true;
            this.CompactFormattingModifierKeyBindingTextBox.Size = new System.Drawing.Size(126, 25);
            this.CompactFormattingModifierKeyBindingTextBox.TabIndex = 12;
            this.CompactFormattingModifierKeyBindingTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CompactFormattingModifierKeyBindingTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CompactFormattingModifierKeyBindingTextBox_KeyDown);
            // 
            // CompactFomattingKeyBindingLabel
            // 
            this.CompactFomattingKeyBindingLabel.AutoSize = true;
            this.CompactFomattingKeyBindingLabel.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CompactFomattingKeyBindingLabel.Location = new System.Drawing.Point(26, 69);
            this.CompactFomattingKeyBindingLabel.Name = "CompactFomattingKeyBindingLabel";
            this.CompactFomattingKeyBindingLabel.Size = new System.Drawing.Size(242, 21);
            this.CompactFomattingKeyBindingLabel.TabIndex = 11;
            this.CompactFomattingKeyBindingLabel.Text = "Compact formatting key binding :";
            this.CompactFomattingKeyBindingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResetButton.Location = new System.Drawing.Point(29, 194);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(91, 27);
            this.ResetButton.TabIndex = 15;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ApplyButton.Location = new System.Drawing.Point(341, 194);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(91, 27);
            this.ApplyButton.TabIndex = 16;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 235);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.CompactFormattingKeyBindingPlusLabel);
            this.Controls.Add(this.CompactFormattingMainKeyBindingTextBox);
            this.Controls.Add(this.CompactFormattingModifierKeyBindingTextBox);
            this.Controls.Add(this.CompactFomattingKeyBindingLabel);
            this.Controls.Add(this.DisplaySuccessNotificationEnabled);
            this.Controls.Add(this.DisplaySuccessNotificationLabel);
            this.Controls.Add(this.TimeWaitingMs);
            this.Controls.Add(this.TimeWaitingLabel);
            this.Controls.Add(this.IndentedFormattingKeyBindingPlusLabel);
            this.Controls.Add(this.IndentedFormattingMainKeyBindingTextBox);
            this.Controls.Add(this.IndentedFormattingModifierKeyBindingTextBox);
            this.Controls.Add(this.IndentedFomattingKeyBindingLabel);
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
        private System.Windows.Forms.Label IndentedFomattingKeyBindingLabel;
        private System.Windows.Forms.TextBox IndentedFormattingModifierKeyBindingTextBox;
        private System.Windows.Forms.TextBox IndentedFormattingMainKeyBindingTextBox;
        private System.Windows.Forms.Label IndentedFormattingKeyBindingPlusLabel;
        private System.Windows.Forms.TextBox TimeWaitingMs;
        private System.Windows.Forms.Label TimeWaitingLabel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox DisplaySuccessNotificationEnabled;
        private System.Windows.Forms.Label DisplaySuccessNotificationLabel;
        private System.Windows.Forms.Label CompactFormattingKeyBindingPlusLabel;
        private System.Windows.Forms.TextBox CompactFormattingMainKeyBindingTextBox;
        private System.Windows.Forms.TextBox CompactFormattingModifierKeyBindingTextBox;
        private System.Windows.Forms.Label CompactFomattingKeyBindingLabel;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button ApplyButton;
    }
}