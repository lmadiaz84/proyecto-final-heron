Public Class Recepcion1
    Inherits System.Windows.Forms.Form
    Dim dbconection As New OleDb.OleDbConnection()
    Dim darecepcion As OleDb.OleDbDataAdapter
    Dim darecepcion_det As OleDb.OleDbDataAdapter
    Dim dacontacto As OleDb.OleDbDataAdapter
    Dim dainstrumento As OleDb.OleDbDataAdapter
    Dim cbrecepcion As OleDb.OleDbCommandBuilder
    Dim cbrecepcion_det As OleDb.OleDbCommandBuilder
    Dim ds As DataSet
    Dim ds2 As DataSet
    Dim dtrecepcion As DataTable
    Dim dtrecepcion_det As DataTable
    Dim dtcontacto As DataTable
    Dim dtinstrumento As DataTable
    Dim dr As DataRow
    Dim dr2 As DataRow
    Dim registro As Integer
    Dim registro2 As Integer
    Dim anterior As String
    Dim anterior2 As String
    Dim dvinstrumento As DataView
    Private Sub Recepcion1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Dim ubicacion As String
        ubicacion = Application.StartupPath
        dbconection.ConnectionString = "provider=microsoft.jet.oledb.4.0; data source=" & ubicacion & "\Heron.mdb"
        dbconection.Open()
        darecepcion = New OleDb.OleDbDataAdapter("select * from recepcion", dbconection)
        darecepcion_det = New OleDb.OleDbDataAdapter("select * from recepcion_det", dbconection)
        dacontacto = New OleDb.OleDbDataAdapter("select * from contacto", dbconection)
        dainstrumento = New OleDb.OleDbDataAdapter("select * from instrumento", dbconection)

        Dim cbrecepcion As New OleDb.OleDbCommandBuilder(darecepcion)
        darecepcion.UpdateCommand = cbrecepcion.GetUpdateCommand
        darecepcion.InsertCommand = cbrecepcion.GetInsertCommand
        darecepcion.DeleteCommand = cbrecepcion.GetDeleteCommand
        darecepcion.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Dim cbrecepcion_det As New OleDb.OleDbCommandBuilder(darecepcion_det)
        darecepcion_det.InsertCommand = cbrecepcion_det.GetInsertCommand
        darecepcion_det.MissingSchemaAction = MissingSchemaAction.AddWithKey

        bloquear(True)
        bloquear2(True)

        dtrecepcion = New DataTable

        ds = New DataSet
        darecepcion.Fill(ds, "recepcion")
        dtrecepcion = ds.Tables("recepcion")
        dacontacto.Fill(ds, "contacto")
        dtcontacto = ds.Tables("contacto")
        dainstrumento.Fill(ds, "instrumento")
        dtinstrumento = ds.Tables("instrumento")
        darecepcion_det.Fill(ds, "recepcion_det")
        dtrecepcion_det = ds.Tables("recepcion_det")
        dvinstrumento = dtrecepcion_det.DefaultView

        ds2 = New DataSet
        darecepcion_det.Fill(ds2, "recepcion_det")
        dtrecepcion_det = ds2.Tables("recepcion_det")

        limpiar()
        limpiar2()

        'registro = 0
        'registro2 = 0

        completar_contacto()

        If dtrecepcion.Rows.Count - 1 > 0 Then
            registro = 0
            dr = dtrecepcion.Rows(registro)
            verdatos(dr)
        End If
        If dtrecepcion_det.Rows.Count - 1 > 0 Then
            registro2 = 0
            dr2 = dtrecepcion_det.Rows(registro2)
            verdatos2(dr2)
        End If
        dbconection.Close()
    End Sub
    Private Sub completar_contacto()
        cmbcontacto.Text = ""
        Dim pos As Integer
        'Dim dr As DataRow
        cmbcontacto.Items.Clear()
        For pos = 0 To dtcontacto.Rows.Count - 1
            dr = dtcontacto.Rows(pos)
            cmbcontacto.Items.Add(dr("nom_contacto").ToString())
        Next
    End Sub
    Private Sub verdatos(ByVal dr1 As DataRow)
        Dim ab As Integer
        Dim a, b As String
        Dim i As Integer
        Dim encontrado As Boolean
        ab = dr1("id_recepcion").ToString
        txtn1.Text = ab
        i = 0
        While Not encontrado And i <= dtcontacto.Rows.Count - 1
            If dtcontacto.Rows(i).Item("id_contacto").ToString = dr1("id_contacto").ToString Then
                encontrado = True
                cmbcontacto.SelectedIndex = i
            Else
                i = i + 1
            End If
        End While
        txtn2.Text = dr1("num_remito").ToString
        a = dr1("fecha_llegada").ToString
        txtn3.Text = Format(a, "short date")
        b = dr1("fecha_recepcion").ToString
        txtn4.Text = Format(b, "short date")
        txtn5.Text = dr1("cantidad").ToString
        txtn6.Text = dr1("usuario").ToString
    End Sub
    Private Sub verdatos2(ByVal dr3 As DataRow)
        Dim ab As Integer
        ab = dr3("id_recepcion_det").ToString
        txtn7.Text = ab
        txtn8.Text = dr3("id_recepcion").ToString
        txtn9.Text = dr3("id_instr_cliente").ToString
        cmbtipo_trabajo.Text = dr3("tipo_trabajo").ToString
        cmbestado_prioridad.Text = dr3("estado_prioridad").ToString
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
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
        cmbcontacto.Enabled = Not parametro
        txtn2.Enabled = Not parametro
        txtn3.Enabled = Not parametro
        txtn4.Enabled = Not parametro
        txtn5.Enabled = Not parametro
        txtn6.Enabled = Not parametro
    End Sub
    Private Sub bloquear2(ByVal parametr As Boolean)
        btnnuevo2.Enabled = parametr
        btnmodificar2.Enabled = parametr
        btnaceptar2.Enabled = Not parametr
        btnant2.Enabled = parametr
        btnsig2.Enabled = parametr
        btncancelar2.Enabled = Not parametr
        txtn9.Enabled = Not parametr
        txtn8.Enabled = Not parametr
        cmbestado_prioridad.Enabled = Not parametr
        cmbtipo_trabajo.Enabled = Not parametr
    End Sub
    Private Sub limpiar()
        txtn1.Text = ""
        cmbcontacto.Text = ""
        txtn2.Text = ""
        txtn3.Text = ""
        txtn4.Text = ""
        txtn5.Text = ""
        txtn6.Text = ""
    End Sub
    Private Sub limpiar2()
        txtn9.Text = ""
        txtn7.Text = ""
        txtn8.Text = ""
        cmbtipo_trabajo.Text = ""
        cmbestado_prioridad.Text = ""
    End Sub
    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        bloquear(True)
        If dr Is Nothing Then
            limpiar()
        Else
            verdatos(dr)
        End If
    End Sub
    Private Sub btnant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnant.Click
        registro = registro - 1
        If registro >= 0 Then
            dr = dtrecepcion.Rows(registro)
            verdatos(dr)
        Else
            registro = 0
            MsgBox("Ha llegado a la primera recepciòn registrada!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btnsig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsig.Click
        registro = registro + 1
        If registro <= dtrecepcion.Rows.Count - 1 Then
            dr = dtrecepcion.Rows(registro)
            verdatos(dr)
        Else
            registro = registro - 1
            MsgBox("Ha llegado al ultima recepciòn registrada!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        End If
    End Sub
    Private Sub guardardatos(ByVal dr1 As DataRow)
        dr1("id_contacto") = dtcontacto.Rows(cmbcontacto.SelectedIndex).Item("id_contacto").ToString
        dr1("num_remito") = txtn2.Text
        dr1("fecha_llegada") = txtn3.Text
        dr1("fecha_recepcion") = txtn4.Text
        dr1("cantidad") = txtn5.Text
        dr1("usuario") = txtn6.Text
    End Sub
    Private Sub guardardatos2(ByVal dr3 As DataRow)
        dr3("id_recepcion") = txtn8.Text
        dr3("id_instr_cliente") = txtn9.Text
        dr3("tipo_trabajo") = cmbtipo_trabajo.Text
        dr3("estado_prioridad") = cmbestado_prioridad.Text
    End Sub
    Private Sub cmbcontacto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbcontacto.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13) Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn2.Focus()
            End If
        End If
    End Sub

    Private Sub cmbcontacto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcontacto.LostFocus
        txtn2.Focus()
    End Sub
    Private Sub txtn2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn2.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn3.Focus()
            End If
        End If
    End Sub
    Private Sub txtn2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn2.LostFocus
        txtn3.Focus()
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

    Private Sub txtn4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn4.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 47 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                If Not IsDate(txtn4.Text) Then
                    MsgBox("ingrese una fecha vàlida")
                    txtn4.Text = ""
                    txtn4.Focus()
                Else
                    txtn5.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtn4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn4.LostFocus
        txtn5.Focus()
    End Sub

    Private Sub txtn5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn5.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 32 And k <> 46 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn6.Focus()
            End If
        End If
    End Sub

    Private Sub txtn5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn5.LostFocus
        txtn6.Focus()
    End Sub

    Private Sub txtn6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn6.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k < 65) Or k > 90 And k < 97 Or k > 122 Then
            e.Handled = True
        Else
            If (k = 13) Then
                btnaceptar.Focus()
            End If
        End If
    End Sub

    Private Sub txtn6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn6.LostFocus
        btnaceptar.Focus()
    End Sub

    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        If anterior = "N" Then
            Dim dr As DataRow = dtrecepcion.NewRow()
            guardardatos(dr)
            dtrecepcion.Rows.Add(dr)
        Else
            Dim dr As DataRow = dtrecepcion.Rows(registro)
            guardardatos(dr)
        End If

        darecepcion.Update(dtrecepcion)
        dtrecepcion.AcceptChanges()
        bloquear(True)
        limpiar()
        verdatos(dr)

    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        bloquear(False)
        anterior = "N"
        limpiar()
        cmbcontacto.Focus()
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        bloquear(False)
        anterior = "M"
        cmbcontacto.Focus()

    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        dvinstrumento.RowFilter = "id_recepcion=" + txtn1.Text
        If dvinstrumento.Count > 0 Then
            MsgBox("No es posible eliminar la recepciòn.Tiene instrumentos!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        Else
            If MsgBox("eliminar recepciòn " + Trim(txtn1.Text) + " ? ", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                dtrecepcion.Rows(registro).Delete()
                darecepcion.Update(dtrecepcion)
                dtrecepcion.AcceptChanges()
                registro = 0
                If dtrecepcion.Rows.Count > 0 Then
                    Dim dr As DataRow = dtrecepcion.Rows(registro)
                    verdatos(dr)
                Else
                    limpiar()
                    MsgBox("No existe recepciòn en nuestros registros", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                End If
            End If
        End If
    End Sub

    Private Sub btnant2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnant2.Click
        registro2 = registro2 - 1
        If registro2 >= 0 Then
            dr2 = dtrecepcion_det.Rows(registro2)
            verdatos2(dr2)
        Else
            registro2 = 0
            MsgBox("Ha llegado a la primera recepciòn_det registrada!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btnsig2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsig2.Click
        registro2 = registro2 + 1
        If registro2 <= dtrecepcion_det.Rows.Count - 1 Then
            dr2 = dtrecepcion_det.Rows(registro2)
            verdatos2(dr2)
        Else
            registro2 = registro2 - 1
            MsgBox("Ha llegado al ultima recepciòn_det registrada!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btnaceptar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar2.Click
        If anterior2 = "N" Then
            Dim dr2 As DataRow = dtrecepcion_det.NewRow()
            guardardatos2(dr2)
            dtrecepcion_det.Rows.Add(dr2)
        Else
            Dim dr2 As DataRow = dtrecepcion_det.Rows(registro2)
            guardardatos2(dr2)
        End If
        darecepcion_det.Update(dtrecepcion_det)
        dtrecepcion_det.AcceptChanges()
        bloquear2(True)
        limpiar2()
        verdatos2(dr2)
    End Sub

    Private Sub btnmodificar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar2.Click
        bloquear2(False)

        anterior2 = "M"
        txtn8.Focus()
    End Sub

    Private Sub btncancelar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar2.Click
        bloquear2(True)
        If dr Is Nothing Then
            limpiar2()
        Else
            verdatos2(dr2)
        End If
    End Sub

    Private Sub btnsalir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir2.Click
        Me.Close()
    End Sub

    Private Sub btnnuevo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo2.Click
        bloquear2(False)
        anterior2 = "N"
        limpiar2()
        txtn8.Focus()
    End Sub

    Private Sub txtn8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn8.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn9.Focus()
            End If
        End If
    End Sub

    Private Sub txtn8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn8.LostFocus
        txtn9.Focus()
    End Sub

    Private Sub txtn9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn9.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                cmbtipo_trabajo.Focus()
            End If
        End If
    End Sub

    Private Sub txtn9_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn9.LostFocus
        cmbtipo_trabajo.Focus()
    End Sub
End Class