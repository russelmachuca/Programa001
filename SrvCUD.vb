'CUD = Create, Update, Delete
Public Class SrvCUD
    Public Shared Sub CreateEmpresa(ruc As String, razonSocial As String, tipo As String, codigoRubro As String, dniAsesor As String)
        Using ctx = New DemoR2Entities()
            Dim empresa = New tblEmpresa()
            empresa.RUC = ruc
            empresa.RazonSocial = razonSocial
            empresa.Tipo = tipo
            empresa.CodigoRubro = codigoRubro
            empresa.DNIAsesor = dniAsesor

            ctx.tblEmpresa.Add(empresa)
            ctx.SaveChanges()
        End Using
    End Sub

End Class
