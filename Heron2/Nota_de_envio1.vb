Public Class Nota_de_envio1
    Inherits System.Windows.Forms.Form
    Dim dbconection As New OleDb.OleDbConnection()
    Dim danotaenvio As OleDb.OleDbDataAdapter
    Dim danotaenvio_det As OleDb.OleDbDataAdapter
    Dim dacliente As OleDb.OleDbDataAdapter
    Dim dains As OleDb.OleDbDataAdapter
    Dim cbnotaenvio As OleDb.OleDbCommandBuilder
    Dim cbnotaenvio_det As OleDb.OleDbCommandBuilder
    Dim ds As DataSet
    Dim dtnotaenvio As DataTable
    Dim dtnotaenvio_det As DataTable
    Dim dtclientes As DataTable
    Dim dtinst As DataTable
    Dim dr As DataRow
    Dim dr2 As DataRow
    Dim registro As Integer
    Dim registro2 As Integer
    Dim anterior2 As String
    Dim anterior As String
    Dim dvcliente As DataView
    Private Sub Nota_de_envio1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bloquear(True)
        bloquear2(True)
        Dim ubicacion As String
        ubicacion = Application.StartupPath
        dbconection.ConnectionString = "provider =microsoft.Jet.oledb.4.0;data source =" & ubicacion & "\Heron.mdb"
        dbconection.Open()
        danotaenvio = New OleDb.OleDbDataAdapter("Select * from nota_de_envio", dbconection)
        danotaenvio_det = New OleDb.OleDbDataAdapter("Select * from nota_de_envio_det", dbconection)
        dacliente = New OleDb.OleDbDataAdapter("Select * from cliente", dbconection)
        dains = New OleDb.OleDbDataAdapter("Select * from instrumento", dbconection)

        Dim cbnotaenvio As New OleDb.OleDbCommandBuilder(danotaenvio)
        danotaenvio.UpdateCommand = cbnotaenvio.GetUpdateCommand
        danotaenvio.InsertCommand = cbnotaenvio.GetInsertCommand
        danotaenvio.DeleteCommand = cbnotaenvio.GetDeleteCommand
        danotaenvio.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Dim cbnotaenvio_det As New OleDb.OleDbCommandBuilder(danotaenvio_det)
        danotaenvio_det.InsertCommand = cbnotaenvio_det.GetInsertCommand
        danotaenvio_det.MissingSchemaAction = MissingSchemaAction.AddWithKey

        ds = New DataSet
        danotaenvio.Fill(ds, "nota_de_envio")
        dtnotaenvio = ds.Tables("nota_de_envio")
        danotaenvio_det.Fill(ds, "nota_de_envio_det")
        dtnotaenvio_det = ds.Tables("nota_de_envio_det")
        dacliente.Fill(ds, "cliente")
        dtclientes = ds.Tables("cliente")
        dains.Fill(ds, "instrumento")
        dtinst = ds.Tables("instrumento")
        dvcliente = dtnotaenvio_det.DefaultView

        limpiar()
        limpiar2()

        'registro = 0
        'registro2 = 0

        completar_clientes()

        If (dtnotaenvio.Rows.Count - 1 > 0) Then
            registro = 0
            dr = dtnotaenvio.Rows(registro)
            verdatos(dr)
        End If
        If (dtnotaenvio_det.Rows.Count - 1 > 0) Then
            registro2 = 0
            dr2 = dtnotaenvio_det.Rows(registro2)
            verdatos2(dr2)
        End If

    End Sub
    Private Sub completar_clientes()
        cmb.Text = ""
        Dim pos As Integer
        'Dim dr As DataRow
        cmb.Items.Clear()
        For pos = 0 To dtclientes.Rows.Count - 1
            dr = dtclientes.Rows(pos)
            cmb.Items.Add(dr("nom_cliente").ToString())
        Next
    End Sub
    Private Sub verdatos(ByVal dr1 As DataRow)
        Dim b As String
        Dim a As Integer
        Dim pos As Integer
        Dim encontrado As Boolean
        a = dr1("id_nota_de_envio").ToString
        txtn1.Text = a
        pos = 0
        While Not encontrado And pos <= dtclientes.Rows.Count - 1
            If dtclientes.Rows(pos).Item("id_cliente").ToString = dr1("id_cliente").ToString() Then
                encontrado = True
                cmb.SelectedIndex = pos
            Else
                pos += 1
            End If
        End While

        b = dr1("fecha").ToString
        txtn3.Text = Format(b, "Short date")
        txtn4.Text = dr1("observaciones").ToString
    End Sub
    Private Sub verdatos2(ByVal dr11 As DataRow)
        Dim a As Integer
        a = dr11("id_nota_de_envio_det").ToString
        txtn5.Text = a
        txtn6.Text = dr11("id_nota_de_envio").ToString()
        txtn7.Text = dr11("id_instr_cliente").ToString
        txtn8.Text = dr11("cantidad").ToString
    End Sub
    Private Sub bloquear(ByVal parametro As Boolean)
        btnnuevo.Enabled = parametro
        btnmodificar.Enabled = parametro
        btnaceptar.Enabled = Not parametro
        btnant.Enabled = parametro
        btnsig.Enabled = parametro
        btncancelar.Enabled = Not parametro
        btnsalir.Enabled = parametro
        btneliminar.Enabled = parametro
        cmb.Enabled = Not parametro
        txtn3.Enabled = Not parametro
        txtn4.Enabled = Not parametro

    End Sub
    Private Sub bloquear2(ByVal parametr As Boolean)
        btnmodificar2.Enabled = parametr
        btnnuevo2.Enabled = parametr
        btnaceptar2.Enabled = Not parametr
        btncancelar2.Enabled = Not parametr
        btnant2.Enabled = parametr
        btnsig2.Enabled = parametr
        txtn6.Enabled = Not parametr
        txtn7.Enabled = Not parametr
        txtn8.Enabled = Not parametr
    End Sub
    Private Sub limpiar()
        txtn1.Text = ""
        cmb.Text = ""
        txtn3.Text = ""
        txtn4.Text = ""
    End Sub
    Private Sub limpiar2()
        txtn5.Text = ""
        txtn6.Text = ""
        txtn7.Text = ""
        txtn8.Text = ""
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnsalir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir2.Click
        Me.Close()
    End Sub

    Private Sub btnant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnant.Click
        registro = registro - 1
        If registro >= 0 Then
            dr = dtnotaenvio.Rows(registro)
            verdatos(dr)
        Else
            registro = 0
            MsgBox("Ha llegado a la primera nota de envio registrada!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btnsig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsig.Click
        registro = registro + 1
        If registro <= dtnotaenvio.Rows.Count - 1 Then
            dr = dtnotaenvio.Rows(registro)
            verdatos(dr)
        Else
            registro = registro - 1
            MsgBox("Ha llegado al ultima nota de envio registrada!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btnant2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnant2.Click
        registro2 = registro2 - 1
        If registro2 >= 0 Then
            dr2 = dtnotaenvio_det.Rows(registro2)
            verdatos2(dr2)
        Else
            registro2 = 0
            MsgBox("Ha llegado a la primera nota de envio_det registrada!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btnsig2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsig2.Click
        registro2 = registro2 + 1
        If registro2 <= dtnotaenvio_det.Rows.Count - 1 Then
            dr2 = dtnotaenvio_det.Rows(registro2)
            verdatos2(dr2)
        Else
            registro2 = registro2 - 1
            MsgBox("Ha llegado al ultima nota de envio_det registrada!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        bloquear(True)
        If dr Is Nothing Then
            limpiar()
        Else
            verdatos(dr)
        End If
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        bloquear(False)
        anterior = "M"
        cmb.Focus()
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        bloquear(False)
        anterior = "N"
        limpiar()
        cmb.Focus()
    End Sub
    Private Sub guardardatos(ByVal dr1 As DataRow)
        dr1("id_cliente") = dtclientes.Rows(cmb.SelectedIndex).Item("id_cliente").ToString
        dr1("fecha") = txtn3.Text
        dr1("observaciones") = txtn4.Text
    End Sub
    Private Sub guardardatos2(ByVal dr2 As DataRow)
        dr2("id_nota_de_envio") = txtn6.Text
        dr2("id_instr_cliente") = txtn7.Text
        dr2("cantidad") = txtn8.Text
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        If anterior = "N" Then
            Dim d As DataRow = dtnotaenvio.NewRow()
            guardardatos(d)
            dtnotaenvio.Rows.Add(d)
        Else
            Dim x As DataRow = dtnotaenvio.Rows(registro)
            guardardatos(x)
        End If
        danotaenvio.Update(dtnotaenvio)
        dtnotaenvio.AcceptChanges()
        bloquear(True)
        limpiar()
        verdatos(dr)
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        dvcliente.RowFilter = "id_nota_de_envio=" + Val(txtn6.Text)
        If dvcliente.Count > 0 Then
            MsgBox("no es posible eliminar la nota tiene instrumentos", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        Else
            If MsgBox("eliminar nota" + Trim(txtn1.Text) + "?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                dtnotaenvio.Rows(registro).Delete()
                danotaenvio.Update(dtnotaenvio)
                dtnotaenvio.AcceptChanges()
                registro = 0
                If dtnotaenvio.Rows.Count > 0 Then
                    Dim dr As DataRow = dtnotaenvio.Rows(registro)
                    verdatos(dr)
                Else
                    limpiar()
                    MsgBox("no existe nota de envio en nuestros registros", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                End If
            End If
        End If
    End Sub

    Private Sub btnaceptar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar2.Click
        If anterior2 = "N" Then
            Dim dr2 As DataRow = dtnotaenvio_det.NewRow()
            guardardatos2(dr2)
            dtnotaenvio_det.Rows.Add(dr2)
        Else
            Dim dr2 As DataRow = dtnotaenvio_det.Rows(registro2)
            guardardatos2(dr2)
        End If
        danotaenvio_det.Update(dtnotaenvio_det)
        dtnotaenvio_det.AcceptChanges()
        bloquear2(True)
        limpiar2()
        verdatos2(dr2)
    End Sub

    Private Sub btnmodificar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar2.Click
        bloquear2(False)
        anterior2 = "M"
        txtn6.Focus()
    End Sub

    Private Sub btncancelar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar2.Click
        bloquear2(True)
        If dr Is Nothing Then
            limpiar2()
        Else
            verdatos2(dr2)
        End If
    End Sub

    Private Sub btnnuevo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo2.Click
        bloquear2(False)
        anterior2 = "N"
        limpiar2()
        txtn6.Focus()
    End Sub

    Private Sub cmb_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13) Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn3.Focus()
            End If
        End If
    End Sub

    Private Sub txtn3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn3.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 47 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                If Not IsDate(txtn3.Text) Then
                    MsgBox("ingrese una fecha vàlida")
                    txtn3.Text = ""
                    txtn3.Focus()
                Else
                    txtn4.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtn3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn3.LostFocus
        txtn4.Focus()
    End Sub

    Private Sub cmb_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb.LostFocus
        txtn3.Focus()
    End Sub

    Private Sub txtn4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn4.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 45 And k <> 46 And k < 48) Or k > 57 And k < 64 Or k > 90 And k < 97 Or k > 122 Then
            e.Handled = True
        Else
            If k = 13 Then
                btnaceptar.Focus()
            End If
        End If
    End Sub

    Private Sub txtn4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn4.LostFocus
        btnaceptar.Focus()
    End Sub

    Private Sub txtn6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn6.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 45 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn7.Focus()
            End If
        End If
    End Sub

    Private Sub txtn6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn6.LostFocus
        txtn7.Focus()
    End Sub

    Private Sub txtn7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn7.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 45 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn8.Focus()
            End If
        End If
    End Sub

    Private Sub txtn7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn7.LostFocus
        txtn8.Focus()
    End Sub

    Private Sub txtn8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn8.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 45 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                btnaceptar2.Focus()
            End If
        End If
    End Sub

    Private Sub txtn8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn8.LostFocus
        btnaceptar2.Focus()
    End Sub
End Class