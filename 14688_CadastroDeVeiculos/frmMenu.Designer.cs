namespace _14688_CadastroDeVeiculos
{
    partial class frmMenu
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
            System.Windows.Forms.Button btnIncludeManufacturer;
            this.btnincludeVechicle = new System.Windows.Forms.Button();
            this.btnVehicleType = new System.Windows.Forms.Button();
            this.btnFuel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            btnIncludeManufacturer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIncludeManufacturer
            // 
            btnIncludeManufacturer.Image = global::_14688_CadastroDeVeiculos.Properties.Resources.tool;
            btnIncludeManufacturer.Location = new System.Drawing.Point(122, 12);
            btnIncludeManufacturer.Name = "btnIncludeManufacturer";
            btnIncludeManufacturer.Size = new System.Drawing.Size(104, 42);
            btnIncludeManufacturer.TabIndex = 1;
            btnIncludeManufacturer.Text = "Fabricantes";
            btnIncludeManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnIncludeManufacturer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnIncludeManufacturer.UseVisualStyleBackColor = true;
            btnIncludeManufacturer.Click += new System.EventHandler(this.btnIncludeManufacturer_Click);
            // 
            // btnincludeVechicle
            // 
            this.btnincludeVechicle.Image = global::_14688_CadastroDeVeiculos.Properties.Resources.plus_square;
            this.btnincludeVechicle.Location = new System.Drawing.Point(12, 12);
            this.btnincludeVechicle.Name = "btnincludeVechicle";
            this.btnincludeVechicle.Size = new System.Drawing.Size(104, 42);
            this.btnincludeVechicle.TabIndex = 0;
            this.btnincludeVechicle.Text = "Veiculos";
            this.btnincludeVechicle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnincludeVechicle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnincludeVechicle.UseVisualStyleBackColor = true;
            this.btnincludeVechicle.Click += new System.EventHandler(this.btnincludeVechicle_Click);
            // 
            // btnVehicleType
            // 
            this.btnVehicleType.Image = global::_14688_CadastroDeVeiculos.Properties.Resources.server;
            this.btnVehicleType.Location = new System.Drawing.Point(232, 12);
            this.btnVehicleType.Name = "btnVehicleType";
            this.btnVehicleType.Size = new System.Drawing.Size(104, 42);
            this.btnVehicleType.TabIndex = 2;
            this.btnVehicleType.Text = "Categorias";
            this.btnVehicleType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVehicleType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVehicleType.UseVisualStyleBackColor = true;
            this.btnVehicleType.Click += new System.EventHandler(this.btnVehicleType_Click);
            // 
            // btnFuel
            // 
            this.btnFuel.Image = global::_14688_CadastroDeVeiculos.Properties.Resources.droplet;
            this.btnFuel.Location = new System.Drawing.Point(342, 12);
            this.btnFuel.Name = "btnFuel";
            this.btnFuel.Size = new System.Drawing.Size(104, 42);
            this.btnFuel.TabIndex = 3;
            this.btnFuel.Text = "Combustiveis";
            this.btnFuel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFuel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFuel.UseVisualStyleBackColor = true;
            this.btnFuel.Click += new System.EventHandler(this.btnFuel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::_14688_CadastroDeVeiculos.Properties.Resources.log_out;
            this.btnClose.Location = new System.Drawing.Point(791, 249);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 42);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Fechar";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_14688_CadastroDeVeiculos.Properties.Resources.pngegg;
            this.ClientSize = new System.Drawing.Size(907, 303);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFuel);
            this.Controls.Add(this.btnVehicleType);
            this.Controls.Add(btnIncludeManufacturer);
            this.Controls.Add(this.btnincludeVechicle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMenu";
            this.Text = "Cadastro de Veiculos";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnincludeVechicle;
        private System.Windows.Forms.Button btnVehicleType;
        private System.Windows.Forms.Button btnFuel;
        private System.Windows.Forms.Button btnClose;
    }
}

