<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Nota_de_envio1
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnant = New System.Windows.Forms.Button
        Me.btnsig = New System.Windows.Forms.Button
        Me.btneliminar = New System.Windows.Forms.Button
        Me.btnsalir = New System.Windows.Forms.Button
        Me.btncancelar = New System.Windows.Forms.Button
        Me.btnaceptar = New System.Windows.Forms.Button
        Me.btnmodificar = New System.Windows.Forms.Button
        Me.btnnuevo = New System.Windows.Forms.Button
        Me.cmb = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtn4 = New System.Windows.Forms.TextBox
        Me.txtn3 = New System.Windows.Forms.TextBox
        Me.txtn1 = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.btnsalir2 = New System.Windows.Forms.Button
        Me.btnnuevo2 = New System.Windows.Forms.Button
        Me.txtn5 = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.btnant2 = New System.Windows.Forms.Button
        Me.btnsig2 = New System.Windows.Forms.Button
        Me.btnaceptar2 = New System.Windows.Forms.Button
        Me.btncancelar2 = New System.Windows.Forms.Button
        Me.btnmodificar2 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtn6 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtn8 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtn7 = New System.Windows.Forms.TextBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(2, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(347, 336)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnant)
        Me.TabPage1.Controls.Add(Me.btnsig)
        Me.TabPage1.Controls.Add(Me.btneliminar)
        Me.TabPage1.Controls.Add(Me.btnsalir)
        Me.TabPage1.Controls.Add(Me.btncancelar)
        Me.TabPage1.Controls.Add(Me.btnaceptar)
        Me.TabPage1.Controls.Add(Me.btnmodificar)
        Me.TabPage1.Controls.Add(Me.btnnuevo)
        Me.TabPage1.Controls.Add(Me.cmb)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtn4)
        Me.TabPage1.Controls.Add(Me.txtn3)
        Me.TabPage1.Controls.Add(Me.txtn1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(339, 310)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Nota de envio"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnant
        '
        Me.btnant.Location = New System.Drawing.Point(105, 269)
        Me.btnant.Name = "btnant"
        Me.btnant.Size = New System.Drawing.Size(75, 23)
        Me.btnant.TabIndex = 60
        Me.btnant.Text = "<<"
        Me.btnant.UseVisualStyleBackColor = True
        '
        'btnsig
        '
        Me.btnsig.Location = New System.Drawing.Point(206, 269)
        Me.btnsig.Name = "btnsig"
        Me.btnsig.Size = New System.Drawing.Size(75, 23)
        Me.btnsig.TabIndex = 59
        Me.btnsig.Text = ">>"
        Me.btnsig.UseVisualStyleBackColor = True
        '
        'btneliminar
        '
        Me.btneliminar.Location = New System.Drawing.Point(148, 236)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(75, 23)
        Me.btneliminar.TabIndex = 58
        Me.btneliminar.Text = "Eliminar"
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnsalir
        '
        Me.btnsalir.Location = New System.Drawing.Point(253, 236)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(75, 23)
        Me.btnsalir.TabIndex = 57
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.UseVisualStyleBackColor = True
        '
        'btncancelar
        '
        Me.btncancelar.Location = New System.Drawing.Point(43, 236)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(75, 23)
        Me.btncancelar.TabIndex = 56
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = True
        '
        'btnaceptar
        '
        Me.btnaceptar.Location = New System.Drawing.Point(253, 185)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnaceptar.TabIndex = 55
        Me.btnaceptar.Text = "Aceptar"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'btnmodificar
        '
        Me.btnmodificar.Location = New System.Drawing.Point(148, 185)
        Me.btnmodificar.Name = "btnmodificar"
        Me.btnmodificar.Size = New System.Drawing.Size(75, 23)
        Me.btnmodificar.TabIndex = 54
        Me.btnmodificar.Text = "Modificar"
        Me.btnmodificar.UseVisualStyleBackColor = True
        '
        'btnnuevo
        '
        Me.btnnuevo.Location = New System.Drawing.Point(43, 185)
        Me.btnnuevo.Name = "btnnuevo"
        Me.btnnuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnnuevo.TabIndex = 53
        Me.btnnuevo.Text = "Nuevo"
        Me.btnnuevo.UseVisualStyleBackColor = True
        '
        'cmb
        '
        Me.cmb.FormattingEnabled = True
        Me.cmb.Location = New System.Drawing.Point(137, 70)
        Me.cmb.Name = "cmb"
        Me.cmb.Size = New System.Drawing.Size(100, 21)
        Me.cmb.TabIndex = 52
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(62, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Observación:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(91, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Fecha:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(74, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Nº Cliente:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(62, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Nº de envio:"
        '
        'txtn4
        '
        Me.txtn4.Location = New System.Drawing.Point(137, 159)
        Me.txtn4.Name = "txtn4"
        Me.txtn4.Size = New System.Drawing.Size(100, 20)
        Me.txtn4.TabIndex = 47
        '
        'txtn3
        '
        Me.txtn3.Location = New System.Drawing.Point(137, 114)
        Me.txtn3.Name = "txtn3"
        Me.txtn3.Size = New System.Drawing.Size(100, 20)
        Me.txtn3.TabIndex = 46
        '
        'txtn1
        '
        Me.txtn1.Enabled = False
        Me.txtn1.Location = New System.Drawing.Point(137, 19)
        Me.txtn1.Name = "txtn1"
        Me.txtn1.Size = New System.Drawing.Size(100, 20)
        Me.txtn1.TabIndex = 45
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.btnsalir2)
        Me.TabPage2.Controls.Add(Me.btnnuevo2)
        Me.TabPage2.Controls.Add(Me.txtn5)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.btnant2)
        Me.TabPage2.Controls.Add(Me.btnsig2)
        Me.TabPage2.Controls.Add(Me.btnaceptar2)
        Me.TabPage2.Controls.Add(Me.btncancelar2)
        Me.TabPage2.Controls.Add(Me.btnmodificar2)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtn6)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.txtn8)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txtn7)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(339, 310)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Nota de envio det"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'btnsalir2
        '
        Me.btnsalir2.Location = New System.Drawing.Point(140, 207)
        Me.btnsalir2.Name = "btnsalir2"
        Me.btnsalir2.Size = New System.Drawing.Size(75, 23)
        Me.btnsalir2.TabIndex = 36
        Me.btnsalir2.Text = "Salir"
        Me.btnsalir2.UseVisualStyleBackColor = True
        '
        'btnnuevo2
        '
        Me.btnnuevo2.Location = New System.Drawing.Point(191, 178)
        Me.btnnuevo2.Name = "btnnuevo2"
        Me.btnnuevo2.Size = New System.Drawing.Size(75, 23)
        Me.btnnuevo2.TabIndex = 35
        Me.btnnuevo2.Text = "Nuevo"
        Me.btnnuevo2.UseVisualStyleBackColor = True
        '
        'txtn5
        '
        Me.txtn5.Enabled = False
        Me.txtn5.Location = New System.Drawing.Point(115, 13)
        Me.txtn5.Name = "txtn5"
        Me.txtn5.Size = New System.Drawing.Size(100, 20)
        Me.txtn5.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 33
        Me.Label8.Text = "Nº de envio det:"
        '
        'btnant2
        '
        Me.btnant2.Location = New System.Drawing.Point(46, 250)
        Me.btnant2.Name = "btnant2"
        Me.btnant2.Size = New System.Drawing.Size(75, 23)
        Me.btnant2.TabIndex = 32
        Me.btnant2.Text = "<<"
        Me.btnant2.UseVisualStyleBackColor = True
        '
        'btnsig2
        '
        Me.btnsig2.Location = New System.Drawing.Point(140, 250)
        Me.btnsig2.Name = "btnsig2"
        Me.btnsig2.Size = New System.Drawing.Size(75, 23)
        Me.btnsig2.TabIndex = 31
        Me.btnsig2.Text = ">>"
        Me.btnsig2.UseVisualStyleBackColor = True
        '
        'btnaceptar2
        '
        Me.btnaceptar2.Location = New System.Drawing.Point(6, 178)
        Me.btnaceptar2.Name = "btnaceptar2"
        Me.btnaceptar2.Size = New System.Drawing.Size(75, 23)
        Me.btnaceptar2.TabIndex = 30
        Me.btnaceptar2.Text = "Aceptar"
        Me.btnaceptar2.UseVisualStyleBackColor = True
        '
        'btncancelar2
        '
        Me.btncancelar2.Location = New System.Drawing.Point(46, 207)
        Me.btncancelar2.Name = "btncancelar2"
        Me.btncancelar2.Size = New System.Drawing.Size(75, 23)
        Me.btncancelar2.TabIndex = 29
        Me.btncancelar2.Text = "Cancelar"
        Me.btncancelar2.UseVisualStyleBackColor = True
        '
        'btnmodificar2
        '
        Me.btnmodificar2.Location = New System.Drawing.Point(97, 178)
        Me.btnmodificar2.Name = "btnmodificar2"
        Me.btnmodificar2.Size = New System.Drawing.Size(75, 23)
        Me.btnmodificar2.TabIndex = 28
        Me.btnmodificar2.Text = "Modificar"
        Me.btnmodificar2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(43, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Nº de envio:"
        '
        'txtn6
        '
        Me.txtn6.Enabled = False
        Me.txtn6.Location = New System.Drawing.Point(115, 58)
        Me.txtn6.Name = "txtn6"
        Me.txtn6.Size = New System.Drawing.Size(100, 20)
        Me.txtn6.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Nº instrumento:"
        '
        'txtn8
        '
        Me.txtn8.Location = New System.Drawing.Point(115, 150)
        Me.txtn8.Name = "txtn8"
        Me.txtn8.Size = New System.Drawing.Size(100, 20)
        Me.txtn8.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(57, 153)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Cantidad:"
        '
        'txtn7
        '
        Me.txtn7.Location = New System.Drawing.Point(115, 105)
        Me.txtn7.Name = "txtn7"
        Me.txtn7.Size = New System.Drawing.Size(100, 20)
        Me.txtn7.TabIndex = 19
        '
        'Nota_de_envio1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 342)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Nota_de_envio1"
        Me.Text = "Nota_de_envio1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnant As System.Windows.Forms.Button
    Friend WithEvents btnsig As System.Windows.Forms.Button
    Friend WithEvents btneliminar As System.Windows.Forms.Button
    Friend WithEvents btnsalir As System.Windows.Forms.Button
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents btnaceptar As System.Windows.Forms.Button
    Friend WithEvents btnmodificar As System.Windows.Forms.Button
    Friend WithEvents btnnuevo As System.Windows.Forms.Button
    Friend WithEvents cmb As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtn4 As System.Windows.Forms.TextBox
    Friend WithEvents txtn3 As System.Windows.Forms.TextBox
    Friend WithEvents txtn1 As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtn6 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtn8 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtn7 As System.Windows.Forms.TextBox
    Friend WithEvents btnant2 As System.Windows.Forms.Button
    Friend WithEvents btnsig2 As System.Windows.Forms.Button
    Friend WithEvents btnaceptar2 As System.Windows.Forms.Button
    Friend WithEvents btncancelar2 As System.Windows.Forms.Button
    Friend WithEvents btnmodificar2 As System.Windows.Forms.Button
    Friend WithEvents txtn5 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnsalir2 As System.Windows.Forms.Button
    Friend WithEvents btnnuevo2 As System.Windows.Forms.Button
End Class
