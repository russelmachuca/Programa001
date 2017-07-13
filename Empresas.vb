Imports ModEmpresa.Negocio

Public Class Empresas
    Private Sub Empresas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbRubroDes.DataSource = SrvLista.Rubros() 'Cargamos el combobox de rubros
        cbAsesorNombres.DataSource = SrvLista.Asesores() 'Cargamos el combobox de asesores
        cbRubroDes.SelectedIndex = -1 'Para que no seleccione ningun rubro por defecto
        cbAsesorNombres.SelectedIndex = -1 'Para que no seleccione ningun asesor por defecto

        bsEmpresas.DataSource = SrvLista.Empresas() 'Cargamos el bindingsource de Empresas que a su vez esta relacionado con el DataGridView
    End Sub

    'Validamos que solo ingrese numeros
    Private Sub tbRuc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbRuc.KeyPress
        If Char.IsNumber(e.KeyChar) Then 'si la tecla presionada es numero
            e.Handled = False 'entonces permitir
        ElseIf Char.IsControl(e.KeyChar) Then 'si la tecla presionada es un control EJEMPLO: la tecla para borrar lo que escribi
            e.Handled = False 'entonces permitir
        Else
            e.Handled = True 'para todo lo demas, denegar EJEMPLO: la barra espaciadora
        End If

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If ValidarControles() Then
            Dim tipo = If((rbPrivado.Checked), "R", "U") 'R = pRivado, U = pUblico
            Dim codigoRubro = cbRubroDes.SelectedValue.ToString()
            Dim dniAsesor = cbAsesorNombres.SelectedValue.ToString()

            SrvCUD.CreateEmpresa(tbRuc.Text, tbRazonSocial.Text, tipo, codigoRubro, dniAsesor)
            LimpiarControles()
            MessageBox.Show("Los cambios se guardaron exitosamente")
            bsEmpresas.DataSource = SrvLista.Empresas()
        End If
    End Sub

    Private Sub LimpiarControles()
        tbRuc.Text = ""
        tbRazonSocial.Text = ""
        rbPrivado.Checked = False
        rbPublico.Checked = False
        cbRubroDes.SelectedIndex = -1
        cbAsesorNombres.SelectedIndex = -1
    End Sub

    Private Function ValidarControles() As Boolean
        Dim mensaje = ""
        Dim esCorrecto = True

        If tbRuc.Text.Length < 11 Then
            mensaje = "El ruc debe tener 11 números"
        ElseIf tbRazonSocial.Text.Trim().Length <= 10 Then
            mensaje = "Ingresa la Razón social"
        ElseIf rbPrivado.Checked = False AndAlso rbPublico.Checked = False Then
            mensaje = "Elige si la empresa es privada o pública"
        ElseIf cbRubroDes.SelectedIndex = -1 Then
            mensaje = "Selecciona el Rubro al que pertenece la empresa"
        ElseIf cbAsesorNombres.SelectedIndex = -1 Then
            mensaje = "Elige el Asesor de la Empresa"
        End If

        If mensaje <> "" Then
            esCorrecto = False
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return esCorrecto
    End Function

    Private Sub tcListaEditar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcListaEditar.SelectedIndexChanged
        If (tcListaEditar.SelectedIndex = 1) Then 'index 0 = Lista, index 1 = Editar
            tbRuc.Focus() 'Hara focus/seleccionara el textbox RUC
        End If
    End Sub
End Class