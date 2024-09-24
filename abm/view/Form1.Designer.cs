namespace tutos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnguardar = new System.Windows.Forms.Button();
            this.txtruta = new System.Windows.Forms.TextBox();
            this.btnabrir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsep = new System.Windows.Forms.TextBox();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(72)))), ((int)(((byte)(68)))));
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnguardar.ForeColor = System.Drawing.Color.White;
            this.btnguardar.Location = new System.Drawing.Point(23, 244);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(585, 64);
            this.btnguardar.TabIndex = 6;
            this.btnguardar.Text = "Exportar a CSV";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // txtruta
            // 
            this.txtruta.Location = new System.Drawing.Point(23, 66);
            this.txtruta.Name = "txtruta";
            this.txtruta.Size = new System.Drawing.Size(539, 32);
            this.txtruta.TabIndex = 1;
            this.txtruta.TextChanged += new System.EventHandler(this.txtruta_TextChanged);
            // 
            // btnabrir
            // 
            this.btnabrir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(72)))), ((int)(((byte)(68)))));
            this.btnabrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnabrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnabrir.ForeColor = System.Drawing.Color.White;
            this.btnabrir.Location = new System.Drawing.Point(576, 62);
            this.btnabrir.Name = "btnabrir";
            this.btnabrir.Size = new System.Drawing.Size(52, 39);
            this.btnabrir.TabIndex = 2;
            this.btnabrir.Text = "...";
            this.btnabrir.UseVisualStyleBackColor = false;
            this.btnabrir.Click += new System.EventHandler(this.btnabrir_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Guardar en...";
            // 
            // txtsep
            // 
            this.txtsep.Location = new System.Drawing.Point(637, 390);
            this.txtsep.Name = "txtsep";
            this.txtsep.Size = new System.Drawing.Size(10, 32);
            this.txtsep.TabIndex = 5;
            this.txtsep.Text = ";";
            this.txtsep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtsep.TextChanged += new System.EventHandler(this.txtsep_TextChanged);
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Location = new System.Drawing.Point(23, 187);
            this.dateTimePickerDesde.MinDate = new System.DateTime(2024, 3, 1, 0, 0, 0, 0);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(200, 32);
            this.dateTimePickerDesde.TabIndex = 7;
            this.dateTimePickerDesde.Value = new System.DateTime(2024, 3, 1, 0, 0, 0, 0);
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Location = new System.Drawing.Point(362, 187);
            this.dateTimePickerHasta.MinDate = new System.DateTime(2024, 3, 1, 0, 0, 0, 0);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(200, 32);
            this.dateTimePickerHasta.TabIndex = 8;
            this.dateTimePickerHasta.Value = new System.DateTime(2024, 3, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(19, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Desde";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(370, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hasta";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(640, 320);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerHasta);
            this.Controls.Add(this.dateTimePickerDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnabrir);
            this.Controls.Add(this.txtruta);
            this.Controls.Add(this.txtsep);
            this.Controls.Add(this.btnguardar);
            this.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.Text = "  ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.TextBox txtruta;
        private System.Windows.Forms.Button btnabrir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsep;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

