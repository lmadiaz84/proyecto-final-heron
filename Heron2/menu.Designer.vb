<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class menu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.instrumentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActualizacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActualizacionToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.RecepciònToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActualizaciònToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NotaDeEnvioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IngresarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IngresarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.instrumentoToolStripMenuItem, Me.ClientesToolStripMenuItem, Me.RecepciònToolStripMenuItem, Me.NotaDeEnvioToolStripMenuItem, Me.ReporteToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(624, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'instrumentoToolStripMenuItem
        '
        Me.instrumentoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizacionToolStripMenuItem})
        Me.instrumentoToolStripMenuItem.Name = "instrumentoToolStripMenuItem"
        Me.instrumentoToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
        Me.instrumentoToolStripMenuItem.Text = "Instrumentos"
        '
        'ActualizacionToolStripMenuItem
        '
        Me.ActualizacionToolStripMenuItem.Name = "ActualizacionToolStripMenuItem"
        Me.ActualizacionToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ActualizacionToolStripMenuItem.Text = "Ingresar"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizacionToolStripMenuItem1})
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'ActualizacionToolStripMenuItem1
        '
        Me.ActualizacionToolStripMenuItem1.Name = "ActualizacionToolStripMenuItem1"
        Me.ActualizacionToolStripMenuItem1.Size = New System.Drawing.Size(116, 22)
        Me.ActualizacionToolStripMenuItem1.Text = "Ingresar"
        '
        'RecepciònToolStripMenuItem
        '
        Me.RecepciònToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizaciònToolStripMenuItem})
        Me.RecepciònToolStripMenuItem.Name = "RecepciònToolStripMenuItem"
        Me.RecepciònToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.RecepciònToolStripMenuItem.Text = "Recepciòn"
        '
        'ActualizaciònToolStripMenuItem
        '
        Me.ActualizaciònToolStripMenuItem.Name = "ActualizaciònToolStripMenuItem"
        Me.ActualizaciònToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ActualizaciònToolStripMenuItem.Text = "Ingresar"
        '
        'NotaDeEnvioToolStripMenuItem
        '
        Me.NotaDeEnvioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IngresarToolStripMenuItem})
        Me.NotaDeEnvioToolStripMenuItem.Name = "NotaDeEnvioToolStripMenuItem"
        Me.NotaDeEnvioToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.NotaDeEnvioToolStripMenuItem.Text = "Nota de envio"
        '
        'IngresarToolStripMenuItem
        '
        Me.IngresarToolStripMenuItem.Name = "IngresarToolStripMenuItem"
        Me.IngresarToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.IngresarToolStripMenuItem.Text = "Ingresar"
        '
        'ReporteToolStripMenuItem
        '
        Me.ReporteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IngresarToolStripMenuItem1})
        Me.ReporteToolStripMenuItem.Name = "ReporteToolStripMenuItem"
        Me.ReporteToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ReporteToolStripMenuItem.Text = "Reporte"
        '
        'IngresarToolStripMenuItem1
        '
        Me.IngresarToolStripMenuItem1.Name = "IngresarToolStripMenuItem1"
        Me.IngresarToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.IngresarToolStripMenuItem1.Text = "Ingresar"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Blue
        Me.ClientSize = New System.Drawing.Size(624, 117)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "menu"
        Me.Text = "Menù"
        Me.TransparencyKey = System.Drawing.Color.Transparent
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents instrumentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActualizacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActualizacionToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecepciònToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActualizaciònToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotaDeEnvioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReporteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IngresarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
