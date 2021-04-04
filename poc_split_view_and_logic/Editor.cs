﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonEditor
{
    public partial class Editor : Form
    {
        private EditorModel Model;

        public Editor(EditorModel model)
        {
            InitializeComponent();
            this.Model = model;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void TextComponent_TextChanged(object sender, EventArgs e)
        {
            Model.Content = TextComponent.Text;
        }

        private void CompactJsonMenuItem_Click(object sender, EventArgs e)
        {
            if (Model.IsValidJson)
            {
                TextComponent.Text = Model.GetCompactJson();
            }
        }

        private void IndentedJsonMenuItem_Click(object sender, EventArgs e)
        {
            if (Model.IsValidJson)
            {
                TextComponent.Text = Model.GetIndentedJson();
            }
        }
    }
}
