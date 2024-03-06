namespace NathanAudioPlayer
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PlayButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.FolderSelect = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.DisplayLabel = new System.Windows.Forms.Label();
            this.BackgroundPlayer = new System.ComponentModel.BackgroundWorker();
            this.FilesDisplay = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RemoveButton = new System.Windows.Forms.Button();
            this.RemoveButtonWorker = new System.ComponentModel.BackgroundWorker();
            this.SkipButton = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.WaitingTimeLabel = new System.Windows.Forms.Label();
            this.isRandomCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Enabled = false;
            this.PlayButton.Location = new System.Drawing.Point(12, 406);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(80, 32);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // PauseButton
            // 
            this.PauseButton.Enabled = false;
            this.PauseButton.Location = new System.Drawing.Point(98, 406);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(80, 32);
            this.PauseButton.TabIndex = 1;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(270, 406);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(80, 32);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // FolderSelect
            // 
            this.FolderSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FolderSelect.Location = new System.Drawing.Point(12, 38);
            this.FolderSelect.Name = "FolderSelect";
            this.FolderSelect.Size = new System.Drawing.Size(130, 36);
            this.FolderSelect.TabIndex = 5;
            this.FolderSelect.Text = "Select a folder";
            this.FolderSelect.UseVisualStyleBackColor = true;
            this.FolderSelect.Click += new System.EventHandler(this.button4_Click);
            // 
            // DisplayLabel
            // 
            this.DisplayLabel.AutoSize = true;
            this.DisplayLabel.BackColor = System.Drawing.SystemColors.Control;
            this.DisplayLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisplayLabel.Location = new System.Drawing.Point(8, 9);
            this.DisplayLabel.Name = "DisplayLabel";
            this.DisplayLabel.Size = new System.Drawing.Size(187, 24);
            this.DisplayLabel.TabIndex = 7;
            this.DisplayLabel.Text = "Please select a folder";
            // 
            // BackgroundPlayer
            // 
            this.BackgroundPlayer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundPlayer_DoWork);
            // 
            // FilesDisplay
            // 
            this.FilesDisplay.BackColor = System.Drawing.SystemColors.Window;
            this.FilesDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilesDisplay.CheckBoxes = true;
            this.FilesDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName});
            this.FilesDisplay.HideSelection = false;
            this.FilesDisplay.LabelWrap = false;
            this.FilesDisplay.Location = new System.Drawing.Point(12, 80);
            this.FilesDisplay.Name = "FilesDisplay";
            this.FilesDisplay.Size = new System.Drawing.Size(450, 320);
            this.FilesDisplay.TabIndex = 8;
            this.FilesDisplay.TileSize = new System.Drawing.Size(292, 40);
            this.FilesDisplay.UseCompatibleStateImageBehavior = false;
            this.FilesDisplay.View = System.Windows.Forms.View.Details;
            // 
            // FileName
            // 
            this.FileName.Text = "File names";
            this.FileName.Width = 450;
            // 
            // RemoveButton
            // 
            this.RemoveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(0)))));
            this.RemoveButton.Location = new System.Drawing.Point(386, 406);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(76, 32);
            this.RemoveButton.TabIndex = 9;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = false;
            this.RemoveButton.Visible = false;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // RemoveButtonWorker
            // 
            this.RemoveButtonWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RemoveButtonWorker_DoWork);
            // 
            // SkipButton
            // 
            this.SkipButton.Enabled = false;
            this.SkipButton.Location = new System.Drawing.Point(184, 406);
            this.SkipButton.Name = "SkipButton";
            this.SkipButton.Size = new System.Drawing.Size(80, 32);
            this.SkipButton.TabIndex = 10;
            this.SkipButton.Text = "Skip";
            this.SkipButton.UseVisualStyleBackColor = true;
            this.SkipButton.Click += new System.EventHandler(this.SkipButton_Click);
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(12, 473);
            this.numericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(90, 22);
            this.numericUpDown.TabIndex = 11;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // WaitingTimeLabel
            // 
            this.WaitingTimeLabel.AutoSize = true;
            this.WaitingTimeLabel.Location = new System.Drawing.Point(108, 475);
            this.WaitingTimeLabel.Name = "WaitingTimeLabel";
            this.WaitingTimeLabel.Size = new System.Drawing.Size(201, 16);
            this.WaitingTimeLabel.TabIndex = 12;
            this.WaitingTimeLabel.Text = "Waiting time between recordings";
            // 
            // isRandomCheckBox
            // 
            this.isRandomCheckBox.AutoSize = true;
            this.isRandomCheckBox.Location = new System.Drawing.Point(12, 447);
            this.isRandomCheckBox.Name = "isRandomCheckBox";
            this.isRandomCheckBox.Size = new System.Drawing.Size(165, 20);
            this.isRandomCheckBox.TabIndex = 13;
            this.isRandomCheckBox.Text = "Randomize recordings";
            this.isRandomCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(572, 511);
            this.Controls.Add(this.isRandomCheckBox);
            this.Controls.Add(this.WaitingTimeLabel);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.SkipButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.FilesDisplay);
            this.Controls.Add(this.DisplayLabel);
            this.Controls.Add(this.FolderSelect);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.PlayButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Recorder player";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button FolderSelect;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label DisplayLabel;
        private System.ComponentModel.BackgroundWorker BackgroundPlayer;
        private System.Windows.Forms.ListView FilesDisplay;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.Button RemoveButton;
        private System.ComponentModel.BackgroundWorker RemoveButtonWorker;
        private System.Windows.Forms.Button SkipButton;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Label WaitingTimeLabel;
        private System.Windows.Forms.CheckBox isRandomCheckBox;
    }
}

