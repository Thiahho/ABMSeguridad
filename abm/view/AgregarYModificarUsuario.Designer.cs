
namespace abm.view
{
    partial class AgregarYModificarUsuario
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
            this.DGVUsuarios = new System.Windows.Forms.DataGridView();
            this.bGuardarCambiosUsuarios = new System.Windows.Forms.Button();
            this.bSalirEditar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.NomUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApeUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dniUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVUsuarios
            // 
            this.DGVUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NomUsuario,
            this.ApeUsuario,
            this.dniUsuario});
            this.DGVUsuarios.Location = new System.Drawing.Point(152, 12);
            this.DGVUsuarios.Name = "DGVUsuarios";
            this.DGVUsuarios.Size = new System.Drawing.Size(516, 176);
            this.DGVUsuarios.TabIndex = 0;
            this.DGVUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // bGuardarCambiosUsuarios
            // 
            this.bGuardarCambiosUsuarios.Location = new System.Drawing.Point(616, 389);
            this.bGuardarCambiosUsuarios.Name = "bGuardarCambiosUsuarios";
            this.bGuardarCambiosUsuarios.Size = new System.Drawing.Size(94, 27);
            this.bGuardarCambiosUsuarios.TabIndex = 1;
            this.bGuardarCambiosUsuarios.Text = "GuardarCambios";
            this.bGuardarCambiosUsuarios.UseVisualStyleBackColor = true;
            // 
            // bSalirEditar
            // 
            this.bSalirEditar.Location = new System.Drawing.Point(94, 389);
            this.bSalirEditar.Name = "bSalirEditar";
            this.bSalirEditar.Size = new System.Drawing.Size(86, 27);
            this.bSalirEditar.TabIndex = 2;
            this.bSalirEditar.Text = "Salir";
            this.bSalirEditar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 270);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(322, 269);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(187, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(568, 269);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(175, 20);
            this.textBox3.TabIndex = 5;
            // 
            // NomUsuario
            // 
            this.NomUsuario.HeaderText = "Nombre";
            this.NomUsuario.Name = "NomUsuario";
            // 
            // ApeUsuario
            // 
            this.ApeUsuario.HeaderText = "PASSWORD";
            this.ApeUsuario.MaxInputLength = 12;
            this.ApeUsuario.Name = "ApeUsuario";
            // 
            // dniUsuario
            // 
            this.dniUsuario.HeaderText = "TIPO";
            this.dniUsuario.Name = "dniUsuario";
            // 
            // AgregarYModificarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bSalirEditar);
            this.Controls.Add(this.bGuardarCambiosUsuarios);
            this.Controls.Add(this.DGVUsuarios);
            this.Name = "AgregarYModificarUsuario";
            this.Text = "AgregarYModificarUsuario";
            this.Load += new System.EventHandler(this.AgregarYModificarUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVUsuarios;
        private System.Windows.Forms.Button bGuardarCambiosUsuarios;
        private System.Windows.Forms.Button bSalirEditar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApeUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn dniUsuario;
    }
}