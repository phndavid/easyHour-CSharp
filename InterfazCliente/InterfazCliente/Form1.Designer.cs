namespace InterfazCliente
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSelecArchivo = new System.Windows.Forms.TabPage();
            this.lblCargandoCarrera = new MetroFramework.Controls.MetroLabel();
            this.chkSimultaneidad = new MetroFramework.Controls.MetroCheckBox();
            this.btnCarga = new MetroFramework.Controls.MetroButton();
            this.txtNombreArchivo = new MetroFramework.Controls.MetroTextBox();
            this.btnSeleccionarArchivo = new MetroFramework.Controls.MetroButton();
            this.lblSeleccionarArchivo = new MetroFramework.Controls.MetroLabel();
            this.comboCarreras = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tabSelecCombinacion = new System.Windows.Forms.TabPage();
            this.lblModo = new MetroFramework.Controls.MetroLabel();
            this.comboModos = new MetroFramework.Controls.MetroComboBox();
            this.btnFiltarHorarios = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerarCombinaciones = new MetroFramework.Controls.MetroButton();
            this.comboCarreraActual = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.TabFiltros = new System.Windows.Forms.TabPage();
            this.btnAtrasSel = new MetroFramework.Controls.MetroButton();
            this.label2 = new System.Windows.Forms.Label();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.chkEnSemana = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.comboCantidadDiasLibres = new MetroFramework.Controls.MetroComboBox();
            this.lblDiasLibresMinimos = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.chkListFiltrosHoraDias = new System.Windows.Forms.CheckedListBox();
            this.btnAgregarFiltroHoraDia = new MetroFramework.Controls.MetroButton();
            this.txtHoraFinFiltro = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.txtHoraInicioFiltro = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.comboDias = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.lblFiltroHoraDia = new MetroFramework.Controls.MetroLabel();
            this.tabHorarios = new System.Windows.Forms.TabPage();
            this.lblHorarioNumero = new MetroFramework.Controls.MetroLabel();
            this.favoritebox = new System.Windows.Forms.PictureBox();
            this.lblListaHorarios = new MetroFramework.Controls.MetroLabel();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.lblHorariosGenerados = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnAnteriorHorario = new MetroFramework.Controls.MetroButton();
            this.btnSiguienteHorario = new MetroFramework.Controls.MetroButton();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.tabManual = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridManual = new System.Windows.Forms.DataGridView();
            this.lblHorariosManuales = new System.Windows.Forms.Label();
            this.lblGeneracionCombinaciones = new MetroFramework.Controls.MetroLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMisHorarios = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.btnGenerar = new MetroFramework.Controls.MetroButton();
            this.btnHome = new MetroFramework.Controls.MetroButton();
            this.treeMateria = new InterfazCliente.MyTreeView();
            this.treeConjuntoMaterias = new InterfazCliente.MyTreeView();
            this.treeGrupo = new InterfazCliente.MyTreeView();
            this.tabControl1.SuspendLayout();
            this.tabSelecArchivo.SuspendLayout();
            this.tabSelecCombinacion.SuspendLayout();
            this.TabFiltros.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.tabHorarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.favoritebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.tabManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridManual)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabSelecArchivo);
            this.tabControl1.Controls.Add(this.tabSelecCombinacion);
            this.tabControl1.Controls.Add(this.TabFiltros);
            this.tabControl1.Controls.Add(this.tabHorarios);
            this.tabControl1.Controls.Add(this.tabManual);
            this.tabControl1.Location = new System.Drawing.Point(172, 85);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1194, 674);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSelecArchivo
            // 
            this.tabSelecArchivo.AutoScroll = true;
            this.tabSelecArchivo.Controls.Add(this.lblCargandoCarrera);
            this.tabSelecArchivo.Controls.Add(this.chkSimultaneidad);
            this.tabSelecArchivo.Controls.Add(this.btnCarga);
            this.tabSelecArchivo.Controls.Add(this.txtNombreArchivo);
            this.tabSelecArchivo.Controls.Add(this.btnSeleccionarArchivo);
            this.tabSelecArchivo.Controls.Add(this.lblSeleccionarArchivo);
            this.tabSelecArchivo.Controls.Add(this.comboCarreras);
            this.tabSelecArchivo.Controls.Add(this.metroLabel1);
            this.tabSelecArchivo.Location = new System.Drawing.Point(23, 4);
            this.tabSelecArchivo.Name = "tabSelecArchivo";
            this.tabSelecArchivo.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelecArchivo.Size = new System.Drawing.Size(1167, 666);
            this.tabSelecArchivo.TabIndex = 0;
            this.tabSelecArchivo.Text = "Seleccionar Carrera";
            this.tabSelecArchivo.UseVisualStyleBackColor = true;
            // 
            // lblCargandoCarrera
            // 
            this.lblCargandoCarrera.AutoSize = true;
            this.lblCargandoCarrera.Location = new System.Drawing.Point(533, 500);
            this.lblCargandoCarrera.Name = "lblCargandoCarrera";
            this.lblCargandoCarrera.Size = new System.Drawing.Size(134, 19);
            this.lblCargandoCarrera.TabIndex = 7;
            this.lblCargandoCarrera.Text = "Cargando Carrera. . .";
            this.lblCargandoCarrera.Visible = false;
            // 
            // chkSimultaneidad
            // 
            this.chkSimultaneidad.AutoSize = true;
            this.chkSimultaneidad.Location = new System.Drawing.Point(539, 361);
            this.chkSimultaneidad.Name = "chkSimultaneidad";
            this.chkSimultaneidad.Size = new System.Drawing.Size(99, 15);
            this.chkSimultaneidad.TabIndex = 6;
            this.chkSimultaneidad.Text = "Simultaneidad";
            this.chkSimultaneidad.UseSelectable = true;
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(526, 434);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(123, 23);
            this.btnCarga.TabIndex = 5;
            this.btnCarga.Text = "Cargar Carrera";
            this.btnCarga.UseSelectable = true;
            this.btnCarga.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Enabled = false;
            this.txtNombreArchivo.Lines = new string[0];
            this.txtNombreArchivo.Location = new System.Drawing.Point(376, 275);
            this.txtNombreArchivo.MaxLength = 32767;
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.PasswordChar = '\0';
            this.txtNombreArchivo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNombreArchivo.SelectedText = "";
            this.txtNombreArchivo.Size = new System.Drawing.Size(411, 23);
            this.txtNombreArchivo.TabIndex = 4;
            this.txtNombreArchivo.UseSelectable = true;
            // 
            // btnSeleccionarArchivo
            // 
            this.btnSeleccionarArchivo.Location = new System.Drawing.Point(793, 275);
            this.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            this.btnSeleccionarArchivo.Size = new System.Drawing.Size(30, 23);
            this.btnSeleccionarArchivo.TabIndex = 3;
            this.btnSeleccionarArchivo.Text = "...";
            this.btnSeleccionarArchivo.UseSelectable = true;
            this.btnSeleccionarArchivo.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // lblSeleccionarArchivo
            // 
            this.lblSeleccionarArchivo.AutoSize = true;
            this.lblSeleccionarArchivo.Location = new System.Drawing.Point(526, 253);
            this.lblSeleccionarArchivo.Name = "lblSeleccionarArchivo";
            this.lblSeleccionarArchivo.Size = new System.Drawing.Size(123, 19);
            this.lblSeleccionarArchivo.TabIndex = 2;
            this.lblSeleccionarArchivo.Text = "Seleccionar Archivo";
            // 
            // comboCarreras
            // 
            this.comboCarreras.FormattingEnabled = true;
            this.comboCarreras.ItemHeight = 23;
            this.comboCarreras.Location = new System.Drawing.Point(394, 131);
            this.comboCarreras.Name = "comboCarreras";
            this.comboCarreras.Size = new System.Drawing.Size(411, 29);
            this.comboCarreras.TabIndex = 1;
            this.comboCarreras.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(544, 109);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(124, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Seleccionar Carrera";
            // 
            // tabSelecCombinacion
            // 
            this.tabSelecCombinacion.Controls.Add(this.lblModo);
            this.tabSelecCombinacion.Controls.Add(this.comboModos);
            this.tabSelecCombinacion.Controls.Add(this.btnFiltarHorarios);
            this.tabSelecCombinacion.Controls.Add(this.label1);
            this.tabSelecCombinacion.Controls.Add(this.btnGenerarCombinaciones);
            this.tabSelecCombinacion.Controls.Add(this.comboCarreraActual);
            this.tabSelecCombinacion.Controls.Add(this.metroLabel7);
            this.tabSelecCombinacion.Controls.Add(this.metroLabel5);
            this.tabSelecCombinacion.Controls.Add(this.metroLabel4);
            this.tabSelecCombinacion.Controls.Add(this.metroLabel3);
            this.tabSelecCombinacion.Controls.Add(this.treeMateria);
            this.tabSelecCombinacion.Controls.Add(this.treeConjuntoMaterias);
            this.tabSelecCombinacion.Controls.Add(this.treeGrupo);
            this.tabSelecCombinacion.Location = new System.Drawing.Point(23, 4);
            this.tabSelecCombinacion.Name = "tabSelecCombinacion";
            this.tabSelecCombinacion.Padding = new System.Windows.Forms.Padding(3);
            this.tabSelecCombinacion.Size = new System.Drawing.Size(1167, 666);
            this.tabSelecCombinacion.TabIndex = 1;
            this.tabSelecCombinacion.Text = "Seleccionar Materias/Grupos";
            this.tabSelecCombinacion.UseVisualStyleBackColor = true;
            // 
            // lblModo
            // 
            this.lblModo.AutoSize = true;
            this.lblModo.Location = new System.Drawing.Point(114, 151);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(45, 19);
            this.lblModo.TabIndex = 25;
            this.lblModo.Text = "Modo";
            // 
            // comboModos
            // 
            this.comboModos.FormattingEnabled = true;
            this.comboModos.ItemHeight = 23;
            this.comboModos.Location = new System.Drawing.Point(115, 173);
            this.comboModos.Name = "comboModos";
            this.comboModos.Size = new System.Drawing.Size(140, 29);
            this.comboModos.TabIndex = 24;
            this.comboModos.UseSelectable = true;
            this.comboModos.SelectedIndexChanged += new System.EventHandler(this.comboModos_SelectedIndexChanged_1);
            // 
            // btnFiltarHorarios
            // 
            this.btnFiltarHorarios.Location = new System.Drawing.Point(114, 517);
            this.btnFiltarHorarios.Name = "btnFiltarHorarios";
            this.btnFiltarHorarios.Size = new System.Drawing.Size(140, 29);
            this.btnFiltarHorarios.TabIndex = 23;
            this.btnFiltarHorarios.Text = "Filtrar Horarios";
            this.btnFiltarHorarios.UseSelectable = true;
            this.btnFiltarHorarios.Click += new System.EventHandler(this.btnFiltarHorarios_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 25);
            this.label1.TabIndex = 22;
            this.label1.Text = "Generar Combinaciones";
            // 
            // btnGenerarCombinaciones
            // 
            this.btnGenerarCombinaciones.Location = new System.Drawing.Point(886, 517);
            this.btnGenerarCombinaciones.Name = "btnGenerarCombinaciones";
            this.btnGenerarCombinaciones.Size = new System.Drawing.Size(140, 29);
            this.btnGenerarCombinaciones.TabIndex = 21;
            this.btnGenerarCombinaciones.Text = "Generar Combinaciones";
            this.btnGenerarCombinaciones.UseSelectable = true;
            this.btnGenerarCombinaciones.Click += new System.EventHandler(this.btnGenerarCombinaciones_Click_1);
            // 
            // comboCarreraActual
            // 
            this.comboCarreraActual.FormattingEnabled = true;
            this.comboCarreraActual.ItemHeight = 23;
            this.comboCarreraActual.Location = new System.Drawing.Point(114, 94);
            this.comboCarreraActual.Name = "comboCarreraActual";
            this.comboCarreraActual.Size = new System.Drawing.Size(378, 29);
            this.comboCarreraActual.TabIndex = 10;
            this.comboCarreraActual.UseSelectable = true;
            this.comboCarreraActual.SelectedIndexChanged += new System.EventHandler(this.comboCarreraActual_SelectedIndexChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(114, 59);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(59, 19);
            this.metroLabel7.TabIndex = 9;
            this.metroLabel7.Text = "Carreras";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(570, 59);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(100, 19);
            this.metroLabel5.TabIndex = 5;
            this.metroLabel5.Text = "Grupos / Clases";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(114, 283);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(59, 19);
            this.metroLabel4.TabIndex = 4;
            this.metroLabel4.Text = "Materias";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(261, 151);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(68, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Semestres";
            // 
            // TabFiltros
            // 
            this.TabFiltros.Controls.Add(this.btnAtrasSel);
            this.TabFiltros.Controls.Add(this.label2);
            this.TabFiltros.Controls.Add(this.metroPanel2);
            this.TabFiltros.Controls.Add(this.metroPanel1);
            this.TabFiltros.Location = new System.Drawing.Point(23, 4);
            this.TabFiltros.Name = "TabFiltros";
            this.TabFiltros.Size = new System.Drawing.Size(1167, 666);
            this.TabFiltros.TabIndex = 2;
            this.TabFiltros.Text = "Filtrar Horarios";
            this.TabFiltros.UseVisualStyleBackColor = true;
            // 
            // btnAtrasSel
            // 
            this.btnAtrasSel.Location = new System.Drawing.Point(141, 501);
            this.btnAtrasSel.Name = "btnAtrasSel";
            this.btnAtrasSel.Size = new System.Drawing.Size(101, 23);
            this.btnAtrasSel.TabIndex = 24;
            this.btnAtrasSel.Text = "Atras";
            this.btnAtrasSel.UseSelectable = true;
            this.btnAtrasSel.Click += new System.EventHandler(this.btnAtrasSel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Filtrar Horarios";
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.chkEnSemana);
            this.metroPanel2.Controls.Add(this.metroLabel14);
            this.metroPanel2.Controls.Add(this.comboCantidadDiasLibres);
            this.metroPanel2.Controls.Add(this.lblDiasLibresMinimos);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(689, 63);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(341, 420);
            this.metroPanel2.TabIndex = 21;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // chkEnSemana
            // 
            this.chkEnSemana.AutoSize = true;
            this.chkEnSemana.Location = new System.Drawing.Point(56, 162);
            this.chkEnSemana.Name = "chkEnSemana";
            this.chkEnSemana.Size = new System.Drawing.Size(256, 15);
            this.chkEnSemana.TabIndex = 23;
            this.chkEnSemana.Text = "Excluir Sábado y Domingo (Sólo En Semana)";
            this.chkEnSemana.UseSelectable = true;
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(43, 110);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(90, 19);
            this.metroLabel14.TabIndex = 22;
            this.metroLabel14.Text = "Cantidad Días";
            // 
            // comboCantidadDiasLibres
            // 
            this.comboCantidadDiasLibres.FormattingEnabled = true;
            this.comboCantidadDiasLibres.ItemHeight = 23;
            this.comboCantidadDiasLibres.Location = new System.Drawing.Point(152, 110);
            this.comboCantidadDiasLibres.Name = "comboCantidadDiasLibres";
            this.comboCantidadDiasLibres.Size = new System.Drawing.Size(121, 29);
            this.comboCantidadDiasLibres.TabIndex = 21;
            this.comboCantidadDiasLibres.UseSelectable = true;
            // 
            // lblDiasLibresMinimos
            // 
            this.lblDiasLibresMinimos.AutoSize = true;
            this.lblDiasLibresMinimos.Location = new System.Drawing.Point(105, 22);
            this.lblDiasLibresMinimos.Name = "lblDiasLibresMinimos";
            this.lblDiasLibresMinimos.Size = new System.Drawing.Size(159, 19);
            this.lblDiasLibresMinimos.TabIndex = 20;
            this.lblDiasLibresMinimos.Text = "Filtro Días Libres Mínimos";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.chkListFiltrosHoraDias);
            this.metroPanel1.Controls.Add(this.btnAgregarFiltroHoraDia);
            this.metroPanel1.Controls.Add(this.txtHoraFinFiltro);
            this.metroPanel1.Controls.Add(this.metroLabel13);
            this.metroPanel1.Controls.Add(this.txtHoraInicioFiltro);
            this.metroPanel1.Controls.Add(this.metroLabel12);
            this.metroPanel1.Controls.Add(this.comboDias);
            this.metroPanel1.Controls.Add(this.metroLabel11);
            this.metroPanel1.Controls.Add(this.lblFiltroHoraDia);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(141, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(551, 420);
            this.metroPanel1.TabIndex = 20;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // chkListFiltrosHoraDias
            // 
            this.chkListFiltrosHoraDias.CheckOnClick = true;
            this.chkListFiltrosHoraDias.FormattingEnabled = true;
            this.chkListFiltrosHoraDias.Location = new System.Drawing.Point(227, 80);
            this.chkListFiltrosHoraDias.Name = "chkListFiltrosHoraDias";
            this.chkListFiltrosHoraDias.Size = new System.Drawing.Size(251, 229);
            this.chkListFiltrosHoraDias.TabIndex = 23;
            this.chkListFiltrosHoraDias.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListFiltrosHoraDias_ItemCheck);
            // 
            // btnAgregarFiltroHoraDia
            // 
            this.btnAgregarFiltroHoraDia.Location = new System.Drawing.Point(78, 286);
            this.btnAgregarFiltroHoraDia.Name = "btnAgregarFiltroHoraDia";
            this.btnAgregarFiltroHoraDia.Size = new System.Drawing.Size(101, 23);
            this.btnAgregarFiltroHoraDia.TabIndex = 22;
            this.btnAgregarFiltroHoraDia.Text = "Agregar Filtro";
            this.btnAgregarFiltroHoraDia.UseSelectable = true;
            this.btnAgregarFiltroHoraDia.Click += new System.EventHandler(this.btnAgregarFiltroHoraDia_Click);
            // 
            // txtHoraFinFiltro
            // 
            this.txtHoraFinFiltro.Lines = new string[0];
            this.txtHoraFinFiltro.Location = new System.Drawing.Point(118, 209);
            this.txtHoraFinFiltro.MaxLength = 32767;
            this.txtHoraFinFiltro.Name = "txtHoraFinFiltro";
            this.txtHoraFinFiltro.PasswordChar = '\0';
            this.txtHoraFinFiltro.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHoraFinFiltro.SelectedText = "";
            this.txtHoraFinFiltro.Size = new System.Drawing.Size(75, 23);
            this.txtHoraFinFiltro.TabIndex = 21;
            this.txtHoraFinFiltro.UseSelectable = true;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(28, 209);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(59, 19);
            this.metroLabel13.TabIndex = 20;
            this.metroLabel13.Text = "Hora Fin";
            // 
            // txtHoraInicioFiltro
            // 
            this.txtHoraInicioFiltro.Lines = new string[0];
            this.txtHoraInicioFiltro.Location = new System.Drawing.Point(118, 149);
            this.txtHoraInicioFiltro.MaxLength = 32767;
            this.txtHoraInicioFiltro.Name = "txtHoraInicioFiltro";
            this.txtHoraInicioFiltro.PasswordChar = '\0';
            this.txtHoraInicioFiltro.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHoraInicioFiltro.SelectedText = "";
            this.txtHoraInicioFiltro.Size = new System.Drawing.Size(75, 23);
            this.txtHoraInicioFiltro.TabIndex = 19;
            this.txtHoraInicioFiltro.UseSelectable = true;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(28, 149);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(72, 19);
            this.metroLabel12.TabIndex = 18;
            this.metroLabel12.Text = "Hora Inicio";
            // 
            // comboDias
            // 
            this.comboDias.FormattingEnabled = true;
            this.comboDias.ItemHeight = 23;
            this.comboDias.Location = new System.Drawing.Point(78, 80);
            this.comboDias.Name = "comboDias";
            this.comboDias.Size = new System.Drawing.Size(121, 29);
            this.comboDias.TabIndex = 17;
            this.comboDias.UseSelectable = true;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(28, 80);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(28, 19);
            this.metroLabel11.TabIndex = 16;
            this.metroLabel11.Text = "Dia";
            // 
            // lblFiltroHoraDia
            // 
            this.lblFiltroHoraDia.AutoSize = true;
            this.lblFiltroHoraDia.Location = new System.Drawing.Point(194, 17);
            this.lblFiltroHoraDia.Name = "lblFiltroHoraDia";
            this.lblFiltroHoraDia.Size = new System.Drawing.Size(96, 19);
            this.lblFiltroHoraDia.TabIndex = 15;
            this.lblFiltroHoraDia.Text = "Filtro Hora/Dia";
            // 
            // tabHorarios
            // 
            this.tabHorarios.Controls.Add(this.lblHorarioNumero);
            this.tabHorarios.Controls.Add(this.favoritebox);
            this.tabHorarios.Controls.Add(this.lblListaHorarios);
            this.tabHorarios.Controls.Add(this.metroLabel15);
            this.tabHorarios.Controls.Add(this.metroButton1);
            this.tabHorarios.Controls.Add(this.metroToggle1);
            this.tabHorarios.Controls.Add(this.lblHorariosGenerados);
            this.tabHorarios.Controls.Add(this.listView1);
            this.tabHorarios.Controls.Add(this.btnAnteriorHorario);
            this.tabHorarios.Controls.Add(this.btnSiguienteHorario);
            this.tabHorarios.Controls.Add(this.dataGrid);
            this.tabHorarios.Location = new System.Drawing.Point(23, 4);
            this.tabHorarios.Name = "tabHorarios";
            this.tabHorarios.Size = new System.Drawing.Size(1167, 666);
            this.tabHorarios.TabIndex = 3;
            this.tabHorarios.Text = "Horarios Autmoáticos";
            this.tabHorarios.UseVisualStyleBackColor = true;
            // 
            // lblHorarioNumero
            // 
            this.lblHorarioNumero.AutoSize = true;
            this.lblHorarioNumero.Location = new System.Drawing.Point(284, 12);
            this.lblHorarioNumero.Name = "lblHorarioNumero";
            this.lblHorarioNumero.Size = new System.Drawing.Size(14, 19);
            this.lblHorarioNumero.TabIndex = 23;
            this.lblHorarioNumero.Text = "/";
            // 
            // favoritebox
            // 
            this.favoritebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.favoritebox.Location = new System.Drawing.Point(496, 4);
            this.favoritebox.Name = "favoritebox";
            this.favoritebox.Size = new System.Drawing.Size(30, 30);
            this.favoritebox.TabIndex = 22;
            this.favoritebox.TabStop = false;
            this.favoritebox.Click += new System.EventHandler(this.favoritebox_Click);
            // 
            // lblListaHorarios
            // 
            this.lblListaHorarios.AutoSize = true;
            this.lblListaHorarios.Location = new System.Drawing.Point(743, 12);
            this.lblListaHorarios.Name = "lblListaHorarios";
            this.lblListaHorarios.Size = new System.Drawing.Size(72, 19);
            this.lblListaHorarios.TabIndex = 21;
            this.lblListaHorarios.Text = "Generados";
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(790, 16);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(25, 19);
            this.metroLabel15.TabIndex = 20;
            this.metroLabel15.Text = "    ";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(876, 10);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(99, 23);
            this.metroButton1.TabIndex = 19;
            this.metroButton1.Text = "Exportar a Excel";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Location = new System.Drawing.Point(790, 14);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 17);
            this.metroToggle1.TabIndex = 18;
            this.metroToggle1.Text = "Off";
            this.metroToggle1.UseSelectable = true;
            this.metroToggle1.CheckedChanged += new System.EventHandler(this.metroToggle1_CheckedChanged);
            // 
            // lblHorariosGenerados
            // 
            this.lblHorariosGenerados.AutoSize = true;
            this.lblHorariosGenerados.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorariosGenerados.Location = new System.Drawing.Point(73, 9);
            this.lblHorariosGenerados.Name = "lblHorariosGenerados";
            this.lblHorariosGenerados.Size = new System.Drawing.Size(205, 25);
            this.lblHorariosGenerados.TabIndex = 5;
            this.lblHorariosGenerados.Text = "Horarios Generados";
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.Location = new System.Drawing.Point(109, 561);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(833, 50);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnAnteriorHorario
            // 
            this.btnAnteriorHorario.Enabled = false;
            this.btnAnteriorHorario.Location = new System.Drawing.Point(25, 561);
            this.btnAnteriorHorario.Name = "btnAnteriorHorario";
            this.btnAnteriorHorario.Size = new System.Drawing.Size(78, 23);
            this.btnAnteriorHorario.TabIndex = 3;
            this.btnAnteriorHorario.Text = "Anterior";
            this.btnAnteriorHorario.UseSelectable = true;
            this.btnAnteriorHorario.Click += new System.EventHandler(this.btnAnteriorHorario_Click);
            // 
            // btnSiguienteHorario
            // 
            this.btnSiguienteHorario.Enabled = false;
            this.btnSiguienteHorario.Location = new System.Drawing.Point(948, 561);
            this.btnSiguienteHorario.Name = "btnSiguienteHorario";
            this.btnSiguienteHorario.Size = new System.Drawing.Size(78, 23);
            this.btnSiguienteHorario.TabIndex = 2;
            this.btnSiguienteHorario.Text = "Siguiente";
            this.btnSiguienteHorario.UseSelectable = true;
            this.btnSiguienteHorario.Click += new System.EventHandler(this.btnSiguienteHorario_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.Enabled = false;
            this.dataGrid.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGrid.Location = new System.Drawing.Point(73, 37);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.ShowCellToolTips = false;
            this.dataGrid.ShowEditingIcon = false;
            this.dataGrid.Size = new System.Drawing.Size(905, 518);
            this.dataGrid.TabIndex = 0;
            // 
            // tabManual
            // 
            this.tabManual.Controls.Add(this.panel2);
            this.tabManual.Controls.Add(this.dataGridManual);
            this.tabManual.Controls.Add(this.lblHorariosManuales);
            this.tabManual.Location = new System.Drawing.Point(23, 4);
            this.tabManual.Name = "tabManual";
            this.tabManual.Size = new System.Drawing.Size(1167, 666);
            this.tabManual.TabIndex = 4;
            this.tabManual.Text = "Horario Manual";
            this.tabManual.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(891, -4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 674);
            this.panel2.TabIndex = 8;
            // 
            // dataGridManual
            // 
            this.dataGridManual.AllowUserToAddRows = false;
            this.dataGridManual.AllowUserToDeleteRows = false;
            this.dataGridManual.AllowUserToResizeColumns = false;
            this.dataGridManual.AllowUserToResizeRows = false;
            this.dataGridManual.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridManual.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridManual.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridManual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridManual.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridManual.Enabled = false;
            this.dataGridManual.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridManual.Location = new System.Drawing.Point(63, 51);
            this.dataGridManual.MultiSelect = false;
            this.dataGridManual.Name = "dataGridManual";
            this.dataGridManual.ReadOnly = true;
            this.dataGridManual.RowHeadersVisible = false;
            this.dataGridManual.ShowCellToolTips = false;
            this.dataGridManual.ShowEditingIcon = false;
            this.dataGridManual.Size = new System.Drawing.Size(822, 518);
            this.dataGridManual.TabIndex = 7;
            // 
            // lblHorariosManuales
            // 
            this.lblHorariosManuales.AutoSize = true;
            this.lblHorariosManuales.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorariosManuales.Location = new System.Drawing.Point(58, 23);
            this.lblHorariosManuales.Name = "lblHorariosManuales";
            this.lblHorariosManuales.Size = new System.Drawing.Size(193, 25);
            this.lblHorariosManuales.TabIndex = 6;
            this.lblHorariosManuales.Text = "Horarios Manuales";
            // 
            // lblGeneracionCombinaciones
            // 
            this.lblGeneracionCombinaciones.AutoSize = true;
            this.lblGeneracionCombinaciones.Location = new System.Drawing.Point(1148, 60);
            this.lblGeneracionCombinaciones.Name = "lblGeneracionCombinaciones";
            this.lblGeneracionCombinaciones.Size = new System.Drawing.Size(185, 19);
            this.lblGeneracionCombinaciones.TabIndex = 15;
            this.lblGeneracionCombinaciones.Text = "Generando Combinaciones. . .";
            this.lblGeneracionCombinaciones.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnMisHorarios);
            this.panel1.Controls.Add(this.metroButton4);
            this.panel1.Controls.Add(this.btnGenerar);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Location = new System.Drawing.Point(-1, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 674);
            this.panel1.TabIndex = 16;
            // 
            // btnMisHorarios
            // 
            this.btnMisHorarios.BackgroundImage = global::InterfazCliente.Properties.Resources.Star1;
            this.btnMisHorarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMisHorarios.Location = new System.Drawing.Point(24, 194);
            this.btnMisHorarios.Name = "btnMisHorarios";
            this.btnMisHorarios.Size = new System.Drawing.Size(151, 35);
            this.btnMisHorarios.TabIndex = 27;
            this.btnMisHorarios.Text = "Mis Horarios";
            this.btnMisHorarios.UseSelectable = true;
            this.btnMisHorarios.Click += new System.EventHandler(this.btnMisHorarios_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("metroButton4.BackgroundImage")));
            this.metroButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.metroButton4.Location = new System.Drawing.Point(24, 156);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(151, 35);
            this.metroButton4.TabIndex = 26;
            this.metroButton4.Text = "Manual";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerar.BackgroundImage")));
            this.btnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGenerar.Location = new System.Drawing.Point(24, 117);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(151, 35);
            this.btnGenerar.TabIndex = 25;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseSelectable = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHome.Location = new System.Drawing.Point(24, 78);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(151, 35);
            this.btnHome.TabIndex = 24;
            this.btnHome.Text = "Home";
            this.btnHome.UseSelectable = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click_1);
            // 
            // treeMateria
            // 
            this.treeMateria.CheckBoxes = true;
            this.treeMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.treeMateria.Location = new System.Drawing.Point(114, 305);
            this.treeMateria.Name = "treeMateria";
            this.treeMateria.ShowLines = false;
            this.treeMateria.ShowPlusMinus = false;
            this.treeMateria.Size = new System.Drawing.Size(378, 181);
            this.treeMateria.TabIndex = 20;
            this.treeMateria.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeMateria_AfterCheck_1);
            this.treeMateria.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMateria_AfterSelect);
            // 
            // treeConjuntoMaterias
            // 
            this.treeConjuntoMaterias.CheckBoxes = true;
            this.treeConjuntoMaterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.treeConjuntoMaterias.Location = new System.Drawing.Point(261, 173);
            this.treeConjuntoMaterias.Name = "treeConjuntoMaterias";
            this.treeConjuntoMaterias.ShowLines = false;
            this.treeConjuntoMaterias.ShowPlusMinus = false;
            this.treeConjuntoMaterias.Size = new System.Drawing.Size(231, 106);
            this.treeConjuntoMaterias.TabIndex = 19;
            this.treeConjuntoMaterias.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeConjuntoMaterias_AfterCheck);
            this.treeConjuntoMaterias.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeConjuntoMaterias_AfterSelect);
            this.treeConjuntoMaterias.DoubleClick += new System.EventHandler(this.treeSemestre_DoubleClick);
            // 
            // treeGrupo
            // 
            this.treeGrupo.CheckBoxes = true;
            this.treeGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.treeGrupo.Location = new System.Drawing.Point(570, 81);
            this.treeGrupo.Name = "treeGrupo";
            this.treeGrupo.ShowLines = false;
            this.treeGrupo.ShowPlusMinus = false;
            this.treeGrupo.Size = new System.Drawing.Size(456, 405);
            this.treeGrupo.TabIndex = 18;
            this.treeGrupo.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeGrupo_AfterCheck);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 758);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblGeneracionCombinaciones);
            this.Name = "Form1";
            this.Text = "Easy Hour Functional Test - Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSelecArchivo.ResumeLayout(false);
            this.tabSelecArchivo.PerformLayout();
            this.tabSelecCombinacion.ResumeLayout(false);
            this.tabSelecCombinacion.PerformLayout();
            this.TabFiltros.ResumeLayout(false);
            this.TabFiltros.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.tabHorarios.ResumeLayout(false);
            this.tabHorarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.favoritebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.tabManual.ResumeLayout(false);
            this.tabManual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridManual)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSelecArchivo;
        private MetroFramework.Controls.MetroTextBox txtNombreArchivo;
        private MetroFramework.Controls.MetroButton btnSeleccionarArchivo;
        private MetroFramework.Controls.MetroLabel lblSeleccionarArchivo;
        private MetroFramework.Controls.MetroComboBox comboCarreras;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TabPage tabSelecCombinacion;
        private MetroFramework.Controls.MetroButton btnCarga;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox comboCarreraActual;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroCheckBox chkSimultaneidad;
        private MetroFramework.Controls.MetroLabel lblCargandoCarrera;
        private System.Windows.Forms.TabPage TabFiltros;
        private MyTreeView treeConjuntoMaterias;
        private MyTreeView treeGrupo;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroCheckBox chkEnSemana;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroComboBox comboCantidadDiasLibres;
        private MetroFramework.Controls.MetroLabel lblDiasLibresMinimos;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.CheckedListBox chkListFiltrosHoraDias;
        private MetroFramework.Controls.MetroButton btnAgregarFiltroHoraDia;
        private MetroFramework.Controls.MetroTextBox txtHoraFinFiltro;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox txtHoraInicioFiltro;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroComboBox comboDias;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel lblFiltroHoraDia;
        private System.Windows.Forms.TabPage tabHorarios;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ListView listView1;
        private MetroFramework.Controls.MetroButton btnAnteriorHorario;
        private MetroFramework.Controls.MetroButton btnSiguienteHorario;
        private System.Windows.Forms.Label lblHorariosGenerados;
        private MetroFramework.Controls.MetroLabel lblGeneracionCombinaciones;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroToggle metroToggle1;
        private MetroFramework.Controls.MetroLabel lblListaHorarios;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private System.Windows.Forms.PictureBox favoritebox;
        private MetroFramework.Controls.MetroLabel lblHorarioNumero;
        private System.Windows.Forms.TabPage tabManual;
        private System.Windows.Forms.DataGridView dataGridManual;
        private System.Windows.Forms.Label lblHorariosManuales;
        private MyTreeView treeMateria;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton btnGenerar;
        private MetroFramework.Controls.MetroButton btnHome;
        private MetroFramework.Controls.MetroButton btnGenerarCombinaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroButton btnFiltarHorarios;
        private MetroFramework.Controls.MetroButton btnMisHorarios;
        private System.Windows.Forms.Panel panel2;
        private MetroFramework.Controls.MetroButton btnAtrasSel;
        private MetroFramework.Controls.MetroLabel lblModo;
        private MetroFramework.Controls.MetroComboBox comboModos;
    }
}

