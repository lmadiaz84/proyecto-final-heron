Public Class Instrumentos
    Dim dbconection As New OleDb.OleDbConnection()
    Dim dainstrumento As OleDb.OleDbDataAdapter
    Dim damodelos As OleDb.OleDbDataAdapter
    Dim damagnitud As OleDb.OleDbDataAdapter
    Dim daplanta As OleDb.OleDbDataAdapter
    Dim darecepcion As OleDb.OleDbDataAdapter
    Dim cbinstrumento As OleDb.OleDbCommandBuilder
    Dim cbmodelo As OleDb.OleDbCommandBuilder
    Dim cbmagnitud As OleDb.OleDbCommandBuilder
    Dim ds As DataSet
    Dim dtinstrumento As DataTable
    Dim dtmodelo As DataTable
    Dim dtmagnitud As DataTable
    Dim dtrecpecion As DataTable
    Dim dtplanta As DataTable
    Dim dr As DataRow
    Dim registro As Integer
    Dim anterior As String
    Dim dvrecepcion As DataView
    Private Sub Instrumentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bloquear(True)
        Dim ubicacion As String
        ubicacion = Application.StartupPath
        dbconection.ConnectionString = "provider=microsoft.jet.oledb.4.0; data source=" & ubicacion & "\Heron.mdb"
        dbconection.Open()
        dainstrumento = New OleDb.OleDbDataAdapter("select * from instrumento", dbconection)
        damodelos = New OleDb.OleDbDataAdapter("select * from modelo", dbconection)
        damagnitud = New OleDb.OleDbDataAdapter("select * from magnitud", dbconection)
        daplanta = New OleDb.OleDbDataAdapter("select * from planta", dbconection)
        darecepcion = New OleDb.OleDbDataAdapter("select * from recepcion_det", dbconection)

        Dim cbinstrumento As New OleDb.OleDbCommandBuilder(dainstrumento)
        dainstrumento.UpdateCommand = cbinstrumento.GetUpdateCommand
        dainstrumento.InsertCommand = cbinstrumento.GetInsertCommand
        dainstrumento.DeleteCommand = cbinstrumento.GetDeleteCommand
        dainstrumento.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Dim cbmodelo As New OleDb.OleDbCommandBuilder(damodelos)
        damodelos.InsertCommand = cbmodelo.GetInsertCommand
        damodelos.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Dim cbmagnitud As New OleDb.OleDbCommandBuilder(damagnitud)
        damagnitud.InsertCommand = cbmagnitud.GetInsertCommand
        damagnitud.MissingSchemaAction = MissingSchemaAction.AddWithKey

        dtinstrumento = New DataTable

        ds = New DataSet
        dainstrumento.Fill(ds, "instrumento")
        dtinstrumento = ds.Tables("instrumento")
        damodelos.Fill(ds, "modelo")
        dtmodelo = ds.Tables("modelo")
        damagnitud.Fill(ds, "magnitud")
        dtmagnitud = ds.Tables("magnitud")
        daplanta.Fill(ds, "planta")
        dtplanta = ds.Tables("planta")
        darecepcion.Fill(ds, "recepcion_det")
        dtrecpecion = ds.Tables("recepcion_det")
        dvrecepcion = dtrecpecion.DefaultView

        limpiar()
        'registro = 0

        completar_magnitud()
        completar_modelo()
        completar_planta()

        If dtinstrumento.Rows.Count - 1 > 0 Then
            registro = 0
            dr = dtinstrumento.Rows(registro)
            verdatos(dr)
        End If
        dbconection.Close()
    End Sub
    Private Sub completar_magnitud()
        cmbmagnitud.Text = ""
        Dim pos As Integer
        'Dim dr As DataRow
        cmbmagnitud.Items.Clear()
        For pos = 0 To dtmagnitud.Rows.Count - 1
            dr = dtmagnitud.Rows(pos)
            cmbmagnitud.Items.Add(dr("nom_magnitud").ToString())
        Next
    End Sub
    Private Sub completar_planta()
        cmbplanta.Text = ""
        Dim pos As Integer
        'Dim dr As DataRow
        cmbplanta.Items.Clear()
        For pos = 0 To dtplanta.Rows.Count - 1
            dr = dtplanta.Rows(pos)
            cmbplanta.Items.Add(dr("descripcion").ToString())
        Next
    End Sub
    Private Sub completar_modelo()
        cmbmodelo.Text = ""
        Dim pos As Integer
        'Dim dr As DataRow
        cmbmodelo.Items.Clear()
        For pos = 0 To dtmodelo.Rows.Count - 1
            dr = dtmodelo.Rows(pos)
            cmbmodelo.Items.Add(dr("nom_modelo").ToString())
        Next
    End Sub
    Private Sub verdatos(ByVal dr1 As DataRow)
        Dim ab As Integer
        Dim a, b As String
        Dim i, e As Integer
        Dim encontrado, enco As Boolean
        ab = dr1("id_instr_cliente").ToString
        txtn1.Text = ab
        i = 0
        While Not encontrado And i <= dtmodelo.Rows.Count - 1
            If dtmodelo.Rows(i).Item("id_modelo").ToString = dr1("id_modelo").ToString Then
                encontrado = True
                cmbmodelo.SelectedIndex = i
            Else
                i = i + 1
            End If
        End While
        txtn3.Text = dr1("nom_instrumento").ToString
        txtn4.Text = dr1("numserie_instrumento").ToString
        txtn5.Text = dr1("sector_instrumeto").ToString
        e = 0
        While Not enco And e <= dtmagnitud.Rows.Count - 1
            If dtmagnitud.Rows(e).Item("id_magnitud").ToString = dr1("id_magnitud").ToString Then
                enco = True
                cmbmagnitud.SelectedIndex = e
            Else
                e = e + 1
            End If
        End While
        cmbestadoinstrumento.Text = dr1("estado_instrumento").ToString
        txtn8.Text = dr1("ptos_calib_instrumento").ToString
        txtn9.Text = dr1("rango_instrumento").ToString
        Dim u As Integer
        Dim encon As Boolean
        u = 0
        While Not encon And u <= dtplanta.Rows.Count - 1
            If dtplanta.Rows(u).Item("id_planta").ToString = dr1("id_planta").ToString Then
                encon = True
                cmbplanta.SelectedIndex = u
            Else
                u = u + 1
            End If
        End While

        txtn11.Text = dr1("tipo_vence").ToString
        a = dr1("fecha_calib_instrumento").ToString
        txtn12.Text = Format(a, "short date")
        b = dr1("prox_fecha_calib_instrumento").ToString
        txtn13.Text = Format(b, "short date")
        cmbestadoenvio.Text = dr1("estado_envio").ToString
        cmbestadotrabajo.Text = dr1("estado_trabajo").ToString
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
        cmbmodelo.Enabled = Not parametro
        txtn3.Enabled = Not parametro
        txtn4.Enabled = Not parametro
        txtn5.Enabled = Not parametro
        cmbmagnitud.Enabled = Not parametro
        cmbestadoinstrumento.Enabled = Not parametro
        cmbestadoenvio.Enabled = Not parametro
        txtn9.Enabled = Not parametro
        cmbestadotrabajo.Enabled = Not parametro
        txtn8.Enabled = Not parametro
        cmbplanta.Enabled = Not parametro
        txtn11.Enabled = Not parametro
        txtn12.Enabled = Not parametro
        txtn13.Enabled = Not parametro
    End Sub
    Private Sub limpiar()
        txtn1.Text = ""
        cmbmodelo.Text = ""
        txtn3.Text = ""
        txtn4.Text = ""
        txtn5.Text = ""
        cmbmagnitud.Text = ""
        cmbestadoinstrumento.Text = ""
        txtn8.Text = ""
        txtn9.Text = ""
        cmbplanta.Text = ""
        txtn11.Text = ""
        txtn12.Text = ""
        txtn13.Text = ""
        cmbestadoenvio.Text = ""
        cmbestadotrabajo.Text = ""
    End Sub
    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        bloquear(True)
        If dr Is Nothing Then
            limpiar()
        Else
            verdatos(dr)
        End If

    End Sub

    Private Sub btnmodifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        bloquear(False)
        anterior = "M"
        cmbmodelo.Focus()
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        bloquear(False)
        anterior = "N"
        limpiar()
        cmbmodelo.Focus()
    End Sub
    Private Sub btnsig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsig.Click
        registro = registro + 1
        If registro <= dtinstrumento.Rows.Count - 1 Then
            dr = dtinstrumento.Rows(registro)
            verdatos(dr)
        Else
            registro = registro - 1
            MsgBox("Ha llegado al ultimo instrumento registrado!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub btnant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnant.Click
        registro = registro - 1
        If registro >= 0 Then
            dr = dtinstrumento.Rows(registro)
            verdatos(dr)
        Else
            registro = 0
            MsgBox("Ha llegado al primer instrumento registrado!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        End If
    End Sub
    Private Sub guardardatos(ByVal dr1 As DataRow)
        dr1("id_modelo") = dtmodelo.Rows(cmbmodelo.SelectedIndex).Item("id_modelo").ToString
        dr1("nom_instrumento") = txtn3.Text
        dr1("numserie_instrumento") = txtn4.Text
        dr1("sector_instrumeto") = txtn5.Text
        dr1("id_magnitud") = dtmagnitud.Rows(cmbmagnitud.SelectedIndex).Item("id_magnitud").ToString
        dr1("estado_instrumento") = cmbestadoinstrumento.Text
        dr1("ptos_calib_instrumento") = txtn8.Text
        dr1("rango_instrumento") = txtn9.Text
        dr1("id_planta") = dtplanta.Rows(cmbplanta.SelectedIndex).Item("id_planta").ToString
        dr1("tipo_vence") = txtn11.Text
        dr1("fecha_calib_instrumento") = txtn12.Text
        dr1("prox_fecha_calib_instrumento") = txtn13.Text
        dr1("estado_envio") = cmbestadoenvio.Text
        dr1("estado_trabajo") = cmbestadotrabajo.Text
    End Sub
    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        If anterior = "N" Then
            Dim dr As DataRow = dtinstrumento.NewRow()
            guardardatos(dr)
            dtinstrumento.Rows.Add(dr)
        Else
            Dim dr As DataRow = dtinstrumento.Rows(registro)
            guardardatos(dr)
        End If

        dainstrumento.Update(dtinstrumento)
        dtinstrumento.AcceptChanges()
        bloquear(True)
        limpiar()
        verdatos(dr)
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        dvrecepcion.RowFilter = "id_instr_cliente=" + txtn1.Text
        If dvrecepcion.Count > 0 Then
            MsgBox("No es posible eliminar el instrumento.Tiene recepcion!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        Else
            If MsgBox("eliminar instrumento " + Trim(txtn1.Text) + " ? ", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                dtinstrumento.Rows(registro).Delete()
                dainstrumento.Update(dtinstrumento)
                dtinstrumento.AcceptChanges()
                registro = 0
                If dtinstrumento.Rows.Count > 0 Then
                    Dim dr As DataRow = dtinstrumento.Rows(registro)
                    verdatos(dr)
                Else
                    limpiar()
                    MsgBox("No existe instrumento en nuestros registros", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                End If
            End If
        End If
    End Sub

    Private Sub cmbmodelo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbmodelo.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13) Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn3.Focus()
            End If
        End If
    End Sub

    Private Sub cmbmodelo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmodelo.LostFocus
        txtn3.Focus()
    End Sub

    Private Sub txtn3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn3.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k < 48) Or k > 57 And k < 65 Or k > 90 And k < 97 Or k > 122 Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn4.Focus()
            End If
        End If
    End Sub

    Private Sub txtn3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn3.LostFocus
        txtn4.Focus()
    End Sub

    Private Sub txtn4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn4.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn5.Focus()
            End If
        End If
    End Sub

    Private Sub txtn4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn4.LostFocus
        txtn5.Focus()
    End Sub

    Private Sub txtn5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn5.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 46 And k < 65) Or k > 90 And k < 97 Or k > 122 Then
            e.Handled = True
        Else
            If k = 13 Then
                cmbmagnitud.Focus()
            End If
        End If
    End Sub

    Private Sub txtn5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn5.LostFocus
        cmbmagnitud.Focus()
    End Sub

    Private Sub cmbmagnitud_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbmagnitud.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13) Then
            e.Handled = True
        Else
            If k = 13 Then
                cmbestadoinstrumento.Focus()
            End If
        End If
    End Sub

    Private Sub cmbmagnitud_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbmagnitud.LostFocus
        cmbestadoinstrumento.Focus()
    End Sub

    Private Sub cmbestadoinstrumento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbestadoinstrumento.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13) Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn8.Focus()
            End If
        End If
    End Sub

    Private Sub cmbestadoinstrumento_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbestadoinstrumento.LostFocus
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
        If (k <> 8 And k <> 13 And k <> 45 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                cmbplanta.Focus()
            End If
        End If
    End Sub

    Private Sub txtn9_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn9.LostFocus
        cmbplanta.Focus()
    End Sub

    Private Sub cmbplanta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbplanta.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13) Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn11.Focus()
            End If
        End If
    End Sub

    Private Sub cmbplanta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbplanta.LostFocus
        txtn11.Focus()
    End Sub

    Private Sub txtn11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn11.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 47 And k < 65) Or k > 90 And k < 97 Or k > 122 Then
            e.Handled = True
        Else
            If k = 13 Then

                txtn12.Focus()
            End If
        End If

    End Sub

    Private Sub txtn11_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn11.LostFocus
        txtn12.Focus()
    End Sub

    Private Sub txtn12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn12.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 47 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                If Not IsDate(txtn12.Text) Then
                    MsgBox("ingrese una fecha vàlida")
                    txtn12.Text = ""
                    txtn12.Focus()
                Else
                    txtn13.Focus()
                End If
            End If

        End If
    End Sub

    Private Sub txtn12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn12.LostFocus
        txtn13.Focus()
    End Sub

    Private Sub txtn13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn13.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 47 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                If Not IsDate(txtn13.Text) Then
                    MsgBox("ingrese una fecha vàlida")
                    txtn13.Text = ""
                    txtn13.Focus()
                Else
                    cmbestadoenvio.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtn13_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn13.LostFocus
        cmbestadoenvio.Focus()
    End Sub

    Private Sub cmbestadoenvio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbestadoenvio.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13) Then
            e.Handled = True
        Else
            If k = 13 Then
                cmbestadotrabajo.Focus()
            End If
        End If
    End Sub

    Private Sub cmbestadoenvio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbestadoenvio.LostFocus
        cmbestadotrabajo.Focus()
    End Sub

    Private Sub cmbestadotrabajo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbestadotrabajo.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13) Then
            e.Handled = True
        Else
            If k = 13 Then
                btnaceptar.Focus()
            End If
        End If
    End Sub

    Private Sub cmbestadotrabajo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbestadotrabajo.LostFocus
        btnaceptar.Focus()
    End Sub
End Class