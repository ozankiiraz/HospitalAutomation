
namespace HospitalAutomation
{
    partial class Prescription
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
            this.dataGridViewIlaclar = new System.Windows.Forms.DataGridView();
            this.dataGridViewRecete = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIlaclar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecete)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewIlaclar
            // 
            this.dataGridViewIlaclar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIlaclar.Location = new System.Drawing.Point(13, 87);
            this.dataGridViewIlaclar.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewIlaclar.Name = "dataGridViewIlaclar";
            this.dataGridViewIlaclar.RowHeadersWidth = 51;
            this.dataGridViewIlaclar.Size = new System.Drawing.Size(423, 230);
            this.dataGridViewIlaclar.TabIndex = 0;
            this.dataGridViewIlaclar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIlaclar_CellClick);
            // 
            // dataGridViewRecete
            // 
            this.dataGridViewRecete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecete.Location = new System.Drawing.Point(543, 77);
            this.dataGridViewRecete.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewRecete.Name = "dataGridViewRecete";
            this.dataGridViewRecete.RowHeadersWidth = 51;
            this.dataGridViewRecete.Size = new System.Drawing.Size(435, 240);
            this.dataGridViewRecete.TabIndex = 1;
            this.dataGridViewRecete.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRecete_CellClick);
            this.dataGridViewRecete.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewRecete_RowsAdded);
            this.dataGridViewRecete.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewRecete_RowsRemoved);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 140);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "EKLE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(451, 197);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 49);
            this.button2.TabIndex = 3;
            this.button2.Text = "SİL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lime;
            this.button3.Location = new System.Drawing.Point(815, 325);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 74);
            this.button3.TabIndex = 4;
            this.button3.Text = "REÇETE ONAYLA";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "T.C Kimlik No :";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(149, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 30);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox2.Location = new System.Drawing.Point(149, 43);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(158, 30);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(44, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "İlaç Adı :";
            // 
            // Prescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(993, 422);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewRecete);
            this.Controls.Add(this.dataGridViewIlaclar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Prescription";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Prescription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIlaclar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewIlaclar;
        private System.Windows.Forms.DataGridView dataGridViewRecete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
    }
}