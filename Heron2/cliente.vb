Public Class cliente
    Dim dbconnection As New OleDb.OleDbConnection()
    Dim dacliente As OleDb.OleDbDataAdapter
    Dim dalocalidad As OleDb.OleDbDataAdapter
    Dim daprovincia As OleDb.OleDbDataAdapter
    Dim dacontacto As OleDb.OleDbDataAdapter
    Dim cbclientes As OleDb.OleDbCommandBuilder
    Dim cblocalidad As OleDb.OleDbCommandBuilder
    Dim cbpcia As OleDb.OleDbCommandBuilder
    Dim dtcliente As DataTable
    Dim dtprovincia As DataTable
    Dim dtlocalidad As DataTable
    Dim dtcontacto As DataTable
    Dim dr As DataRow
    Dim ds As DataSet
    Dim registro As Integer
    Dim anterior As String
    Dim dvcontacto As DataView
    Private Sub cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bloquear(True)
        Dim ubicacion As String
        ubicacion = Application.StartupPath
        dbconnection.ConnectionString = "provider = Microsoft.jet.oledb.4.0;Data Source=" & ubicacion & "\Heron.mdb"
        dbconnection.Open()
        dacliente = New OleDb.OleDbDataAdapter("Select * from cliente", dbconnection)
        dalocalidad = New OleDb.OleDbDataAdapter("select * from localidad", dbconnection)
        daprovincia = New OleDb.OleDbDataAdapter("select * from provincia", dbconnection)
        dacontacto = New OleDb.OleDbDataAdapter("select * from contacto", dbconnection)

        Dim cbclientes As New OleDb.OleDbCommandBuilder(dacliente)
        dacliente.UpdateCommand = cbclientes.GetUpdateCommand
        dacliente.InsertCommand = cbclientes.GetInsertCommand
        dacliente.DeleteCommand = cbclientes.GetDeleteCommand
        dacliente.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Dim cbpcia As New OleDb.OleDbCommandBuilder(daprovincia)
        daprovincia.InsertCommand = cbpcia.GetInsertCommand
        daprovincia.MissingSchemaAction = MissingSchemaAction.AddWithKey

        Dim cblocalidad As New OleDb.OleDbCommandBuilder(dalocalidad)
        dalocalidad.InsertCommand = cblocalidad.GetInsertCommand
        dalocalidad.MissingSchemaAction = MissingSchemaAction.AddWithKey

        dtcliente = New DataTable()

        ds = New DataSet
        dacliente.Fill(ds, "cliente")
        dtcliente = ds.Tables("cliente")
        dalocalidad.Fill(ds, "localidad")
        dtlocalidad = ds.Tables("localidad")
        daprovincia.Fill(ds, "provincia")
        dtprovincia = ds.Tables("provincia")
        dacontacto.Fill(ds, "contacto")
        dtcontacto = ds.Tables("contacto")
        dvcontacto = dtcontacto.DefaultView

        limpiar()
        'registro = 0
        completar_provincias()
        completar_localidades()

        If dtcliente.Rows.Count - 1 > 0 Then
            dr = dtcliente.Rows(registro)
            verdatos(dr)
        End If
        dbconnection.Close()
    End Sub
    Private Sub completar_provincias()
        cmbprovincia.Text = ""
        Dim pos As Integer
        'Dim dr As DataRow
        cmbprovincia.Items.Clear()
        For pos = 0 To dtprovincia.Rows.Count - 1
            dr = dtprovincia.Rows(pos)
            cmbprovincia.Items.Add(dr("nom_pcia").ToString)
        Next
    End Sub
    Private Sub completar_localidades()
        cmblocalidad.Text = ""
        Dim pos As Integer
        'Dim dr As DataRow
        cmblocalidad.Items.Clear()
        For pos = 0 To dtlocalidad.Rows.Count - 1
            dr = dtlocalidad.Rows(pos)
            cmblocalidad.Items.Add(dr("nom_localidad").ToString)
        Next
    End Sub
    Private Sub verdatos(ByVal dr1 As DataRow)
        Dim a As String
        Dim b As New Integer
        Dim i, e As Integer
        Dim encontrado, enco As Boolean
        b = dr1("id_cliente").ToString
        txtn1.Text = b
        txtn2.Text = dr1("nom_cliente").ToString
        txtn3.Text = dr1("domiciliofiscal_cliente").ToString
        txtn4.Text = dr1("tel1_cliente").ToString
        txtn5.Text = dr1("tel2_cliente").ToString
        txtn6.Text = dr1("email_cliente").ToString
        txtn7.Text = dr1("web_cliente").ToString
        cmbestado.Text = dr1("estado_cliente").ToString
        a = dr1("fechaestado_cliente").ToString
        txtn9.Text = Format(a, "short date")
        i = 0
        While Not encontrado And i <= dtprovincia.Rows.Count - 1
            If dtprovincia.Rows(i).Item("id_pcia").ToString = dr1("id_pcia").ToString Then
                encontrado = True
                cmbprovincia.SelectedIndex = i
            Else
                i = i + 1
            End If
        End While
        e = 0
        While Not enco And e <= dtlocalidad.Rows.Count - 1
            If dtlocalidad.Rows(e).Item("id_localidad").ToString = dr1("id_localidad").ToString Then
                enco = True
                cmblocalidad.SelectedIndex = e
            Else
                e = e + 1
            End If
        End While
    End Sub

    Private Sub btnsig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsig.Click
        registro = registro + 1
        If registro <= dtcliente.Rows.Count - 1 Then
            dr = dtcliente.Rows(registro)
            verdatos(dr)
        Else
            registro = registro - 1
            MsgBox("Ha llegado al ultimo cliente registrado!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)

        End If
    End Sub

    Private Sub btnant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnant.Click
        registro = registro - 1
        If registro >= 0 Then
            dr = dtcliente.Rows(registro)
            verdatos(dr)
        Else
            registro = 0
            MsgBox("Ha llegado al primer cliente registrado!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)

        End If
    End Sub
    Private Sub limpiar()
        txtn1.Text = ""
        txtn2.Text = ""
        txtn3.Text = ""
        txtn4.Text = ""
        txtn5.Text = ""
        txtn6.Text = ""
        txtn7.Text = ""
        cmbestado.Text = ""
        txtn9.Text = ""
        cmblocalidad.Text = ""
        cmbprovincia.Text = ""
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
        txtn2.Enabled = Not parametro
        txtn3.Enabled = Not parametro
        txtn4.Enabled = Not parametro
        txtn5.Enabled = Not parametro
        txtn6.Enabled = Not parametro
        txtn7.Enabled = Not parametro
        cmbestado.Enabled = Not parametro
        txtn9.Enabled = Not parametro
        cmblocalidad.Enabled = Not parametro
        cmbprovincia.Enabled = Not parametro
    End Sub
    Private Sub btnaceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaceptar.Click
        If anterior = "N" Then
            Dim dr As DataRow = dtcliente.NewRow()
            guardardatos(dr)
            dtcliente.Rows.Add(dr)
        Else
            Dim dr As DataRow = dtcliente.Rows(registro)
            guardardatos(dr)
        End If
        dacliente.Update(dtcliente)
        dtcliente.AcceptChanges()
        bloquear(True)
        limpiar()
        verdatos(dr)
    End Sub
    Private Sub guardardatos(ByVal dr1 As DataRow)
        dr1("nom_cliente") = txtn2.Text
        dr1("domiciliofiscal_cliente") = txtn3.Text
        dr1("tel1_cliente") = txtn4.Text
        dr1("tel2_cliente") = txtn5.Text
        dr1("email_cliente") = txtn6.Text
        dr1("web_cliente") = txtn7.Text
        dr1("estado_cliente") = cmbestado.Text
        dr1("fechaestado_cliente") = txtn9.Text
        dr1("id_localidad") = dtlocalidad.Rows(cmblocalidad.SelectedIndex).Item("id_localidad").ToString()
        dr1("id_pcia") = dtprovincia.Rows(cmbprovincia.SelectedIndex).Item("id_pcia").ToString

    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        bloquear(True)
        If dr Is Nothing Then
            limpiar()
        Else
            verdatos(dr)
        End If
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        bloquear(False)
        anterior = "N"
        limpiar()
        txtn2.Focus()
    End Sub

    Private Sub btnmodificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodificar.Click
        bloquear(False)
        anterior = "M"
        txtn2.Focus()
    End Sub

    Private Sub btneliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneliminar.Click
        dvcontacto.RowFilter = "id_cliente=" + txtn1.Text
        If dvcontacto.Count > 0 Then
            MsgBox("No es posible eliminar el cliente.Tiene contactos!!!", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
        Else
            If MsgBox("eliminar cliente " + Trim(txtn1.Text) + " ? ", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                dtcliente.Rows(registro).Delete()
                dacliente.Update(dtcliente)
                dtcliente.AcceptChanges()
                registro = 0
                If dtcliente.Rows.Count > 0 Then
                    Dim dr As DataRow = dtcliente.Rows(registro)
                    verdatos(dr)
                Else
                    limpiar()
                    MsgBox("No existe clientes en nuestros registros", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                End If
            End If
        End If
    End Sub

    Private Sub txtn2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn2.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 32 And k <> 46 And k < 65) Or k > 90 And k < 97 Or k > 122 Then
            e.Handled = True
        Else
            If k = 13 Then
                If txtn2.Text = "" Then
                    MsgBox("Ingrese caracteres")
                    txtn2.Focus()
                Else
                    txtn3.Focus()
                End If

            End If
        End If
    End Sub

    Private Sub txtn2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn2.LostFocus
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
        If (k <> 8 And k <> 13 And k <> 45 And k < 48) Or k > 57 Then
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
        If (k <> 8 And k <> 13 And k <> 45 And k < 48) Or k > 57 Then
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
        If (k <> 8 And k <> 13 And k <> 45 And k <> 46 And k < 48) Or k > 57 And k < 64 Or k > 90 And k < 97 Or k > 122 Then
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
        If (k <> 8 And k <> 13 And k <> 45 And k <> 46 And k < 48) Or k > 57 And k < 64 Or k > 90 And k < 97 Or k > 122 Then
            e.Handled = True
        Else
            If k = 13 Then
                cmbestado.Focus()
            End If
        End If
    End Sub

    Private Sub txtn7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn7.LostFocus
        cmbestado.Focus()
    End Sub

    Private Sub cmbestado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbestado.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13) Then
            e.Handled = True
        Else
            If k = 13 Then
                txtn9.Focus()
            End If
        End If
    End Sub

    Private Sub cmbestado_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbestado.LostFocus
        txtn9.Focus()
    End Sub

    Private Sub txtn9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtn9.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13 And k <> 47 And k < 48) Or k > 57 Then
            e.Handled = True
        Else
            If k = 13 Then
                If Not IsDate(txtn9.Text) Then
                    MsgBox("ingrese una fecha vàlida")
                    txtn9.Text = ""
                    txtn9.Focus()
                Else
                    cmblocalidad.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtn9_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtn9.LostFocus
        cmblocalidad.Focus()
    End Sub

    Private Sub cmblocalidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmblocalidad.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13) Then
            e.Handled = True
        Else
            If k = 13 Then
                cmbprovincia.Focus()
            End If
        End If
    End Sub

    Private Sub cmblocalidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmblocalidad.LostFocus
        cmbprovincia.Focus()
    End Sub

    Private Sub cmbprovincia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbprovincia.KeyPress
        Dim k As Byte = Asc(e.KeyChar)
        If (k <> 8 And k <> 13) Then
            e.Handled = True
        Else
            If k = 13 Then
                btnaceptar.Focus()
            End If
        End If
    End Sub

    Private Sub cmbprovincia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbprovincia.LostFocus
        btnaceptar.Focus()
    End Sub
End Class