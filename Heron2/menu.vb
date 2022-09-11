Public Class menu

    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        If MsgBox("¿Desea salir de la aplicación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje de salida") = MsgBoxResult.Yes Then
            End
        End If
    End Sub

    Private Sub ActualizacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizacionToolStripMenuItem.Click
        Dim z As New Instrumentos
        z.ShowDialog()
    End Sub
    Private Sub ActualizacionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizacionToolStripMenuItem1.Click
        Dim x As New cliente
        x.ShowDialog()
    End Sub

    Private Sub ActualizaciònToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizaciònToolStripMenuItem.Click
        Dim x As New Recepcion1
        x.ShowDialog()
    End Sub

    Private Sub menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub IngresarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarToolStripMenuItem.Click
        Dim x As New Nota_de_envio1
        x.ShowDialog()
    End Sub

    Private Sub IngresarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresarToolStripMenuItem1.Click
        Dim x As New Form1
        x.ShowDialog()
    End Sub
End Class