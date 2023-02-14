namespace Nasłuchiwanie_Plików
{
    partial class LoginANDPassword
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
            this.Login_Label = new System.Windows.Forms.Label();
            this.Password_Label = new System.Windows.Forms.Label();
            this.Login_textBox = new System.Windows.Forms.TextBox();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.Login_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Login_Label
            // 
            this.Login_Label.AutoSize = true;
            this.Login_Label.Location = new System.Drawing.Point(24, 47);
            this.Login_Label.Name = "Login_Label";
            this.Login_Label.Size = new System.Drawing.Size(37, 15);
            this.Login_Label.TabIndex = 0;
            this.Login_Label.Text = "Login";
            // 
            // Password_Label
            // 
            this.Password_Label.AutoSize = true;
            this.Password_Label.Location = new System.Drawing.Point(4, 103);
            this.Password_Label.Name = "Password_Label";
            this.Password_Label.Size = new System.Drawing.Size(57, 15);
            this.Password_Label.TabIndex = 1;
            this.Password_Label.Text = "Password";
            // 
            // Login_textBox
            // 
            this.Login_textBox.Location = new System.Drawing.Point(67, 44);
            this.Login_textBox.Name = "Login_textBox";
            this.Login_textBox.Size = new System.Drawing.Size(178, 23);
            this.Login_textBox.TabIndex = 2;
            this.Login_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_textBox_KeyDown);
            // 
            // Password_textBox
            // 
            this.Password_textBox.Location = new System.Drawing.Point(67, 100);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(178, 23);
            this.Password_textBox.TabIndex = 3;
            this.Password_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_textBox_KeyDown);
            // 
            // Login_button
            // 
            this.Login_button.Location = new System.Drawing.Point(107, 154);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(82, 28);
            this.Login_button.TabIndex = 4;
            this.Login_button.Text = "Login";
            this.Login_button.UseVisualStyleBackColor = true;
            this.Login_button.Click += new System.EventHandler(this.Login_button_Click);
            // 
            // LoginANDPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 227);
            this.Controls.Add(this.Login_button);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Login_textBox);
            this.Controls.Add(this.Password_Label);
            this.Controls.Add(this.Login_Label);
            this.MaximizeBox = false;
            this.Name = "LoginANDPassword";
            this.Text = "Security";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Login_Label;
        private Label Password_Label;
        private TextBox Login_textBox;
        private TextBox Password_textBox;
        private Button Login_button;
    }
}