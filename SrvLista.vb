Public Class SrvLista
    Public Shared Function Rubros() As List(Of tblRubro)
        Using ctx = New DemoR2Entities()
            Dim query = ctx.tblRubro
            Dim result = query.ToList()
            Return result
        End Using
    End Function
    'captura de asesores y concatenar.shared metodo compartido
    Public Shared Function Asesores() As List(Of SrvCC.TAsesor)
        Using ctx = New DemoR2Entities()

            Dim query = From a In ctx.tblAsesor ' a es la variable que representa a la tabla asesor
                        Select New SrvCC.TAsesor With {
                            .Dni = a.DNI, 'el . te permite acceder a las propiedades de la clase creada TAsesor
                            .Nombres = a.Nombres + ", " + a.Apellidos
        }
            Dim result = query.ToList() 'convierte el resultado convertida a lista
            Return result
        End Using
    End Function

    Public Shared Function Empresas() As List(Of SrvCC.TEmpresa)
        Using ctx = New DemoR2Entities()

            Dim query = From e In ctx.tblEmpresa
                        Select New SrvCC.TEmpresa With {
                            .Codigo = e.Codigo,
                            .RUC = e.RUC,
                            .RazonSocial = e.RazonSocial,
                            .Rubro = e.tblRubro.Descripcion,
                            .Asesor = e.tblAsesor.Apellidos + ", " + e.tblAsesor.Nombres
        }

            Dim result = query.ToList()
            Return result
        End Using
    End Function
End Class
