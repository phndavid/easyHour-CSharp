using MetroFramework.Forms;
using Mundo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace InterfazCliente
{
    public partial class Form1 : MetroForm
    {
        public EasyHour principal { get; set; }

        public TreeNode lastConjuntoMaterias { get; set; }
        public TreeNode lastMateria { get; set; }
        public int PosHorario { get; set; }
        public List<Horario> HorariosActuales { get; set; }

        public bool ReinicioSemestre { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            principal = new EasyHour();
            string[] carreras = new string[]
            {
                "INGENIERÍA DE SISTEMAS",
                "INGENIERÍA TELEMÁTICA",
                "ECONOMÍA Y NEGOCIOS INTERNACIONALES",
                "ADMINISTRACIÓN DE EMPRESAS",
                "DERECHO",
                "ANTROPOLOGIÍA",
                "BIOLOGÍA",
                "DISEÑO DE MEDIOS INTERACTIVOS",
                "MERCADEO INTERNACIONAL Y PUBLICIDAD",
                "INGENIERÍA INDUSTRIAL",
                "CIENCIAS POLÍTICAS",
                "PSICOLOGÍA",
                "SOCIOLOGÍA",
                "QUÍMICA FARMACEUTICA",
                "CONTABILIDAD Y FINANZAS"
            };

            foreach (string s in carreras)
                comboCarreras.Items.Add(s);

            string[] dias = new string[]
            {
                "Lunes",
                "Martes",
                "Miercoles",
                "Jueves",
                "Viernes!",
                "Sabado",
                "Domingo"
            };

            string[] modos = new string[]
            {
                "Principales",
                "Inglés",
                "Electivas"
            };

            foreach (string s in modos)
                comboModos.Items.Add(s);
            comboModos.SelectedIndex = 0;

            comboDias.Items.Add("Todos los Días");
            foreach (string s in dias)
            {
                comboDias.Items.Add(s);
                chkListFiltrosHoraDias.Items.Add("FullDay - " + s);
            }

            comboCantidadDiasLibres.Items.Add("Sin Filtro");
            for (int i = 0; i < 7; i++)
                comboCantidadDiasLibres.Items.Add(i + 1 + "");
            comboCantidadDiasLibres.SelectedIndex = 0;

            dataGrid.ColumnCount = 7;
            dataGridManual.ColumnCount = 7;
            dataGrid.ColumnHeadersVisible = false;
            dataGridManual.ColumnHeadersVisible = false;
            var dayRow = new DataGridViewRow();
            var dayRowManual = new DataGridViewRow();
            for (int i = 0; i < 7; i++)
            {
                dataGrid.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridManual.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dayRow.Cells.Add(new DataGridViewTextBoxCell()
                {
                    Value = dias[i]
                });
                dayRowManual.Cells.Add(new DataGridViewTextBoxCell()
                {
                    Value = dias[i]
                });
            }
            dataGrid.Rows.Add(dayRow);
            dataGridManual.Rows.Add(dayRowManual);
            dataGrid.DefaultCellStyle.SelectionBackColor = dataGrid.DefaultCellStyle.BackColor;
            dataGrid.DefaultCellStyle.SelectionForeColor = dataGrid.DefaultCellStyle.ForeColor;
            dataGridManual.DefaultCellStyle.SelectionBackColor = dataGrid.DefaultCellStyle.BackColor;
            dataGridManual.DefaultCellStyle.SelectionForeColor = dataGrid.DefaultCellStyle.ForeColor;

            favoritebox.Image = InterfazCliente.Properties.Resources.Star2;
            HorariosActuales = new List<Horario>();

            var tt1 = new ToolTip();
            tt1.ToolTipIcon = ToolTipIcon.Info;
            tt1.ShowAlways = true;
            tt1.IsBalloon = true;
            tt1.SetToolTip(lblSeleccionarArchivo, "Debes seleccionar el archivo ordenado de la carrera.");
            tt1.SetToolTip(lblFiltroHoraDia, "Los filtros Hora/Día, Todos los días y FullDay " + Environment.NewLine + "sirven para excluir los horarios que cumplen las condiciones" +
                Environment.NewLine + "FullDay: Elimina los horarios que tengan clase los días filtrados" +
                Environment.NewLine + "Todos los días: Elimina los horarios que tengan clase a cierta hora en algún día de la semana" +
                Environment.NewLine + "Día específico / Hora: Elimina los horarios que tienen clase en un día y hora especificos.");
            tt1.SetToolTip(lblDiasLibresMinimos, "El filtro de días minimos libres sirve para excluir a los horarios que no tengan" +
                Environment.NewLine + "como mínimo la cantidad especificada de días libres" +
                Environment.NewLine + "Excluir sábados y domingos: sólo tiene en cuenta los horarios con días mínimos libres entre semana.");
            tt1.SetToolTip(lblHorariosGenerados, "Aquí, después de seleccionar algunas materias y grupos, puedes generar todas las combinaciones" +
                Environment.NewLine + "con la cantidad de materias seleccionadas.");

            //this.Size = new Size((int)(Screen.PrimaryScreen.Bounds.Width * 0.45), (int)(Screen.PrimaryScreen.Bounds.Height*0.6)); 
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "XLSX files|*.xlsx";
            theDialog.InitialDirectory = @"C:\";
            if (theDialog.ShowDialog() == DialogResult.OK)
                txtNombreArchivo.Text = theDialog.FileName;
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            string nombreCarrera = (string)comboCarreras.SelectedItem;
            string nombreArchivo = txtNombreArchivo.Text;
            bool simultaneidad = chkSimultaneidad.Checked;
            lblCargandoCarrera.Visible = true;
            try
            {
                Carrera c = principal.cargarCarrera(nombreCarrera, simultaneidad, nombreArchivo);
                if (c != null)
                    comboCarreraActual.Items.Add(c);
                MessageBox.Show("Ha cargado la carrera " + nombreCarrera, "Carga Finalizada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Carga");
                Debug.PrintException(ex);
            }
            lblCargandoCarrera.Visible = false;
        }

        private void btnGenerarCombinaciones_Click(object sender, EventArgs e)
        {
            lblGeneracionCombinaciones.Visible = true;
            string dias = (string)comboCantidadDiasLibres.SelectedItem;
            int cantidadDiasFiltro = (dias != "Sin Filtro") ? cantidadDiasFiltro = Convert.ToInt32(dias) : 0;
            try
            {
                PosHorario = 0;
                HorariosActuales = principal.GenerarHorarios(cantidadDiasFiltro, chkEnSemana.Checked);
                refrescarEstadoBoton();
                llenarListaNumerosHorario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Debug.PrintException(ex);
            }
            if (HorariosActuales.Count == 0)
                MessageBox.Show("No existen combinaciones generadas para las materias, grupos, cantidad de materias y filtros seleccionados", "No Hay Combinaciones");
            else
                pintarHorarioGridView(HorariosActuales[0]);
            lblGeneracionCombinaciones.Visible = false;
        }

        public void pintarHorarioGridView(Horario h)
        {
            int rowCount = 0;
            limpiarDataGridView();
            Dictionary<string, Color> colores = FileManager.AsignarColores(principal.Materias);
            foreach (Grupo g in h)
            {
                var row = new DataGridViewRow();
                for (int i = 0; i < 7; i++)
                {
                    row.Cells.Add(new DataGridViewTextBoxCell()
                    {
                        Value = ""
                    });
                }
                foreach (Clase c in g.Clases)
                {
                    int dia = c.NumeroDia;

                    row.Cells[dia].Value = FileManager.reporteClase(g, c);
                    row.Cells[dia].Style.BackColor = colores[g.Materia.Nombre];
                }
                rowCount++;
                dataGrid.Rows.Add(row);
            }
        }

        public void limpiarDataGridView()
        {
            for (int i = dataGrid.Rows.Count - 1; i >= 1; i--)
                dataGrid.Rows.RemoveAt(i);
        }

        private void comboCarreraActual_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiarAllTrees(false);
            Carrera carrera = (Carrera)comboCarreraActual.SelectedItem;
            if (carrera != null)
            {
                refrescarConjuntosMaterias();
                treeMateria.Nodes.Clear();
                treeGrupo.Nodes.Clear();
            }
            cambiarAllTrees(true);
        }
        private void btnAgregarFiltroHoraDia_Click(object sender, EventArgs e)
        {
            string item = (string)comboDias.SelectedItem;
            string inicio = txtHoraInicioFiltro.Text;
            string fin = txtHoraFinFiltro.Text;
            if (item != null && txtHoraInicioFiltro.Text != "" && txtHoraFinFiltro.Text != "" && Clase.verificarHoras(inicio, fin))
            {
                string filtro = item + " De: " + inicio + " A: " + fin;
                chkListFiltrosHoraDias.Items.Add(filtro);
                chkListFiltrosHoraDias.SelectedItem = filtro;
                chkListFiltrosHoraDias.SetItemChecked(chkListFiltrosHoraDias.Items.Count - 1, true);
            }
        }

        private void chkListFiltrosHoraDias_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ;
            string item = (string)chkListFiltrosHoraDias.SelectedItem;
            if (item != null)
            {
                string[] data = item.Split(' ');
                bool check = !chkListFiltrosHoraDias.GetItemChecked(chkListFiltrosHoraDias.SelectedIndex);
                if (data[0] == "FullDay")
                {
                    if (check)
                        principal.DiasFiltrados.Add(Clase.GetDiaFullStringToInt(data[2]));
                    else
                        principal.DiasFiltrados.Remove(Clase.GetDiaFullStringToInt(data[2]));
                }
                else
                {
                    string inicio = txtHoraInicioFiltro.Text;
                    string fin = txtHoraFinFiltro.Text;
                    string filtro = ((data[0] == "Todos") ? item.Replace("Todos los Días", "Semana") : item);
                    if (check)
                        principal.FiltrosHoraDia.Add(filtro);
                    else
                        principal.FiltrosHoraDia.Remove(filtro);
                }
            }
        }

        public void refrescarConjuntosMaterias()
        {
            string modo = (string)comboModos.SelectedItem;
            if (modo == "Principales")
            {
                refrescarSemestres();
                lblModo.Text = "Semestres";
            }
            else if (modo == "Inglés")
            {
                refrescarIngles();
                lblModo.Text = "Inglés";
            }
            else
            {
                refrscarCategoriasElectivas();
                lblModo.Text = "Categorías Electivas";
            }
            treeConjuntoMaterias.Refresh();
        }

        public void refrescarSemestres()
        {
            treeConjuntoMaterias.Nodes.Clear();
            Carrera carrera = (Carrera)comboCarreraActual.SelectedItem;
            if (carrera != null)
            {
                for (int i = 1; i < carrera.Semestres.Count; i++)
                {
                    Semestre s = carrera.Semestres[i];
                    treeConjuntoMaterias.Nodes.Add(s.ToString());
                    treeConjuntoMaterias.Nodes[treeConjuntoMaterias.GetNodeCount(false) - 1].Tag = s;
                    treeConjuntoMaterias.Nodes[treeConjuntoMaterias.GetNodeCount(false) - 1].Checked = s.Estado;
                }
            }
            treeConjuntoMaterias.SelectedNode = null;
        }

        public void refrescarIngles()
        {
            treeConjuntoMaterias.Nodes.Clear();
            treeConjuntoMaterias.Nodes.Add(principal.Ingles.ToString());
            treeConjuntoMaterias.Nodes[treeConjuntoMaterias.GetNodeCount(false) - 1].Tag = principal.Ingles;
            treeConjuntoMaterias.Nodes[treeConjuntoMaterias.GetNodeCount(false) - 1].Checked = principal.Ingles.Estado;
            treeConjuntoMaterias.SelectedNode = null;
        }

        public void refrscarCategoriasElectivas()
        {
            treeConjuntoMaterias.Nodes.Clear();
            List<ConjuntoMaterias> electivas = principal.CategoriasElectivas;
            for (int i = 1; i < electivas.Count; i++)
            {
                ConjuntoMaterias categoria = electivas[i];
                treeConjuntoMaterias.Nodes.Add(categoria.ToString());
                treeConjuntoMaterias.Nodes[treeConjuntoMaterias.GetNodeCount(false) - 1].Tag = categoria;
                treeConjuntoMaterias.Nodes[treeConjuntoMaterias.GetNodeCount(false) - 1].Checked = categoria.Estado;
            }
            treeConjuntoMaterias.SelectedNode = null;
        }

        public void refrescarMaterias(ConjuntoMaterias conjunto)
        {
            treeMateria.Nodes.Clear();
            foreach (Materia m in conjunto.Materias)
            {
                treeMateria.Nodes.Add(m.ToString());
                treeMateria.Nodes[treeMateria.GetNodeCount(false) - 1].Tag = m;
                treeMateria.Nodes[treeMateria.GetNodeCount(false) - 1].Checked = m.Estado;
            }
            treeMateria.SelectedNode = null;
            treeMateria.Refresh();
        }

        public void refrescarGrupos(Materia materia)
        {
            treeGrupo.Nodes.Clear();
            foreach (Grupo g in materia.Grupos)
            {
                treeGrupo.Nodes.Add(g.ToString());
                treeGrupo.Nodes[treeGrupo.GetNodeCount(false) - 1].Tag = g;
                treeGrupo.Nodes[treeGrupo.GetNodeCount(false) - 1].Checked = g.Estado;
            }
            treeGrupo.Refresh();
        }
        private void treeConjuntoMaterias_AfterSelect(object sender, TreeViewEventArgs e)
        {
            cambiarAllTrees(false);
            lastConjuntoMaterias = e.Node;
            ConjuntoMaterias conjunto = (ConjuntoMaterias)lastConjuntoMaterias.Tag;
            refrescarMaterias(conjunto);
            treeGrupo.Nodes.Clear();
            cambiarAllTrees(true);
        }

        private void treeConjuntoMaterias_AfterCheck(object sender, TreeViewEventArgs e)
        {
            cambiarAllTrees(false);
            lastConjuntoMaterias = e.Node;
            treeConjuntoMaterias.SelectedNode = lastConjuntoMaterias;
            ConjuntoMaterias conjuntoMaterias = (ConjuntoMaterias)lastConjuntoMaterias.Tag;
            conjuntoMaterias.Estado = (e.Node.Checked);
            principal.cambiarEstadoMaterias(conjuntoMaterias);
            refrescarMaterias(conjuntoMaterias);
            treeGrupo.Nodes.Clear();
            cambiarAllTrees(true);
        }

        private void treeMateria_AfterCheck_1(object sender, TreeViewEventArgs e)
        {
            cambiarAllTrees(false);
            TreeNode node = e.Node;
            Materia materia = (Materia)node.Tag;
            lastMateria = node;
            treeMateria.SelectedNode = lastMateria;
            materia.Estado = node.Checked;
            if (materia.Estado)
                principal.Materias.Add(materia);
            else
                principal.Materias.Remove(materia);
            bool has = hasCheckedNodes(treeMateria);
            if (!has)
            {
                lastConjuntoMaterias.Checked = false;
                ((ConjuntoMaterias)lastConjuntoMaterias.Tag).Estado = false;
                refrescarConjuntosMaterias();
            }
            principal.cambiarEstadoGrupos(materia);
            refrescarGrupos(materia);
            if (lastConjuntoMaterias != null && lastConjuntoMaterias.Checked == false && lastMateria.Checked)
            {
                lastConjuntoMaterias.Checked = true;
                ((ConjuntoMaterias)lastConjuntoMaterias.Tag).Estado = true;
                refrescarConjuntosMaterias();
            }
            cambiarAllTrees(true);
        }

        private void treeMateria_AfterSelect(object sender, TreeViewEventArgs e)
        {
            cambiarAllTrees(false);
            lastMateria = e.Node;
            Materia materia = (Materia)lastMateria.Tag;
            materia.Estado = e.Node.Checked;
            treeGrupo.Nodes.Clear();
            refrescarGrupos(materia);
            cambiarAllTrees(true);
        }

        private void treeGrupo_AfterCheck(object sender, TreeViewEventArgs e)
        {
            cambiarAllTrees(false);
            TreeNode node = e.Node;
            Grupo grupo = (Grupo)node.Tag;
            grupo.Estado = node.Checked;
            if (grupo.Estado)
                principal.Grupos.Add(grupo);
            else
                principal.Grupos.Remove(grupo);
            if (!lastMateria.Checked)
            {
                lastMateria.Checked = true;
                if (lastConjuntoMaterias != null && lastConjuntoMaterias.Checked == false)
                {
                    lastConjuntoMaterias.Checked = true;
                    ((ConjuntoMaterias)lastConjuntoMaterias.Tag).Estado = true;
                    refrescarConjuntosMaterias();
                }
            }
            else
            {
                bool has = hasCheckedNodes(treeGrupo);
                if (!has)
                {
                    lastMateria.Checked = false;
                    bool has2 = hasCheckedNodes(treeMateria);
                    if (!has2)
                    {
                        lastConjuntoMaterias.Checked = false;
                        ((ConjuntoMaterias)lastConjuntoMaterias.Tag).Estado = false;
                        refrescarConjuntosMaterias();
                    }
                    ((Materia)lastMateria.Tag).Estado = false;
                }
            }
            cambiarAllTrees(true);
        }
        public bool hasCheckedNodes(MyTreeView tree)
        {
            bool has = false;
            for (int i = 0; i < tree.Nodes.Count && !has; i++)
                if (tree.Nodes[i].Checked) has = true;
            return has;
        }

        public void cambiarEventosTree(bool estado, MyTreeView tree)
        {
            if (tree == treeConjuntoMaterias)
            {
                if (estado)
                {
                    treeConjuntoMaterias.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeConjuntoMaterias_AfterCheck);
                    treeConjuntoMaterias.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeConjuntoMaterias_AfterSelect);
                }
                else
                {
                    treeConjuntoMaterias.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.treeConjuntoMaterias_AfterCheck);
                    treeConjuntoMaterias.AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(this.treeConjuntoMaterias_AfterSelect);
                }
            }
            else if (tree == treeMateria)
            {
                if (estado)
                {
                    treeMateria.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeMateria_AfterCheck_1);
                    treeMateria.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMateria_AfterSelect);
                }
                else
                {
                    treeMateria.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.treeMateria_AfterCheck_1);
                    treeMateria.AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(this.treeMateria_AfterSelect);
                }
            }
            else
            {
                if (estado)
                {
                    treeGrupo.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeGrupo_AfterCheck);
                }
                else
                {
                    treeGrupo.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.treeGrupo_AfterCheck);
                }
            }
        }

        public void cambiarAllTrees(bool estado)
        {
            cambiarEventosTree(estado, treeConjuntoMaterias);
            cambiarEventosTree(estado, treeMateria);
            cambiarEventosTree(estado, treeGrupo);
        }
        private void treeSemestre_DoubleClick(object sender, EventArgs e)
        {
            var localPosition = treeConjuntoMaterias.PointToClient(Cursor.Position);
            var hitTestInfo = treeConjuntoMaterias.HitTest(localPosition);
            if (hitTestInfo.Location == TreeViewHitTestLocations.StateImage)
                return;
        }

        public void refrescarComponentesNavegacionHorarios()
        {
            refrescarEstadoBoton();
            refrescarFavorito();
            refrescarHorarioNumero();
            listView1.EnsureVisible(PosHorario);
        }

        private void btnSiguienteHorario_Click(object sender, EventArgs e)
        {
            List<Horario> horarios = (metroToggle1.Checked) ? principal.HorariosFavoritos : HorariosActuales;
            PosHorario++;
            Horario h = horarios[PosHorario];
            this.listView1.Items[PosHorario].Selected = true;
            refrescarComponentesNavegacionHorarios();
        }
        private void btnAnteriorHorario_Click(object sender, EventArgs e)
        {
            List<Horario> horarios = (metroToggle1.Checked) ? principal.HorariosFavoritos : HorariosActuales;
            PosHorario--;
            Horario h = horarios[PosHorario];
            this.listView1.Items[PosHorario].Selected = true;
            refrescarComponentesNavegacionHorarios();
        }
        public void refrescarEstadoBoton()
        {
            List<Horario> horarios = (metroToggle1.Checked) ? principal.HorariosFavoritos : HorariosActuales;
            if (horarios.Count <= 1)
            {
                btnSiguienteHorario.Enabled = false;
                btnAnteriorHorario.Enabled = false;
            }
            else
            {
                if (PosHorario == horarios.Count - 1)
                    btnSiguienteHorario.Enabled = false;
                else
                    btnSiguienteHorario.Enabled = true;
                if (PosHorario == 0)
                    btnAnteriorHorario.Enabled = false;
                else
                    btnAnteriorHorario.Enabled = true;
            }
        }

        public void llenarListaNumerosHorario(bool favoritos = false)
        {
            listView1.Items.Clear();
            List<Horario> horarios = (favoritos) ? principal.HorariosFavoritos : HorariosActuales;
            if (horarios != null)
            {
                for (int i = 0; i < horarios.Count; i++)
                    listView1.Items.Add("      " + (i + 1) + "      ");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                List<Horario> horarios = (metroToggle1.Checked && principal.HorariosFavoritos.Count > 0) ? principal.HorariosFavoritos : HorariosActuales;
                PosHorario = Convert.ToInt32(listView1.SelectedItems[0].Text) - 1;
                pintarHorarioGridView(horarios[PosHorario]);
                refrescarComponentesNavegacionHorarios();
            }
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            PosHorario = 0;
            limpiarDataGridView();
            if (metroToggle1.Checked)
            {
                lblListaHorarios.Text = "Favoritos";
                if (principal.HorariosFavoritos.Count > 0)
                {
                    pintarHorarioGridView(principal.HorariosFavoritos[0]);
                    llenarListaNumerosHorario(true);
                }
                else
                {
                    MessageBox.Show("No hay horarios favoritos" + Environment.NewLine + "Añada horarios a sus favoritos para visualizarlos", "Lista sin horarios");
                }
            }
            else
            {
                lblListaHorarios.Text = "Generados";
                if (HorariosActuales.Count > 0)
                {
                    pintarHorarioGridView(HorariosActuales[0]);
                    llenarListaNumerosHorario();
                }
                else
                    MessageBox.Show("No hay horarios generados" + Environment.NewLine + "Genere horarios para visualizarlos", "Lista sin horarios");
            }
            refrescarComponentesNavegacionHorarios();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            if (HorariosActuales.Count > 0)
            {
                List<Horario> horarios = (metroToggle1.Checked) ? principal.HorariosFavoritos : HorariosActuales;
                if (horarios.Count > 0)
                    FileManager.pintarHorariosExcel(horarios, principal.Materias);
                else
                    MessageBox.Show("La lista seleccionada no tiene ningún elemento.", "Error de exportación a Excel");
            }
            else
                MessageBox.Show("Antes de exportar debe generar horarios.", "Error de exportación a Excel");
        }

        private void favoritebox_Click(object sender, EventArgs e)
        {
            if (HorariosActuales.Count > 0)
            {
                List<Horario> horarios = (metroToggle1.Checked) ? principal.HorariosFavoritos : HorariosActuales;
                if (horarios.Count > 0)
                {
                    Horario h = horarios[PosHorario];
                    if (principal.HorariosFavoritos.Contains(h))
                    {
                        principal.HorariosFavoritos.Remove(h);
                        if (metroToggle1.Checked)
                        {
                            llenarListaNumerosHorario(true);
                            limpiarDataGridView();
                            PosHorario = 0;
                            if (horarios.Count > 0)
                                pintarHorarioGridView(horarios[0]);
                        }
                    }
                    else
                        principal.HorariosFavoritos.Add(h);
                    refrescarComponentesNavegacionHorarios();
                }
                else
                    MessageBox.Show("No hay un horario actual." + Environment.NewLine + "Genere horarios o seleccione una lista con horarios.", "Error al seleccionar favorito");
            }
            else
                MessageBox.Show("No hay horarios generados" + Environment.NewLine + "Seleccione materias (grupos) y presione Generar Combinaciones", "Error al seleccionar horario favorito");
        }

        public void refrescarFavorito()
        {
            if (HorariosActuales.Count > 0)
            {
                List<Horario> horarios = (metroToggle1.Checked) ? principal.HorariosFavoritos : HorariosActuales;
                if (horarios.Count > 0)
                {
                    if (principal.HorariosFavoritos.Contains(horarios[PosHorario]))
                        favoritebox.Image = InterfazCliente.Properties.Resources.Star1;
                    else
                        favoritebox.Image = InterfazCliente.Properties.Resources.Star2;
                }
            }
        }
    
        public void refrescarHorarioNumero()
        {
            lblHorarioNumero.Text = (PosHorario + 1)+"/"+HorariosActuales.Count;
        }

     
        private void btnHome_Click_1(object sender, EventArgs e)
        {
              tabControl1.SelectedTab = tabSelecArchivo;
              btnHome.Image = InterfazCliente.Properties.Resources.Star1;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSelecCombinacion;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabManual;
        }

        private void btnGenerarCombinaciones_Click_1(object sender, EventArgs e)
        {
            
            lblGeneracionCombinaciones.Visible = true;
            string dias = (string)comboCantidadDiasLibres.SelectedItem;
            int cantidadDiasFiltro = (dias != "Sin Filtro") ? cantidadDiasFiltro = Convert.ToInt32(dias) : 0;
            HorariosActuales = principal.GenerarHorarios(cantidadDiasFiltro, chkEnSemana.Checked);
            PosHorario = 0;
            refrescarEstadoBoton();
            llenarListaNumerosHorario();
            lblGeneracionCombinaciones.Visible = false;
            if (HorariosActuales.Count == 0)
                MessageBox.Show("No existen combinaciones generadas para las materias, grupos, cantidad de materias y filtros seleccionados", "No Hay Combinaciones");
            else
                pintarHorarioGridView(HorariosActuales[0]);
            
            tabControl1.SelectedTab = tabHorarios;
        }

        private void btnFiltarHorarios_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = TabFiltros;
        }

        private void btnMisHorarios_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHorarios;
        }

        private void btnAtrasSel_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabSelecCombinacion;
        }

        private void comboModos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cambiarAllTrees(false);
            refrescarConjuntosMaterias();
            treeMateria.Nodes.Clear();
            treeGrupo.Nodes.Clear();
            cambiarAllTrees(true);
        }

   
    }
}
